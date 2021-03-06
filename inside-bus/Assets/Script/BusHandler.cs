using System.Collections;
using UnityEngine;

public class BusHandler : CharacterHandler
{

    public static Vector2 BUS_STOP     = new Vector2(0,0);
    public static Vector2 BUS_ENTRY    = new Vector2(+7f,+1f);
    public static Vector2 BUS_EXIT     = new Vector2(-7f,+1f);
    public static Vector2 BUS_MOVEMENT = new Vector2(-0.05f,0);

    private string _currentState;

    void ChangeAnimationState(string state)
    {
        if (_currentState == state) return;

        _animator.Play(state);

        _currentState = state;
    }

    // animator methods ...
    public void EnginesOff(){
        ChangeAnimationState("bus_engines_off");
        //FindObjectOfType<AudioManager>().Play("engines_off");
    }

    public void EnginesOn(){
        ChangeAnimationState("bus_engines_on");
    }

    public void Fly(){
        ChangeAnimationState("bus_fly");
        //FindObjectOfType<AudioManager>().Play("fly");
    }

    public void Open(){
        ChangeAnimationState("bus_open");
        //FindObjectOfType<AudioManager>().Play("open");
    }

    public void Close(){
        ChangeAnimationState("bus_close");
    }

    public void Idle(){
        ChangeAnimationState("bus_idle");
    }


    public void BusInit(){
        Idle();
        _rigidBody.position = BusHandler.BUS_ENTRY;
    }

    public IEnumerator BusStart(){
        Fly();
        while (_rigidBody.position.x > BusHandler.BUS_STOP.x){
            _rigidBody.MovePosition(_rigidBody.position + BusHandler.BUS_MOVEMENT);
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);  //1.5f
        EnginesOff();
        yield return new WaitForSeconds(0.9f);  //1.0f //2.0f
        Open();
        yield return new WaitForSeconds(2.0f);
    }

    public IEnumerator BusEnd(){
        Close();
        yield return new WaitForSeconds(2.1f);
        EnginesOn();
        yield return new WaitForSeconds(0.9f);
        Fly();
        yield return new WaitForSeconds(0.62f);
        while(_rigidBody.position.x > BusHandler.BUS_EXIT.x){
            _rigidBody.MovePosition(_rigidBody.position + BusHandler.BUS_MOVEMENT);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        BusInit();
        yield break;
    }




}
