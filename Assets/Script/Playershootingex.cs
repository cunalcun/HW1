using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playershootingex : MonoBehaviour
{
    public GameObject regularBulletPrefab;  // 좌클릭 탄환
    public GameObject burstBulletPrefab;    // 우클릭 3점사 탄환
    public Transform shootPoint;            // 탄환 발사 위치
    public float burstDelay = 0.1f;         // 3점사 간격

    private int burstCount = 0;             // 3점사 발사 횟수
    private float burstTimer = 0f;          // 3점사 타이머
    private bool isBurstFiring = false;     // 3점사 중인지 확인


    void Update()
    {
        // 좌클릭 기본 발사
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet(regularBulletPrefab);
        }

        // 우클릭 3점사
        if (Input.GetMouseButtonDown(1))
        {
            isBurstFiring = true;
            burstCount = 0;
            burstTimer = 0;
        }


        if (isBurstFiring)
        {
            burstTimer += Time.deltaTime;

            if (burstTimer >= burstDelay && burstCount < 3)
            {
                FireBullet(burstBulletPrefab);
                burstCount++;
                burstTimer = 0;
            }

            if (burstCount >= 3)
            {
                isBurstFiring = false; 
            }
        }
    }

    void FireBullet(GameObject bulletPrefab)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation); 
        Destroy(bullet, 5f);
    }
}