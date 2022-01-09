using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerScript : MonoBehaviour
{
    public Text answerText;
    public Button moreButton;
    public Button lessButton;
  

    // Start is called before the first frame update
    void Start()
    {
        answerText = GetComponent<Text>() as Text;
        moreButton.onClick.AddListener(onClickTask);
        lessButton.onClick.AddListener(onClickTask1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onClickTask()
    {
        int numero = Convert.ToInt32(answerText.text);
        answerText.text = (numero + 1).ToString();
    }

    void onClickTask1()
    {
        int numero = Convert.ToInt32(answerText.text);
        if(numero > 0)
            answerText.text = (numero - 1).ToString();
    }
}
