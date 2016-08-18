﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComputeSource : Compute {

   public class SourceInfo
    {
        public int instancedParticles;
        public int availableParticles;
        public int totalParticles;
        public uint timer;
        public int particleLife;

        public SourceInfo(int available, int particleLife)
        {
            this.instancedParticles = 0;
            this.availableParticles = available;
            this.totalParticles = available;
            this.timer = 0;
            this.particleLife = particleLife;
        }

        public void update(ShaderConstants.Source s)
        {
            timer += 1;
            if(timer % s.spawnPeriod == 0)
            {
                instancedParticles += s.spawnAmount;
                if (timer > particleLife)
                    availableParticles -= s.spawnAmount; //we have some dying at each spawn period.


            }
        }

    }

    
    public ComputeShader spawnShader;

    public int InstancedParticles
    {
        get
        {
            if (sourceInfo == null)
                return 0;
            int sum = 0;
            foreach (SourceInfo s in sourceInfo)
                sum += s.instancedParticles;
            return sum;
        }
    }

    public int AvailableParticles
    {
        get
        {
            if (sourceInfo == null)
                return 0;
            int sum = 0;
            foreach (SourceInfo s in sourceInfo)
                sum += s.availableParticles;
            return sum;
        }
    }

    private int spawnHandle;
    private int gpuSourceNumber = 0;

    //compute buffers for spawning particles
    private ComputeBuffer spawnTimers;
    private ComputeBuffer sources;

    private List<SourceInfo> sourceInfo = new List<SourceInfo>();
    private List<ShaderConstants.Source> cpuSources = new List<ShaderConstants.Source>();

    private ParticleManager pm;
    private ParticleStatistics ps;

    public void Awake()
    {
        pm = GameObject.Find("ParticleManager").GetComponent<ParticleManager>();
        ps = GameObject.Find("ParticleManager").GetComponentInChildren<ParticleStatistics>();
    }

    public override void SetupShader(ParticleManager pm)
    {        

        spawnHandle = spawnShader.FindKernel("Spawn");       

        spawnShader.SetBuffer(spawnHandle, "positions", pm.positions);
        spawnShader.SetBuffer(spawnHandle, "velocities", pm.velocities);
        spawnShader.SetBuffer(spawnHandle, "properties", pm.properties);

    }

    public int AddSource(ShaderConstants.Source s)
    {

        //Add the new source to cpu
        int location = cpuSources.Count;
        cpuSources.Add(s);

        //Start info
        sourceInfo.Add(new SourceInfo(1000, Mathf.CeilToInt(pm.ParticleLifeEnd / pm.TimeStep)));

        //keep track of statistics for updating available/unavailable particles
        //we use update in SourceInfo to get an estimate, but that only accounts for particle death from their lifetime.
        ps.ComputeModifierStatistics(ShaderConstants.PARTICLE_MODIFIER_SPAWN, location, (_, e) =>
        {
            sourceInfo[location].instancedParticles = ((ParticleStatisticsModifierEventArgs)e).sum[1];
            sourceInfo[location].availableParticles = sourceInfo[location].totalParticles - ((ParticleStatisticsModifierEventArgs)e).sum[1];
        });


        syncBuffers();

        return location;

    }

    public void updateSource(int i, ShaderConstants.Source s)
    {
        cpuSources[i] = s;
        syncBuffers();
    }

    private void syncBuffers() { 
        //extend if necessary
        if (sources != null)
            sources.Release();
        ShaderConstants.Source[] data = extendSources(cpuSources);
        gpuSourceNumber = data.Length;

        //send to GPU
        sources = new ComputeBuffer(gpuSourceNumber, ShaderConstants.SOURCE_STRIDE);
        sources.SetData(data);
        spawnShader.SetBuffer(spawnHandle, "sources", sources);

        //treat timers, including copy-back
        int[] timers = new int[gpuSourceNumber];
        if (spawnTimers != null)
        {
           //copy back what we have 
            spawnTimers.GetData(timers);
            spawnTimers.Release();
        }
        spawnTimers = new ComputeBuffer(gpuSourceNumber, ShaderConstants.UINT_STRIDE);
        spawnTimers.SetData(timers);
        spawnShader.SetBuffer(spawnHandle, "spawnTimers", spawnTimers);

    }

    /*
     * Need to extend soucres so that it's a multiple of the blocksize
     */
    private static ShaderConstants.Source[] extendSources(List<ShaderConstants.Source> list)
    {
        int length = ShaderConstants.SPAWN_BLOCKSIZE_X * Mathf.CeilToInt((float)list.Count / ShaderConstants.SPAWN_BLOCKSIZE_X);
        ShaderConstants.Source[] sload = new ShaderConstants.Source[length];
        for (int i = 0; i < list.Count; i++)
            sload[i] = list[i];
        for (int i = list.Count; i < length; i++)
            sload[i].spawnPeriod = 0x7FFFFFFF;
        return sload;
    }

    public override void UpdatePreIntegrate(int nx)
    {
        if (cpuSources.Count == 0)
            return;

        int ns = Mathf.CeilToInt((float)gpuSourceNumber / ShaderConstants.SPAWN_BLOCKSIZE_X);
        spawnShader.Dispatch(spawnHandle, ns, 1, 1);

        //This code mimicks the GPU code
        //Need to keep track of how many particles I've created, etc.

        bool dirty = false;
        for (int i = 0; i < sourceInfo.Count; i++)
        {
            sourceInfo[i].update(cpuSources[i]);
            if(sourceInfo[i].availableParticles < 0 && cpuSources[i].spawnAmount > 0)
            {
                ShaderConstants.Source s = cpuSources[i];
                s.spawnAmount = 0;
                cpuSources[i] = s;
                dirty = true;
            } else if(sourceInfo[i].availableParticles > 0 && cpuSources[i].spawnAmount == 0)
            {
                ShaderConstants.Source s = cpuSources[i];
                s.spawnAmount = 1;
                cpuSources[i] = s;
                dirty = true;
            }
        }
        if (dirty)
            syncBuffers();
    }

    public override void ReleaseBuffers()
    {
        sources.Release();
        spawnTimers.Release();
    }
}
