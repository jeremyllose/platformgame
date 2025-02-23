using UnityEngine;

public class CharacterMovingPlatform : MonoBehaviour
{
    public string allowedTag; // Example: "Ventus" or "Petra"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(allowedTag))
        {
            Debug.Log(other.name + " is not allowed! Disabling collision.");
            Collider2D characterCollider = other.GetComponent<Collider2D>();
            Collider2D platformCollider = GetComponent<Collider2D>();

            if (characterCollider != null && platformCollider != null)
            {
                Physics2D.IgnoreCollision(characterCollider, platformCollider, true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(allowedTag))
        {
            Debug.Log(other.name + " left, restoring collision.");
            Collider2D characterCollider = other.GetComponent<Collider2D>();
            Collider2D platformCollider = GetComponent<Collider2D>();

            if (characterCollider != null && platformCollider != null)
            {
                Physics2D.IgnoreCollision(characterCollider, platformCollider, false);
            }
        }
    }
}