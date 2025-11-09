using UnityEngine;

public class LectureAudioAnomaly : Anomaly
{

    public AudioSource audioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public override void Activate()
    {
        audioSource.Play();
    }

    public override void Deactivate()
    {
        audioSource.Stop();
    }
}
