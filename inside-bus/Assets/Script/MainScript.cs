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

    [SerializeField] private GameObject _bus;
    private GameObject _bus2;
    private int rispostaEsatta;
    private int score;
    private bool _gameStarted;

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
    

    // delay for every start of new game
    private WaitForSeconds _delay = new WaitForSeconds(3.0f);

    private IEnumerator StepUpdate(){
        yield return _delay;
        BusHandler script = _bus2.GetComponent<BusHandler>() as BusHandler;
        script.BusInit();
        yield return StartCoroutine(script.BusStart());
        _spawner.Spawn(5, Spawner.MALE_TO_IN);
        //_spawner.Spawn(3, Spawner.MALE_TO_OUT);
        yield return StartCoroutine(_spawner.MoveAll());
        while(_spawner.VisibleObject() > 0){
            print(_spawner.VisibleObject());
            yield return null;
        }
        print("tutti morti...");
        yield return StartCoroutine(script.BusEnd());
        _gameStarted = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        // float tempo = (float)GetRandomNumber(5, 30);
        // timer.timerValue = tempo;
        // timerShadow.timerValue = tempo;
        // rispostaEsatta = 120;
        _bus2 = Instantiate(_bus, BusHandler.BUS_ENTRY, Quaternion.identity);
        _gameStarted = false;
    }


    // Update is called once per frame
    void Update()
    {



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!_gameStarted){
            _gameStarted = true;
            // generate 3 random number 
            StartCoroutine(StepUpdate());
        } else{

            // update component

        }


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
