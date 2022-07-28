using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public Transform PlayerTransform;

    void spawn()
    {
        Vector3 spawnPosition = PlayerTransform.position;

        
        transform.position = spawnPosition;
        //Debug.Log($"distance : {Vector3.Distance(PlayerTransform.position, transform.position)}");

       
        var bullet = BulletObjectPool.GetObject();
        
        //Instantiate(Monster, spawnPosition, Quaternion.identity);

    }



}
