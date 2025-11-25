using UnityEngine;

public class OIIAII_anomaly : Anomaly
{

    void Start()
    {
    }

    public override void Activate()
    {
        SetChildrenActive(true);
    }

    public override void Deactivate()
    {
        SetChildrenActive(false);
    }

    private void SetChildrenActive(bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}
