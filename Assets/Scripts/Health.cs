using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player death, like restarting the level, playing a death animation, etc.
        Debug.Log("Player died!");

        // Example: Restart level (you can replace this with your preferred death handling)
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}