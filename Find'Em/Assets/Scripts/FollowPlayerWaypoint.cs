using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerWaypoint : MonoBehaviour
{
    public Transform playerMarker;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<NavMeshAgent>().destination = playerMarker.position;
    }
}
