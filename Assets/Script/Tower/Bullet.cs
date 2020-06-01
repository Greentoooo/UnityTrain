﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform mTarget;
    public float speed=30.0f;//子弹速度
    public float damageNum = 50.0f;
    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mTarget == null) return;
        Vector3 dir = mTarget.position - this.transform.position;
        if (Vector3.Distance(mTarget.position, this.transform.position) < speed * Time.deltaTime) {
            HitTarget();
            return;
        }//如果击中目标
        this.transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);
        this.transform.LookAt(mTarget);
    }
    private void HitTarget()
    {
        EnemyDamage();
        //子弹打中别人后消失。
        Destroy(this.gameObject);
    }
    private void EnemyDamage()
    {
        EnemyHealth enemyHp = mTarget.GetComponent<EnemyHealth>();
        if (enemyHp != null)
        {
            Debug.Log("扣血了");
            enemyHp.Damage(damageNum);
        }
    }
}
