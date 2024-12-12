using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBubble : MonoBehaviour
{
    public Transform target;
    public Text bubbleText;

    private void Awake()
    {
        bubbleText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position + Vector3.up * 1.5f;
        }
    }
    
    public void SetText(string text)
    {
        bubbleText.text = text;
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
