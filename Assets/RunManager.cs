using System.Collections;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public Vector3 playerStartPosition = new Vector3(25, 0, 0);
    public int runCounter = 0;
    public int totalRuns = 7;
    public GameObject anomalyManager;
    private bool roundHasBegun = false; // i.e. player has entered the room
    private bool roundHasEnded = false; // i.e. roundHasBegun and the player has left the room
    private bool playerEnteredThroughRightDoor = false;
    private bool allowCollisions = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Runner started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ColissionCooldown();

        // Player exits classroom
        if (roundHasBegun && !roundHasEnded && (other.name == "door_frame_right" || other.name == "door_frame_left") && allowCollisions)
        {
            Debug.Log("Round " + runCounter + " Exited door");
            bool rightDoorExitedThrough = other.name == "door_frame_right";
            bool playerExitedThroughEntryDoor = (rightDoorExitedThrough && playerEnteredThroughRightDoor) || (!rightDoorExitedThrough && !playerEnteredThroughRightDoor);
            bool anomalyIsActive = anomalyManager.GetComponent<AnomalyManager>().anomalyIsActive;
            bool playerMadeRightChoice = (playerExitedThroughEntryDoor && anomalyIsActive) || (!playerExitedThroughEntryDoor && !anomalyIsActive);

            FinishRound(playerMadeRightChoice);
        }
        // Player enters classroom
        else if (!roundHasBegun && !roundHasEnded && (other.name == "door_frame_right" || other.name == "door_frame_left") && allowCollisions)
        {
            anomalyManager.GetComponent<AnomalyManager>().ResetRound();
            Debug.Log("Round " + runCounter + " Entered door");

            roundHasBegun = true;
            playerEnteredThroughRightDoor = other.name == "door_frame_right";      
        }

    }
    IEnumerator ColissionCooldown()
    {
        allowCollisions = false;
        yield return new WaitForSeconds(2);
        allowCollisions = true;
    }

    void FinishRound(bool playerMadeRightChoice)
    {
        // Player chose correct door or there is no anomaly
        if (playerMadeRightChoice)
        {
            runCounter ++;
            anomalyManager.GetComponent<AnomalyManager>().ResetRound();
        }
        else // Player chose wrong door
        {
            runCounter = 0;
            anomalyManager.GetComponent<AnomalyManager>().ResetGame();
        }

        // playerHasWon
        if (runCounter == totalRuns)
        {
            anomalyManager.GetComponent<AnomalyManager>().ResetRound();
            // Player win screen
        }

        roundHasBegun = false;
        roundHasEnded = false; 
        
        // Teleport player to spawn
        // fade to black;

    }
}