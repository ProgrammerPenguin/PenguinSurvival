using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Weapon 
{
    public Transform bulletPosition;
    public GameObject bullet;
    public int BulletSpeed;
    public float AttackDelay;
    public bool IsAttackReady;

    private float time;

    
    public void Use()
    {
        Shot();
    }
    void Shot()
    {
        
        var intantBullet = BulletObjectPool.GetObject();
        
        // Destroy(intantBullet, 4f);
        //BulletObjectPool.ReturnObject(intantBullet);
    }

 

}
