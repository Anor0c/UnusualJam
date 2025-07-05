using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;



public enum Playertype
{
    Humain = 0,
    Chien = 1,
    Plante = 2
}
[RequireComponent(typeof(CharacterController), (typeof(Collider)))]
public class BaseController : MonoBehaviour
{
    [Header("References")]
    private CharacterController character;
    [SerializeField] private Collider InteractCollider;

    [Header("Look")]
    private Vector2 lookInput;
    [SerializeField] private float MaxLookSpeed = 10f; 

    [Header("HorizontalMovement")]
    private Vector2 moveInput = Vector2.zero;
    private Vector3 moveInputDirection = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private float MoveSpeed = 1.0f;

    [Header("VerticalMovement")]
    private RaycastHit isGrounded;
    private bool isJumping = false;
    private float CurrentVerticalSpeed = 0f;
    [SerializeField] private float JumpForce = 100.0f;
    [SerializeField] private float Gravity = 9.81f;


    [Header("Events")]
    public UnityEvent<Vector2> OnMoveInputPerformed;
    public UnityEvent OnInteractInputPressed;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }
    #region "Movement"
    public void Move(InputAction.CallbackContext _ctx)
    {
        if (!_ctx.performed)
        {
            moveInput = Vector2.zero;
            moveInputDirection = Vector3.zero;
        }
        else
        {
            moveInput = _ctx.ReadValue<Vector2>().normalized;

            OnMoveInputPerformed.Invoke(moveInput);
        }
    }
    public void Jump(InputAction.CallbackContext _ctx)
    {
        if (_ctx.performed)
        {
            isJumping = true;

        }
        else
        {
            isJumping = false;
        }
    }


    private void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out isGrounded, 1.05f))
        {
            if (isJumping)
            {
                CurrentVerticalSpeed = JumpForce;
            }
            else
            {
                CurrentVerticalSpeed = 0f;
            }
        }
        else
        {
            CurrentVerticalSpeed -= Gravity;
        }
        moveInputDirection = moveInput.x * transform.right + moveInput.y * transform.forward;
        moveDirection = new Vector3 (moveInputDirection.x *  MoveSpeed, CurrentVerticalSpeed,  moveInputDirection.z* MoveSpeed) * Time.deltaTime;
        character.Move(moveDirection);
    }
    #endregion
    #region "Look"
    public void Look(InputAction.CallbackContext _ctx)
    {
        if (_ctx.performed) 
        {
            lookInput=_ctx.ReadValue<Vector2>();
        }
        transform.eulerAngles += new Vector3(0f, Mathf.Clamp( lookInput.x, -MaxLookSpeed, MaxLookSpeed ), 0f);
    }
    #endregion
    #region "Interaction"
    public void Interract(InputAction.CallbackContext _ctx)
    {
        if (_ctx.started)
        {
            OnInteractInputPressed.Invoke();
        }
    }
    #endregion
}
