using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private int timeToEnd = 20;

    private bool gamePaused = false;
    private bool endGame = false;
    private bool win = false;

    void Start()
    {
        InvokeRepeating("Stopper", 2f, 1f);
    }

    void Update()
    {
        PauseCheck();
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    private void Stopper()
    {
        timeToEnd--;
        //Debug.Log($"Time: {timeToEnd} sec.");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!!");
        }
        else
        {
            Debug.Log("You Lose!!!");
        }
    }
}
