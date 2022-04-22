using System.Collections;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{

    [SerializeField] private GameObject _time;
    [SerializeField] private GameObject _timeText;
    public int _seconds, _minutes;

    public int GetTimerValue()
    {
        return _seconds + (_minutes * 60);
    }

    public void SetTimerValue(int minutes, int seconds)
    {
        _seconds = seconds;
        _minutes = minutes;

    }


    // attiva e disattiva timer scritte 
    public void EnableTimer()
    {
        _timeText.SetActive(true);
        _time.SetActive(true);
    }

    public void DisableTimer()
    {
        _timeText.SetActive(false);
        _time.SetActive(false);
    }


    public IEnumerator TimerTask()
    {

        EnableTimer();
        while (true)
        {
            _time.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", _minutes, _seconds++);
            if (_seconds == 60)
            {
                _minutes++;
                _seconds = 0;
            }

            yield return new WaitForSeconds(1.0f);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* if (this.TimerValue > 0) {
            this.TimerValue -= Time.deltaTime;
        }
        else {
            this.TimerValue = 0;
        }

        this.Minutes = (int)(this.TimerValue / 60f);
        this.Seconds = (int)(this.TimerValue % 60f);
        this._timeText.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds); */

    }

}