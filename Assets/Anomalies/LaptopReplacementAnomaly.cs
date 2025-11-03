using UnityEngine;

public class LaptopReplacementAnomaly : Anomaly
{

    public GameObject laptop;
    public GameObject replacement;
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
        laptop.SetActive(false);
        replacement.SetActive(true);
        
    }

    public override void Deactivate()
    {
        base.Deactivate();
        replacement.SetActive(false);
        laptop.SetActive(true);
    }
}
