using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleScript : MonoBehaviour
{
    
    // parameters for switch the animation of associated game object 
    public float HorizontalValue; // value for horizontal axis direction of animation  ; range [-1;1] ; 
    public float VerticalValue; // value for vertical axis direction of animation  ; range [-1;1] ; 
    public float AnimationSpeed; // value for animation speed  ; range [0; ...] ; 
                                          //if this <= 0.01 --> animation in IDLE position 
    
    // some components associated to game object...
    public Rigidbody2D RigidBody; 
    public Animator Animator; 


    // setters and getters 
    public void SetHorizontalValue(float value){ 
        HorizontalValue = value;
    }

    public float GetHorizontalValue(){
        return HorizontalValue;
    }

    public void SetVerticalValue(float value){ 
        VerticalValue = value;
    }

    public float GetVerticalValue(){
        return VerticalValue;
    }

    public void SetAnimationSpeed(float value){ 
        AnimationSpeed = value;
    }

    public float GetAnimationSpeed(){
        return AnimationSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if we want to switch the male animation from the keyboard or other input...
        //movement.x = Input.GetAxisRaw("Horizontal"); // return int from -1 to 1
        //movement.y = Input.GetAxisRaw("Vertical"); // return int from -1 to 1
        
        // Updating the parameters of animation...
        Animator.SetFloat("Horizontal", HorizontalValue);
        Animator.SetFloat("Vertical", VerticalValue);
        Animator.SetFloat("Speed", AnimationSpeed);
  
    }

}
