using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : State, IHitable {
    [SerializeField] float speed;
    [SerializeField] GameObject rotationObject;

    private new void OnEnable() {
        base.OnEnable();
        rotationObject = GameObject.Find("Rotation Object");
        speed = rotationObject.GetComponent<RotationGameObject>().Speed;
        transform.localRotation = rotationObject.transform.localRotation;
    }

    void Update() {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void Activate() {
        gameObject.SetActive(false);
        Debug.Log("Got Coin!");
    }

    private new void OnDisable() {
        base.OnDisable();
    }
}
