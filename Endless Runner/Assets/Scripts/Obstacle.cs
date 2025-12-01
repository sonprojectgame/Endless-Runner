using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : State, IHitable {
    private new void OnEnable() {
        base.OnEnable();
    }

    public void Activate() {
        EventManager.Publish(EventType.STOP);
    }

    private new void OnDisable() {
        base.OnDisable();
    }
}
