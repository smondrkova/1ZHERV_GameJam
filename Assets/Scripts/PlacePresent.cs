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
    
    public void OnPlace()
    {
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
        Debug.Log("Present placed!");
    }

    public void OnDestroy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(placementPoint.position, 0.5f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Present"))
            {
                Destroy(hit.gameObject);
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
