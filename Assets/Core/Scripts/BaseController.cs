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

    [Header("HorizontalMovement")]
    private Vector2 moveInput = Vector2.zero;
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

        if (Physics.Raycast(transform.position, Vector3.down, out isGrounded, 1.1f))
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

        moveDirection = new Vector3(moveInput.x * MoveSpeed, CurrentVerticalSpeed, moveInput.y * MoveSpeed) * Time.deltaTime;
        character.Move(moveDirection);
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
