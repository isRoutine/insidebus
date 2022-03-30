using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : Character
{


    public void BusInit(){
        _rigidBody.position = CharacterScript.BUS_ENTRY;
    }

    // animator methods ...
    public void EnginesOff(){ _animator.SetTrigger("engines_off"); }

    public void EnginesOn(){ _animator.SetTrigger("engines_on"); }

    public void Fly(){ _animator.SetTrigger("fly"); }

    public void Open(){ _animator.SetTrigger("open"); }

    public void Close(){ _animator.SetTrigger("close"); }

    public void Idle(){ _animator.SetTrigger("idle"); }

}
