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
        Debug.Log("»ý¼º´ï");
        Vector3 high = new Vector3(0f, 100f, 0f);
        Instantiate(magicball, transform.position + high, transform.rotation);
    }



}
