using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male : Character
{
    
    // parameters for switch the animation of associated game object 
    private float _horizontalValue   { get; set; } // value for horizontal axis direction of animation  ; range [-1;1] ; 
    private float _verticalValue     { get; set; } // value for vertical axis direction of animation  ; range [-1;1] ; 
    private float _animationSpeed    { get; set; } // value for animation speed  ; range [0; ...] ; 
                                                    //if this <= 0.01 --> animation in IDLE position 

    private const float DEFAULT_ANIMATION_SPEED = 0.02f ;

    public Male(float horizontalValue, float verticalValue){
        _horizontalValue = horizontalValue;
        _verticalValue = verticalValue;
        _animationSpeed = DEFAULT_ANIMATION_SPEED;
    }

}
