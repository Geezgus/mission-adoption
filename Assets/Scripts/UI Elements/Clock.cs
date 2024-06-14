using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public int Days {get; private set;}
    public int Hours {get; private set;}
    public int Minutes {get; private set;}
    public int Seconds {get; private set;}

    [SerializeField, Range(0.0000001f, 0.00695f)] float speedupFactor =  0.00695f;

    void Update()
    {
        float time = (Time.time / speedupFactor);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        float rotationDegreesPerDay = 360f;
        const int CLOCKWISE = -1;

        Days = timeSpan.Days + 3;
        Hours = timeSpan.Hours;
        Minutes = timeSpan.Minutes;
        Seconds = timeSpan.Seconds;

        transform.eulerAngles = new Vector3(0, 0, 180 + CLOCKWISE * (time/HoursToSeconds(24)) * rotationDegreesPerDay);
    }


    public float MinutesToHours(float m)
    {
        return 60 * m;
    }

    public float SecondsToHours(float s)
    {
        return s / 3600f;
    }

    public float HoursToMinutes(float h)
    {
        return 60 * h;
    }

    public float SecondsToMinutes(float s)
    {
        return s / 60f;
    }

    public float HoursToSeconds(float h)
    {
        return 3600 * h;
    }

    public float MinutesToSeconds(float m)
    {
        return 60 * m;
    }
}