using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public float baseDamage = 10f;
    public GameObject atkParticlePrefab;

    void Start()
    {
        currentHP = maxHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(baseDamage);

            // ������ ���� �� ����
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 particlePosition = transform.position + Vector3.up * 1.5f; // ���ϴ� ���̷� ���� ����
                Instantiate(atkParticlePrefab, particlePosition, Quaternion.identity);
                enemy.hit();
            }
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
        Debug.Log("������ �ı��Ǿ����ϴ�!");
        GameManager.instance.BaseDestroyed();
        Destroy(gameObject);
    }
}
