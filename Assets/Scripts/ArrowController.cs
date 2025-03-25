using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Vector3 targetPosition; // Target position for the arrow movement
    public float moveSpeed = 2f; // Speed of arrow movement
    private bool hasMoved = false; // Track if the arrow has moved

    private void OnTriggerEnter(Collider other)
    {
        if (!hasMoved) // Only move if it hasn't already moved
        {
            Debug.Log("Arrow triggered! Moving to target position.");
            hasMoved = true;
            StopAllCoroutines();
            StartCoroutine(MoveArrow(targetPosition));
        }
    }

    private System.Collections.IEnumerator MoveArrow(Vector3 targetPosition)
    {
        Debug.Log("Starting to move the arrow to position: " + targetPosition);
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        transform.position = targetPosition; // Snap to final position
        Debug.Log("Arrow movement complete. Final position: " + transform.position);
    }
}
