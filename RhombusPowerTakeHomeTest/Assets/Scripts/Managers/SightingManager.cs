using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class SightingManager : MonoBehaviour
{
    private int[] monthDayAmounts = {0, 31,28,31,30,31,30,31,31,30,31,30,31};
    public static SightingManager instance;
    public GameObject sightingLocations;
    public TMP_Text time;
    public TMP_Text date;
    private int index = 0;
    private SightingProperties[] locations;
    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start() {
        locations = sightingLocations.gameObject.GetComponentsInChildren<SightingProperties>();
    }
    public IEnumerator ClockAndGameUpdater()
    {
        while(GameUI.instance.menuOpen || GameUI.instance.visualizationOpen)
                yield return null;
        SightingInfo[] sightingInfo = MapBuilder.instance.sightingInfo;
        while(index < sightingInfo.Length)
        {
            string[] t = time.text.Split(':');
            int hour = Int32.Parse(t[0]);
            
            while(hour == sightingInfo[index].GetHour() && date.text.Equals(sightingInfo[index].Date))
            {
                locations[index].gameObject.GetComponent<Animator>().SetTrigger("UFOAnimation");
                index++;
            }
            if(hour == 24)
            {
                string[] d = date.text.Split('/');
                int monthIndex = Int32.Parse(d[1]);
                int day = Int32.Parse(d[0]);
                if(day == monthDayAmounts[monthIndex])
                {
                    if(monthIndex == 12)
                    {
                        int yr = Int32.Parse(d[3]);
                        yr++;
                        d[2] = yr.ToString();
                        date.text = "01/01/" + d[2];
                    }
                    else
                        date.text = "01/" + ((monthIndex+1>9) ? (monthIndex+1).ToString():("0"+(monthIndex+1).ToString())) + "/"+ d[2];
                }
                else
                {
                    date.text = ((++day>9)?(day).ToString():"0"+day.ToString()) + "/" + d[1] + "/" + d[2];
                }
                time.text = "00:00:00";
            }
            else
            {
                time.text = ((++hour>9) ? (hour.ToString()) : ("0" + hour.ToString())) + ":00:00";
            }
            yield return new WaitForSecondsRealtime(.01f);
        }
        
    }
    private void UpdateIndex(int year)
    {
        for (int i = 0; i < locations.Length; i++)
        {
            if(locations[i].sightingInfo.GetYear() == year)
            {
                index = i;
                break;
            }
        }
        Debug.Log(index);
        Debug.Log(locations[index].sightingInfo.City);
    }
    public void JumpForward()
    {
        string[] d = date.text.Split('/');
        if(d[2].Equals("1999"))
            return;
        UpdateIndex(Int32.Parse(d[2])+1);
        time.text = "00:00:00";
        date.text = "01/01/" + (Int32.Parse(d[2])+1).ToString();
    }

    public void JumpBack()
    {
        string[] d = date.text.Split('/');
        if(d[2].Equals("1950"))
        {
            date.text = "01/01/" + (Int32.Parse(d[2])).ToString();
            index = 0;
            return;
        }
        UpdateIndex(Int32.Parse(d[2])-1);
        time.text = "00:00:00";
        date.text = "01/01/" + (Int32.Parse(d[2])-1).ToString();
    }
}
