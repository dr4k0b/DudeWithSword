using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector3 movement;

    private Rigidbody rb;

    public Animator Animations;
    [Header("Movement")]
    public float maxSpeed;
    public float acceleration;
    public float deacceleration;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnMove(InputValue context)
    {
        moveDirection = context.Get<Vector2>();
    }

    public void MoveBehaviour()
    {
        Vector3 topView = new Vector3(moveDirection.x, 0, moveDirection.y);

        if (moveDirection.magnitude > 0.1f) //player gives input
        {
            movement += topView * acceleration;
        }
        else if (movement.magnitude >= deacceleration)
        {
            movement -= movement.normalized * deacceleration;
        }
        else if (movement.magnitude > 0)
        {
            movement = Vector3.zero;
        }

        if (movement.magnitude > maxSpeed)
        {
            movement = movement.normalized * maxSpeed;
        }

        Animations.SetFloat("Velocity", movement.magnitude / maxSpeed);

        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        movement.y = rb.linearVelocity.y;
        rb.linearVelocity = movement;
    }
}
