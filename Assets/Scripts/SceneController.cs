using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject[] enemies; // Reference to all enemy GameObjects (can be empty if no enemies)
    public GameObject pausePanel; // Reference to the PausePanel GameObject

    private bool isGameFrozen = true; // Tracks whether the game is frozen or not
    private bool isInMainMenu = false; // Tracks if the current scene is the MainMenu
    private bool isGameOver = false; // Flag for game over (win/lose)
    private bool isGamePaused = false; // Flag for game paused (PausePanel displayed)

    void Start()
    {
        // Set the game state based on the active scene
        UpdateGameState();
        SceneManager.sceneLoaded += OnSceneLoaded; // Register to check when the scene is loaded
    }

    private void Update()
    {
        // Check if we are still in the MainMenu
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            isInMainMenu = true;
        }
        else
        {
            isInMainMenu = false;
        }

        // Check if the game is over (win/lose)
        if (isGameOver)
        {
            FreezeGameplay(); // Freeze gameplay during win/lose panel
        }
        else
        {
            // If we're in the MainMenu, freeze everything
            if (isInMainMenu)
            {
                FreezeGameplay();
            }
            else
            {
                UnfreezeGameplay();
            }
        }

        // Check if the PausePanel is active (game is paused)
        if (pausePanel.activeSelf)
        {
            isGamePaused = true;
            FreezeGameplay(); // Freeze gameplay when PausePanel is active
        }
        else
        {
            isGamePaused = false;
            if (!isInMainMenu && !isGameOver)
            {
                UnfreezeGameplay(); // Unfreeze gameplay if not paused and not in main menu
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update game state when a new scene is loaded
        UpdateGameState();
    }

    private void UpdateGameState()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            isGameFrozen = true; // Freeze game when in MainMenu
            FreezeGameplay();
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            isGameFrozen = false; // Unfreeze game when in SampleScene
            UnfreezeGameplay();
        }
    }

    private void FreezeGameplay()
    {
        // Freeze the time and disable player/enemy behaviors
        Time.timeScale = 0f; // Pause the game by setting time scale to 0

        // Disable player movement script
        if (player != null)
        {
            var playerMovement = player.GetComponent<MonoBehaviour>(); // Get your player movement script (e.g., Driver)
            if (playerMovement != null)
                playerMovement.enabled = false; // Disable player movement
        }

        // Disable enemy AI
        foreach (var enemy in enemies)
        {
            var enemyAI = enemy.GetComponent<MonoBehaviour>(); // Get your enemy AI script
            if (enemyAI != null)
                enemyAI.enabled = false; // Disable enemy AI
        }

        // Optionally disable other gameplay components like particle systems, physics, etc. if necessary
    }

    private void UnfreezeGameplay()
    {
        // Unfreeze the time and re-enable player/enemy behaviors
        Time.timeScale = 1f; // Resume the game by setting time scale to 1

        // Re-enable player movement script
        if (player != null)
        {
            var playerMovement = player.GetComponent<MonoBehaviour>(); // Get your player movement script (e.g., Driver)
            if (playerMovement != null)
                playerMovement.enabled = true; // Re-enable player movement
        }

        // Re-enable enemy AI
        foreach (var enemy in enemies)
        {
            var enemyAI = enemy.GetComponent<MonoBehaviour>(); // Get your enemy AI script
            if (enemyAI != null)
                enemyAI.enabled = true; // Re-enable enemy AI
        }

        // Re-enable other gameplay components if necessary
    }

    // Example method to set the game over state (win/lose)
    public void SetGameOver(bool isWin)
    {
        isGameOver = true; // Game over state is true
        Debug.Log(isWin ? "You Win!" : "You Lose!");
    }

    // Example method to pause the game
    public void PauseGame()
    {
        if (!isGamePaused)
        {
            pausePanel.SetActive(true); // Show the PausePanel
        }
    }

    // Example method to resume the game
    public void ResumeGame()
    {
        if (isGamePaused)
        {
            pausePanel.SetActive(false); // Hide the PausePanel
        }
    }
}
