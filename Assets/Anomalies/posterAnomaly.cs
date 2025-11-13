using UnityEngine;

public class PosterAnomaly : Anomaly
{
    private Texture originalTexture;
    private Texture catTexture;
    private Renderer posterRenderer;

    void Start()
    {
        posterRenderer = GetComponent<Renderer>();

        if (posterRenderer != null)
            originalTexture = posterRenderer.material.mainTexture;

        catTexture = Resources.Load<Texture>("CatPoster");
    }

    public override void Activate()
    {
        Debug.Log("Poster Anomaly Activated");
        if (posterRenderer != null && catTexture != null)
            posterRenderer.material.mainTexture = catTexture;
    }

    public override void Deactivate()
    {
        Debug.Log("Poster Anomaly Deactivated");
        if (posterRenderer != null && originalTexture != null)
            posterRenderer.material.mainTexture = originalTexture;
    }
}
