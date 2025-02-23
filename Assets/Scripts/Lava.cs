using UnityEngine;

public class Lava : MonoBehaviour
{
    public float damageAmount = 100f;
    public GameObject losePanel; // Reference to the Lose Panel

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ventus") || other.CompareTag("Petra")) // Check if character touches lava
        {
            Debug.Log(other.name + " has touched the lava!");

            // Get the Health component of the character
            Health health = other.GetComponent<Health>();
            
            if (health != null)
            {
                health.TakeDamage((int)damageAmount); // Apply damage
                Debug.Log(other.name + " took " + damageAmount + " damage! Current health: " + health.currentHealth);
            }
            else
            {
                Debug.LogWarning(other.name + " has no Health script!");
            }
            
            // If health reaches zero, trigger death
            if (health == null || health.currentHealth <= 0)
            {
                KillPlayer(other.gameObject);
            }
        }
    }

    private void KillPlayer(GameObject player)
    {
        player.SetActive(false); // Deactivate the character to simulate death

        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Debug.Log("Lose panel activated!");
        }
        else
        {
            Debug.LogWarning("Lose Panel is not assigned in the Inspector!");
        }
    }
}
