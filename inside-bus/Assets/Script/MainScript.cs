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
    
    private float delay = 0;
    private bool flag = false;
    private bool printed = false;
    private int rispostaEsatta;
    private int score = 4000;

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
    

    // Start is called before the first frame update
    void Start()
    {
        float tempo = (float)GetRandomNumber(5, 30);
        timer.TimerValue = tempo;
        rispostaEsatta = 120;
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

        if (delay > 3 && (flag == false)) {
            flag = true;
            character.SpawnMen("model1", 5, 1f);
            character.SpawnBus("model2", 1, 1f);
            Debug.Log("inviato " + delay);
        }

        //Debug.Log(delay);
        delay += Time.fixedDeltaTime;
    }

    public void PrintScore()
    {
        int vite = Convert.ToInt32(this.lives.text);
        if (vite != 0)
        {
            printed = true;
            int diff = Math.Abs(this.rispostaEsatta - Convert.ToInt32(answer.GetAnswerText()));
            if (diff > 0)
                score = score + (200 * diff);
            else
                score = score + (200 * this.rispostaEsatta);

            Debug.Log("Score" + score.ToString());
        }
    }

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
