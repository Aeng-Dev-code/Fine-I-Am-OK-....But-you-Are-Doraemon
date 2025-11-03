using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint saved at " + transform.position);
            }
        }
    }
}