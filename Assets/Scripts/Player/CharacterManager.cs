using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }
    
    [Header("Characters")]
    public GameObject pickUpCharacter;
    public GameObject placeCharacter;
    
    private GameObject activeCharacter;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        activeCharacter = placeCharacter;
    }
    
    public void SwitchCharacter(GameObject newCharacter)
    {
        activeCharacter = newCharacter;
    }
    
    public GameObject GetActiveCharacter()
    {
        return activeCharacter;
    }
    
    public void SwitchToPickUpCharacter()
    {
        activeCharacter = pickUpCharacter;
        Debug.Log("Switched to Pick-Up Character");
    }

    public void SwitchToPlaceCharacter()
    {
        activeCharacter = placeCharacter;
        Debug.Log("Switched to Place Character");
    }

}
