using UnityEngine;

public class Lava : MonoBehaviour
    // When the player collides with the lava
 {
    public GameObject losePanel; // Reference to the Lose Panel

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ventus") || other.CompareTag("Petra")) // Check if the character touches lava
        {
            Debug.Log(other.name + " has touched the lava!");
            KillPlayer(other.gameObject); // "Kill" the player
        }
    }

    private void KillPlayer(GameObject player)
    {
        // Disable the player or trigger any death animation here
        player.SetActive(false); // Deactivate the character to simulate death

        // Show the lose panel
        losePanel.SetActive(true);
        Debug.Log("Lose panel activated!");
    }
}