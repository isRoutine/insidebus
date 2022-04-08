using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleHandler : CharacterHandler
{

    // parameters for switch the animation of associated game object 
    public float _horizontalValue   { get; set; } // value for horizontal axis direction of animation  ; range [-1;1] ; 
    public float _verticalValue     { get; set; } // value for vertical axis direction of animation  ; range [-1;1] ; 
    public float _animationSpeed    { get; set; } // value for animation speed  ; range [0; ...] ; 
                                                    //if this <= 0.01 --> animation in IDLE position 

    public bool _arrived {get; set;}

    private const float DEFAULT_VERTICAL_VALUE = 1.0f;
    private const float DEFAULT_ANIMATION_SPEED = 1.0f;

    //  shifting the rigidbody of movement vector2
    public IEnumerator Move(Vector2 start, Vector2 end, int type, Vector2 movement){
        
        _animator.SetFloat("Speed",DEFAULT_ANIMATION_SPEED);  
        
        if(type == Spawner.MALE_TO_IN)
            _animator.SetFloat("Vertical",1.0f);     
        else 
            _animator.SetFloat("Vertical",-1.0f);  

        while(_rigidBody.position.y < end.y){
            _rigidBody.MovePosition(_rigidBody.position + movement);
            yield return null;
        }
        _arrived = true;
    }

    void Start(){
       _arrived = false;
    }


    // Update is called once per frame
    void Update()
    {


    }



    void FixedUpdate()
    {



    }


}
