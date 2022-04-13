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

    [SerializeField] private TextMeshProUGUI scoreValue;
    private bool gameOverBool = false;
    private int endScore;
    private int growthRate = 5;

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
        return _lives;
    }

    public TimeScript GetTimer()
    {
        return this._timer;
    }

    public GameObject GetGameOverUI()
    {
        return this.GameOverUI;
    }       
    

    // delay for every start of new game
    private WaitForSeconds _delay = new WaitForSeconds(1.0f);

    private IEnumerator StepUpdate(int entranti , int uscenti){
        yield return _delay;
        BusHandler script = _bus.GetComponent<BusHandler>() as BusHandler;
        script.BusInit();
        yield return StartCoroutine(script.BusStart());
        _spawner.Spawn(entranti, Spawner.MALE_ENTRANTE);
        _spawner.Spawn(uscenti, Spawner.MALE_USCENTE);
        yield return StartCoroutine(_spawner.MoveAll());
        yield return new WaitUntil(_spawner.IsEmptyScene);
        print("tutti morti...");
        yield return StartCoroutine(script.BusEnd());
        //_gameStarted = false;
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
            int att = (int)GetRandomNumber(0, 20);
            int ent = (int)GetRandomNumber(0, 10);
            int usc = (int)GetRandomNumber(0, 10);
            print("ent: " + ent);
            print("usc: " + usc);
            StartCoroutine(StepUpdate(ent, usc));
        }

    }


    public void PrintScore()
    {
            int vite = Convert.ToInt32(this._lives.text);
            if (vite != 0)
            {
                //printed = true;
                int diff = Math.Abs(this.rispostaEsatta - Convert.ToInt32(this._answer.GetAnswerText()));
                if (diff > 0)
                    score = score + (200 * diff);
                else
                    score = score + (200 * this.rispostaEsatta);

                Debug.Log("Score" + score.ToString());
            }

        }
        // int vite = Convert.ToInt32(this._lives);
        // if (_answer.rispostaInviata && (vite != 0))
        // {
        //     int diff = Math.Abs(this.rispostaEsatta - Convert.ToInt32(_answer.getAnswerText()));
        //     if (diff > 0)
        //         score = score + (200 * diff);
        //     else
        //         score = score + (200 * this.rispostaEsatta);
            
        //     Debug.Log("Score" + score.ToString());
        //     _answer.rispostaInviata = false;
        // }

    public void GameOver()
    {
        if (endScore != score && score > endScore)
            endScore += growthRate;
    }

    public void SetGameOver(bool b)
    {
        this.gameOverBool = b;
    }

}
