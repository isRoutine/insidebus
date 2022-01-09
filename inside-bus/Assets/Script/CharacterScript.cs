using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Character {
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
	public GameObject male;
	private Queue<Character> toSpawn;
    private LinkedList<GameObject> spawned;
    private Vector2 startPosition;
    private int visible;
    private int amountSpawned;
    private float timing = 0;
    private bool flag = false;


	public void Spawn(string model, int qty, float interval) {
            for(int i = 0; i < qty; i++){
                Character c = new Character(male,interval);
                toSpawn.Enqueue(c);            
            }
	}

    // Start is called before the first frame update
    void Start()
    {
    	toSpawn = new Queue<Character>(); // queue of character waiting for spawn
        spawned = new LinkedList<GameObject>(); //list of character already spawned
        startPosition = new Vector2(-0.7f, -6); // default start position for all characters
        visible = 0; // number of character now in action, visible on the screen
        amountSpawned = 0; // number of character spawned 
        MaleScript s =  male.GetComponent<MaleScript>() as MaleScript;
        s.VerticalValue = +1.0f; // setting the animation of male
        s.AnimationSpeed = 0.02f; // setting the speed animation of male
    }

    // Update is called once per frame
    void Update()
    {
     
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if(toSpawn.Count > 0 || flag){

            if(toSpawn.Count > 0){
                Character peek = toSpawn.Peek();
                if (timing > peek.Time)
                {
                    GameObject temp = Instantiate(peek.Figure, startPosition, Quaternion.identity);
                    temp.name = "Male" + amountSpawned;         
                    spawned.AddFirst(temp);
                    timing = 0;
                    amountSpawned++;
                    visible++;
                    toSpawn.Dequeue();
                    flag = true;
                }
            }

            LinkedListNode<GameObject> c = spawned.First;
            while (c != null){
                
                Rigidbody2D rigidBody = c.Value.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D; 
                if (rigidBody.position.y <= +2){ // punto in cui si devono fermare
                    Vector2 movement = new Vector2(0, 0.5f);
                    rigidBody.MovePosition(rigidBody.position + (movement * 1f * Time.fixedDeltaTime));        
                }
                else {
                    GameObject temp = c.Value;
                    spawned.RemoveLast();
                    Destroy(temp);      
                }
                c = c.Next;
            }
            timing += Time.fixedDeltaTime;
        }
    }
}

