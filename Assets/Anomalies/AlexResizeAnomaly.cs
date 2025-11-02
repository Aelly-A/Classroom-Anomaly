using UnityEngine;

public class AlexResizeAnomaly : Anomaly
{
    public GameObject profAlex;
    public float resizeSpeed = 1f;
    public float maxScaleMultiplier = 2f;
    public bool shrinkAnomaly = false;

    Vector3 startingScale;
    bool stillResizing = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Scale: " + profAlex.transform.localScale);
        Debug.Log(stillResizing);
        if (!stillResizing)
        {
            return;
        }

        float direction = shrinkAnomaly ? -1f : 1f;
        float scaleFactor = 1 + resizeSpeed * Time.deltaTime * direction;

        Vector3 bottom = profAlex.transform.position - profAlex.transform.up * (profAlex.transform.localScale.y / 2f);

        profAlex.transform.localScale *= scaleFactor;

        profAlex.transform.position = bottom + profAlex.transform.up * (profAlex.transform.localScale.y / 2f);


        if (!shrinkAnomaly && profAlex.transform.localScale.x >= startingScale.x * maxScaleMultiplier)
        {
            stillResizing = false;
        }
        else if (shrinkAnomaly && profAlex.transform.localScale.x <= startingScale.x / maxScaleMultiplier)
        {
            stillResizing = false;
        }
    }

    public override void Activate()
    {
        base.Activate();
        profAlex.SetActive(true);
        startingScale = profAlex.transform.localScale;

        // Fix for not being able to get professor object scale
        if (profAlex.transform.localScale.sqrMagnitude < 0.001f)
        {
            startingScale = new Vector3(0.75f, 1.27f, 0.75f);
            profAlex.transform.localScale = startingScale;
        }

        Debug.Log("Starting scale: " + startingScale);
        stillResizing = true;
    }

    public override void Deactivate()
    {
        stillResizing = false;
        profAlex.transform.localScale = startingScale;
        base.Deactivate();
    }
}
