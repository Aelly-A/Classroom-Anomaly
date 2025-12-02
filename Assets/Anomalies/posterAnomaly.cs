using UnityEngine;

public class PosterAnomaly : Anomaly
{
    public GameObject catPoster;   // Reference to your cat sprite object

    void Start()
    {
        // Make sure it's hidden at the start
        if (catPoster != null)
            catPoster.SetActive(false);
    }

    public override void Activate()
    {
        Debug.Log("Poster Anomaly Activated");

        if (catPoster != null)
            catPoster.SetActive(true);
    }

    public override void Deactivate()
    {
        Debug.Log("Poster Anomaly Deactivated");

        if (catPoster != null)
            catPoster.SetActive(false);
    }
}
