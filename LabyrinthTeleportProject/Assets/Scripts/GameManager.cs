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

    public int points = 0;

    private int redKey = 0;
    private int greenKey = 0;
    private int goldKey = 0;

    void Start()
    {
        InvokeRepeating("Stopper", 2f, 1f);
    }

    void Update()
    {
        PauseCheck();

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log($"Key red: {redKey}, key green: {greenKey}, key gold: {goldKey}");
            Debug.Log($"Points: {points}");
        }
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

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddRemoveTime(int addRemove)
    {
        timeToEnd += addRemove;
    }

    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1f);
    }

    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red)
        {
            redKey++;
        }
        else if (keyColor == KeyColor.Green)
        {
            greenKey++;
        }
        else if (keyColor == KeyColor.Gold)
        {
            goldKey++;
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
