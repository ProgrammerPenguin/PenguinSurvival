using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool Instance;
    public GameObject PoolgameObject;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    private Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;

    }

    private Bullet CreateNewObject()
    {
        var newobj = Instantiate(poolingObjectPrefab, transform).GetComponent<Bullet>();
        newobj.gameObject.SetActive(false);
        return newobj;
    }

    private void Initalize(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static Bullet GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null,false);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newobj = Instance.CreateNewObject();
            newobj.transform.SetParent(null,false);
            newobj.gameObject.SetActive(true);
            return newobj;
        }
    }

    public static void ReturnObject(Bullet bullet)
    { 
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(bullet);
    }
}
