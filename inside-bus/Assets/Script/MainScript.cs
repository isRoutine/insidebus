using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    //[SerializeField] private TimeScript _timer;
    [SerializeField] private UIManager _manager;
    [SerializeField] private AnswerScript _answer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshProUGUI _lives;
    
    [SerializeField] private GameObject _busPrefab;
    private GameObject _bus;

    private GameObject _score;
    private int _scoreValue;
    private int _endScoreValue;

    private bool _gameStarted;
    private int _difficulty;
    private int _level;

    PlayFabManager playFabManager;

    private static System.Random random = new System.Random();

    private double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public void SetLives(int lives)
    {
        _lives.text = lives.ToString();
    }

    public int GetLives()
    {
        return Convert.ToInt32(_lives.text);
    }

    public int GetDifficulty()
    {
        return _difficulty;
    }

    private void SetScore(int scoreValue)
    {
        _scoreValue = scoreValue;
    }

    // da fare...
    // calcolo att+ent-usc == ans --> ok e guadagna vite (ancora da definire quante)
    // altrimenti togli di quante vite è sbagliato  ---> return true 
    // se hai sbagliato più di quante ne hai ---> return false

    // usare i metodi set e get lives per aggiornarle
    private bool UpdateLives(int att, int ent, int usc, int ans)
    {
        int correctAnswer = att + ent - usc;

        if (ans == correctAnswer)
        {
            SetLives(GetLives() + 10);
            return true;
        }
        else if (Math.Abs(correctAnswer - ans) < GetLives())
        {
            SetLives(GetLives() - Math.Abs(correctAnswer - ans));
            return true;
        }
        else
            return false;
    }

    // delay for every start of new game
    private WaitForSeconds _delay = new WaitForSeconds(1.0f);

    private IEnumerator StepUpdate(int attuali, int entranti, int uscenti)
    {
        yield return _delay;
        _answer.SetQuantity(attuali);
        _answer.DisableAnswer();
        //_timer.SetTimerValue(0, 0);

        BusHandler script = _bus.GetComponent<BusHandler>() as BusHandler;
        script.BusInit();
        yield return StartCoroutine(script.BusStart());

        _spawner.Spawn(entranti, Spawner.MALE_ENTRANTE);
        _spawner.Spawn(uscenti, Spawner.MALE_USCENTE);
        
        // move all male from start to end position 
        // and wait until scene is empty
        yield return StartCoroutine(_spawner.MoveAll(_level));
        yield return new WaitUntil(_spawner.IsEmptyScene);
        print("tutti morti...");

        yield return StartCoroutine(script.BusEnd());

        _answer.EnableAnswer();
       // Coroutine timerCoroutine = StartCoroutine(_timer.TimerTask());
        while (_answer._answerConfirmed == false)
            yield return null;
        // StopCoroutine(timerCoroutine);
        print("risposta confermata");
        print(_answer.GetQuantity());
        //StopCoroutine(timerCoroutine);
        //_timer.DisableTimer();

        if (!UpdateLives(attuali, entranti, uscenti, _answer.GetQuantity()))
        {
            _manager.SetGameOverUIActive();
            _manager.ClearUI();
            _endScoreValue = 0;
            StartCoroutine(Scoring());
        }
        else
        {
            StartCoroutine(Scoring());
            yield return new WaitForSeconds(2.0f);
            _gameStarted = false;
            _difficulty++;
        }
    }

    private IEnumerator Scoring()
    {
        if (_manager.IsGameOver())
            _score = GameObject.FindGameObjectWithTag("gameOverUI");
        else
            _score = GameObject.FindGameObjectWithTag("scoreUI");

        int growthRate = 10;
        TextMeshProUGUI t = _score.GetComponent<TextMeshProUGUI>();
        t.text = _endScoreValue.ToString("0");
        SetScore((_scoreValue + CalculateScore()));

        if (_manager.IsGameOver() && _scoreValue != 0)
            FindObjectOfType<AudioManager>().Play("score");
        
        while ((_endScoreValue != _scoreValue) && (_scoreValue > _endScoreValue))
        {
            _endScoreValue += growthRate;
            t.text = _endScoreValue.ToString();
            yield return new WaitForSeconds(0.0025f);
        }

        if (_manager.IsGameOver())
        {
            int highScore = PlayerPrefs.GetInt("highscore");
            playFabManager.SendLeaderboard(_endScoreValue);
            if (_endScoreValue > highScore)
            {
                PlayerPrefs.SetInt("highscore", _endScoreValue);
                _manager.SetHighScoreActive();
                //invio il punteggio alla classifica generale su playfab
                //playFabManager.SendLeaderboard(_endScoreValue);
            }
        }

    }

    private int CalculateScore()
    {
        return 5 * ((GetLives() * 2) + GetDifficulty());
    }


    // Start is called before the first frame update
    void Start()
    {
        _bus = Instantiate(_busPrefab, BusHandler.BUS_ENTRY, Quaternion.identity);
        _gameStarted = false;
        //_timer.SetTimerValue(0,0);
        _scoreValue = 0;
        _endScoreValue = 0;
        _difficulty = 1;
        _level = 1;
        playFabManager = GameObject.Find("game").GetComponent<PlayFabManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!_gameStarted)
        {   
            _gameStarted = true;
            _level++;
            print("_level: " + _level);
            // generate 3 random number
            int att = (int)GetRandomNumber(3, 5 * _level);
            int usc = (int)GetRandomNumber(3, att);
            int ent = (int)GetRandomNumber(3, 5 * _level);
            print("ent: " + ent);
            print("usc: " + usc);
            print("att :" + att);
            StartCoroutine(StepUpdate(att, ent, usc));
        }

    }

}






