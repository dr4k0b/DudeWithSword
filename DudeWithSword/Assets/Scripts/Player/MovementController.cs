using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movement;
    [HideInInspector]
    public Vector3 turnTarget;

    private Vector2 moveDirection;
    public Vector3 topView { get { return new Vector3(moveDirection.x, 0, moveDirection.y); } }

    private Rigidbody rb;

    public Animator Animations;
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
        moveDirection = context.Get<Vector2>();
    }

    public void MoveBehaviour()
    {

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
            turnTarget = movement;
        }

        movement.y = rb.linearVelocity.y;
    }

    public void TurnPlayer(Vector3 target)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, target, turnTime));
    }
}
