﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wave))]
[RequireComponent(typeof(SphereCollider))]
public class WaveSinNextNode : SingNextNode
{
    public bool isInfectd = false;
    private void Awake()
    {
        SphereCollider collider = gameObject.GetComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = 0.5f;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (!isInfectd)
        {
            isInfectd = true;
            Destroy(this.transform.Find("PreEffect").gameObject);
            this.transform.Find("AfterEffect").GetComponent<ParticleSystem>().Play();
            Wave wave = gameObject.GetComponent<Wave>();
            GameObject enemyManager = GameObject.Find("EnemyManager");
            
            if (enemyManager != null)
            {
                EnemyManager manager = enemyManager.GetComponent<EnemyManager>();
                wave.m_aliveCallBack += manager.aliveCallback;
                wave.m_deadCallBack += manager.destroyCallback;
            }

            wave.StartWave();
        }
    }
}
