using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public Transform thisPosition;

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("COLLIDED");
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = destination.position;
            other.transform.rotation = destination.rotation;
        }
    }
}
