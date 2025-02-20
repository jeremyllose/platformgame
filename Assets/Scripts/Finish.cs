using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{

    AudioManager audioManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static Finish Instance;

    // Reference to the win menu
    [SerializeField] private GameObject winMenu;  // Make sure to assign this in the Inspector
    [SerializeField] private string playerTag = "Player"; // Make sure to define the player tag
    void Start()
    {

    }
    void Awake()
    {
        Instance = this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.CompareTag(playerTag))
        {
            Debug.Log("Player reached the finish line!");
            // Activate the win menu
            winMenu.SetActive(true);
            audioManager.PlaySFX(audioManager.VictorySFX);
        }
        
    }
}
