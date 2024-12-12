using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private FollowerDialogue followerDialogue;
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
        followerDialogue = FollowerDialogue.Instance;
        //StartFirstDialogue();
    }

    public void StartFirstDialogue()
    {
        Debug.Log("Starting first dialogue...");
        followerDialogue.StartDialogue(followerDialogue.firstDialogueLines, OnFirstDialogueComplete);
    }
    
    private void OnFirstDialogueComplete()
    {
        Debug.Log("First dialogue complete!");
        followerDialogue.StartDialogue(followerDialogue.secondDialogueLines, OnSecondDialogueComplete);
        Player.PlayerController.Instance.SwitchCharacter(1);
        PresentManager.Instance.ResetPresentUI();
    }
    
    private void OnSecondDialogueComplete()
    {
        Debug.Log("Second dialogue complete!");
        followerDialogue.StartDialogue(followerDialogue.finalDialogueLines, OnLastDialogueComplete);
    }
    
    private void OnLastDialogueComplete()
    {
        Debug.Log("Last dialogue complete!");
        UIManager.Instance.ShowExitButton();
    }
    
}
