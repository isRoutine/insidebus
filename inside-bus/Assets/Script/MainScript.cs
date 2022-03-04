using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public TimeScript timer;
    public AnswerScript answer;
    public CharacterScript character;
    public Text lives;
    private float delay = 0;
    private bool flag = false;
    private int rispostaEsatta;

    public int getRispostaEsatta()
    {
        return rispostaEsatta;
    }

    public Text getLives()
    {
        return lives;
    }
    // Start is called before the first frame update
    void Start()
    {
        rispostaEsatta = 120;
    }

    // Update is called once per frame
    void Update()
    {



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (delay > 3 && (flag == false)) {
            flag = true;
            character.Spawn("model1", 5, 1f);
            Debug.Log("inviato " + delay);
        }

        //Debug.Log(delay);
        delay += Time.fixedDeltaTime;
        
    }

}
