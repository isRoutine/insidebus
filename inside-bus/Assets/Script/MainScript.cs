using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public TimeScript timer;
    public AnswerScript answer;
    public CharacterScript character;
    private float delay = 0;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (delay > 3 && (flag==false)){
            flag = true;
            character.Spawn("model1", 5, 1f);
            Debug.Log("inviato " + delay);
        }
        Debug.Log(delay);
        delay += Time.fixedDeltaTime;

    }
}
