using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public DoorController door; // Reference to the door this button controls

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only trigger for characters with "Ventus" or "Petra" tags
        if (other.CompareTag("Ventus") || other.CompareTag("Petra"))
        {
            Debug.Log("Button pressed by " + other.tag + "!");
            door.ToggleDoor(true); // Open the door
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Only trigger for characters with "Ventus" or "Petra" tags
        if (other.CompareTag("Ventus") || other.CompareTag("Petra"))
        {
            Debug.Log("Button released by " + other.tag + "!");
            door.ToggleDoor(false); // Close the door
        }
    }
}
