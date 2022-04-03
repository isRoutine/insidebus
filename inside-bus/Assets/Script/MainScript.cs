using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
     
    [SerializeField] private TimeScript timer;
    [SerializeField] private TimeScript timerShadow;
    [SerializeField] private AnswerScript answer;
    [SerializeField] public Spawner _spawner;
    [SerializeField] private Text lives;
    [SerializeField] private Text livesBis;
    [SerializeField] private GameObject GameOverUI;
    
    private float delay = 0;
    private bool flag = false;
    private int rispostaEsatta;
    private int score;

    private static System.Random random = new System.Random();
    public double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public int getRispostaEsatta()
    {
        return rispostaEsatta;
    }

    public Text getLives()
    {
        return lives;
    }

    public Text getLivesBis()
    {
        return livesBis;
    }

    public TimeScript getTimer()
    {
        return this.timer;
    }

    public GameObject getGameOverUI()
    {
        return this.GameOverUI;
    }       
    

    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        // float tempo = (float)GetRandomNumber(5, 30);
        // timer.timerValue = tempo;
        // timerShadow.timerValue = tempo;
        // rispostaEsatta = 120;

        _spawner.Spawn(5,1);
    }


    // Update is called once per frame
    void Update()
    {



    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // if (delay > 3 && (flag == false)) {
        //     flag = true;
        //     _spawner.Spawn(5,1);   

        // }

        //Debug.Log(delay);
        // delay += Time.fixedDeltaTime;


        // int vite = Convert.ToInt32(this.lives);
        // if (answer.rispostaInviata && (vite != 0))
        // {
        //     int diff = Math.Abs(this.rispostaEsatta - Convert.ToInt32(answer.getAnswerText()));
        //     if (diff > 0)
        //         score = score + (200 * diff);
        //     else
        //         score = score + (200 * this.rispostaEsatta);
            
        //     Debug.Log("Score" + score.ToString());
        //     answer.rispostaInviata = false;
        // }

    }

}
