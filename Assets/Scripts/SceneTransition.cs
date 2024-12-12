using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneTransition : MonoBehaviour
{
    [Header("Transition Settings")]
    public string targetScene; // Name of the scene to load
    public Vector3 spawnPositionInTargetScene; // Player spawn position in the new scene
    public GameObject[] presentPrefabs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(targetScene);
        }
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reposition the player
        var player = Player.PlayerController.Instance;
        if (player != null)
        {
            player.transform.position = spawnPositionInTargetScene;
        }

        // Reposition the follower if it exists
        var follower = Follower.Instance;
        if (follower != null)
        {
            if (player != null)
            {
                // Snap the follower near the player on scene load
                Vector3 offset = follower.isToRightOfTarget ? Vector3.right * 2f : Vector3.left * 2f;
                follower.transform.position = player.transform.position + offset;
            }
        }

        // Load presents
        LoadPresentsForScene(scene.name);
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void LoadPresentsForScene(string sceneName)
    {
        var presents = PresentManager.Instance.GetPresentsForScene(sceneName);
        foreach (var present in presents)
        {
            GameObject prefab = Array.Find(presentPrefabs, p => p.name == present.prefabName);
            
            if (prefab != null)
            {
                Instantiate(prefab, present.position, present.rotation);
            }
            else
            {
                Debug.LogWarning($"Failed to load prefab: {present.prefabName}");
            }
        }
    }
}