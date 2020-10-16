using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    public GameObject PlayerController;
    public float movementMultiplier = 2f;
    private Vector3 origionalPos;

    // Start is called before the first frame update
    void Start()
    {
        origionalPos = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = PlayerController.transform.position * movementMultiplier + origionalPos;
    }

}
