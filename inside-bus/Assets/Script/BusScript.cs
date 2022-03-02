using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bus {

    private GameObject figure;
    private float time;

    public Bus(GameObject bus, float time)
    {
        this.figure = bus;
        this.time = time;
    }

    public float Time
    {
        get { return time; }
        set { time = value; }
    }

    public GameObject Figure
    {
        get { return figure; }
        set { figure = value; }
    }

}

public class BusScript : MonoBehaviour
{

    public GameObject bus;
    private Queue<Bus> toSpawn;
    private LinkedList<GameObject> spawned;
    private Vector2 startPosition;
    private int visible;
    private int amountSpawned;
    private float timing = 0;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
