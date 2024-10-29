using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f; 
    private float currentHP;
    public GameObject deathParticlePrefab;

    void Start()
    {
        currentHP = maxHP;
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        if (deathParticlePrefab != null)
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }
        GameManager.instance.EnemyKilled();
        Destroy(gameObject);
    }
    public void hit()
    {
        Destroy(gameObject);
    }

}

