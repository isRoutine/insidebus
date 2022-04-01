using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // [SerializeField] consent to edit private fields
    // from Unity UI, but not from other class
    [SerializeField] protected Rigidbody2D _rigidBody;
    [SerializeField] protected Animator    _animator;


    //  shifting the rigidbody of movement vector2
    public void Move(Vector2 movement){
         _rigidBody.MovePosition(_rigidBody.position + movement);
    }

}
