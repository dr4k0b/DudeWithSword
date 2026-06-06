using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StateEvent
{
    [SerializeField] string _tag;
    [SerializeField] UnityEvent _event;

    public string tag { get => _tag;  }

    public void TriggerEvent()
    {
        _event.Invoke();
    }
}
