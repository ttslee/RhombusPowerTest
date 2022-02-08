using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapBuilder : MonoBehaviour
{
    public GameObject SitingLocation;
    public float latitudeOffset;
    public float longitudeOffset;
    public static MapBuilder instance;
    public TextAsset jsonFile;
    public SightingInfo[] sightingInfo;

    [SerializeField]
    private float minLat;
    [SerializeField]
    private float minLon;
    [SerializeField]
    private float maxLat;
    [SerializeField]
    private float maxLon;

    public MapBuilder getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        fillSightingInfo();
    }

    public void fillSightingInfo()
    {
        sightingInfo = JsonHelper.FromJson<SightingInfo>(jsonFile.text);
        getMinLonAndLat();
        getMaxLonAndLat();
    }

    private void getMinLonAndLat()
    {
        float minLat = float.MaxValue;
        float minLon = float.MaxValue;
        foreach(SightingInfo s in sightingInfo)
        {
            if(s.Longitude < minLon)
                minLon = s.Longitude;
            if(s.Latitude < minLat)
                minLat = s.Latitude;
        }
        this.minLat = minLat;
        this.minLon = minLon;
    }

    private void getMaxLonAndLat()
    {
        float maxLat = float.MinValue;
        float maxLon = float.MinValue;
        foreach(SightingInfo s in sightingInfo)
        {
            if(s.Longitude > minLon)
                maxLat = s.Longitude;
            if(s.Latitude > minLat)
                maxLon = s.Latitude;
        }
        this.maxLat = maxLat;
        this.maxLon = maxLon;
    }
}
