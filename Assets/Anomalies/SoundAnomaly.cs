using UnityEngine;

public class SoundAnomaly : Anomaly
{
    private AudioSource audioSource;
    private AudioClip anomalyClip;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }


        anomalyClip = Resources.Load<AudioClip>("AnomalySound"); // placeholder for now till i find the right sounds
        audioSource.clip = anomalyClip;

    }

    public override void Activate()
    {
        Debug.Log("Sound Anomaly Activated");
        if (audioSource != null && anomalyClip != null)
        {
            audioSource.Play();
        }
    }

    public override void Deactivate()
    {
        Debug.Log("Sound Anomaly Deactivated");
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
