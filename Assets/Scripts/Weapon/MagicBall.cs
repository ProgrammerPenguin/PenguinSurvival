using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public GameObject meshobj;
    public GameObject effectobj;
    public Rigidbody Rigidbody;

    private void Start()
    {
        StartCoroutine(Explosion());

        
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(4f);
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0f, LayerMask.GetMask("Enemy"));

        foreach (RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Monster>().HitByMagicBall(transform.position);
        }
        effectobj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }


}
