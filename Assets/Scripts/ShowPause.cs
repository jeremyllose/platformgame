using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Assigned in Inspector
    private bool isPaused = false;

    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogWarning("ESC key pressed");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Debug.LogWarning("Game is paused, trying to unpause");
            UnpauseGame();
        }
        else
        {
            Debug.LogWarning("Game is not paused, trying to pause");
            PauseGame();
        }
    }

    private void PauseGame()
    {
        FindPausePanel(); // Ensure it's assigned before pausing

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f; // Freezes the game
        isPaused = true;
    }

    private void UnpauseGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f; // Resumes the game
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
