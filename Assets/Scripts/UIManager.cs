using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public GameObject startMenu;
    
    [Header("Slides")]
    public GameObject[] slides;
    private int currentSlideIndex = 0;
    
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
        
    }
    
    public void ShowTutorial()
    {
        startMenu.SetActive(false);
        ShowSlide(0);
    }
    
    public void ShowNextSlide()
    {
        if (currentSlideIndex < slides.Length - 1)
        {
            HideSlide(currentSlideIndex);
            currentSlideIndex++;
            ShowSlide(currentSlideIndex);
        }
    }
    
    public void ShowPreviousSlide()
    {
        if (currentSlideIndex > 0)
        {
            HideSlide(currentSlideIndex);
            currentSlideIndex--;
            ShowSlide(currentSlideIndex);
        }
    }
    
    private void ShowSlide(int index)
    {
        slides[index].SetActive(true);

        if (index == 1)
        {
            PresentManager.Instance.SetPresentCountText(10);
        } else if (index == 2)
        {
            PresentManager.Instance.SetPresentCountText(0);
        }
    }
    
    private void HideSlide(int index)
    {
        slides[index].SetActive(false);
    }
    
    public void StartGame()
    {
        PresentManager.Instance.SetPresentCountText(10);
        slides[currentSlideIndex].SetActive(false);
        GameManager.Instance.StartGame();
    }
}
