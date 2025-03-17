using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPause : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private GameObject pausePanel; // Pause panel UI
    private bool isPaused = false; // Tracks the current pause state
    void Update()
>>>>>>> parent of c29eeec (yes)
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
<<<<<<< HEAD
=======
            // Log when the ESC key is pressed
            Debug.LogWarning("ESC key pressed");

            // Check if game is already paused
            if (isPaused)
            {
                Debug.LogWarning("Game is paused, trying to unpause");
            }
            else
            {
                Debug.LogWarning("Game is not paused, trying to pause");
            }

            // Toggle the pause state when ESC is pressed
>>>>>>> parent of c29eeec (yes)
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
<<<<<<< HEAD
        FindPausePanel(); // Ensure it's assigned before pausing

=======
        // Show the pause panel
>>>>>>> parent of c29eeec (yes)
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
<<<<<<< HEAD

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
=======
}
>>>>>>> parent of c29eeec (yes)
