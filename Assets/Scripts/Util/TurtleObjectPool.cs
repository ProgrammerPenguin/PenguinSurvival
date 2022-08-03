using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleObjectPool : MonoBehaviour
{
    public static TurtleObjectPool Instance;

    [SerializeField]
    private GameObject _poolingObjectPrefab;

    private Queue<Monster> _poolingObjectQueue = new Queue<Monster>();

    private void Awake()
    {
        Instance = this;
    }

    private Monster CreateNewObject(Transform transform)
    {
        var newobj = Instantiate(_poolingObjectPrefab, transform).GetComponent<Monster>();
        newobj.gameObject.SetActive(false);
        return newobj;
    }

    private void Initalize(int count, Transform transform)
    {
        for (int i = 0; i < count; ++i)
        {
            _poolingObjectQueue.Enqueue(CreateNewObject(transform));
        }
    }

    public static Monster GetObject(Transform transform)
    {
        if (Instance._poolingObjectQueue.Count > 0)
        {
            var obj = Instance._poolingObjectQueue.Dequeue();
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
        Instance._poolingObjectQueue.Enqueue(monster);
    }
}
