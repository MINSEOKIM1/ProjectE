using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    Waiting,
    Dungeon
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
        State = GameState.Dungeon;
    }
}
