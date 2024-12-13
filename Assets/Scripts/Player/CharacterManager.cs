using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    
    public Player.PlayerController[] characters; 
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
    
}