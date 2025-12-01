using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {
    [SerializeField] float speed = 20f;
    [SerializeField] float accel = 5f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float term = 10f;

    public float Speed {
        get { return speed; }
    }

    void Awake() {
        StartCoroutine(Acceleration());
    }

    IEnumerator Acceleration() {
        while(speed < maxSpeed) {
            yield return CoroutineCache.WaitForSecond(term);

            speed += accel;
        }
    }
}
