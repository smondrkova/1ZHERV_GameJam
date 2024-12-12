using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 playerPosition; 
    public GameObject tutorial;

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
    
    public void SavePlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

    public void LoadScene(string sceneName, Vector3 spawnPosition)
    {
        // Update the player's spawn position
        playerPosition = spawnPosition;
        
        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        DialogueManager.Instance.StartFirstDialogue();
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Quitting in Unity Editor: 
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER || UNITY_WEBGL
        // Quitting in the WebGL build: 
        Application.OpenURL(Application.absoluteURL);
#else // !UNITY_WEBPLAYER
        // Quitting in all other builds: 
        Application.Quit();
#endif
    }
}