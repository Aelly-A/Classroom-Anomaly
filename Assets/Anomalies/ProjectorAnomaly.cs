using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class ProjectorAnomaly : MonoBehaviour
{
    int count = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Blink), 0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
    }
    

    void Blink()
    {
        count++; // Kind of a janky way to have this blink at an uneven rate
        transform.parent.gameObject.SetActive(count % 4 == 0);        
        if (count == 64)
        {
            count = 0;
        }
    }
}
