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
    private TrailRenderer _trailRenderer;
    public int BulletSpeed;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
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

        _trailRenderer.enabled = true;
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

        _trailRenderer.enabled = false;
        BulletObjectPool.ReturnObject(this);
    }

   
}
