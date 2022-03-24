using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public TimeScript timer;
    public TimeScript timerShadow;
    public AnswerScript answer;
    public CharacterScript character;
    //public BusScript bus;
    public Text lives;
    public Text livesBis;
    public GameObject GameOverUI;
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
        
    // Start is called before the first frame update
    void Start()
    {
        float tempo = (float)GetRandomNumber(0, 10);
        timer.timerValue = tempo;
        timerShadow.timerValue = tempo;
        rispostaEsatta = 120;
    }

    // Update is called once per frame
    void Update()
    {



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (delay > 3 && (flag == false)) {
            flag = true;
            character.Spawn("model1", 5, 1f);
            //bus.Spawn("model1", 1, 1f);
            Debug.Log("inviato " + delay);
        }

        //Debug.Log(delay);
        delay += Time.fixedDeltaTime;


        int vite = Convert.ToInt32(this.lives);
        if (answer.rispostaInviata && (vite != 0))
        {
            int diff = Math.Abs(this.rispostaEsatta - Convert.ToInt32(answer.answerText));
            if (diff > 0)
                score = score + (200 * diff);
            else
                score = score + (200 * this.rispostaEsatta);
            
            Debug.Log("Score" + score.ToString());
            answer.rispostaInviata = false;
        }

    }

}
