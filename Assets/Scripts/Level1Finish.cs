using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private string nextLevelName; // Assign the next level in the inspector
    
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void ProceedToNextLevel()
    {
        Debug.Log("Proceeding to the next level...");
        
        // Reset time scale before proceeding
        Time.timeScale = 1;

        if (!string.IsNullOrEmpty(nextLevelName) && SceneManager.GetActiveScene().name != nextLevelName)
        {
            SceneManager.LoadSceneAsync(nextLevelName);
        }
        else
        {
            Debug.LogWarning("Next level is already active or not set.");
        }

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
