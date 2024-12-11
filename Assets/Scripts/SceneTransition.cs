using UnityEngine;
using UnityEngine.SceneManagement;

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
            //GameManager.Instance.LoadScene(targetScene, spawnPositionInTargetScene);
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(targetScene);
        }
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Player.PlayerController.Instance.transform.position = spawnPositionInTargetScene;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}