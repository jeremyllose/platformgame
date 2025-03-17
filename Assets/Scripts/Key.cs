using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string keyOwner; // Set in Inspector to "Ventus" or "Petra"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(keyOwner))
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
