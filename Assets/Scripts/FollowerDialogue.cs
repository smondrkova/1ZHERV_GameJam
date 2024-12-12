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
    
    private Coroutine dialogueCoroutine;
    
    private void Start()
    {
        dialogueBubble.SetActive(false);
    }

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
    
    private IEnumerator DisplayDialogue(string message)
    {
        dialogueText.text = "";
        dialogueBubble.SetActive(true);
        
        foreach (char letter in message)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust typing speed
        }
        
        yield return new WaitForSeconds(displayDuration);
        dialogueBubble.SetActive(false);
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
