using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsMenuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingsMenu();
        }
    }

    public void ToggleSettingsMenu()
    {
        if (settingsMenuPanel != null)
        {
            settingsMenuPanel.SetActive(!settingsMenuPanel.activeSelf);

            if (settingsMenuPanel.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}