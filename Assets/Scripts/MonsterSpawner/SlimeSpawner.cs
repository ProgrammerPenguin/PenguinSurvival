using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeSpawner : MonoBehaviour
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
        
        if (Vector3.Distance(PlayerTransform.position, transform.position) > MaxDistance)
        {
            return;
        }
        else
        {
            var monster = SlimeObjectPool.GetObject(transform);
        }
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
