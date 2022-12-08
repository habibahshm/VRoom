using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class time : MonoBehaviour
{
    public GameObject secondHandle;
    public GameObject minHandle;
    public GameObject hrHandle;
    int oldSeconds;

    void Update()
    {
        DateTime currentTime = DateTime.Now;
        
        int second = currentTime.Second;
        if(second != oldSeconds)
        {
            UpdateTime(currentTime);
        }

        oldSeconds = second;
        
       
    }

    void UpdateTime(DateTime currentTime)
    {
        int hour = currentTime.Hour;
        int minute = currentTime.Minute;
        int second = currentTime.Second;


        secondHandle.transform.localRotation = Quaternion.Euler(second * 6, 0, 0);
        minHandle.transform.localRotation = Quaternion.Euler(minute * 6, 0, 0);
        hrHandle.transform.localRotation = Quaternion.Euler(hour * 30, 0, 0);

    }
}
