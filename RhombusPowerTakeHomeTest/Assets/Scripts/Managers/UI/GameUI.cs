using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    
    public TMP_Text spottedCount;

    public bool menuOpen{get;set;}
    public bool visualizationOpen{get;set;}
    public GameObject pauseMenu;
    public GameObject visualizationScreen;
    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        menuOpen = false;
        visualizationOpen = false;
    }
    public void OpenPauseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        menuOpen = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuOpen = false;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Open2DVisualization()
    {
        pauseMenu.gameObject.SetActive(false);
        visualizationScreen.gameObject.SetActive(true);
        menuOpen = false;
        visualizationOpen = true;
    }

    public void OpenPauseMenuFromVisualization()
    {
        menuOpen = true;
        pauseMenu.gameObject.SetActive(true);
        visualizationScreen.gameObject.SetActive(false);
        visualizationOpen = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
