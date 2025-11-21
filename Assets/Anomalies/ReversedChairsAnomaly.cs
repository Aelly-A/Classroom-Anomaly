using UnityEditor.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class ReversedChairsAnomaly : Anomaly
{
    GameObject[] chairs;
    private bool chairsAreRotated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Activate()
    {
        Debug.Log("Reversed Chairs Activated");
        chairs = GameObject.FindGameObjectsWithTag("Chair");

        foreach (GameObject chair in chairs)
        {
            chair.transform.Rotate(0f, 180f, 0f, Space.World);
        }
        
        chairsAreRotated = true;
        Debug.Log($"Rotated {chairs.Length} by 180 degrees");
    }

    public override void Deactivate()
    {
        if (chairs == null || !chairsAreRotated)
        {
            return;
        } 

        chairsAreRotated = false;
        foreach (GameObject chair in chairs)
        {
            chair.transform.Rotate(0f, -180f, 0f, Space.World);
        }
    }
}
