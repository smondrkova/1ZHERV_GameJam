using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionBubbleController : MonoBehaviour
{
    [Header("Settings")]
    public float interactionRange = 1.5f; 
    public GameObject interactionBubblePrefab; 
    private InteractionBubble interactionBubbleScript;

    private GameObject interactionBubbleInstance;
    private Transform player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        interactionBubbleInstance = Instantiate(interactionBubblePrefab, transform.position, Quaternion.identity);
        interactionBubbleInstance.SetActive(false);
        
        interactionBubbleScript = interactionBubbleInstance.GetComponent<InteractionBubble>();
    }

    private void Update()
    {
        player = Player.PlayerController.Instance.transform;
        
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactionRange)
            {
                interactionBubbleInstance.SetActive(true);
                interactionBubbleInstance.transform.position = transform.position + Vector3.up * 0.6f; // Adjust offset

                if (Player.PlayerController.Instance.currentCharacter.gameObject.name == "Adult")
                {
                    interactionBubbleScript.SetText("[Q] Destroy");
                }
                else if (Player.PlayerController.Instance.currentCharacter.gameObject.name == "Kid")
                {
                    interactionBubbleScript.SetText("[E] Pick Up");
                }
                else
                {
                    interactionBubbleInstance.SetActive(false);
                }
            }
            else
            {
                interactionBubbleInstance.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        if (interactionBubbleInstance != null)
        {
            Destroy(interactionBubbleInstance);
        }
    }
}
