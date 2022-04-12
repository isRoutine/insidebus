using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusHandler : CharacterHandler
{

    public static Vector2 BUS_STOP     = new Vector2(0,0);
    public static Vector2 BUS_ENTRY    = new Vector2(+7f,+1f);
    public static Vector2 BUS_EXIT     = new Vector2(-7f,+1f);
    public static Vector2 BUS_MOVEMENT = new Vector2(-0.05f,0);

    // animator methods ...
    public void EnginesOff(){ _animator.SetTrigger("engines_off"); }

    public void EnginesOn(){ _animator.SetTrigger("engines_on"); }

    public void Fly(){ _animator.SetTrigger("fly"); }

    public void Open(){ _animator.SetTrigger("open"); }

    public void Close(){ _animator.SetTrigger("close"); }

    public void Idle(){ _animator.SetTrigger("idle"); }


    public void BusInit(){
        Idle();
        _rigidBody.position = BusHandler.BUS_ENTRY;
    }

    public IEnumerator BusStart(){
        Fly();
        while(_rigidBody.position.x > BusHandler.BUS_STOP.x){
            _rigidBody.MovePosition(_rigidBody.position + BusHandler.BUS_MOVEMENT);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        EnginesOff();
        yield return new WaitForSeconds(1.0f);
        Open();
        yield return new WaitForSeconds(2.0f);
    }

    public IEnumerator BusEnd(){
        Close();
        yield return new WaitForSeconds(2.0f);
        EnginesOn();
        yield return new WaitForSeconds(2.0f);
        Fly();
        while(_rigidBody.position.x > BusHandler.BUS_EXIT.x){
            _rigidBody.MovePosition(_rigidBody.position + BusHandler.BUS_MOVEMENT);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        BusInit();
        yield break;
    }




}
