using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps; // Import for Tilemap

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearTime = 1.5f; // Time before disappearing
    public float respawnTime = 3f; // Time before reappearing
    public float fadeSpeed = 2f; // Speed of fading effect

    private BoxCollider2D[] platformColliders; // Store both colliders
    private Tilemap platformTilemap; // Reference to Tilemap for fading effect

    private void Start()
    {
        platformColliders = GetComponents<BoxCollider2D>(); // Get both colliders
        platformTilemap = GetComponent<Tilemap>(); // Get Tilemap
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ventus") || collision.collider.CompareTag("Petra"))
        {
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearTime - 0.5f); // Delay before fading

        // Start fading effect (if Tilemap exists)
        if (platformTilemap != null)
        {
            float fadeAmount = 1f;
            while (fadeAmount > 0)
            {
                fadeAmount -= Time.deltaTime * fadeSpeed;
                platformTilemap.color = new Color(1f, 1f, 1f, fadeAmount);
                yield return null;
            }
        }

        // Disable both colliders
        foreach (BoxCollider2D col in platformColliders)
        {
            col.enabled = false;
        }

        yield return new WaitForSeconds(respawnTime); // Wait for platform to reappear

        // Re-enable colliders
        foreach (BoxCollider2D col in platformColliders)
        {
            col.enabled = true;
        }

        // Restore visibility (if Tilemap exists)
        if (platformTilemap != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        if (platformTilemap != null)
        {
            float fadeAmount = 0f;
            while (fadeAmount < 1f)
            {
                fadeAmount += Time.deltaTime * fadeSpeed;
                platformTilemap.color = new Color(1f, 1f, 1f, fadeAmount);
                yield return null;
            }
        }
    }
}
