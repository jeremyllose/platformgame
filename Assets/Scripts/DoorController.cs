using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openPosition; // Target position for the door to open
    private Vector3 closedPosition; // Initial door position
    public float moveSpeed = 2f; // Speed of door movement
    private bool isOpen = false; // Door state

    private void Start()
    {
        closedPosition = transform.position; // Save the initial position
    }

    public void ToggleDoor(bool isPressed)
    {
        if (isPressed && !isOpen) // Only open if the door isn't already open
        {
            Debug.Log("Opening the door!");
            isOpen = true;
            StopAllCoroutines();
            StartCoroutine(MoveDoor(openPosition));
        }
        else if (!isPressed && isOpen) // Only close if the door is open
        {
            Debug.Log("Closing the door!");
            isOpen = false;
            StopAllCoroutines();
            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    private System.Collections.IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Debug.Log("Starting to move the door to position: " + targetPosition);
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        transform.position = targetPosition; // Snap to final position
        Debug.Log("Door movement complete. Final position: " + transform.position);
    }
}
