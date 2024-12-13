using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneTransition : MonoBehaviour
{
    [Header("Transition Settings")]
    public string targetScene; 
    public Vector3 spawnPositionInTargetScene; 
    public GameObject[] presentPrefabs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(targetScene);
        }
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var player = Player.PlayerController.Instance;
        if (player != null)
        {
            player.transform.position = spawnPositionInTargetScene;
        }
        
        var follower = Follower.Instance;
        if (follower != null)
        {
            if (player != null)
            {
                // spawn follower on the side of the player
                Vector3 offset = follower.isToRightOfTarget ? Vector3.right * 2f : Vector3.left * 2f;
                follower.transform.position = player.transform.position + offset;
            }
        }
        
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