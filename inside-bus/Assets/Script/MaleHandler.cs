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

    private const float DEFAULT_ANIMATION_SPEED = 0.02f ;


    // Update is called once per frame
    void Update()
    {


    }



    void FixedUpdate()
    {



    }


}
