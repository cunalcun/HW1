using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyTime; // źȯ ���� �ð�

    void Start()
    {
        Destroy(gameObject, destroyTime); // ���� �ð� �� źȯ �ڵ� ����
    }

    private void Update()
    {
        
    }
}

