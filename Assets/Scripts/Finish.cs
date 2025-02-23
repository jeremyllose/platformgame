using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;  // Reference to the Win Panel
    [SerializeField] private string requiredTag;   // Set in Inspector to "Ventus" or "Petra"
    
    private static bool ventusFinished = false;
    private static bool petraFinished = false;
    private static bool ventusHasKey = false;
    private static bool petraHasKey = false;

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(requiredTag))
        {
            if (requiredTag == "Ventus" && ventusHasKey)
            {
                ventusFinished = true;
            }
            else if (requiredTag == "Petra" && petraHasKey)
            {
                petraFinished = true;
            }
            else
            {
                Debug.Log(collision.name + " needs their key to enter!");
                return; // Prevent entering without the key
            }

            Debug.Log(collision.name + " reached their door with the key!");
            CheckWinCondition();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(requiredTag))
        {
            if (requiredTag == "Ventus")
                ventusFinished = false;
            if (requiredTag == "Petra")
                petraFinished = false;
        }
    }

    private void CheckWinCondition()
    {
        if (ventusFinished && petraFinished)
        {
            Debug.Log("Both characters are at their doors with keys. Showing win panel!");
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Call these methods when a character picks up their key
    public static void VentusGetsKey()
    {
        ventusHasKey = true;
        Debug.Log("Ventus obtained the key!");
    }

    public static void PetraGetsKey()
    {
        petraHasKey = true;
        Debug.Log("Petra obtained the key!");
    }
}
