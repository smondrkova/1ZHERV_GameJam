using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentManager : MonoBehaviour
{
    public static PresentManager Instance;

    [Header("Present settings")] 
    public int totalPresents = 10;
    public int remainingPresentsToPlace;
    public int pickedUpPresents;
    
    [Header("UI settings")] 
    public Text presentCountText;

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
    
    private void Start()
    {
        remainingPresentsToPlace = totalPresents;
        pickedUpPresents = 0;
        UpdatePresentCountText();
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
    
    public void RemovePresent(string sceneName, Vector3 position)
    {
        if (scenePresents.ContainsKey(sceneName))
        {
            for (int i = 0; i < scenePresents[sceneName].Count; i++)
            {
                if (scenePresents[sceneName][i].position == position)
                {
                    scenePresents[sceneName].RemoveAt(i);
                    return;
                }
            }
        }
    }

    public List<PresentData> GetPresentsForScene(string sceneName)
    {
        if (scenePresents.ContainsKey(sceneName))
        {
            return scenePresents[sceneName];
        }
        return new List<PresentData>();
    }
    
    public void PlacePresentUI()
    {
        if (remainingPresentsToPlace <= 0) return;
        remainingPresentsToPlace--;
        UpdatePresentCountText();
    }
    
    public void PickUpPresentUI()
    {
        if (pickedUpPresents >= totalPresents) return;
        pickedUpPresents++;
        UpdatePresentCountText();
    }
    
    public void DestroyedPresentUI()
    {
        remainingPresentsToPlace++;
        UpdatePresentCountText();
    }

    public void ResetPresentUI()
    {
        remainingPresentsToPlace = 0;
        UpdatePresentCountText();
    }
    
    private void UpdatePresentCountText()
    {
        if (remainingPresentsToPlace != 0)
        {
            presentCountText.text = $"{remainingPresentsToPlace}/{totalPresents}";
        }
        else
        {
            presentCountText.text = $"{pickedUpPresents}/{totalPresents}";
        }
    }
    
    public void SetPresentCountText(int numberOfPresents)
    {
        presentCountText.text = $"{numberOfPresents}/{totalPresents}";
    }
    
}