using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float timerValue = 90f;
    public Text timeText;
    public float seconds, minutes;


    public float TimerValue {
        get { return timerValue; }
        set { timerValue = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>() as Text;

    }

    // Update is called once per frame
    void Update()
    {

        if (timerValue > 0) {
            timerValue -= Time.deltaTime;
        }
        else {
            timerValue = 0;
        }

        minutes = (int)(timerValue / 60f);
        seconds = (int)(timerValue % 60f);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}
