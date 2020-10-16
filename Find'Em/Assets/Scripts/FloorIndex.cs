using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIndex : MonoBehaviour
{
    
    public bool running = true;

    public float secondsBetweenNodeLightUp = 10;

    public FloorNode[] floor;

    private int amountOfGreen;
    private int maxAmountOfGreen;

    void Start()
    {
        floor = transform.GetComponentsInChildren<FloorNode>();
        StartCoroutine(SetRandom());
    }

    IEnumerator SetRandom()
    {
        while (running)
        {
            yield return new WaitForSeconds(secondsBetweenNodeLightUp);
            print("lighting up");
            floor[Random.Range(0, floor.Length)].GreenPhase();
            amountOfGreen++;
        }
    }
}
