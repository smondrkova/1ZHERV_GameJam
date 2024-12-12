using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacePresent : MonoBehaviour
{
    [Header("Placement Settings")]
    public GameObject presentPrefab; // Prefab of the present to place
    public Transform placementPoint;
    public LayerMask placementLayerMask; // Layer mask to filter placement positions
    
    public bool isEnabled = true;
    
    public void OnPlace()
    {
        if (!isEnabled) return;
        Place();
    }

    private void Place()
    {
        if (PresentManager.Instance.remainingPresentsToPlace == 0)
        {
            Debug.Log("No presents left to place.");
            return;
        }
        
        Debug.Log("Placing present...");
        
        if (presentPrefab == null)
        {
            Debug.LogWarning("No present prefab assigned to PlacePresent script.");
            return;
        }
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(placementPoint.position, 0.5f, placementLayerMask);
        if (hits.Length > 0)
        {
            Debug.Log("Cannot place present here, something is in the way.");
            return;
        }

        GameObject newPresent = Instantiate(presentPrefab, placementPoint.position, Quaternion.identity);
        
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PresentManager.Instance.SavePresent(sceneName, newPresent.transform.position, newPresent.transform.rotation, presentPrefab.name);
        PresentManager.Instance.PlacePresentUI();
        
        Debug.Log("Present placed!");
    }

    public void OnDestroy()
    {
        if (!isEnabled) return;
        Destroy();
    }

    private void Destroy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(placementPoint.position, 0.5f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Present"))
            {
                Destroy(hit.gameObject);
                
                string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                PresentManager.Instance.RemovePresent(sceneName, hit.transform.position);
                PresentManager.Instance.DestroyedPresentUI();
                return;
            }
        }
        
        Debug.Log("No present found to destroy.");
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(placementPoint.position, 0.5f); // Placement range
    }

}
