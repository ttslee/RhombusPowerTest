using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightingManager : MonoBehaviour
{
    public static SightingManager instance;

    private void Awake() {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start() 
    {
        SplitSightingData();
        
    }
    private void SplitSightingData()
    {
        foreach (var sightingLoc in MapBuilder.instance.sightingInfo)
        {
            sightingLoc.SplitDateAndTime();
        }
    }
}
