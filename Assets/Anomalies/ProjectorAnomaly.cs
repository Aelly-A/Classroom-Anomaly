using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class ProjectorAnomaly : Anomaly
{
    int count = 0;
    
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
        Debug.Log("Projector Activated");
        InvokeRepeating(nameof(Blink), 0f, 1f);
    }

    public override void Deactivate()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

    void Blink()
    {
        count++; // Kind of a janky way to have this blink at an uneven rate
        gameObject.SetActive(count % 4 == 0);        
        if (count == 64)
        {
            count = 0;
        }
    }
}
