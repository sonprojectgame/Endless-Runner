using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositionManager : State {
    private Coroutine coroutine;

    [SerializeField] Transform[] parentRoads;
    [SerializeField] Transform[] randomPositionX;
    [SerializeField] GameObject obstacleManager;

    [SerializeField] int index = -1;
    [SerializeField] float[] randompositionZ = new float[16];
    [SerializeField] float offset = 2.5f;


    private void Awake() {
        for (int i = 0; i < randompositionZ.Length; i++)
            randompositionZ[i] = -10.0f + offset * i;

        obstacleManager = GameObject.Find("Obstacle Manager");
    }


    public void InitializePosition() {
        if (coroutine == null)
            coroutine = StartCoroutine(SetPosition());

        index = (index + 1) % parentRoads.Length;

        transform.SetParent(parentRoads[index]);
        transform.localPosition += new Vector3(0, 0, 40);
    }

    public IEnumerator SetPosition() {
        while (state) {
            yield return CoroutineCache.WaitForSecond(2.5f);

            transform.localPosition = new Vector3(0, 0, randompositionZ[Random.Range(0, parentRoads.Length)]);
            
            GameObject obstacle = obstacleManager.GetComponent<ObstacleManager>().GetObstacle();
            obstacle.transform.position = randomPositionX[Random.Range(0, 3)].position;
            obstacle.transform.SetParent(transform.root.GetChild(index));
            obstacle.SetActive(true);
        }
    }
}
