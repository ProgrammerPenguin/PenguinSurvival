using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float time;
    private Transform _transform;
    private GameManager _gameManager;
    private Rigidbody _rigidbody;
    public int BulletSpeed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = GameManager.Instance;
    }

    private void FixedUpdate()
    {
       // Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        _rigidbody.velocity = _transform.forward * BulletSpeed;
       // bulletRigid.velocity = bulletPosition.forward * BulletSpeed;
    }
    private void OnEnable()
    {
        Invoke("DestortyBullet", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BulletObjectPool.ReturnObject(this);
        }
    }

    void DestortyBullet()
    {

       // _transform.Translate(_gameManager.FireTransform.position);
        
        BulletObjectPool.ReturnObject(this);
    }

   
}
