using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPause : MonoBehaviour
{
    public static ShowPause Instance { get; private set; } // Singleton instance

    [SerializeField] private GameObject pausePanel; // Assigned in Inspector
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the script persistent
            SceneManager.sceneLoaded += OnSceneLoaded; // Re-assign UI when scene loads
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Toggle pause state and show/hide the pause panel accordingly
        if (isPaused)
            UnpauseGame();
        else
            PauseGame();
    }

    private void PauseGame()
    {
        FindPausePanel(); // Ensure it's assigned before pausing

        if (pausePanel != null)
            pausePanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f; // Freezes the game

        // Set the pause state to true
        isPaused = true;
    }

    private void UnpauseGame()
    {
        // Hide the pause panel
        if (pausePanel != null)
            pausePanel.SetActive(false);

        // Unpause the game
        Time.timeScale = 1f; // Resumes the game

        // Set the pause state to false
        isPaused = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPausePanel(); // Re-find the panel after scene change
    }

    private void FindPausePanel()
    {
        if (pausePanel == null)
        {
            pausePanel = GameObject.FindGameObjectWithTag("PausePanel"); // Find it again in new scenes
        }
    }
}
