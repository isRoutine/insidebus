using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    private GameObject figure;
    private float time;

    public Character(GameObject character, float time){
        this.figure = character;
        this.time = time;
    }

    public float Time{
        get { return time; }
        set { time = value; }
    }

    public GameObject Figure{
        get { return figure; }
        set { figure = value; }
    }
}

public class CharacterScript : MonoBehaviour
{
    private Vector2 BUS_STOP;
    private Vector2 BUS_ENTRY;
    private Vector2 BUS_EXIT;

    private Vector2 MALE_STOP;
    private Vector2 MALE_ENTRY;

    
    public GameObject male;
    private Queue<Character> toSpawn;
    private LinkedList<GameObject> spawned;   

    public GameObject bus;
    private GameObject busSpawned;

    private Vector2 startPosition;
    public int visible;
    private int amountSpawned;
    private int SpawnedBus;
    private float timing = 0;
    private float delay = 0;
    private bool flag = false;


    public void SpawnMen(string model, int qty, float interval)
    {
        for (int i = 0; i < qty; i++)
        {
            Character c = new Character(male, interval);
            toSpawn.Enqueue(c);
        }
    }

    public void SpawnBus(string model, int qty, float interval)
    {
        for (int i = 0; i < qty; i++)
        {
            Character c = new Character(bus, interval);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        // BUS SETUP __________________________________
        
        BUS_STOP    = new Vector2(0,0);
        BUS_ENTRY   = new Vector2(+7f,0);
        BUS_EXIT    = new Vector2(-7f,0);

        amountSpawned = 0; // number of character spawned 
        SpawnedBus = 0;


        // MALE SETUP __________________________________
        
        MALE_STOP   = new Vector2(-1f,0);
        MALE_ENTRY  = new Vector2(-1f,-1f);

        MaleScript s = male.GetComponent<MaleScript>() as MaleScript;
        s.SetVerticalValue(1.0f); // setting the animation of male
        s.SetAnimationSpeed(0.02f); // setting the speed animation of male

        toSpawn = new Queue<Character>(); // queue of character waiting for spawn
        spawned = new LinkedList<GameObject>();//list of character already spawned
        visible = 0; // number of character now in action, visible on the screen

    }

    // Update is called once per frame
    void Update()
    {

    }



    // Update is called once per frame
    void FixedUpdate()
    {

        // if (toSpawn.Count > 0 || flag)
        // {

        //     if (toSpawn.Count > 0)
        //     {
        //         Character peek = toSpawn.Peek();
        //         if (timing > peek.Time)
        //         {
        //             GameObject temp = Instantiate(peek.Figure, startPosition, Quaternion.identity);
        //             temp.name = "Male" + amountSpawned;
        //             spawned.AddFirst(temp);
        //             timing = 0;
        //             amountSpawned++;
        //             visible++;
        //             toSpawn.Dequeue();
        //             flag = true;
        //         }
        //     }

        //     LinkedListNode<GameObject> c = spawned.First;
        //     while (c != null)
        //     {

        //         Rigidbody2D rigidBody = c.Value.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        //         if (rigidBody.position.y <= +2)
        //         { // punto in cui si devono fermare
        //             Vector2 movement = new Vector2(0, 0.5f);
        //             rigidBody.MovePosition(rigidBody.position + (movement * 1f * Time.fixedDeltaTime));
        //         }
        //         else
        //         {
        //             GameObject temp = c.Value;
        //             spawned.RemoveLast();
        //             Destroy(temp);
        //             visible--;
        //         }
        //         c = c.Next;
        //     }
        //     timing += Time.fixedDeltaTime;
        // }

        if (SpawnedBus == 0)
        {
            SpawnedBus = 1;
            busSpawned = Instantiate(bus, BUS_ENTRY , Quaternion.identity);
            busSpawned.name = "Bus";
        }

        if (busSpawned != null)
        {
            Rigidbody2D busBody = busSpawned.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            BusScript b = busSpawned.GetComponent<BusScript>() as BusScript;

            if (busBody.position.x > BUS_STOP.x)
                busBody.MovePosition(busBody.position + (new Vector2(-0.5f, 0) * Time.fixedDeltaTime * 2f));
            else
            {
                Debug.Log("EnginesOff : " + b.getAnimator().GetBool("engines_off"));
                b.EnginesOff();
                //Debug.Log("EnginesOff : " + b.getAnimator().GetBool("engines_off"));
                b.Idle();
                b.Open();
                b.Close();
            }

            if (visible == 0 && busBody.position.x <= -0.038f)
            {
                b.EnginesOn();
                b.Fly();
                //if(b.GetComponent<Animator>().GetComponent<Animation>().IsPlaying("bus_fly"))
                    busBody.MovePosition(busBody.position + (new Vector2(-0.5f, 0) * Time.fixedDeltaTime * 2f));
            }

            if (busBody.position.x < -6.5f)
            {
                Destroy(busSpawned);
                //SpawnedBus = 0;
            }
        }
    }
}

