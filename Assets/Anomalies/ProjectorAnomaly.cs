using UnityEngine;

public class ProjectorAnomaly : Anomaly
{
    int count = 0;
    public GameObject whiteboardLeft;
    public GameObject whiteboardRight;
    
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
        whiteboardLeft.SetActive(false);
        whiteboardRight.SetActive(false);
        InvokeRepeating(nameof(Blink), 0f, 1f);
    }

    public override void Deactivate()
    {
        CancelInvoke();
        gameObject.SetActive(false);
        whiteboardLeft.SetActive(true);
        whiteboardRight.SetActive(true);
    }

    void Blink()
    {
        count++; // Kind of a janky way to have this blink at an uneven rate
        gameObject.SetActive(count % 8 == 0);        
        if (count == 64)
        {
            count = Random.Range(0, 2);
        }
    }
}
