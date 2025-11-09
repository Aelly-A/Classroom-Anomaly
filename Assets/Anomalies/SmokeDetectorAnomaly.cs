using UnityEngine;


public class SmokeDetector : Anomaly
{

    public AudioSource audioSource;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Beep()
    {
        if (Random.Range(0, 5) == 0)
        {
            Debug.Log("Beep");
            audioSource.Play();
        }
        else
        {
            Debug.Log("Silence");
        }
    }
    
    
    public override void Activate()
    {
        InvokeRepeating(nameof(Beep), 0f, 3f);
    }

    public override void Deactivate()
    {
        CancelInvoke();
    }
}
