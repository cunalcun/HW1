using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnInterval = 5f;      
    public Transform spawnPoint;  
    public Transform[] waypoints; 

    private float spawnTimer = 0f;

    void Update()
    {
        // 스폰 타이머 업데이트
        spawnTimer += Time.deltaTime;

        // 스폰 간격이 지나면 자동차 생성
        if (spawnTimer >= spawnInterval)
        {
            SpawnCar();
            spawnTimer = 0f; // 타이머 초기화
        }
    }

    // 자동차를 생성하는 함수
    void SpawnCar()
    {
        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);

        // CarController에 웨이포인트 배열 전달
        CarController carController = newCar.GetComponent<CarController>();
        if (carController != null)
        {
            carController.SetWaypoints(waypoints);
        }
    }
}
