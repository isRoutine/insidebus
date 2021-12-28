using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScript : MonoBehaviour
{
    public float start;
    public int menInside;
    public GameObject man;
    public float delay;
    public int amountSpawned;
    public Vector2 movimento;
    public LinkedList<GameObject> men ;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
        menInside = 0;
        delay = 0;
        amountSpawned = 0;
        men = new LinkedList<GameObject>();
        movimento = new Vector2();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);

        if ( delay >=1 )
        {
            GameObject temp = Instantiate(man, new Vector2(0, -4), Quaternion.identity);
            temp.name = "Man" + amountSpawned.ToString();
            men.AddFirst(temp);
            delay = 0;
            amountSpawned++;
        }

        LinkedListNode<GameObject> m = men.First;
        while (m != null){
            movimento.y = m.Value.transform.position.y;
            if (movimento.y <= +2){ // punto in cui si devono fermare
            	movimento.y += 0.5f * Time.deltaTime;
            	m.Value.transform.position = movimento;        	
            }
            else {
            	menInside++;
            	Debug.Log(menInside.ToString());
            	GameObject temp = m.Value;
            	men.RemoveLast();
        		Destroy(temp);    	
            }
            m = m.Next;
        }
        delay += Time.deltaTime;
    }
}
