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
    public bool flag;
    public bool click;

    public void IsClicked()
    {
        click = true;
    }

    public int AnswerValue {
        get { return Convert.ToInt32(answerText.text); }
        set { answerValue = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        click = false;
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

    }

}
