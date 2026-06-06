using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateEventManager : MonoBehaviour
{
    [SerializeField] List<StateEvent> stateEvents;

    public void TriggerEvent(string eventTag)
    {
        stateEvents.Find(e =>  e.tag == eventTag)?.TriggerEvent();
    }
}
