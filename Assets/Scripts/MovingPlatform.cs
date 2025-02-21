using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Destination point
    public float speed = 2f; // Movement speed
    public float waitTime = 1f; // Time to wait at each point

    private Vector3 targetPosition; // Current target
    private bool isWaiting = false; // To prevent moving while waiting

    private void Start()
    {
        targetPosition = pointA.position; // Start moving towards Point A
    }

    private void Update()
    {
        if (!isWaiting) // Only move if not waiting
        {
            // Move platform towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the platform reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                StartCoroutine(WaitAndSwitchTarget()); // Wait and switch target
            }
        }
    }

    private IEnumerator WaitAndSwitchTarget()
    {
        isWaiting = true; // Pause movement
        yield return new WaitForSeconds(waitTime); // Wait for the defined time

        // Switch to the other point
        targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;

        isWaiting = false; // Resume movement
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ventus") || collision.collider.CompareTag("Petra"))
        {
            collision.collider.transform.SetParent(transform); // Parent the player to the platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ventus") || collision.collider.CompareTag("Petra"))
        {
            collision.collider.transform.SetParent(null); // Unparent the player
        }
    }
}
