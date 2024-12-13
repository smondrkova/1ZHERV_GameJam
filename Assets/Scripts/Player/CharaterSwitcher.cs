using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Character References")]
    public GameObject[] characters; 
    private int activeCharacterIndex = 0;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        
        // activate the first character and deactivate the others
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == activeCharacterIndex);
        }
    }

    public void OnCharacterSelect(InputValue value)
    {
        int selectedCharacter = Mathf.RoundToInt(value.Get<float>());
        
        SwitchCharacter(selectedCharacter - 1); 
    }

    private void SwitchCharacter(int newIndex)
    {
        if (newIndex >= 0 && newIndex < characters.Length)
        {
            // deactivate the current character
            characters[activeCharacterIndex].SetActive(false);

            // activate the selected character
            activeCharacterIndex = newIndex;
            characters[activeCharacterIndex].SetActive(true);
            
            playerController.animator = characters[activeCharacterIndex].GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("Invalid character index: " + newIndex);
        }
    }
}