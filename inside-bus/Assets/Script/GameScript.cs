using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScript : MonoBehaviour
{
    public float start;
    public GameObject man;
    public float delay;
    public int amountSpawned;
    public Vector2 movimento;
    public List<GameObject> men ;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;

        delay = 0;
        amountSpawned = 0;

        men = new List<GameObject>();
        movimento = new Vector2();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);


        if ( delay >=5 )
        {
            GameObject temp = Instantiate(man, new Vector2(0, -4), Quaternion.identity);
            temp.name = "Man" + amountSpawned.ToString();

            men.Add(temp);

            delay = 0;
            amountSpawned++;
        }

        foreach (GameObject m in men)
        {
            movimento.y = m.transform.position.y;
            movimento.y += 0.5f * Time.deltaTime;
            m.transform.position = movimento;
        }

        delay += Time.deltaTime;
    }
}
