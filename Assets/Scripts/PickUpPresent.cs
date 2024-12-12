using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpPresent : MonoBehaviour
{
    private GameObject pickedUpPresentPrefab;
    public bool isEnabled = false;

    public void Start()
    {
        isEnabled = false;
    }

    public void OnPickUp(InputValue value)
    {
        if (!isEnabled) return;
        if (pickedUpPresentPrefab == null)
        {
            TryPickUp();
        }
    }
    
    private void TryPickUp()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Present"))
            {
                Debug.Log("Present picked up!");
                pickedUpPresentPrefab = hit.gameObject;
                Destroy(hit.gameObject);
                
                string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                PresentManager.Instance.RemovePresent(sceneName, hit.transform.position);
                PresentManager.Instance.PickUpPresentUI();
                return;
            }
        }
        
        Debug.Log("No present found to pick up.");
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f); // Pick-up range
    }

}
