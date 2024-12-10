using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [Header("Transition Settings")]
    public string targetScene; // Name of the scene to load
    public Vector3 spawnPositionInTargetScene; // Player spawn position in the new scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("HERE");
            // Use the GameManager to load the new scene
            GameManager.Instance.LoadScene(targetScene, spawnPositionInTargetScene);
        }
    }
}