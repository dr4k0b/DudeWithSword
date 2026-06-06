using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator stateMachine;
    public Animator animations;

    private bool attacking;
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnAttack()
    {
        if (!attacking)
        {
            stateMachine.SetBool("Attack", true);
            animations.SetBool("Attack", true);
            attacking = true;
        }
    }

    public void AttackExit()
    {
        stateMachine.SetBool("Attack", false);
        animations.SetBool("Attack", false);
        attacking = false;
    }

}
