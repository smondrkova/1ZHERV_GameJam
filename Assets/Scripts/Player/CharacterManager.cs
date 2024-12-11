using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    
    public Player.PlayerController[] characters; // Array of all characters
    public Player.PlayerController activeCharacter;
    private bool canSwitchCharacter = false;
    

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
        // Set the first character as active by default
        SetActiveCharacter(characters[0]);
    }
    
    public void OnCharacterSelect(InputValue value)
    {
        if (!canSwitchCharacter) return;

        int selectedCharacterIndex = Mathf.RoundToInt(value.Get<float>()) - 1; // Convert input to 0-based index

        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characters.Length)
        {
            SetActiveCharacter(characters[selectedCharacterIndex]);
        }
        else
        {
            Debug.LogWarning("Invalid character selection input.");
        }
    }

    public void SetActiveCharacter(Player.PlayerController newCharacter)
    {
        if (canSwitchCharacter == false)
        {
            Debug.Log("Switching characters is disabled.");
            return;
        }

        if (activeCharacter != null)
        {
            activeCharacter.isActiveCharacter = false;
            
            // remove from destroy on load
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.MoveGameObjectToScene(activeCharacter.gameObject, currentScene);
        }
        
        activeCharacter = newCharacter;
        activeCharacter.isActiveCharacter = true;
        
        DontDestroyOnLoad(activeCharacter.gameObject);

        Debug.Log($"Switched to: {activeCharacter.gameObject.name}");
    }
    
    public void AllowCharacterSwitching(bool allowSwitching)
    {
        canSwitchCharacter = allowSwitching;
    }

    public Player.PlayerController GetActiveCharacter()
    {
        return activeCharacter;
    }
}