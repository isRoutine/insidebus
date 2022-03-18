using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bus : Character {

    private GameObject figure;
    private float time;

    public Bus(GameObject bus, float time) : base(bus, time)
    {
        this.figure = bus;
        this.time = time;
    }

}

public class BusScript : MonoBehaviour
{

    /* public GameObject busObject;
    private Queue<Bus> toSpawn;
    private LinkedList<GameObject> spawned;
    private Vector2 startPosition;
    private int visible;
    private int amountSpawned;
    private float timing = 0;
    private bool flag = false;

    public void Spawn(string model, int qty, float interval)
    {
        for (int i = 0; i < qty; i++)
        {
            Bus b = new Bus(busObject, interval);
            toSpawn.Enqueue(b);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        toSpawn = new Queue<Bus>(); // queue of character waiting for spawn
        spawned = new LinkedList<GameObject>(); //list of character already spawned
        startPosition = new Vector2(1f, 10f); // default start position for all characters
        visible = 0; // number of character now in action, visible on the screen
        amountSpawned = 0; // number of character spawned 
        BusObject bus = busObject.GetComponent<BusObject>() as BusObject;
        bus.SetVerticalValue(1.0f); // setting the animation of male
        bus.SetAnimationSpeed(0.02f); // setting the speed animation of male
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if (toSpawn.Count > 0 || flag)
        {

            if (toSpawn.Count > 0)
            {
                Bus peek = toSpawn.Peek();
                if (timing > peek.Time)
                {
                    GameObject temp = Instantiate(peek.Figure, startPosition, Quaternion.identity);
                    temp.name = "Bus" + amountSpawned;
                    spawned.AddFirst(temp);
                    timing = 0;
                    amountSpawned++;
                    visible++;
                    toSpawn.Dequeue();
                    flag = true;
                }
            }

            LinkedListNode<GameObject> c = spawned.First;
            while (c != null)
            {

                Rigidbody2D rigidBody = c.Value.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
                if (rigidBody.position.y <= +2)
                { // punto in cui si devono fermare
                    Vector2 movement = new Vector2(0, 0.5f);
                    rigidBody.MovePosition(rigidBody.position + (movement * 1f * Time.fixedDeltaTime));
                }
                else
                {
                    GameObject temp = c.Value;
                    spawned.RemoveLast();
                    Destroy(temp);
                }
                c = c.Next;
            }
            timing += Time.fixedDeltaTime;
        }
    } */

}
