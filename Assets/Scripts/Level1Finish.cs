using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private GameObject winPanel; // Assign in Inspector or find dynamically

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void ProceedToNextLevel()
    {
        Debug.Log("Proceed button pressed, loading next level...");

        // If winPanel is null, try finding it dynamically
        if (winPanel == null)
        {
            winPanel = GameObject.FindGameObjectWithTag("WinPanel");
        }

        // Hide win panel
        if (winPanel != null)
        {
            winPanel.SetActive(false);
            Debug.Log("Win panel hidden.");
        }
        else
        {
            Debug.LogWarning("Win panel reference is missing or not found!");
        }

        // Unpause game if it was paused
        Time.timeScale = 1f;

        // Determine next level based on the current scene
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene = "";

        if (currentScene == "Level1")
        {
            nextScene = "Level2";
        }
        else if (currentScene == "Level2")
        {
            nextScene = "Level3";
        }
        else
        {
            Debug.LogWarning("No next level defined for " + currentScene);
            return; // Stop if there's no next level
        }

        // Load next level
        SceneManager.LoadSceneAsync(nextScene);
        Debug.Log("Loading " + nextScene);

        // Play sound effect
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.menuSFX);
        }
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed, exiting application...");
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.menuSFX);
        }
        Application.Quit();
    }
}
