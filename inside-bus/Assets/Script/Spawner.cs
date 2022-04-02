using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
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

    private IEnumerator InstantiateMaleCoroutine;

    
    private IEnumerator InstantiateMale(int qty, Vector2 position, LinkedList<GameObject> list){
        for(int i=0; i < qty; i++){
            yield return new WaitForSeconds(1.0f);  
            GameObject newObject = Instantiate(_male, position, Quaternion.identity);
            print("spawn male_" + i);
            list.AddFirst(newObject);         
        }
    }

    public void Spawn(int qty, int spawnPosition){
        
        Vector2 position = MALE_ENTRY_TO_IN;
        LinkedList<GameObject> list = _spawnedToIn;

        if(spawnPosition == MALE_TO_OUT){
            position = MALE_ENTRY_TO_OUT;
            list = _spawnedToOut;
        }

        InstantiateMaleCoroutine = InstantiateMale(qty,position,list);
        StartCoroutine(InstantiateMaleCoroutine);
    }



    // public void UpdateSpawnedObject(){
  
    //     LinkedListNode<GameObject> _in = _spawnedToIn.First;
    //     LinkedListNode<GameObject> _out = _spawnedToOut.First;
        
    //     do{
    //         if(_in != null){
    //             MaleHandler script = _in.Value.GetComponent<MaleHandler>() as MaleHandler;
    //             script.Move( MALE_MOVEMENT * Time.fixedDeltaTime);
    //             _in = _in.Next;
    //         }

    //         if(_out != null){
    //             MaleHandler script = _out.Value.GetComponent<MaleHandler>() as MaleHandler;
    //             script.Move( - MALE_MOVEMENT * Time.fixedDeltaTime);
    //             _out = _out.Next;
    //         }
    //     }while(_out != null || _in != null);
    // }


    // Start is called before the first frame update
    void Start()
    {
        _spawnedToIn = new LinkedList<GameObject>(); //list of character already spawned
        _spawnedToOut = new LinkedList<GameObject>(); //list of character already spawned
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    // Update is called once per frame
    void FixedUpdate()
    {

    }
}

