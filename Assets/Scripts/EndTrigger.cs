using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // For TextMeshPro

public class EndTrigger : MonoBehaviour
{
    // public string mainMenu = "Main Menu";

    // References to UI elements    
    [SerializeField] private GameObject winPanel;    // The panel holding "You Win!" message and buttons
    [SerializeField] private TextMeshProUGUI winText; // The text component for "You Win!"
    [SerializeField] private GameObject retryButton;  // The retry button UI
    [SerializeField] private GameObject menuButton;   // The main menu button UI

    AudioManager audioManager;
    private void Start()
    {
        // Initially hide the win panel
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the end!");

            // Show the win panel
            if (winPanel != null)
                winPanel.SetActive(true);
            Time.timeScale = 0;

            // Show the "You Win!" message
            if (winText != null)
                winText.text = "You Win!";
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        audioManager.PlaySFX(audioManager.menuSFX);
        Time.timeScale = 1;
    }
    // public void Menu()
    // {
    //     SceneManager.LoadScene("MainMenuScene");
    //     audioManager.PlaySFX(audioManager.menuSFX);
    //     Time.timeScale = 1;

    // }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
