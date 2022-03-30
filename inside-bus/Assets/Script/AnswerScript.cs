using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] private Text _answerText;
    private int _answerValue;

    [SerializeField] private Button _moreButton;
    [SerializeField] private Button _lessButton;
    [SerializeField] private Button _answerButton;

    [SerializeField] private GameObject _moreButtonGO;
    [SerializeField] private GameObject _lessButtonGO;
    [SerializeField] private GameObject _answerButtonGO;

    [SerializeField] private MainScript _main;
    [SerializeField] private PauseScript _pause;
    [SerializeField] private GameObject _answerPanel;

    public bool Flag;
    public bool Click;
    public bool RispostaInviata;

    public float TimerValue;
    [SerializeField] private Text _timeText;
    public float Seconds, Minutes;

    public void IsClicked()
    {
        this.Click = true;
    }

    public int AnswerValue
    {
        get { return Convert.ToInt32(this._answerText.text); }
        set { this._answerValue = value; }
    }

    public GameObject getMoreButton()
    {
        return this._moreButtonGO;
    }

    public GameObject getLessButton()
    {
        return this._lessButtonGO;
    }

    public GameObject getAnswerButton()
    {
        return this._answerButtonGO;
    }

    public Text getAnswerText()
    {
        return this._answerText;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.Flag = false;
        this.Click = false;
        this.RispostaInviata = false;
        //answerText = GetComponent<Text>() as Text;

    }

    // Update is called once per frame
    void Update()
    {
        this._moreButton.interactable = !this.Flag;
        this._lessButton.interactable = !this.Flag;

        if (this._main.getTimer().TimerValue == 0.0f && this.RispostaInviata == false)
        {
            this.TimerValue += Time.deltaTime;
            this.Minutes = (int)(this.TimerValue / 60f);
            this.Seconds = (int)(this.TimerValue % 60f);
            this._timeText.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
            DarkTimer();
        }
        else
        {
            this._answerPanel.SetActive(false);
            this._pause.FillUI();
        }
    }

    // se utente preme il tasto al centro, cambia lo 
    // stato di un flag boolenao, inizialmente false


    public void MoreTask()
    {
        int numero = Convert.ToInt32(this._answerText.text);
        this._answerText.text = (numero + 1).ToString();

    }

    public void LessTask()
    {
        int numero = Convert.ToInt32(this._answerText.text);
        if (numero > 0)
            this._answerText.text = (numero - 1).ToString();

    }

    public void AnswerTask()
    {
        Flag = !Flag;
        if (this.RispostaInviata)
            return;
        float numero = this._main.getTimer().TimerValue;
        int vite = Convert.ToInt32(this._main.getLives().text);
        if (numero == 0.0f)
        {
            this.RispostaInviata = true;
            if (this.AnswerValue == this._main.getRispostaEsatta())
            {
                this._main.getLives().text = vite.ToString();
                this._main.getLivesBis().text = vite.ToString();
            }

            else
            {
                int diff = Math.Abs(this._main.getRispostaEsatta() - this.AnswerValue);
                if (vite - diff >= 0)
                {
                    vite = vite - diff;
                    this._main.getLives().text = vite.ToString();
                    this._main.getLivesBis().text = vite.ToString();
                }
                else
                {
                    Debug.Log("Game Over");
                    this._main.getLives().text = "0";
                    this._main.getLivesBis().text = "0";
                    this._main.getGameOverUI().SetActive(true);
                    Time.timeScale = 0f;
                    this._answerPanel.SetActive(false);
                    this._answerButtonGO.SetActive(false);
                    this._lessButtonGO.SetActive(false);
                    this._moreButtonGO.SetActive(false);
                    this._pause.GetPauseButton().SetActive(false);

                }
            }
        }

    }

    public void DarkTimer()
    {
        this._answerPanel.SetActive(true);

        
        Color c = this._answerPanel.GetComponent<Image>().color;
        c.a = 0.0005f;
        
        if(this._answerPanel.GetComponent<Image>().color.a < 0.60f)
            this._answerPanel.GetComponent<Image>().color += c;

        this._pause.ClearUI();
    }

}
