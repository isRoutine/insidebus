using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField] private MainScript _main;
    public float TimerValue;
    private Text _timeText;
    public float Seconds, Minutes;

    public float GetTimerValue()
    {
        return this.TimerValue;
    }

    public void SetTimerValue(float value)
    {
        this.TimerValue = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        this._timeText = GetComponent<Text>() as Text;

    }

    // Update is called once per frame
    void Update()
    {

        if (this.TimerValue > 0) {
            this.TimerValue -= Time.deltaTime;
        }
        else {
            this.TimerValue = 0;
        }

        this.Minutes = (int)(this.TimerValue / 60f);
        this.Seconds = (int)(this.TimerValue % 60f);
        this._timeText.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);

    }

}
