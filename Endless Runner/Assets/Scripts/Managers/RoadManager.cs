using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : State {
    [SerializeField] List<GameObject> roads = new List<GameObject>();
    [SerializeField] GameObject speedObject;
    [SerializeField] float speed;
    [SerializeField] float offset = 40.0f;

    void Awake() {
        roads.Capacity = 10;
        speedObject = GameObject.Find("Speed Manager");
    }

    void Update() {
        if (state == false)
            return;

        speed = speedObject.GetComponent<SpeedManager>().Speed;
        for (int i = 0; i < roads.Count; i++) {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void InitializePosition() {
        GameObject newRoad = roads[0];
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.RemoveAt(0);
        roads.Add(newRoad);
    }
}
