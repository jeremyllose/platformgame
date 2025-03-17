using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPause : MonoBehaviour
<<<<<<< Updated upstream
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
=======
 {
     public static ShowPause Instance { get; private set; } // Singleton instance
 
     [SerializeField] private GameObject pausePanel; // Pause panel UI
     private bool isPaused = false; // Tracks the current pause state
 
     private void Awake()
     {
         if (Instance == null)
         {
             Instance = this;
             DontDestroyOnLoad(gameObject); // Persist across scenes
         }
         else
         {
             Destroy(gameObject); // Remove duplicates
         }
     }
 
     void Update()
     {
         // Check if the Escape key is pressed
         if (Input.GetKeyDown(KeyCode.Escape))
         {
             // Log when the ESC key is pressed
             Debug.LogWarning("ESC key pressed");
 
             // Check if game is already paused
             if (isPaused)
             {
                 Debug.LogWarning("Game is paused, trying to unpause");
 @@ -22,14 +35,12 @@ void Update()
                 Debug.LogWarning("Game is not paused, trying to pause");
             }
 
             // Toggle the pause state when ESC is pressed
             TogglePause();
         }
     }
 
     public void TogglePause()
     {
         // Toggle pause state and show/hide the pause panel accordingly
         if (isPaused)
         {
             UnpauseGame();
 @@ -42,27 +53,19 @@ public void TogglePause()
 
     private void PauseGame()
     {
         // Show the pause panel
         if (pausePanel != null)
             pausePanel.SetActive(true);
 
         // Pause the game
         Time.timeScale = 0f; // Freezes the game
 
         // Set the pause state to true
         Time.timeScale = 0f;
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
         Time.timeScale = 1f;
         isPaused = false;
     }
 }
 }
>>>>>>> Stashed changes
