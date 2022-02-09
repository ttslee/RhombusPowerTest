using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        GameManager.instance.LoadGame();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
