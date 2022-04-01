using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterScript : MonoBehaviour
{

    // some reference coordinates...
    public static Vector2 BUS_STOP    = new Vector2(0,0);
    public static Vector2 BUS_ENTRY   = new Vector2(+7f,0);
    public static Vector2 BUS_EXIT    = new Vector2(+7f,0);

    public static int MALE_TO_IN    = 1;
    public static int MALE_TO_OUT   = 0;
    private Vector2 MALE_STOP   = new Vector2(-1f,0);
    private Vector2 MALE_ENTRY_TO_IN  = new Vector2(-1f,-1f);
    private Vector2 MALE_ENTRY_TO_OUT  = new Vector2(+1f,0);
    private Vector2 MALE_MOVEMENT      = new Vector2(0 , 0.5f);
    
    [SerializeField] private GameObject _male;
    private int _toSpawnToIn;
    private LinkedList<GameObject> _spawnedToIn;

    private int _toSpawnToOut;
    private LinkedList<GameObject> _spawnedToOut;

    [SerializeField] private GameObject _bus;

    private int visible;
    private int amountSpawned;
    private int SpawnedBus;
    private float timing = 0;
    private float delay = 0;
    private bool flag = false;


    public void Spawn(int qty, int type){

        if(type == MALE_TO_IN)
            _toSpawnToIn+=qty;
        else 
            _toSpawnToOut+=qty;

    }


    // Start is called before the first frame update
    void Start()
    {

        // // MALE SETUP __________________

        //_toSpawnToIn = new Queue<Male>(); // queue of character waiting for spawn
        _spawnedToIn = new LinkedList<GameObject>(); //list of character already spawned

        //_toSpawnToOut = new Queue<Male>(); // queue of character waiting for spawn
        _spawnedToOut = new LinkedList<GameObject>(); //list of character already spawned
        
        visible = 0; // number of character now in action, visible on the screen

    }

    // Update is called once per frame
    void Update()
    {

    }



    // Update is called once per frame
    void FixedUpdate()
    {


        // instantiate operations

            if(_toSpawnToIn > 0){
                GameObject temp = Instantiate(_male, MALE_ENTRY_TO_IN, Quaternion.identity);
                Male script = temp.GetComponent<Male>() as Male;
                script._verticalValue = +1.0f;
                temp.name = "Male_IN" + (_spawnedToIn.Count + 1);
                _spawnedToIn.AddFirst(temp);
                _toSpawnToIn--;
            }

            if(_toSpawnToOut > 0){
                GameObject temp = Instantiate(_male, MALE_ENTRY_TO_OUT, Quaternion.identity);
                Male script = temp.GetComponent<Male>() as Male;
                script._verticalValue = -1.0f;
                temp.name = "Male_OUT" + (_spawnedToOut.Count + 1);
                _spawnedToOut.AddFirst(temp);
                _toSpawnToOut--;
            }

        // update position of spawned object
        if(_spawnedToIn.Count > 0 || _spawnedToOut.Count >0){
            
            LinkedListNode<GameObject> _in = null;
            LinkedListNode<GameObject> _out = null;

            do{
                _in = _spawnedToIn.First;
                if(_in != null){
                    Male script = _in.Value.GetComponent<Male>() as Male;
                    script.Move( MALE_MOVEMENT * Time.fixedDeltaTime);
                    _in = _in.Next;
                }

                _out = _spawnedToOut.First;
                if(_out != null){
                    Male script = _out.Value.GetComponent<Male>() as Male;
                    script.Move( - MALE_MOVEMENT * Time.fixedDeltaTime);
                    _out = _out.Next;
                }
            }while(_out != null || _in != null);

        }


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

        // if (SpawnedBus == 0)
        // {
        //     SpawnedBus = 1;
        //     busSpawned = Instantiate(bus, BUS_ENTRY , Quaternion.identity);
        //     busSpawned.name = "Bus";
        // }

        // if (busSpawned != null)
        // {
        //     Rigidbody2D busBody = busSpawned.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        //     BusScript b = busSpawned.GetComponent<BusScript>() as BusScript;

        //     if (busBody.position.x > BUS_STOP.x)
        //         busBody.MovePosition(busBody.position + (new Vector2(-0.5f, 0) * Time.fixedDeltaTime * 2f));
        //     else
        //     {
        //         Debug.Log("EnginesOff : " + b.getAnimator().GetBool("engines_off"));
        //         b.EnginesOff();
        //         //Debug.Log("EnginesOff : " + b.getAnimator().GetBool("engines_off"));
        //         b.Idle();
        //         b.Open();
        //         b.Close();
        //     }

        //     if (visible == 0 && busBody.position.x <= -0.038f)
        //     {
        //         b.EnginesOn();
        //         b.Fly();
        //         if (b.GetComponent<Animator>().GetBool("fly"))
        //             busBody.MovePosition(busBody.position + (new Vector2(-0.5f, 0) * Time.fixedDeltaTime * 2f));
        //     }

        //     if (busBody.position.x < -6.5f)
        //     {
        //         Destroy(busSpawned);
        //         //SpawnedBus = 0;
        //     }
        // }
    }
}

