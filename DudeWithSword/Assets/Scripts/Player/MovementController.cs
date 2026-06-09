using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movement;
    [HideInInspector]
    public Vector3 turnTarget;

    public Vector3 moveDirection { get; private set; }

    private Rigidbody rb;

    public Animator Animations;
    public Transform cameraDirection;
    public Transform orientation;
    [Header("Movement")]
    public float maxSpeed;
    public float acceleration;
    public float deacceleration;

    public float turnTime;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement;
        TurnPlayer(turnTarget);
    }

    private void OnMove(InputValue context)
    {
        Vector3 inputDirection = context.Get<Vector2>();
        orientation.forward = (transform.position - new Vector3(cameraDirection.position.x, transform.position.y, cameraDirection.position.z)).normalized;


        moveDirection = orientation.right * inputDirection.x + orientation.forward * inputDirection.y;

    }

    public void MoveBehaviour()
    {

        if (moveDirection.magnitude > 0.1f) //player gives input
        {
            movement += moveDirection * acceleration;
        }
        else if (movement.magnitude >= deacceleration)
        {
            movement -= movement.normalized * deacceleration;
        }
        else if (movement.magnitude > 0)
        {
            movement = Vector3.zero;
        }

        if (movement.magnitude > maxSpeed * moveDirection.magnitude)
        {
            movement = movement.normalized * maxSpeed * moveDirection.magnitude;
        }

        Animations.SetFloat("Velocity", movement.magnitude / maxSpeed);

        if (movement.magnitude > 0.1f)
        {
            turnTarget = moveDirection.normalized;
        }

        movement.y = rb.linearVelocity.y;
    }

    public void TurnPlayer(Vector3 target)
    {
        transform.forward = Vector3.Lerp(transform.forward, target, turnTime);
    }
}
