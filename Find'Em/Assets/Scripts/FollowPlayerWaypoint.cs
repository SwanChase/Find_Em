using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerWaypoint : MonoBehaviour
{
    public Transform playerMarker;
    
    void Update()
    {
        gameObject.GetComponent<NavMeshAgent>().destination = playerMarker.position;
    }
}
