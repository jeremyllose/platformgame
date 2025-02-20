using UnityEngine;

public class Lava : MonoBehaviour
{
    // When the player collides with the lava
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided is the player
        if (collision.gameObject.CompareTag("Ventus") || collision.gameObject.CompareTag("Petra"))
        {
            // Kill the player (for example, by triggering respawn or reducing health)
            Health Health = collision.gameObject.GetComponent<Health>();
            if (Health != null)
            {
                Health.TakeDamage(9999); // Or whatever damage value you want
            }
        }
    }
}