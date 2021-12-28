using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleScript : MonoBehaviour
{

	public float moveSpeed = 1f;
	public Rigidbody2D rb;
	public Animator Animator;
	Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input
        //movement.x = Input.GetAxisRaw("Horizontal"); // return int from -1 to 1
        //movement.y = Input.GetAxisRaw("Vertical"); // return int from -1 to 1

        Animator.SetFloat("Horizontal", 0);
        Animator.SetFloat("Vertical", 1);
        //Animator.SetFloat("Speed", movement.sqrMagnitude);
  
    }

    void FixedUpdate(){
    	//rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
