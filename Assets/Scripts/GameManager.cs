using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 playerPosition; 

    private void Awake()
    {
        // Ensure the GameManager persists between scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName, Vector3 spawnPosition)
    {
        // Update the player's spawn position
        playerPosition = spawnPosition;
        
        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }
}