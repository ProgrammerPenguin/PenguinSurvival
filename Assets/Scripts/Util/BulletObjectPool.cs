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
        Initalize(1000);
    }

    private Bullet CreateNewObject()
    {
        Bullet newobj = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
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
            Bullet obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            
            return obj;
        }
        else
        {
            Bullet newobj = Instance.CreateNewObject();
            newobj.transform.SetParent(null);
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
