using UnityEngine;

public class CharacterHandler : MonoBehaviour
{

    // [SerializeField] consent to edit private fields
    // from Unity UI, but not from other class
    [SerializeField] protected Rigidbody2D _rigidBody;
    [SerializeField] protected Animator    _animator;
    [SerializeField] protected Transform   _transform;


}
