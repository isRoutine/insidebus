using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    // some reference coordinates...
    public static int MALE_TO_IN    = 1;
    public static int MALE_TO_OUT   = 0;
    private Vector2 MALE_STOP   = new Vector2(-1f,0);
    private Vector2 MALE_ENTRY_TO_IN  = new Vector2(-1.3f,-5f);
    private Vector2 MALE_ENTRY_TO_OUT  = new Vector2(+1f,0);
    private Vector2 MALE_MOVEMENT      = new Vector2(0 , 0.05f);
    
    [SerializeField] private GameObject _male;
    private int _toSpawnToIn;
    private LinkedList<GameObject> _spawnedToIn;

    private int _toSpawnToOut;
    private LinkedList<GameObject> _spawnedToOut;

    public int _visibleMale{get; set;}

    
    public void Spawn(int qty, int type){
        
        Vector2 position;
        LinkedList<GameObject> list;

        if(type == MALE_TO_OUT){
            position = MALE_ENTRY_TO_OUT;
            list = _spawnedToOut;
        } else {
            position = MALE_ENTRY_TO_IN;
            list = _spawnedToIn;            
        }

        for(int i=0; i<qty; i++){
            GameObject newObject = Instantiate(_male, position, Quaternion.identity);  
            list.AddFirst(newObject); 
        } 
        _visibleMale += qty;  
    }

    public IEnumerator MoveAll(){

        LinkedListNode<GameObject> _in = _spawnedToIn.First;
        LinkedListNode<GameObject> _out = _spawnedToOut.First;

        while((_in != null) || (_out != null)){
            
            if(_in != null){
                MaleHandler script = _in.Value.GetComponent<MaleHandler>() as MaleHandler;
                StartCoroutine(script.Move(MALE_ENTRY_TO_IN, BusHandler.BUS_STOP, MALE_TO_IN, MALE_MOVEMENT));
                _in = _in.Next;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    public int VisibleObject(){
        return _spawnedToIn.Count + _spawnedToOut.Count;
    }

    private void ClearLists(){
        foreach(GameObject gobject in _spawnedToIn){
            if (gobject == null)
                _spawnedToIn.Remove(gobject);
        }
    }


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
        ClearLists();

    }
}

