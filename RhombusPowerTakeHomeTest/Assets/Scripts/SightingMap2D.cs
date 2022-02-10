using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
// +1000x, -150z (y-value) 1000,400
public class SightingMap2D : MonoBehaviour
{
    private const int xOffset = 1000;
    private const int zOffset = -150;

    public GameObject sightingLocations;
    private Dictionary<int, Tuple<int,int>> yearPartitions;
    private SightingInfo[] sightingInfo;
    private Texture2D ufoMap;
    public Image image;
    public Slider slider;
    public TMP_Text yearText;
    
    // Start is called before the first frame update
    void Start()
    {
        sightingInfo = MapBuilder.instance.sightingInfo;
        FillYearPartitions();
        CreateTexture2D();
    }

    private void Update() 
    {   
        UpdatePixels((int)slider.value);
        yearText.text = slider.value.ToString();
    }
    private bool visited = false;
    private void UpdatePixels(int value)
    {
        for(int i = 0; i < sightingInfo.Length; i++)
        {
            if(sightingInfo[i].GetYear() == value)
            {
                if(value == 1965 && !visited)
                {
                    Debug.Log("1965");
                    Debug.Log("x"+(int)(sightingLocations.gameObject.transform.GetChild(i).position.x+xOffset));
                    Debug.Log("y"+(int)(sightingLocations.gameObject.transform.GetChild(i).position.z+zOffset));
                }
                ufoMap.SetPixel((int)(sightingLocations.gameObject.transform.GetChild(i).position.x+xOffset),(int)(sightingLocations.gameObject.transform.GetChild(i).position.z+zOffset),Color.red);
            }
                
            else
                ufoMap.SetPixel((int)(sightingLocations.gameObject.transform.GetChild(i).position.x+xOffset),(int)(sightingLocations.gameObject.transform.GetChild(i).position.z+zOffset),Color.green);
        }
        if(value == 1965) visited = true;
        ufoMap.Apply();
        image.material.mainTexture = ufoMap;
    }
    private void FillYearPartitions()
    {
        yearPartitions = new Dictionary<int, Tuple<int, int>>();
        int i = 0;
        while(i < sightingInfo.Length-1)
        {
            int startIndex = i;
            int currentYear = sightingInfo[i].GetYear();
            while(i < sightingInfo.Length-1 && sightingInfo[i].GetYear() == currentYear)
                i++;
            yearPartitions.Add(currentYear, new Tuple<int, int>(startIndex, i));
            Debug.Log("NeverEnding");
        }
    }
    private void CreateTexture2D()
    {
        ufoMap = new Texture2D(450,325);
        for(int i = 0; i < sightingInfo.Length; i++)
        {
            ufoMap.SetPixel((int)(sightingLocations.gameObject.transform.GetChild(i).position.x+xOffset),(int)(sightingLocations.gameObject.transform.GetChild(i).position.z+zOffset),Color.green);
        }
                
        for (int x = 0; x < ufoMap.width; x++)
        {
            for (int y = 0; y < ufoMap.height; y++)
            {
                if(ufoMap.GetPixel(x,y) != Color.green)
                    ufoMap.SetPixel(x,y, Color.black);
            }
        }
        ufoMap.Apply();
        image.material.mainTexture = ufoMap;

    }
}
