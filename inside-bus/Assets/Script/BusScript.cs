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
    
    public Animator animator;


    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void EnginesOff()
    {
        animator.SetTrigger("engines_off");
    }

    public void EnginesOn()
    {
        animator.SetTrigger("engines_on");
    }

    public void Fly()
    {
        animator.SetTrigger("fly");
    }

    public void Open()
    {
        animator.SetTrigger("open");
    }

    public void Close()
    {
        animator.SetTrigger("close");
    }

    public void Idle()
    {
        animator.SetTrigger("idle");
    }
}
