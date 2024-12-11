using UnityEngine;

public class Present : MonoBehaviour
{
    public string presentName; // Unique identifier for this present

    private void Start()
    {
        // Check if this present has already been picked up or placed in another scene
        if (PersistentManager.Instance != null)
        {
            if (PersistentManager.Instance.IsPresentPickedUp(presentName))
            {
                Destroy(gameObject); // Remove the present from the scene
            }
            else
            {
                // Check if the present has been placed in another scene
                foreach (var placedPresent in PersistentManager.Instance.placedPresents)
                {
                    if (placedPresent.prefabName == presentName)
                    {
                        Destroy(gameObject); // Remove it from this scene
                        return;
                    }
                }
            }
        }
    }
}