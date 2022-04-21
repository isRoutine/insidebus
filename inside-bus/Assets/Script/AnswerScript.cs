using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerScript : MonoBehaviour
{

    private int _answerValue;

    [SerializeField] private GameObject _more;
    [SerializeField] private GameObject _less;
    [SerializeField] private GameObject _answer;
    [SerializeField] private GameObject _quantity;

    private Button _moreButton;
    private Button _lessButton;
    private Button _answerButton;
    private Text _quantityText;

    public bool _answerConfirmed { get; set; }

    // Start is called before the first frame update
    void Start()
    {

        _moreButton = _more.GetComponent<Button>();
        _lessButton = _less.GetComponent<Button>();
        _answerButton = _answer.GetComponent<Button>();
        _quantityText = _quantity.GetComponent<Text>();

        _answerConfirmed = false;

    }

    // Update is called once per frame
    void Update()
    {
        // this._moreButton.interactable = !this.Flag;
        // this._lessButton.interactable = !this.Flag;

        // if (this._main.GetTimer().TimerValue == 0.0f && this.RispostaInviata == false)
        // {
        //     this.TimerValue += Time.deltaTime;
        //     this.Minutes = (int)(this.TimerValue / 60f);
        //     this.Seconds = (int)(this.TimerValue % 60f);
        //     this._timeText.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
        //     DarkTimer();
        // }
        // else
        // {
        //     this._answerPanel.SetActive(false);
        //     this._pause.FillUI();
        // }
    }

    // se utente preme il tasto al centro, cambia lo 
    // stato di un flag boolenao, inizialmente false

    public void SetQuantity(int quantity)
    {
        _quantityText.text = quantity.ToString();
    }

    public int GetQuantity()
    {
        return Convert.ToInt32(_quantityText.text);
    }

    public void MoreTask()
    {
        SetQuantity(GetQuantity() + 1);
    }

    public void LessTask()
    {
        if (GetQuantity() > 0)
            SetQuantity(GetQuantity() - 1);
    }


    public void EnableAnswer()
    {
        _answerButton.interactable = true;
    }

    public void DisableAnswer()
    {
        _answerButton.interactable = false;
        _answerConfirmed = false;
    }

    public void AnswerTask()
    {
        _answerConfirmed = true;
    }


    // public void AnswerTask()
    // {
    //     Flag = !Flag;
    //     if (this.RispostaInviata)
    //         return;
    //     float numero = this._main.GetTimer().TimerValue;
    //     int vite = Convert.ToInt32(this._main.GetLives().text);
    //     if (numero == 0.0f)
    //     {
    //         this.RispostaInviata = true;
    //         if (this.AnswerValue == this._main.GetRispostaEsatta())
    //         {
    //             this._main.GetLives().text = vite.ToString();
    //         }

    //         else
    //         {
    //             int diff = Math.Abs(this._main.GetRispostaEsatta() - this.AnswerValue);
    //             if (vite - diff >= 0)
    //             {
    //                 vite = vite - diff;
    //                 this._main.GetLives().text = vite.ToString();
    //             }
    //             else
    //             {
    //                 Debug.Log("Game Over");
    //                 this._main.GetLives().text = "0";
    //                 this._main.GetGameOverUI().SetActive(true);
    //                 Time.timeScale = 0f;
    //                 this._answerPanel.SetActive(false);
    //                 this._answerButtonGO.SetActive(false);
    //                 this._lessButtonGO.SetActive(false);
    //                 this._moreButtonGO.SetActive(false);
    //                 this._pause.GetPauseButton().SetActive(false);

    //             }
    //         }
    //     }

    // }

    // public void DarkTimer()
    // {
    //     this._answerPanel.SetActive(true);


    //     Color c = this._answerPanel.GetComponent<Image>().color;
    //     c.a = 0.0005f;

    //     if(this._answerPanel.GetComponent<Image>().color.a < 0.60f)
    //         this._answerPanel.GetComponent<Image>().color += c;

    //     this._pause.ClearUI();
    // }

}
