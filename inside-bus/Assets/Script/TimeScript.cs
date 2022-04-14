using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _time;
    public float Seconds, Minutes;

    // public int GetTimerValue()
    // {

    //     //return _time.text;

    //     // int seconds
    // }

    // public void SetTimerValue(int minutes, int seconds)
    // {

    //     //_time.text = ;
    // }


    // attiva e disattiva timer scritte 
    // ()


    

    // public IEnumerator Timer(){
        
    //     while(true){

    //         yield return new WaitForSeconds(1.0f);  
    //     }

    // }


    // Start is called before the first frame update
    void Start()
    {

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
