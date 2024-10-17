using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int enemiesKilled = 0;
    private int enemiesRemaining = 0;
    public int maxEnemiesAllowed = 10;
    public int killGoal = 5;

    private bool gameOver = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (gameOver) return;

        if (enemiesKilled >= killGoal)
        {
            GameWin();
        }

        if (enemiesRemaining >= maxEnemiesAllowed)
        {
            GameOver();
        }
    }

    // �� óġ �� ȣ��
    public void EnemyKilled()
    {
        enemiesKilled++;
        enemiesRemaining--;
    }

    // �� ���� �� ȣ��
    public void EnemySpawned()
    {
        enemiesRemaining++;
        Debug.Log($"�� ����: �����ִ� �� {enemiesRemaining}����");
    }

    // ���� �й� ó��
    private void GameOver()
    {
        gameOver = true;
        SceneManager.LoadScene("GameOver");
    }

    // ���� �¸� ó��
    private void GameWin()
    {
        gameOver = true;
        SceneManager.LoadScene("WinScreen"); 
    }
}
