using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapBuilder : MonoBehaviour
{
    public Texture2D texture;
    public static MapBuilder instance;

    public GameObject SightingLocation;
    public float latitudeOffset;
    public float longitudeOffset;
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
        FillSightingInfo();
        SpawnSightingLocations();
    }

    public void FillSightingInfo()
    {
        sightingInfo = JsonHelper.FromJson<SightingInfo>(jsonFile.text);
        GetMinLonAndLat();
        GetMaxLonAndLat();
    }

    private void GetMinLonAndLat()
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

    private void GetMaxLonAndLat()
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
    private Vector3 worldSize = new Vector3(2000f, 0.0f, 1000f);
    private void SpawnSightingLocations()
    {
        // float latDiff = Math.Abs(maxLat - minLat);
        // float lonDiff = Math.Abs(maxLon - minLon);
        foreach(SightingInfo s in sightingInfo)
        {
            // float longitudeProportion = (s.Longitude - minLon)/lonDiff;
            // float latitudeProportion = (s.Latitude - minLat)/latDiff;
            // Debug.Log(longitudeProportion);
            // Debug.Log(latitudeProportion);
            // Vector3 spawnLocation = new Vector3(latitudeOffset * latitudeProportion, 0.0f, longitudeOffset*longitudeProportion);
            // Debug.Log(spawnLocation);
            Vector3 v3Point = s.ToVector3();
            Vector3 worldPos = Vector3.zero + Vector3.Scale(v3Point,worldSize*0.5f);
            Debug.Log(worldPos);
            GameObject sitingLocation = Instantiate(SightingLocation,worldPos,Quaternion.identity);
            sitingLocation.gameObject.name = s.City;
            sitingLocation.GetComponentInChildren<SightingProperties>().SetSightingInfo(s);
        }
    }
}
