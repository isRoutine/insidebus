using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScript : MonoBehaviour
{


    public GameObject man;
    public LinkedList<GameObject> men;
    public float moveSpeed = 1f;
    public float delay;
    public int amountSpawned;
    public int menInside;


    // Start is called before the first frame update
    void Start()
    {

        delay = 0;
        amountSpawned = 0;
        menInside = 0;
        men = new LinkedList<GameObject>();
        MaleScript s =  man.GetComponent<MaleScript>();
        s.vValue = 1f;
        s.moveSpeed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Time.time);

        if ( delay >=3 )
        {
            GameObject temp = Instantiate(man, new Vector2(0, -4), Quaternion.identity);
            temp.name = "Man" + amountSpawned.ToString();         
            men.AddFirst(temp);
            delay = 0;
            amountSpawned++;
        }

        LinkedListNode<GameObject> m = men.First;
        while (m != null){
            
            Rigidbody2D rb = m.Value.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D; 
            if (rb.position.y <= +2){ // punto in cui si devono fermare
                Vector2 movement = new Vector2(0, 0.5f);
                rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));      	
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
        delay += Time.fixedDeltaTime;
    }
}
