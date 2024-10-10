using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyTime; // 탄환 제거 시간

    void Start()
    {
        Destroy(gameObject, destroyTime); // 일정 시간 뒤 탄환 자동 제거
    }

    private void Update()
    {
        
    }
}

