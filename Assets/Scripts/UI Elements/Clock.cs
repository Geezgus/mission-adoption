using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] float timePerDayInGame = 10f;
    [SerializeField] TimeMeasurement timeMeasurement = TimeMeasurement.Minutes;
    
    float timeOfDayInSeconds = 0;
    
    enum TimeMeasurement {Hours, Minutes, Seconds};

    void Update()
    {
        timeOfDayInSeconds = getTimeOfDayInSeconds();
        float rotationDegreesPerDay = 360f;
        const int CLOCKWISE = -1;

        transform.eulerAngles = new Vector3(0, 0, CLOCKWISE * timeOfDayInSeconds * rotationDegreesPerDay);
    }
    
    float getTimeOfDayInSeconds()
    {
        return timeMeasurement switch
        {
            TimeMeasurement.Hours => (timeOfDayInSeconds + Time.deltaTime / (timePerDayInGame * 3600)) % 1,
            TimeMeasurement.Minutes => (timeOfDayInSeconds + Time.deltaTime / (timePerDayInGame * 60)) % 1,
            _ => (timeOfDayInSeconds + Time.deltaTime / timePerDayInGame) % 1,
        };
    }
}