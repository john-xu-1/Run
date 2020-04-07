using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    NavMeshAgent epicNavMesh;
    private Transform target;
    
    void Start()
    {
        epicNavMesh = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(!target) target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target)
        {
            epicNavMesh.SetDestination(target.position);
        }
        
    }
}
