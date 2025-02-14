using UnityEngine;

public class ShowPause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Pause panel UI
    private bool isPaused = false; // Tracks the current pause state
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
            }
            else
            {
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
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        // Show the pause panel
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
}
