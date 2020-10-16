using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DTest : MonoBehaviour
{
    Vector3 start = Vector3.zero;
    Vector3 direction = Vector3.down;
    RaycastHit hit;

    void Update()
    {

        if (Physics.Raycast(start, direction, out hit))
        {
            hit.collider.gameObject.SetActive(false);
        }
    }
}
