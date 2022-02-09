using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UFOCollision : MonoBehaviour
{
    private bool collidedWithPlayer = false;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag != "Player")return;
        if(!collidedWithPlayer)
            GameUI.instance.spottedCount.text = (Int32.Parse(GameUI.instance.spottedCount.text) + 1).ToString();
        collidedWithPlayer=true;
    }
}
