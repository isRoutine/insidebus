using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerScript : MonoBehaviour
{
    public Text answerText;
    private int answerValue;

    public Button moreButton;
    public Button lessButton;
    public Button answerButton;
    
    public GameObject moreButtonGO;
    public GameObject lessButtonGO;
    public GameObject answerButtonGO;
    
    public MainScript main;
    
    public bool flag;
    public bool click;
    public bool rispostaInviata;

    public void IsClicked()
    {
        click = true;
    }

    public int AnswerValue
    {
        get { return Convert.ToInt32(answerText.text); }
        set { answerValue = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        click = false;
        rispostaInviata = false;
        answerText = GetComponent<Text>() as Text;
        moreButton.onClick.AddListener(MoreTask);
        lessButton.onClick.AddListener(LessTask);
        answerButton.onClick.AddListener(AnswerTask);

    }

    // Update is called once per frame
    void Update()
    {
        moreButton.interactable = !flag;
        lessButton.interactable = !flag;
    }

    // se utente preme il tasto al centro, cambia lo 
    // stato di un flag boolenao, inizialmente false


    public void MoreTask()
    {
        int numero = Convert.ToInt32(answerText.text);
        answerText.text = (numero + 1).ToString();

    }

    public void LessTask()
    {
        int numero = Convert.ToInt32(answerText.text);
        if (numero > 0)
            answerText.text = (numero - 1).ToString();

    }

    public void AnswerTask()
    {
        flag = !flag;
        if (rispostaInviata)
            return;
        float numero = main.timer.timerValue;
        int vite = Convert.ToInt32(main.getLives().text);
        if (numero == 0.0f)
        {
            rispostaInviata = true;
            if (this.AnswerValue == main.getRispostaEsatta())
            {
                main.getLives().text = vite.ToString();
                main.getLivesBis().text = vite.ToString();
            }

            else
            {
                int diff = Math.Abs(main.getRispostaEsatta() - this.AnswerValue);
                if (vite - diff >= 0)
                {
                    vite = vite - diff;
                    main.getLives().text = vite.ToString();
                    main.getLivesBis().text = vite.ToString();
                }
                else
                {
                    Debug.Log("Game Over");
                    main.getLives().text = "0";
                    main.getLivesBis().text = "0";
                }
            }
        }

    }

}
