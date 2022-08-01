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
        
        Bullet intantBullet = BulletObjectPool.GetObject();
        intantBullet.transform.position = bulletPosition.position + bulletPosition.forward;
        intantBullet.transform.forward = bulletPosition.forward;
        intantBullet.gameObject.SetActive(true);
        
       
        // Destroy(intantBullet, 4f);
        //BulletObjectPool.ReturnObject(intantBullet);
    }

 

}
