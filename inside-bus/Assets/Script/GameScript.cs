using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    public GameObject man;
    //public GameObject busObj;
    public LinkedList<GameObject> men;
    //public LinkedList<GameObject> buses;
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
        MaleScript s =  man.GetComponent<MaleScript>() as MaleScript;
        //BusObject bus = busObj.GetComponent<BusObject>() as BusObject;
        s.VerticalValue = +1.0f;
        s.AnimationSpeed = 0.02f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Time.time);

        if ( delay >=3 )
        {
            GameObject temp = Instantiate(man, new Vector2(0, -4), Quaternion.identity);
            //GameObject tempBus = Instantiate(busObj, new Vector2(0, -5), Quaternion.identity);
            temp.name = "Man" + amountSpawned.ToString();
            //tempBus.name = "Bus";
            men.AddFirst(temp);
            //buses.AddFirst(tempBus);
            
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

        /* LinkedListNode<GameObject> b = buses.First;
        while (b != null)
        {

            Rigidbody2D rb = b.Value.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            if (rb.position.y <= +2)
            { // punto in cui si devono fermare
                Vector2 movement = new Vector2(0, 0.5f);
                rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
            }
            else
            {
                GameObject temp = b.Value;
                buses.RemoveLast();
                Destroy(temp);
            }
            b = b.Next;
        } */

    }

}
