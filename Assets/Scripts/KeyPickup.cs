using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private string keyOwner; // Set in Inspector to "Ventus" or "Petra"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(keyOwner))
        {
            if (keyOwner == "Ventus")
            {
                Finish.VentusGetsKey();
            }
            else if (keyOwner == "Petra")
            {
                Finish.PetraGetsKey();
            }

            Debug.Log(keyOwner + " picked up their key!");
            Destroy(gameObject); // Remove key after pickup
        }
    }
}
