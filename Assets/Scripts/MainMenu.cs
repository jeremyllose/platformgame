using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // For TextMeshPro

public class MainMenu : MonoBehaviour
{
    // References to UI elements
    [SerializeField] private GameObject mainMenuPanel; // Main menu UI
    [SerializeField] private GameObject aboutPanel;    // About UI
    [SerializeField] private GameObject creditsPanel;  // Credits UI
    [SerializeField] private GameObject levelSelectPanel; // Level selection UI

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // Initially show only the main menu
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (aboutPanel != null)
            aboutPanel.SetActive(false);

        if (creditsPanel != null)
            creditsPanel.SetActive(false);

        if (levelSelectPanel != null)
            levelSelectPanel.SetActive(false);
    }

    public void Play()
    {
        Debug.Log("Play button pressed, opening level selection...");

        // Hide the main menu and show level selection
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (levelSelectPanel != null)
            levelSelectPanel.SetActive(true);

        // Play sound effect
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.menuSFX);
        }
    }
    public void LoadLevel(string levelName)
{
    Debug.Log("Loading " + levelName);
    SceneManager.LoadSceneAsync(levelName);
}
    public void LoadLevel1() { LoadLevel("Level1"); }
    public void LoadLevel2() { LoadLevel("Level2"); }
    public void LoadLevel3() { LoadLevel("Level3"); }
    public void LoadLevel4() { LoadLevel("Level4"); }

    public void ShowAbout()
    {
        Debug.LogWarning("About button pressed, showing about panel...");

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (aboutPanel != null)
            aboutPanel.SetActive(true);

        audioManager.PlaySFX(audioManager.menuSFX);
    }

    public void ShowCredits()
    {
        Debug.LogWarning("Credits button pressed, showing credits panel...");

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (creditsPanel != null)
            creditsPanel.SetActive(true);

        audioManager.PlaySFX(audioManager.menuSFX);
    }

    public void BackToMainMenu()
    {
        Debug.LogWarning("Back button pressed, returning to main menu...");

        if (aboutPanel != null)
            aboutPanel.SetActive(false);

        if (creditsPanel != null)
            creditsPanel.SetActive(false);

        if (levelSelectPanel != null)
            levelSelectPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        audioManager.PlaySFX(audioManager.menuSFX);
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed, exiting application...");
        audioManager.PlaySFX(audioManager.menuSFX);
        Application.Quit();
    }
}
