using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
     
    [SerializeField] private TimeScript timer;
    [SerializeField] private AnswerScript answer;
    [SerializeField] private CharacterScript character;
    [SerializeField] private TextMeshProUGUI lives;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private GameObject _busPrefab;
    private GameObject _bus;
    private int rispostaEsatta;
    private int score;
    private bool _gameStarted;

    private static System.Random random = new System.Random();
    public double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public int GetRispostaEsatta()
    {
        return rispostaEsatta;
    }

    public TextMeshProUGUI GetLives()
    {
        return lives;
    }

    public TimeScript GetTimer()
    {
        return this.timer;
    }

    public GameObject GetGameOverUI()
    {
        return this.GameOverUI;
    }       
    

    // delay for every start of new game
    private WaitForSeconds _delay = new WaitForSeconds(1.0f);

    private IEnumerator StepUpdate(){
        yield return _delay;
        BusHandler script = _bus.GetComponent<BusHandler>() as BusHandler;
        script.BusInit();
        yield return StartCoroutine(script.BusStart());
        _spawner.Spawn(5, Spawner.MALE_ENTRANTE);
        _spawner.Spawn(3, Spawner.MALE_USCENTE);
        yield return StartCoroutine(_spawner.MoveAll());
        yield return new WaitUntil(_spawner.IsEmptyScene);
        print("tutti morti...");
        yield return StartCoroutine(script.BusEnd());
        _gameStarted = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        _bus = Instantiate(_busPrefab, BusHandler.BUS_ENTRY, Quaternion.identity);
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
