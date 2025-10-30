using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// This file should be what manages/invokes the anomalies
public class AnomalyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> anomalies; // This is a public list so add to it via Unity's GUI
    public bool anomalyIsActive = false; // This needs to be read by the RunManager to determine if the player won that round

    List<GameObject> usedAnomalies; // Private list to keep track of anomalies used so far

    void Start()
    {
        // Make sure everything is disabled at the start
        DeactivateAllAnomalies();
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRound()
    {
        anomalyIsActive = !(Random.Range(0, 4) == 1); // 1 in 4 chance of no anomaly

        if (anomalyIsActive)
        {
            ActivateAnAnomaly();
        }
    }

    void ActivateAnAnomaly()
    {
        GameObject chosenAnomalyObject = anomalies[Random.Range(0, anomalies.Count)];
        Anomaly chosenAnomaly = chosenAnomalyObject.GetComponent<Anomaly>();
        Debug.Log("Randomly chosen Anomaly: " + chosenAnomaly);

        chosenAnomaly.Activate(); // Activate the anomaly
        usedAnomalies.Add(chosenAnomalyObject);
        anomalies.Remove(chosenAnomalyObject);
    }

    void DeactivateAllAnomalies()
    {
        anomalies.ForEach(anomalyObject => anomalyObject.GetComponent<Anomaly>().Deactivate());
        usedAnomalies.ForEach(anomalyObject => anomalyObject.GetComponent<Anomaly>().Deactivate());
    }


    public void ResetAnomalyTracker()
    {
        usedAnomalies.ForEach(anomaly => anomalies.Add(anomaly));
    }

    public void ResetRound()
    {
        DeactivateAllAnomalies();
        StartRound();
    }
    
    public void ResetGame()
    {
        ResetAnomalyTracker();
        ResetRound();
    }

}
