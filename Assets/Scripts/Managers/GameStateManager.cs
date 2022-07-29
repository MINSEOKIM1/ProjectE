using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState{
    Waiting,
    Dungeon,
    Pause
}

public class GameStateManager : MonoBehaviour
{
    public GameState State { get; private set; }

    public void PrepareGame()
    {
        State = GameState.Waiting;
    }
    
    public void TakeGame()
    {
        Time.timeScale = 1f;
        State = GameState.Dungeon;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        State = GameState.Pause;
    }

    public void ChangeStateInDungeon(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (State == GameState.Dungeon)
            {
                Pause();
                GameManager.Instance.UIManager.PauseWindow.SetActive(true);
            }
            else
            {
                TakeGame();
                GameManager.Instance.UIManager.PauseWindow.SetActive(false);
            }
        }
    }
}
