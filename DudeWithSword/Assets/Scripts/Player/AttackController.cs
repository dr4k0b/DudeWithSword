using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator stateMachine;

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
            attacking = true;
        }
    }

    public void AttackExit()
    {
        stateMachine.SetBool("Attack", false);
        attacking = false;
    }

}
