using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float force;
    [SerializeField] private float speed;
    [SerializeField]  private Character character;
    [SerializeField]  private InputActionReference moveAction;
        
         
    private void OnEnable()
    {
        if (moveAction == null)
        {
            return;
        }
        character = GetComponent<Character>();
        moveAction.action.performed += OnMove;
    }



    private void OnMove(InputAction.CallbackContext obj)
    {
        var request = new ForceRequest();
        request.mode = ForceMode.Force;
        var horizontalInput = obj.ReadValue<Vector2>();
        request.direction = new Vector3(horizontalInput.x, 0, horizontalInput.y);
        request.speed = speed;
        request.force = force;
        character.RequestForce(request);
    }

}
   

