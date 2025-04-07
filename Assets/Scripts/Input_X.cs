using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_X : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private float speed = 20;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Rigidbody rigidbody;
    private bool _isJumpRequested; 
    
    private Vector2 _moveInput;

    private void OnEnable()
    {
        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;
        jumpAction.action.started += HandleJumpInput;
    }
    
    private void HandleJumpInput (InputAction.CallbackContext context)
    {
        _isJumpRequested = true; 
    }
    
    private void HandleMoveInput (InputAction.CallbackContext context)
    {
        Debug.Log(message:context.ReadValue<Vector2>());
        _moveInput = context.ReadValue<Vector2>();
    }
    
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(_moveInput.x, 0, _moveInput.y) * speed, ForceMode.Force);
        if (_isJumpRequested)
        {
            _isJumpRequested = false;
           rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
