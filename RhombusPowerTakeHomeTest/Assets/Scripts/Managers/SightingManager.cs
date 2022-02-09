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

    private void Start() 
    {
        StartCoroutine(ClockAndGameUpdater());
    }

    private IEnumerator ClockAndGameUpdater()
    {
        SightingInfo[] sightingInfo = MapBuilder.instance.sightingInfo;
        while(index < sightingInfo.Length)
        {
            while(GameUI.instance.menuOpen)
                yield return null;
            string[] t = time.text.Split(':');
            int hour = Int32.Parse(t[0]);
            
            if(hour == sightingInfo[index].GetHour() && date.text == sightingInfo[index].Date)
            {
                sightingLocations.gameObject.transform.GetChild(index).gameObject.GetComponent<Animator>().SetTrigger("UFOAnimation");
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
                    }
                    date.text = "01/" + ((monthIndex>9) ? monthIndex.ToString():("0"+monthIndex.ToString())) + d[2];
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
            yield return new WaitForSecondsRealtime(.1f);
        }
        
    }
}
