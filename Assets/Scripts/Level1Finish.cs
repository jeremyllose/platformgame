using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Finish : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Level2";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Proceed2()
    {
        Debug.Log("Play button pressed, loading game...");

        // Ensure you're not unloading and loading the same scene at the same time
        if (SceneManager.GetActiveScene().name != "Level2")
        {
            SceneManager.LoadSceneAsync("Level2"); // Load the desired scene
        }
        else
        {
            Debug.LogWarning("Level2 is already active. Skipping reload.");
        }

        // Play sound effect
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.menuSFX);
        }
    }
    public void Quit()
    {
        Debug.Log("Quit button pressed, exiting application...");
        audioManager.PlaySFX(audioManager.menuSFX);
        Application.Quit();
    }
}

