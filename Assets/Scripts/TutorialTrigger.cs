using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialText; // Assign the UI text in the Inspector

    private void Start()
    {
        if (tutorialText != null)
        {
            tutorialText.SetActive(false); // Hide text initially
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ventus") || other.CompareTag("Petra")) // Check if player enters
        {
            if (tutorialText != null)
            {
                tutorialText.SetActive(true);
                Debug.Log("Tutorial text shown!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ventus") || other.CompareTag("Petra")) // Check if player exits
        {
            if (tutorialText != null)
            {
                tutorialText.SetActive(false);
                Debug.Log("Tutorial text hidden!");
            }
        }
    }
}
