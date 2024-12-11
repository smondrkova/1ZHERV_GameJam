using UnityEngine;

public class SwitchingZone : MonoBehaviour
{
    public CharacterManager characterManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            characterManager.AllowCharacterSwitching(true);
            Debug.Log("Player entered switching zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            characterManager.AllowCharacterSwitching(false);
            Debug.Log("Player exited switching zone.");
        }
    }
}