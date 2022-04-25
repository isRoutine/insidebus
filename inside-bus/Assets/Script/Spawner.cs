using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    // some reference coordinates...
    public static int MALE_ENTRANTE    = 1;
    public static int MALE_USCENTE   = 0;
    private Vector2 MALE_MOVEMENT      = new Vector2(0 , 0.05f);
    
    public static Vector2 MALE_ENTRANTE_START  = new Vector2(+1.3f,-7.0f);
    public static Vector2 MALE_ENTRANTE_STOP   = new Vector2(+1.3f,0);

    public static Vector2 MALE_USCENTE_START  = new Vector2(-1.4f,0.1f);    
    public static Vector2 MALE_USCENTE_STOP  = new Vector2(-1.4f,-7.0f);    


    
    [SerializeField] private GameObject _malePrefab;
    private LinkedList<GameObject> _spawnedEntranti;
    private LinkedList<GameObject> _spawnedUscenti;

    // VisibleMale: num of _malePrefab already visible in scene
    public int VisibleMale{get; set;}

    // IsEmptyScene(): true if VisibleMale == 0
    public bool IsEmptyScene(){
        if(VisibleMale == 0){
            _spawnedEntranti.Clear();
            _spawnedUscenti.Clear();
            return true;
        }
        else 
            return false;;
    }

    // Spawn _malePrefab prefab and add to linkedlist
    public void Spawn(int qty, int type){
        
        Vector2 initPosition;
        LinkedList<GameObject> list;
        if(type == MALE_USCENTE){
            initPosition = MALE_USCENTE_START;
            list = _spawnedUscenti;
        } else {
            initPosition = MALE_ENTRANTE_START;
            list = _spawnedEntranti;            
        }

        for(int i=0; i<qty; i++){
            GameObject obj = Instantiate(_malePrefab, initPosition, Quaternion.identity);  
            list.AddFirst(obj); 
        } 
        VisibleMale += qty;  
    }


    // Coroutine : Call Move() function for every object spawned
    public IEnumerator MoveAll(){

        WaitForSeconds delay = new WaitForSeconds(0.5f); // default delay
        LinkedListNode<GameObject> entrante = _spawnedEntranti.First;
        LinkedListNode<GameObject> uscente = _spawnedUscenti.First;       

        while(entrante!=null || uscente!=null){

            if(entrante != null){
                MaleHandler maleHandler = entrante.Value.GetComponent<MaleHandler>() as MaleHandler;
                maleHandler._spawner = this;
                maleHandler.SetAnimation("up");
                entrante = entrante.Next;
                StartCoroutine(maleHandler.Move(MALE_ENTRANTE_START, MALE_ENTRANTE_STOP, MALE_MOVEMENT));  
            }

            if(uscente!=null){
                MaleHandler maleHandler = uscente.Value.GetComponent<MaleHandler>() as MaleHandler;
                maleHandler._spawner = this;
                maleHandler.SetAnimation("down");
                uscente = uscente.Next;
                StartCoroutine(maleHandler.Move(MALE_USCENTE_START, MALE_USCENTE_STOP, MALE_MOVEMENT));   
            }
            yield return delay;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _spawnedEntranti = new LinkedList<GameObject>(); //list of character already spawned
        _spawnedUscenti = new LinkedList<GameObject>(); //list of character already spawned
        
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

