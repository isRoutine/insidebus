using System.Collections;
using UnityEngine;

public class MaleHandler : CharacterHandler
{

    // parameters for switch the animation of associated game object 
    // private float _horizontalValue; // value for horizontal axis direction of animation  ; range [-1;1] ; 
    // private float _verticalValue; // value for vertical axis direction of animation  ; range [-1;1] ; 
    // private float _animationSpeed;// value for animation speed  ; range [0; ...] ; 
    //                                                 //if this <= 0.01 --> animation in IDLE position 

    [SerializeField] public Spawner _spawner {get; set;}

    private const float DEFAULT_VERTICAL_VALUE = 1.0f;
    private const float DEFAULT_ANIMATION_SPEED = 1.0f;

    public void SetAnimation(string animation){      
        _animator.SetFloat("Speed", DEFAULT_ANIMATION_SPEED);
        
        if(animation == "up")
            _animator.SetFloat("Vertical", 1.0f);
        else if(animation == "down")
            _animator.SetFloat("Vertical", -1.0f);     
        else
            _animator.SetFloat("Vertical", DEFAULT_VERTICAL_VALUE);        
    }

    public IEnumerator Move(Vector2 start, Vector2 end, Vector2 movement){

        if(start == Spawner.MALE_ENTRANTE_START){
            while(_rigidBody.position.y < end.y)
            {
                _rigidBody.MovePosition(_rigidBody.position + movement);
                yield return null;
            }
            _spawner.VisibleMale -= 1;
            Destroy(gameObject);
        }
        else {
            while(_rigidBody.position.y > end.y)
            {
                _rigidBody.MovePosition(_rigidBody.position - movement);
                yield return null;
            }
            _spawner.VisibleMale -= 1;
            Destroy(gameObject);       
        }
    }

    void Start(){

    }


    // Update is called once per frame
    void Update()
    {

    }



    void FixedUpdate()
    {

    }


}
