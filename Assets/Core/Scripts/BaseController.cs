using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;



public enum Playertype
{
    Humain = 0,
    Chien = 1,
    Plante = 2
}
[RequireComponent(typeof (CharacterController), (typeof(Collider)) )]
public class BaseController : MonoBehaviour
{
    [Header ("References")]
    private CharacterController character;
    [SerializeField] private Collider InteractCollider;

    [Header("Movement")]
    private Vector2 moveInput = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private float MoveSpeed = 1.0f;

    [Header("Events")]
     public UnityEvent<Vector2> OnInputPerformed;
    // Start is called before the first frame update
    void Start()
    {
        character=GetComponent <CharacterController>();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            moveInput = Vector2.zero ;
        }
        else
        {
            moveInput = ctx.ReadValue<Vector2>().normalized;
            OnInputPerformed.Invoke(moveInput); 
        }
        moveDirection = new Vector3(moveInput.x * MoveSpeed, moveDirection.y, moveInput.y * MoveSpeed);
    }
    public void Interract(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

        }
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        character.Move(moveDirection);
    }
}
