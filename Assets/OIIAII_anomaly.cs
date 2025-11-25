using UnityEngine;

public class OIIAII_anomaly : MonoBehaviour
{

    void Start()
    {
    }
 public void Activate()
    {
        SetChildrenActive(true);
    }

    public void Deactivate()
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
