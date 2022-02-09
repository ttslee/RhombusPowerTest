using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    public bool menuOpen{get;set;}
    public GameObject pauseMenu;
    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        menuOpen = false;
    }
    public void OpenPauseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        GameUI.instance.menuOpen = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameUI.instance.menuOpen = false;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
