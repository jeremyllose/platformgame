using UnityEngine;

public class PersistentUI : MonoBehaviour
{
    private static PersistentUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep UI across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
}
