using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image healthBar; // Assign the Green (Health) UI Image

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " took damage! Current health: " + currentHealth);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void UpdateHealthUI()
    {
        Debug.Log(gameObject.name + " updating health bar: " + currentHealth); // 🔍 Check if this logs

        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("HealthBar UI Image is not assigned in the Inspector!");
        }
    }


    private void Die()
    {
        Debug.Log(gameObject.name + " died! Reloading in 0.5 seconds...");

        // Disable player controls (optional)
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        Invoke("ReloadScene", 0.5f);
    }
}
