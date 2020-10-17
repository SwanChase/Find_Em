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
    
    [SerializeField]
    private Texture normalText,dangerText,yellowText;
    
    private Renderer renderer;
    private Material mat;
    public bool yellowPhase = false;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        mat = GetComponent<MeshRenderer>().material;
        mat.color = Color.black;
    }

    public void RedPhase()
    {
        currentState = FloorNodeState.Red;
        mat.color = Color.black;
        renderer.material.mainTexture = normalText;
        //Danger go away
    }

    public void GreenPhase()
    {
        currentState = FloorNodeState.Green;
        mat.color = Color.green;
        renderer.material.mainTexture = normalText;
        // goto this point 
    }

    public void YellowPhase() // this reduces points
    {
        yellowPhase = true;
        mat.color = Color.yellow;
        currentState = FloorNodeState.Yellow;
        StartCoroutine(YellowPhaseTimer());
    }

    public void DangerPhase() // this doesnt reduce points
    {
        yellowPhase = true;
        mat.color = Color.yellow;
        currentState = FloorNodeState.Yellow;
        renderer.material.mainTexture = yellowText;
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
        mat.color = Color.red;
        currentState = FloorNodeState.Black;
        renderer.material.mainTexture = dangerText;
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