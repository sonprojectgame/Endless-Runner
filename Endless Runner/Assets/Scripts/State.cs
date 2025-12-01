using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
    [SerializeField] protected bool state = true;

    protected void OnEnable() {
        EventManager.Subscribe(EventType.START, OnExcute);
        EventManager.Subscribe(EventType.STOP, OnStop);
    }

    protected void OnExcute() {
        state = true;
    }

    protected void OnStop() {
        state = false;
    }

    protected void OnDisable() {
        EventManager.UnSubscribe(EventType.START, OnExcute);
        EventManager.UnSubscribe(EventType.STOP, OnStop);
    }
}
