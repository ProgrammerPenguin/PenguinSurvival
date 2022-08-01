using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Weapon
{
    public Transform mgaicPosition;
    public GameObject magicball;
    private Rigidbody _rigidbody;
    public int magicballSpeed;
    public float AttackDelay;
    public bool IsAttackReady;
    
    

    private float time;


    public void Use()
    {
        MagicShot();
    }
    void MagicShot()
    {
        float radx = Random.Range(transform.position.x - 50f, transform.position.x + 50f);
        float radz = Random.Range(transform.position.z - 50f, transform.position.z + 50f);
        Vector3 high = new Vector3(radx, 50f, radz);
        Instantiate(magicball, transform.position + high, transform.rotation);
    }



}
