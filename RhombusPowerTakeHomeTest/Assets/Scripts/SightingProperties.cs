using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightingProperties : MonoBehaviour
{
    [SerializeField]
    private SightingInfo sightingInfo;

    public void SetSightingInfo(SightingInfo s)
    {
        sightingInfo = s;
    }
}
