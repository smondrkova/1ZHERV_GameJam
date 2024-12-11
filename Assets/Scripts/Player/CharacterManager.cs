using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    
    public Player.PlayerController[] characters; // Array of all characters
    public Player.PlayerController activeCharacter;
    private bool canSwitchCharacter = false;

    public Transform[] inactivePositions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("CharacterManager Singleton Initialized");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Debug.Log("CharacterManager Start Method Called");
        // Set the first character as active by default
        //SetActiveCharacter(characters[0]);
        activeCharacter = characters[0];
        activeCharacter.isActiveCharacter = true;
        DontDestroyOnLoad(activeCharacter.gameObject);
        
        // Assign inactive characters to their fixed positions
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != activeCharacter && i < inactivePositions.Length)
            {
                characters[i].transform.position = inactivePositions[i].position;
            }
        }
    }
    
    public void OnCharacterSelect(InputValue value)
    {
        Debug.Log("CharacterManager Start Method Called");
        
        if (!canSwitchCharacter) return;

        int selectedCharacterIndex = Mathf.RoundToInt(value.Get<float>()) - 1; // Convert input to 0-based index

        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characters.Length && characters[selectedCharacterIndex] != activeCharacter)
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
            Vector3 tempPosition = activeCharacter.transform.position;
            activeCharacter.transform.position = newCharacter.transform.position;
            newCharacter.transform.position = tempPosition;
            
            activeCharacter.isActiveCharacter = false;
            
            // Remove Rigidbody2D from the inactive character
            Rigidbody2D rb = activeCharacter.GetComponent<Rigidbody2D>();
            if (rb != null) Destroy(rb);
            
            // remove from destroy on load
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.MoveGameObjectToScene(activeCharacter.gameObject, currentScene);
        }
        
        activeCharacter = newCharacter;
        activeCharacter.isActiveCharacter = true;
        
        // if the charcter does not already have a rigidbody, add one
        Rigidbody2D newRb = activeCharacter.gameObject.AddComponent<Rigidbody2D>();
        newRb.gravityScale = 3f;
        newRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        activeCharacter.rb = newRb;
        
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