﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleManager : MonoBehaviour {

    public Vector2 boundariesLow = new Vector2(-10,-10);
    public Vector2 boundariesHigh = new Vector2(10, 10);
    public float timeStep = 0.01f;
    public float particleDiameter = 1.0f;

    public List<Compute> computes;

    public ComputeShader integrateShader;
    public Material particleMaterial;

    private int _maxParticleNumber = 100000;
    public int maxParticleNumber
    {
        get { return _maxParticleNumber; }
        set {
            this.updateBuffers(value);
        }
    }

    //compute buffers for particle information
    public ComputeBuffer _positions;
    public ComputeBuffer _velocities;
    public ComputeBuffer _forces;
    public ComputeBuffer _properties;

    //buffer that contains geometry
    private ComputeBuffer _quadPoints;

    //handles for calling kernels
    private int _integrate1Handle;
    private int _integrate2Handle;
 

    // Use this for initialization
    void Start() {

        computes = new List<Compute>();
        computes.Add((Compute) GameObject.Find("ParticleManager/ComputeDispersion").GetComponent( typeof(Compute) ));
        computes.Add((Compute)GameObject.Find("ParticleManager/ComputeSpawn").GetComponent(typeof(Compute)));

        //set handles
        _integrate1Handle = integrateShader.FindKernel("Integrate1");
        _integrate2Handle = integrateShader.FindKernel("Integrate2");


        //cerate empty buffers
        _positions = new ComputeBuffer(_maxParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
        _velocities = new ComputeBuffer(_maxParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
        _forces = new ComputeBuffer(_maxParticleNumber, 2 * ShaderConstants.FLOAT_STRIDE);
        _properties = new ComputeBuffer(_maxParticleNumber, ShaderConstants.PROP_STRIDE);


        //initialize the per-particle data
        Vector2[] zeros = new Vector2[_maxParticleNumber]; //create a bunch of zero vectors
        _positions.SetData(zeros);
        _velocities.SetData(zeros);
        _forces.SetData(zeros);

        //make positions interesting
        for (int i = 0; i < _maxParticleNumber; i++)
            zeros[i].Set(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        _positions.SetData(zeros);

        //make velocities interesting
        for (int i = 0; i < _maxParticleNumber; i++)
            zeros[i].Set(Random.Range(-1f,1f), Random.Range(-1f,1f));
        _velocities.SetData(zeros);

        //make forces interesting
        
        for (int i = 0; i < _maxParticleNumber; i++)
            zeros[i].Set(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        //_forces.SetData(zeros);
        

        ShaderConstants.Prop[] props = new ShaderConstants.Prop[_maxParticleNumber];
        for (int i = 0; i < _maxParticleNumber; i++)
           props[i].alive = 0;
        _properties.SetData(props);

       

        //set buffers
        integrateShader.SetBuffer(_integrate1Handle, "positions", _positions);
        integrateShader.SetBuffer(_integrate1Handle, "velocities", _velocities);
        integrateShader.SetBuffer(_integrate1Handle, "forces", _forces);
        integrateShader.SetBuffer(_integrate1Handle, "properties", _properties);

        integrateShader.SetBuffer(_integrate2Handle, "properties", _properties);
        integrateShader.SetBuffer(_integrate2Handle, "positions", _positions);
        integrateShader.SetBuffer(_integrate2Handle, "velocities", _velocities);
        integrateShader.SetBuffer(_integrate2Handle, "forces", _forces);

        //set constants
        integrateShader.SetFloat("timeStep", timeStep);
        integrateShader.SetFloats("boundaryLow", new float[] { boundariesLow.x, boundariesLow.y });
        integrateShader.SetFloats("boundaryHigh", new float[] { boundariesHigh.x, boundariesHigh.y });

        //set-up our geometry for drawing.
        _quadPoints = new ComputeBuffer(6, ShaderConstants.QUAD_STRIDE);
        _quadPoints.SetData(new[]
        {
            new Vector3(-particleDiameter / 2, particleDiameter / 2),
            new Vector3(particleDiameter / 2, particleDiameter / 2),
            new Vector3(particleDiameter / 2, -particleDiameter / 2),
            new Vector3(particleDiameter / 2, -particleDiameter / 2),
            new Vector3(-particleDiameter / 2, -particleDiameter / 2),
            new Vector3(-particleDiameter / 2, particleDiameter / 2),
        });

        // bind resources to material
        particleMaterial.SetBuffer("positions", _positions);
        particleMaterial.SetBuffer("properties", _properties);
        particleMaterial.SetBuffer("quadPoints", _quadPoints);

        foreach (Compute c in computes)
            c.setupShader(this);
    }

    private void OnDestroy()
    {
        _positions.Release();
        _velocities.Release();
        _forces.Release();
        _properties.Release();

        foreach (Compute c in computes)
            c.releaseBuffers();

    }
    private void updateBuffers(int i)
    {
        return;
    }

	// Update is called once per frame
	void Update () {
        int nx = Mathf.CeilToInt((float) _maxParticleNumber / ShaderConstants.PARTICLE_BLOCK_SIZE);

        foreach (Compute c in computes)
            c.updatePreIntegrate(nx);

        integrateShader.Dispatch(_integrate1Handle, nx, 1, 1);

        foreach (Compute c in computes)
            c.updateForces(nx);

        integrateShader.Dispatch(_integrate2Handle, nx, 1, 1);

        foreach (Compute c in computes)
            c.updatePostIntegrate(nx);
        
    }

    private void OnRenderObject()
    {
        if (!SystemInfo.supportsComputeShaders)
        {
            return;
        }

        // set the pass -> there is only 1 pass here because we have a simple shader
        particleMaterial.SetPass(0);

        // draw
        Graphics.DrawProcedural(MeshTopology.Triangles, 6, _maxParticleNumber);
    }
}
