using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour
{
    
    public Animator animator;
    private bool isFlying = false;

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
        isFlying = true;
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

    public bool getState()
    {
        return isFlying;
    }
}
