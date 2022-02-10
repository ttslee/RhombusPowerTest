using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 turn;

    public float speed = 5;
    private IEnumerator gameUpdater;
    
    // Update is called once per frame
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;   
        gameUpdater = SightingManager.instance.ClockAndGameUpdater();
        StartCoroutine(gameUpdater);
        
    }
    void Update()
    {
        
        if(!GameUI.instance.menuOpen && !GameUI.instance.visualizationOpen){
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
            }

            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0f);

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {   
                StopCoroutine(gameUpdater);
                SightingManager.instance.JumpForward();
                StartCoroutine(gameUpdater);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                StopCoroutine(gameUpdater);
                SightingManager.instance.JumpBack();
                StartCoroutine(gameUpdater);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!GameUI.instance.menuOpen)
                if(!GameUI.instance.visualizationOpen)
                    GameUI.instance.OpenPauseMenu();
                else
                    GameUI.instance.OpenPauseMenuFromVisualization();
            else
                GameUI.instance.ResumeGame();
        }

    }
}
