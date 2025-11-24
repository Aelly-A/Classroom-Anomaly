using UnityEngine;

public class Car_anomaly : MonoBehaviour
{
    [Header("References")]
    public AudioSource carAudioSource;   // AudioSource with clip already assigned

    [Header("Settings")]
    public float triggerTime = 2f;       // Time player must stay to activate fancy mode
    public float normalSpinSpeed = 90f;  // degrees per second
    public float fancySpinSpeed = 360f;  // faster spin

    private bool playerInside = false;
    private bool fancyMode = false;
    private float insideTimer = 0f;

    void Update()
    {
        if (playerInside && !fancyMode)
        {
            insideTimer += Time.deltaTime;

            if (insideTimer >= triggerTime)
                ActivateFancyMode();
        }

        // Spin the cat (car) in Y-axis if player is inside
        if (playerInside)
        {
            float speed = fancyMode ? fancySpinSpeed : normalSpinSpeed;
            transform.Rotate(0f, speed * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = true;
        insideTimer = 0f;

        // Play audio normally (no loop yet)
        carAudioSource.loop = false;
        carAudioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        ResetEvent();
    }

    private void ActivateFancyMode()
    {
        fancyMode = true;

        // Just turn looping on — DO NOT restart audio
        carAudioSource.loop = true;
    }

    private void ResetEvent()
    {
        playerInside = false;
        fancyMode = false;
        insideTimer = 0f;

        carAudioSource.Stop();
    }
}
