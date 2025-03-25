using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; // Main panel
    public Button toggleButton; // Main toggle button

    public GameObject ventusPanel; // Assign in Inspector
    public GameObject petraPanel;  // Assign in Inspector
    public GameObject deathPanel;  // Assign in Inspector

    private void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Initially hidden
        }

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleVisibility);
        }
    }

    private void ToggleVisibility()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf); // Toggle visibility
        }
    }

    public void VentusWin()
    {
        Debug.LogWarning("Showing Ventus panel...");
        if (ventusPanel != null)
            ventusPanel.SetActive(true);
    }

    public void PetraWin()
    {
        Debug.LogWarning("Showing Petra panel...");
        if (petraPanel != null)
            petraPanel.SetActive(true);
    }

    public void MonsterLose()
    {
        Debug.LogWarning("Showing Death panel...");
        if (deathPanel != null)
            deathPanel.SetActive(true);
    }
}
