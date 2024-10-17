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
        // ���� Ÿ�̸� ������Ʈ
        spawnTimer += Time.deltaTime;

        // ���� ������ ������ �ڵ��� ����
        if (spawnTimer >= spawnInterval)
        {
            SpawnCar();
            spawnTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    // �ڵ����� �����ϴ� �Լ�
    void SpawnCar()
    {
        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);

        // CarController�� ��������Ʈ �迭 ����
        CarController carController = newCar.GetComponent<CarController>();
        if (carController != null)
        {
            carController.SetWaypoints(waypoints);
        }
    }
}
