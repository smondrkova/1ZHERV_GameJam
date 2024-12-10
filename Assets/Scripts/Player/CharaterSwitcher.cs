using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Character References")]
    public GameObject[] characters; // Assign characters in the Inspector
    private int activeCharacterIndex = 0;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        
        // Activate the first character and deactivate the others
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == activeCharacterIndex);
        }
    }

    public void OnCharacterSelect(InputValue value)
    {
        // Get the input as a float value (e.g., 1, 2, 3)
        int selectedCharacter = Mathf.RoundToInt(value.Get<float>());

        // Switch characters
        SwitchCharacter(selectedCharacter - 1); // Subtract 1 to match the array index
    }

    private void SwitchCharacter(int newIndex)
    {
        if (newIndex >= 0 && newIndex < characters.Length)
        {
            // Deactivate the current character
            characters[activeCharacterIndex].SetActive(false);

            // Activate the selected character
            activeCharacterIndex = newIndex;
            characters[activeCharacterIndex].SetActive(true);
            
            // Update the player controller with the new character
            playerController.animator = characters[activeCharacterIndex].GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("Invalid character index: " + newIndex);
        }
    }
}