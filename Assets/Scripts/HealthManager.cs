using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar; // Assign the Green Fill Image in the Inspector
    public float healthAmount = 100f;
    private float maxHealth = 100f; // Keep track of max health

    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart level
        }

        if (Input.GetKeyDown(KeyCode.Return)) // Simulating damage
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Simulating heal
        {
            Heal(5);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = healthAmount / maxHealth;
    }
}
