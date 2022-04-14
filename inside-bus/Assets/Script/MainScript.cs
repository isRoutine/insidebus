using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
     
    [SerializeField] private TimeScript _timer;
    [SerializeField] private AnswerScript _answer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshProUGUI _lives;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private GameObject _busPrefab;
    private GameObject _bus;
    private int rispostaEsatta;
    private int score = 4000;
    private bool _gameStarted;

    

    private static System.Random random = new System.Random();
    
    public double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public void SetLives(int lives){
        _lives.text = lives.ToString();
    }

    public int GetLives(){
        return Convert.ToInt32(_lives.text);
    }
    

    // da fare...
    // calcolo att+ent-usc == ans --> ok e guadagna vite (ancora da definire quante)
    // altrimenti togli di quante vite è sbagliato  ---> return true 
    // se hai sbagliato più di quante ne hai ---> return false

    // usare i metodi set e get lives per aggiornarle
    private bool UpdateLives(int att, int ent, int usc, int ans){
        int correctAnswer = att + ent - usc;

        if(ans == correctAnswer){
            SetLives(GetLives() + 10 );
            return true;
        }
        else if(Math.Abs(correctAnswer - ans) < GetLives()){
                SetLives(GetLives()- Math.Abs(correctAnswer - ans));
                return true;
            }
        else 
            return false;
    }
    

    // delay for every start of new game
    private WaitForSeconds _delay = new WaitForSeconds(1.0f);

    private IEnumerator StepUpdate(int attuali ,int entranti , int uscenti){
        yield return _delay;
        _answer.SetQuantity(attuali);
        _answer.DisableAnswer();
        
        // init bus and start bus 
        BusHandler busHandler = _bus.GetComponent<BusHandler>() as BusHandler;
        busHandler.BusInit();
        yield return StartCoroutine(busHandler.BusStart());
        
        // spawn male based on random numbers generated
        _spawner.Spawn(entranti, Spawner.MALE_ENTRANTE);
        _spawner.Spawn(uscenti, Spawner.MALE_USCENTE);
        
        // move all male from start to end position 
        // and wait until scene is empty
        yield return StartCoroutine(_spawner.MoveAll());
        yield return new WaitUntil(_spawner.IsEmptyScene);
        
        // bus end 
        yield return StartCoroutine(script.BusEnd());
        
        // enable answer button and wait until 
        // user confirmed the answer
        _answer.EnableAnswer();
        Coroutine timerCoroutine;
        // timerCoroutine = StartCoroutine(_timer.Timer());
        while(_answer._answerConfirmed == false)
            yield return null;
        // StopCoroutine(timerCoroutine);
        print("risposta confermata");
        print(_answer.GetQuantity());

        // update lives based on user's answer
        print(UpdateLives(attuali, entranti, uscenti, _answer.GetQuantity()));

        yield return new WaitForSeconds(2.0f);
        _gameStarted = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        _bus = Instantiate(_busPrefab, BusHandler.BUS_ENTRY, Quaternion.identity);
        _gameStarted = false;
        this._timer.SetTimerValue((float)this.GetRandomNumber(0f, 30f));
    }


    // Update is called once per frame
    void Update()
    {
        scoreValue.text = endScore.ToString("0");
        if (gameOverBool)
            GameOver();

        if (gameOverBool && this.score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!_gameStarted)
        {
            _gameStarted = true;
            // generate 3 random number
            int att = (int)GetRandomNumber(0,20);
            int usc = (int)GetRandomNumber(0,att);
            int ent = (int)GetRandomNumber(0,20);
            print("ent: " + ent);
            print("usc: " + usc);
            print("att :" + att);
            StartCoroutine(StepUpdate(att, ent, usc));
        } 

    }

    public void SetGameOver(bool b)
    {
        this.gameOverBool = b;
    }

}
