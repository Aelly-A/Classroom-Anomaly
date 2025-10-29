using UnityEngine;

[CreateAssetMenu(fileName = "New Anomaly", menuName = "Anomaly", order = 0)]
public class Anomaly : ScriptableObject
{
    public string anomalyName;
    public GameObject anomalyPrefab;
    public AudioClip anomalyAudio;
    // public float appearanceChance = 1f;
    public float minDuration = 5f;
    public float maxDuration = 15f;
}