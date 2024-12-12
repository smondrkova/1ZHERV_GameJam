using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FollowerDialogue : MonoBehaviour
{
    public static FollowerDialogue Instance;

    public GameObject follower;
    
    [Header("UI Elements")]
    public GameObject dialogueBubble;
    public Text dialogueText;
    
    [Header("Dialogue Settings")]
    public float displayDuration = 3f;
    public float typingSpeed = 0.05f;
    
    private Coroutine dialogueCoroutine;
    private bool isPlayingDialogue = false;
    
    [Header("Dialogue Sequences")]
    [TextArea] public string[] firstDialogueLines = 
    {
        "Ah, the joy of Christmas... a time when the world feels just a little brighter.",
        "The gifts, the lights, the laughter—it's all magic, isn't it?",
        "But you know, the real magic isn't in the presents we give or receive.",
        "It's in the thought, the love, and the memories we create together.",
        "Each gift carries a piece of ourselves, wrapped in tradition and tied with a ribbon of care.",
        "When I was young, my grandmother told me the same stories I'm sharing with you now.",
        "She taught me that Christmas isn't just a holiday; it's a connection between the past, present, and future.",
        "We give gifts because it's our way of showing we care, just as those before us did.",
        "You, too, are part of this beautiful cycle—passing on these traditions, creating joy for those around you.",
        "Remember, a gift doesn't have to be big or fancy. The best ones come from the heart.",
        "And the best gift of all? Keeping the spirit of Christmas alive in our hearts."
    };
    
    [TextArea] public string[] secondDialogueLines = 
    {
        "I remember when you were just a little child...",
        "Back then, Christmas wasn't about the gifts or the decorations.",
        "It was about the wonder—the sparkle in your eyes when the lights came on.",
        "Do you remember sitting by the fireplace, waiting for Santa?",
        "The stories, the laughter, the warmth of being together... that was the true magic.",
        "Even the smallest things felt so big—like the sound of bells in the distance.",
        "The smell of gingerbread baking, the rustle of wrapping paper... simple joys, weren't they?",
        "You used to run around in excitement, trying to peek at the presents under the tree.",
        "But it was never really about the presents—it was the mystery, the anticipation.",
        "That magic doesn’t fade with time. It stays with us, in every smile, in every hug.",
        "And now, it’s your turn to share that magic, to pass it on to those who come after you."
    };
    
    
    // private void Start()
    // {
    //     dialogueBubble.SetActive(false);
    // }

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
        
        dialogueBubble.SetActive(false);
    }

    public void Speak(string message)
    {
        if (dialogueBubble == null || dialogueText == null)
        {
            Debug.LogError("Dialogue bubble or text not assigned in the inspector");
            return;
        }
        
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }
        
        dialogueCoroutine = StartCoroutine(DisplayDialogue(message));
    }
    
    public void StartDialogue(string[] dialogueLines, System.Action onComplete = null)
    {
        if (isPlayingDialogue) return;
        
        isPlayingDialogue = true;
        StartCoroutine(PlayDialogueSequence(dialogueLines, onComplete));
    }

    
    private IEnumerator DisplayDialogue(string message)
    {
        dialogueText.text = "";
        dialogueBubble.SetActive(true);
        
        foreach (char letter in message)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(displayDuration);
        dialogueBubble.SetActive(false);
    }
    
    private IEnumerator PlayDialogueSequence(string[] dialogueLines, System.Action onComplete)
    {
        foreach (string line in dialogueLines)
        {
            yield return DisplayDialogue(line);
            yield return new WaitForSeconds(displayDuration);
        }
        
        isPlayingDialogue = false;
        
        onComplete?.Invoke();
    }
    
    private void LateUpdate()
    {
        if (dialogueBubble != null)
        {
            Vector3 bubblePosition = follower.transform.position + new Vector3(0, 1.5f, 0); 
            dialogueBubble.transform.position = bubblePosition;
        }
    }
    
}
