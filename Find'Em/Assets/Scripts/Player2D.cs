using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 500, layerMask))
        {
            Debug.Log("Did Hit");
            GameObject other = hit.collider.gameObject;
            FloorNode floorNode = other.GetComponent<FloorNode>();

            if(floorNode == null)
            { 
                return;
            }

            if(floorNode.currentState != FloorNode.FloorNodeState.Green)
            {
                return;
            }

            print("hit, and lit down");

            floorNode.YellowPhase();
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 500, Color.white);
            Debug.Log("Did not Hit");
        }

    }

    void Update()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 500, layerMask))
        {
            Debug.Log("Detected");
            GameObject other = hit.collider.gameObject;
            FloorNode floorNode = other.GetComponent<FloorNode>();

            if (floorNode.currentState == FloorNode.FloorNodeState.Yellow)
            {
                Debug.Log("On yellow");
                GameManagerScript.score += 1;
            }

            if (floorNode.currentState == FloorNode.FloorNodeState.Black)
            {
                Debug.Log("On black");
                GameManagerScript.score -= 1;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 500, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
