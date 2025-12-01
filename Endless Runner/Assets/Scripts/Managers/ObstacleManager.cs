using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : State {
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();

    [SerializeField] int createCount = 5;
    [SerializeField] int random;

    void Awake() {
        obstacleList.Capacity = 20;

        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create() {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);
            clone.SetActive(false);
            obstacleList.Add(clone);
        }
    }

    bool ExamineActive() {
        for(int i = 0; i < obstacleList.Count; i++) {
            if (obstacleList[i].activeSelf == false)
                return false;
        }

        return true;
    }

    public IEnumerator ActiveObstacle() {
        while (state) {
            yield return CoroutineCache.WaitForSecond(2.5f);

            random = Random.Range(0, obstacleList.Count);

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacleList[random].activeSelf) {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                if (ExamineActive()) {
                    // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                    // obstacleList에 넣어줍니다.
                    GameObject clone = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);
                    clone.SetActive(false);
                    obstacleList.Add(clone);
                }

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                // random 변수의 값을 +1 해서 다시 검색합니다.
                random = (random + 1) % obstacleList.Count;
            }
        }
    }

    public GameObject GetObstacle() {
        return obstacleList[random];
    }
}
