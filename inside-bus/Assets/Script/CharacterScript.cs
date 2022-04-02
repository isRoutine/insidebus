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


    private void CreateMale(){

        while(_toSpawnToIn > 0){
            GameObject obj = Instantiate(_male, MALE_ENTRY_TO_IN, Quaternion.identity);
            Male maleController = obj.GetComponent<Male>() as Male;
            maleController._verticalValue = +1.0f;
            maleController._animationSpeed = +1.0f;
            obj.name = "Male_IN" + (_spawnedToIn.Count + 1);
            _spawnedToIn.AddFirst(obj);
            _toSpawnToIn--;
        }

        while(_toSpawnToOut > 0){
            GameObject obj = Instantiate(_male, MALE_ENTRY_TO_OUT, Quaternion.identity);
            Male maleController = obj.GetComponent<Male>() as Male;
            maleController._verticalValue = -1.0f;
            maleController._animationSpeed = +1.0f;
            obj.name = "Male_OUT" + (_spawnedToOut.Count + 1);
            _spawnedToOut.AddFirst(obj);
            _toSpawnToOut--;
        }
    }


    public void Spawn(int qty, int type){

        if(type == MALE_TO_IN)
            _toSpawnToIn+=qty;
        else 
            _toSpawnToOut+=qty;
        CreateMale();
    }


    public void UpdateSpawnedObject(){
  
        LinkedListNode<GameObject> _in = _spawnedToIn.First;
        LinkedListNode<GameObject> _out = _spawnedToOut.First;
        
        do{
            if(_in != null){
                Male script = _in.Value.GetComponent<Male>() as Male;
                script.Move( MALE_MOVEMENT * Time.fixedDeltaTime);
                _in = _in.Next;
            }

            if(_out != null){
                Male script = _out.Value.GetComponent<Male>() as Male;
                script.Move( - MALE_MOVEMENT * Time.fixedDeltaTime);
                _out = _out.Next;
            }
        }while(_out != null || _in != null);
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

        UpdateSpawnedObject();

        // instantiate operations



        // update position of spawned object




    }
}

