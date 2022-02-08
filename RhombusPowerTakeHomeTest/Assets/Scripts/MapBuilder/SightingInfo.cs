using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// "Date": "06/01/1950",
// "Time": "16:00:00",
// "City": "Philadelphia",
// "State": "MS",
// "Country": "US",
// "Shape": "Disk",
// "Duration": 600,
// "Latitude": 32.7714,
// "Longitude": -89.1167

[Serializable]
public class SightingInfo
{
    public string Date;
    public string Time;
    public string City;
    public string State;
    public string Country;
    public string Shape;
    public int Duration;
    public float Latitude;
    public float Longitude;

    public override string ToString () => this.State;

    public Vector2 ToVector2 () 
        => new Vector2( (float) Math.Sin( this.Longitude * Deg2Rad * 0.5 ) , (float) Math.Sin( this.Latitude * Deg2Rad ) );

    public Vector3 ToVector3 ( float elevation = 0 ) 
        => new Vector3( (float) Math.Sin( this.Longitude * Deg2Rad * 0.5 ) , elevation , (float) Math.Sin( this.Latitude * Deg2Rad ) );

    public Vector3 ToVector3UnitSphere () 
        => Quaternion.Euler(0,-(float)this.Longitude,0) * ( Quaternion.Euler(-(float)this.Latitude,0,0) * Vector3.forward );
    const double Deg2Rad = Mathf.PI / 180.0;
}
