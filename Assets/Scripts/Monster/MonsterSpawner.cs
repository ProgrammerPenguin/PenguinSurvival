using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject Monster;
    public Transform PlayerTransform;
    public float MaxDistance = 5f;
    public float MinDistance = 1f;
    public float SpawnCooltime = 1.5f;

    private NavMeshAgent _navMeshAgent;
    private float _lastSpawnTime = 0f;

    private void Start()
    {
        Debug.Log($"debug : {Vector3.Distance(new Vector3(0f, 0f, 0f), new Vector3(-24.54f, -0.774f, -80.4091f))}");
        _navMeshAgent = GetComponentInChildren<NavMeshAgent>();
    }

    private void Update()
    {
        if (Time.time >= _lastSpawnTime + SpawnCooltime)
        {
            _lastSpawnTime = Time.time;
            spawn();
        }
    }

    void spawn()
    {
        Vector3 spawnPosition = GetRandomPointOnNavMesh(PlayerTransform.position, MaxDistance, MinDistance);
        
        spawnPosition += Vector3.up * 0.5f;
        transform.position = spawnPosition;
        //Debug.Log($"distance : {Vector3.Distance(PlayerTransform.position, transform.position)}");
        
        if (Vector3.Distance(PlayerTransform.position, transform.position) > MaxDistance)
        {
            return;
        }
        else
        {
            var monster = ObjectPool.GetObject(transform);
        }
            //Instantiate(Monster, spawnPosition, Quaternion.identity);

    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float maxdistance , float mindistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxdistance + center;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, maxdistance, NavMesh.AllAreas);

        if (Vector3.Distance(hit.position, PlayerTransform.position) < mindistance)
        {
            return GetRandomPointOnNavMesh(center, maxdistance, mindistance);
        }
        return hit.position;
    }

}
