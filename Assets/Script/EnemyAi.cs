using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;           
    public float changeDirectionTime = 3f;
    private float directionTimer = 0f;   
    private int moveDirection;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        directionTimer += Time.deltaTime;

        if (directionTimer >= changeDirectionTime)
        {
            SetRandomDirection();
            directionTimer = 0f; 
        }

        MoveEnemy();
    }


    void MoveEnemy()
    {
        if (moveDirection == 0)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0); 
        }
        else if (moveDirection == 1)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0); 
        }
        else if (moveDirection == 2)
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime); 
        }
        else if (moveDirection == 3)
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        }
    }

    void SetRandomDirection()
    {
        moveDirection = Random.Range(0, 4); 
    }
}
