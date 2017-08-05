﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rochester.ARTable.UI;

namespace Rochester.ARTable.Particles
{

    public class ParticleManager : MonoBehaviour
    {

        public float TimeStep = 0.01f;
        public float ParticleLifeEnd = 25f;
        public float DragCoefficient = 0f;
        public float ExplodeTime = 1f;
        public float ExplodeRadius = 2f;
        public float ExplodeMeshSize = 0.25f;

        private float ParticleDiameter = 1.0f;



        private List<Compute> computes;

        private World world;
        public ComputeShader integrateShader;
        public Material particleMaterial;

        public const int ParticleNumber = 262144;//262144;//65536;//16384;//262144; //2^18. Must be multiple of 256 (2^8) due to particle reduction blocksize

        //compute buffers for particle information
        public ComputeBuffer positions;
        public ComputeBuffer lastPositions;
        public ComputeBuffer velocities;
        public ComputeBuffer forces;
        public ComputeBuffer properties;
        public ComputeBuffer ginfo;

        //buffer that contains geometry
        private ComputeBuffer quadPoints;

        //handles for calling kernels
        private int integrate1Handle;
        private int integrate2Handle;

        // Use this for initialization
        public void updateParticleBoundary(Vector2 low, Vector2 high)
        {

            integrateShader.SetFloats("boundaryLow", new float[] { low.x, low.y });
            integrateShader.SetFloats("boundaryHigh", new float[] { high.x, high.y });
            foreach (var c in computes)
                c.UpdateBoundary(low, high);
        }

        public IEnumerator slowUpdates()
        {
            for (;;)
            {
                yield return new WaitForSeconds(100f);
            }
        }

        void Start()
        {

            if (world == null)
                world = GameObject.Find("World").GetComponent<World>();

            computes = new List<Compute>();
            foreach (var c in this.GetComponentsInChildren<Compute>())
                computes.Add(c);

            //set handles
            integrate1Handle = integrateShader.FindKernel("Integrate1");
            integrate2Handle = integrateShader.FindKernel("Integrate2");


            //cerate empty buffers
            positions = new ComputeBuffer(ParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
            lastPositions = new ComputeBuffer(ParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
            velocities = new ComputeBuffer(ParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
            forces = new ComputeBuffer(ParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
            properties = new ComputeBuffer(ParticleNumber, ShaderConstants.PROP_STRIDE);
            ginfo = new ComputeBuffer(ParticleNumber, ShaderConstants.GINFO_STRIDE);


            //initialize the per-particle data
            Vector2[] zeros = new Vector2[ParticleNumber]; //create a bunch of zero vectors
            positions.SetData(zeros);
            lastPositions.SetData(zeros);
            velocities.SetData(zeros);
            forces.SetData(zeros);

            //make positions interesting
            for (int i = 0; i < ParticleNumber; i++)
                zeros[i].Set(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            positions.SetData(zeros);

            //make velocities interesting
            for (int i = 0; i < ParticleNumber; i++)
                zeros[i].Set(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //velocities.SetData(zeros);

            //make forces interesting

            for (int i = 0; i < ParticleNumber; i++)
                zeros[i].Set(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            //_forces.SetData(zeros);


            ShaderConstants.Prop[] props = new ShaderConstants.Prop[ParticleNumber];
            for (uint i = 0; i < ParticleNumber; i++)
            {
                props[i].state = ShaderConstants.PARTICLE_STATE_DEAD;
                //if(i < 30000)
                //  props[i].state = ShaderConstants.PARTICLE_STATE_ALIVE;
                props[i].color = new Vector4(1f, 1f, 1f, 1f);
            }

            properties.SetData(props);

            //set up group info.
            var temp = new ShaderConstants.GInfo[ParticleNumber];
            for (uint i = 0; i < ParticleNumber; i++)
            {
                temp[i].interactions = ShaderConstants.INTERACTIONS_DISPERSION |
                 ShaderConstants.INTERACTIONS_GRAVITY |
                 ShaderConstants.INTERACTIONS_ALIGN;
            }
            ginfo.SetData(temp);



            //set buffers
            integrateShader.SetBuffer(integrate1Handle, "positions", positions);
            integrateShader.SetBuffer(integrate1Handle, "lastPositions", lastPositions);
            integrateShader.SetBuffer(integrate1Handle, "velocities", velocities);
            integrateShader.SetBuffer(integrate1Handle, "forces", forces);
            integrateShader.SetBuffer(integrate1Handle, "properties", properties);

            integrateShader.SetBuffer(integrate2Handle, "properties", properties);
            integrateShader.SetBuffer(integrate2Handle, "positions", positions);
            integrateShader.SetBuffer(integrate2Handle, "velocities", velocities);
            integrateShader.SetBuffer(integrate2Handle, "forces", forces);

            //set constants
            integrateShader.SetFloat("timeStep", TimeStep);
            integrateShader.SetFloat("lifeEnd", ParticleLifeEnd);
            integrateShader.SetFloat("drag", DragCoefficient);


            // bind resources to material
            particleMaterial.SetBuffer("positions", positions);
            particleMaterial.SetBuffer("properties", properties);
            particleMaterial.SetFloat("explodeLife", ExplodeTime);
            particleMaterial.SetFloat("explodeRadius", ExplodeRadius);
            particleMaterial.SetFloat("explodeSize", ExplodeMeshSize);
            particleMaterial.SetInt("particleNumber", ParticleNumber);

            foreach (var c in computes)
                c.SetupShader(this);

            StartCoroutine(slowUpdates());
        }


        private void OnDestroy()
        {
            positions.Release();
            velocities.Release();
            forces.Release();
            properties.Release();
            lastPositions.Release();
            ginfo.Release();

            foreach (var c in computes)
                c.ReleaseBuffers();

        }
        private void updateBuffers(int i)
        {
            return;
        }

        // Update is called once per frame
        void Update()
        {
            int nx = Mathf.CeilToInt((float)ParticleNumber / ShaderConstants.PARTICLE_BLOCK_SIZE);

            foreach (var c in computes)
                c.UpdatePreIntegrate(nx);

            integrateShader.SetFloat("timeStep", TimeStep * Time.timeScale);

            integrateShader.Dispatch(integrate1Handle, nx, 1, 1);

            foreach (var c in computes)
                c.UpdateForces(nx);

            integrateShader.Dispatch(integrate2Handle, nx, 1, 1);

            foreach (var c in computes)
                c.UpdatePostIntegrate(nx);

        }

        private void OnRenderObject()
        {
            if (!SystemInfo.supportsComputeShaders)
            {
                new System.Exception("Compute shaders not supported on your platform.");
            }

            // set the pass -> there is only 1 pass here because we have a simple shader
            particleMaterial.SetPass(0);

            // draw
            //Graphics.DrawProcedural(MeshTopology.Triangles, 6, ParticleNumber);
            Graphics.DrawProcedural(MeshTopology.Points, ParticleNumber, 1);
        }
    }

}