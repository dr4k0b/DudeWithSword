using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEventActivator : StateMachineBehaviour
{
    [SerializeField] bool _useOnStateEnter;
    [SerializeField] string _enterEventTag;
    [SerializeField] bool _useOnStateUpdate;
    [SerializeField] string[] _updateEventTag;
    [SerializeField] bool _useOnStateExit;
    [SerializeField] string _exitEventTag;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_useOnStateEnter)
        {
            animator.gameObject.GetComponent<StateEventManager>()?.TriggerEvent(_enterEventTag);
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_useOnStateUpdate)
        {
            foreach (string tag in _updateEventTag)
                animator.gameObject.GetComponent<StateEventManager>()?.TriggerEvent(tag);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_useOnStateExit)
        {
            animator.gameObject.GetComponent<StateEventManager>()?.TriggerEvent(_exitEventTag);
        }
    }
}
