using UnityEngine;

public class LaptopReplacementAnomaly : Anomaly
{

    public GameObject laptop;
    public GameObject replacement;
    public AudioSource audioSource;
    
    public override void Activate()
    {
        base.Activate();

        float volume = PlayerPrefs.GetFloat("VolumeKey", 0.75f);
        audioSource.volume = volume;

        laptop.SetActive(false);
        replacement.SetActive(true);
        InvokeRepeating(nameof(SFX), 0f, 1f);
        
    }

    public override void Deactivate()
    {
        base.Deactivate();
        replacement.SetActive(false);
        laptop.SetActive(true);
        CancelInvoke();
    }

    private void SFX()
    {
        if (Random.Range(0, 3) == 0)
        {
            Debug.Log("SFX");
            audioSource.Play();
        }
        else
        {
            Debug.Log("Silence");
        }
    }
}
