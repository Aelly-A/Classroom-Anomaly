using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Hides the cursor at start of game
        Cursor.visible = false;

        // Locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked; 
    }
}
