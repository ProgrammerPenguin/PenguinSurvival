using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    private Queue<Monster> poolingObjectQueue = new Queue<Monster>();

    private void Awake()
    {
        Instance = this;
        
    }

    private Monster CreateNewObject(Transform transform)
    {
        var newobj = Instantiate(poolingObjectPrefab, transform).GetComponent<Monster>();
        newobj.gameObject.SetActive(false);
        return newobj;
    }

    private void Initalize(int count , Transform transform)
    {
        for(int i = 0; i < count; ++i)
        {
            poolingObjectQueue.Enqueue(CreateNewObject(transform));
        }
    }

    public static Monster GetObject(Transform transform)
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newobj = Instance.CreateNewObject(transform);
            newobj.transform.SetParent(null);
            newobj.gameObject.SetActive(true);
            return newobj;
        }
    }

    public static void ReturnObject(Monster monster)
    {
        monster.gameObject.SetActive(false);
        monster.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(monster);
    }
}
