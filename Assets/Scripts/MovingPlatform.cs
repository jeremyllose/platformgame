using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float waitTime = 1f;

    private Vector3 targetPosition;
    private bool isWaiting = false;
    private Vector3 lastPosition;
    private Vector3 platformVelocity;

    private void Start()
    {
        targetPosition = pointA.position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (!isWaiting)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                StartCoroutine(WaitAndSwitchTarget());
            }
        }
    }

    private IEnumerator WaitAndSwitchTarget()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        isWaiting = false;
    }

    private void FixedUpdate()
    {
        platformVelocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ventus") || collision.collider.CompareTag("Petra"))
        {
            collision.collider.transform.SetParent(transform); // Set player as child of platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ventus") || collision.collider.CompareTag("Petra"))
        {
            collision.collider.transform.SetParent(null); // Remove player from platform
        }
    }
}
