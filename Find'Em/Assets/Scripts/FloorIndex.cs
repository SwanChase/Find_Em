using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIndex : MonoBehaviour
{

    public bool running = true;

    public float secondsBetweenNodeLightUpGreen = 10;
    public float secondsBetweenNodeLightUpBlack = 15;

    public FloorNode[] floor;

    private int amountOfGreen = 0;
    private int maxAmountOfGreen = 5;

    void Start()
    {
        floor = transform.GetComponentsInChildren<FloorNode>();
        StartCoroutine(SetRandomGreen());
        StartCoroutine(SetRandomBlack());
    }

    IEnumerator SetRandomGreen()
    {
        while (running)
        {
            if (amountOfGreen <= maxAmountOfGreen)
            {
                yield return new WaitForSeconds(secondsBetweenNodeLightUpGreen);
                floor[Random.Range(0, floor.Length)].GreenPhase();
                amountOfGreen++;
                print("amountOfGreen + 1");
            }
            else 
            {
                amountOfGreen--;
                print("amountOfGreen - 1");
            }
            print(amountOfGreen);
        }
    }

    IEnumerator SetRandomBlack()
    {
        while (running)
        {
            secondsBetweenNodeLightUpBlack = Random.Range(5, 15);
            yield return new WaitForSeconds(secondsBetweenNodeLightUpBlack);
            print("Darkening");
            floor[Random.Range(0, floor.Length)].DangerPhase();
        }
    }
}
