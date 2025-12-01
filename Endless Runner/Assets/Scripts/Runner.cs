using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RoadLine {
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : State {
    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadline;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] UnityEvent callback;

    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 4f;

    void Awake() {
        roadline = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private new void OnEnable() {
        base.OnEnable();
        InputManager.Instance.action += OnkeyUpdate;
    }

    private void OnkeyUpdate() {
        if (state == false)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && roadline > RoadLine.LEFT) {
            animator.Play("Avoid Left");
            roadline--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && roadline < RoadLine.RIGHT) {
            animator.Play("Avoid Right");
            roadline++;
        }
    }

    private void Move() {
        rigidBody.position = Vector3.Lerp(
            rigidBody.position,
            new Vector3((int)roadline * positionX, 0, 0),
            speed * Time.fixedDeltaTime
            );
    }

    private void FixedUpdate() {
        if (state == false) {
            animator.SetBool("Death", true);
            return;
        }

        Move();
    }

    private new void OnDisable() {
        base.OnDisable();
        InputManager.Instance.action -= OnkeyUpdate;
    }

    private void OnTriggerEnter(Collider other) {
        IHitable hitable = other.GetComponent<IHitable>();
        if (hitable != null)
            hitable.Activate();
    }
}
