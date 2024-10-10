using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playershootingex : MonoBehaviour
{
    public GameObject regularBulletPrefab;  // ��Ŭ�� źȯ
    public GameObject burstBulletPrefab;    // ��Ŭ�� 3���� źȯ
    public Transform shootPoint;            // źȯ �߻� ��ġ
    public float burstDelay = 0.1f;         // 3���� ����

    private int burstCount = 0;             // 3���� �߻� Ƚ��
    private float burstTimer = 0f;          // 3���� Ÿ�̸�
    private bool isBurstFiring = false;     // 3���� ������ Ȯ��


    void Update()
    {
        // ��Ŭ�� �⺻ �߻�
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet(regularBulletPrefab);
        }

        // ��Ŭ�� 3����
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