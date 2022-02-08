using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    [SerializeField] Text timerDisplay;
    private void Update()
    {
        timer += Time.deltaTime;

        TimeSpan timeSpan = new TimeSpan(0, 0, (int)timer);


        timerDisplay.text = timeSpan.Minutes + ":" + timeSpan.Seconds;
    }
}
