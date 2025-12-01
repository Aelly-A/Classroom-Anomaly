//using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class ReversedChairsAnomaly : Anomaly
{
    GameObject[] chairs;
    private bool chairsAreFlipped = false;

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
        base.Activate();
        Debug.Log("Reversed Chairs Activated");
        chairs = GameObject.FindGameObjectsWithTag("Chair");

        foreach (GameObject chair in chairs)
        {
            chair.transform.Rotate(0f, 180f, 0f, Space.World);
        }
        Debug.Log($"Rotated {chairs.Length} by 180 degrees");
        chairsAreFlipped = true;
    }

    public override void Deactivate()
    {
        if (chairs == null || !chairsAreFlipped)
        {
            return;
        }

        foreach (GameObject chair in chairs)
        {
            chair.transform.Rotate(0f, -180f, 0f, Space.World);
        }
        base.Deactivate();
        chairsAreFlipped = false;
    }
}
