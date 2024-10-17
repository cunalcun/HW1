using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP; 
    public float baseDamage = 10f; 

    void Start()
    {
        currentHP = maxHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            DestroyBase(); 
        }
    }

    void DestroyBase()
    {
        Debug.Log("기지가 파괴되었습니다!");
        Destroy(gameObject);
    }
}
