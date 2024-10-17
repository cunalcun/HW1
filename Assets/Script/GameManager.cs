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

    // 적 처치 시 호출
    public void EnemyKilled()
    {
        enemiesKilled++;
        enemiesRemaining--;
    }

    // 적 스폰 시 호출
    public void EnemySpawned()
    {
        enemiesRemaining++;
        Debug.Log($"적 스폰: 남아있는 적 {enemiesRemaining}마리");
    }

    // 게임 패배 처리
    private void GameOver()
    {
        gameOver = true;
        SceneManager.LoadScene("GameOver");
    }

    // 게임 승리 처리
    private void GameWin()
    {
        gameOver = true;
        SceneManager.LoadScene("WinScreen"); 
    }
}
