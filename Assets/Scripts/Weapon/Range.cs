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

    public void Use()
    {
        StartCoroutine(Shot());
    }
    IEnumerator Shot()
    {
        GameObject intantBullet = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPosition.forward * BulletSpeed;
        yield return new WaitForSeconds(0.1f);
        Destroy(intantBullet, 4f);

    }


}
