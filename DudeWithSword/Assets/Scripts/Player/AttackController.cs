using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator stateMachine;
    public Animator animations;
    public TrailRenderer trail;

    [Header("Attacking")]

    public float dash;
    public float deacceleration;
    public float inputBufferWindow;

    private Vector3 direction;
    private float speed;
    private float inputBuffer;

    private bool attacking;
    private Rigidbody rb;
    private MovementController mc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mc = GetComponent<MovementController>();
    }

    void Update()
    {
        if (!attacking)
        {
            stateMachine.SetBool("Attack", false);
            animations.SetBool("Attack", false);

            if (inputBuffer > 0)
            {
                StartCoroutine(AttackDelay());
            }
        }

        inputBuffer -= Time.deltaTime;
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForEndOfFrame();
        Attack();
    }
    private void OnAttack()
    {
        if (!attacking)
        {
            Attack();
        }
        else
        {
            inputBuffer = inputBufferWindow;
        }
    }
    private void Attack()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        direction = transform.forward;
        mc.turnTarget = mc.topView;
        mc.movement = Vector3.zero;

        stateMachine.SetBool("Attack", true);
        animations.SetBool("Attack", true);

        trail.Clear();
        speed = dash;
        attacking = true;
    }
    public void AttackDash()
    {
        mc.movement = direction * speed;
        speed -= deacceleration;
        if (speed < 0) speed = 0;
    }

    public void AttackExit()
    {
        attacking = false;
    }

}
