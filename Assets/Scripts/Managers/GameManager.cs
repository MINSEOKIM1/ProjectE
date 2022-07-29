using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIManager UIManager { get; private set; }
    public GameStateManager GameStateManager { get; private set; }
    public DataManager DataManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            Debug.Log("!!!");
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        UIManager = GetComponentInChildren<UIManager>();
        GameStateManager = GetComponentInChildren<GameStateManager>();
        DataManager = GetComponentInChildren<DataManager>();
    }
}
