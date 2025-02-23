using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject heldKey = null;

    public bool HasKey(GameObject key)
    {
        return heldKey == key;
    }

    public void PickupKey(GameObject key)
    {
        heldKey = key;
        key.SetActive(false); // Hide key when picked up
        Debug.Log(gameObject.name + " picked up " + key.name);
    }
}