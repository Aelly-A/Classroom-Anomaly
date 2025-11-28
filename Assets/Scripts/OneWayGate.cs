using UnityEngine;

public class OneWayGate : MonoBehaviour
{
    [Header("Assign your player object here")]
    public Transform player;

    [Header("Enable/disable the gate at runtime")]
    public bool gateEnabled = false;

    [Header("Direction the player is NOT allowed to cross")]
    public Vector3 forbiddenNormal = Vector3.forward;

    private void OnTriggerStay(Collider other)
    {
        if (!gateEnabled) return;
        if (other.transform != player) return;

        // Vector from gate → player
        Vector3 toPlayer = (player.position - transform.position).normalized;

        // If the player tries crossing the forbidden side...
        if (Vector3.Dot(toPlayer, forbiddenNormal) > 0f)
        {
            // Gently push them back into the room
            player.position -= forbiddenNormal * 0.08f;
        }
    }
}
