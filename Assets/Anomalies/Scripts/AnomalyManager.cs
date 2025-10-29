using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public Anomaly[] allAnomalies;
    private Dictionary<Anomaly, GameObject> activeAnomalies = new Dictionary<Anomaly, GameObject>();

    [Tooltip("Probability of an anomaly being triggered (0.0-1.0).")]
    [Range(0f, 1f)]
    public float spawnChance = 1f;

    public List<Transform> spawnLocations;

    public float minDelay = 1f;
    public float maxDelay = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RandomAnomalyRoutine());
    }

    private IEnumerator RandomAnomalyRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            if (Random.value > spawnChance)
            {
                continue;
            }

            SpawnRandomAnomaly();
        }
    }

    private void SpawnRandomAnomaly()
    {
        Anomaly anomaly = GetRandomAnomaly();

        if (anomaly == null || spawnLocations.Count == 0)
        {
            return;
        }

        Transform location = spawnLocations[Random.Range(0, spawnLocations.Count)];

        GameObject anomalyInstance = Instantiate(anomaly.anomalyPrefab, location.position, location.rotation);
        anomalyInstance.name = anomaly.anomalyName + "_Instance";

        if (anomaly.anomalyAudio != null)
        {
            AudioSource.PlayClipAtPoint(anomaly.anomalyAudio, anomalyInstance.transform.position);
        }

        if (!activeAnomalies.ContainsKey(anomaly))
        {
            activeAnomalies.Add(anomaly, anomalyInstance);
        }

        float anomalyDuration = Random.Range(anomaly.minDuration, anomaly.maxDuration);
        StartCoroutine(AutoRemoveAnomaly(anomaly, anomalyDuration));
    }

    private Anomaly GetRandomAnomaly()
    {
        List<Anomaly> availableAnomalies = new List<Anomaly>();

        foreach (Anomaly a in allAnomalies)
        {
            if (!activeAnomalies.ContainsKey(a))
            {
                availableAnomalies.Add(a);
            }
        }

        if (availableAnomalies.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, availableAnomalies.Count);
        return availableAnomalies[index];
    }

    private IEnumerator AutoRemoveAnomaly(Anomaly anomaly, float duration)
    {
        yield return new WaitForSeconds(duration);
        RemoveAnomaly(anomaly);
    }

    public void RemoveAnomaly(Anomaly anomaly)
    {
        if (activeAnomalies.TryGetValue(anomaly, out GameObject anomalyInstance))
        {
            Destroy(anomalyInstance);
            activeAnomalies.Remove(anomaly);
        }
    }

    public void ClearAnomalies()
    {
        foreach (var anomalyInstance in activeAnomalies.Values)
        {
            Destroy(anomalyInstance);
        }
        activeAnomalies.Clear();
    }
}
