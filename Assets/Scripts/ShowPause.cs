using UnityEngine;

public class ShowPause : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogWarning("ESC key pressed");

            if (isPaused)
            {
                Debug.LogWarning("Game is paused, trying to unpause");
            }
            else
            {
                Debug.LogWarning("Game is not paused, trying to pause");
            }

            TogglePause();
        }
    }

    public void TogglePause()
    {
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
        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    private void UnpauseGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }
}
