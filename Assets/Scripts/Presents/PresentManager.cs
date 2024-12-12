using System.Collections.Generic;
using UnityEngine;

public class PresentManager : MonoBehaviour
{
    public static PresentManager Instance;

    [System.Serializable]
    public class PresentData
    {
        public Vector3 position;
        public Quaternion rotation;
        public string prefabName; // Used to respawn the correct prefab
    }

    private Dictionary<string, List<PresentData>> scenePresents = new Dictionary<string, List<PresentData>>();

    private void Awake()
    {
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

    public void SavePresent(string sceneName, Vector3 position, Quaternion rotation, string prefabName)
    {
        if (!scenePresents.ContainsKey(sceneName))
        {
            scenePresents[sceneName] = new List<PresentData>();
        }

        // Add the present data to the current scene's list
        scenePresents[sceneName].Add(new PresentData { position = position, rotation = rotation, prefabName = prefabName });
    }

    public List<PresentData> GetPresentsForScene(string sceneName)
    {
        if (scenePresents.ContainsKey(sceneName))
        {
            return scenePresents[sceneName];
        }
        return new List<PresentData>();
    }
}