using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorNode : MonoBehaviour
{
    public enum FloorNodeState
    {
        Green,
        Yellow,
        Red,
        Black
    }

    public FloorNodeState currentState = FloorNodeState.Red;
    public float TimebetweenPhases = 5f;

    private Material mat;
    public bool yellowPhase = false;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.color = Color.red;
    }

    public void RedPhase()
    {
        currentState = FloorNodeState.Red;
        mat.color = Color.red;
        //Danger go away
    }

    public void GreenPhase()
    {
        currentState = FloorNodeState.Green;
        mat.color = Color.green;
        // goto this point 
    }

    public void YellowPhase()
    {
        yellowPhase = true;
        mat.color = Color.yellow;
        currentState = FloorNodeState.Yellow;
        StartCoroutine(YellowPhaseTimer());
    }

    private IEnumerator YellowPhaseTimer()
    {
        print("yellow timer");
        Debug.Log("yellow timer");
        TimebetweenPhases = Random.Range(3, 10);
        yield return new WaitForSeconds(TimebetweenPhases);
        BlackPhase();
    }

    public void BlackPhase()
    {
        yellowPhase = false;
        currentState = FloorNodeState.Black;
        mat.color = Color.black;
        StartCoroutine(BlackPhaseTimer());
    }

    private IEnumerator BlackPhaseTimer()
    {
        Debug.Log("Black timer");
        TimebetweenPhases = Random.Range(10, 20);
        yield return new WaitForSeconds(TimebetweenPhases);
        RedPhase();
    }
}