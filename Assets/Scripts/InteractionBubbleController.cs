using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionBubbleController : MonoBehaviour
{
    [Header("Settings")]
    public float interactionRange = 1.5f; // Distance to trigger the bubble
    public GameObject interactionBubblePrefab; // Reference to the bubble prefab
    private InteractionBubble interactionBubbleScript;

    private GameObject interactionBubbleInstance;
    private Transform player; // Player's transform

    private void Start()
    {
        // Locate the player in the scene (ensure the player has the tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Instantiate the bubble but hide it initially
        interactionBubbleInstance = Instantiate(interactionBubblePrefab, transform.position, Quaternion.identity);
        interactionBubbleInstance.SetActive(false);
        
        interactionBubbleScript = interactionBubbleInstance.GetComponent<InteractionBubble>();
    }

    private void Update()
    {
        player = Player.PlayerController.Instance.transform;
        
        if (player != null)
        {
            // Calculate the distance between the player and the present
            float distance = Vector3.Distance(player.position, transform.position);
            Debug.Log("Distance:" + distance);
            Debug.Log("Interaction Range:" + interactionRange);
            if (distance <= interactionRange)
            {
                Debug.Log("In range");
                // Show the bubble and update its position above the present
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
                // Hide the bubble when out of range
                interactionBubbleInstance.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        // Cleanup when the present is destroyed
        if (interactionBubbleInstance != null)
        {
            Destroy(interactionBubbleInstance);
        }
    }
}
