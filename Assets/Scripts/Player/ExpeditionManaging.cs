using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class ExpeditionManaging : MonoBehaviour
{
    public static int CurrentPlayerNum; // 1, 2, 3, ... cf playerNum in PlayerBehavior : 0, 1, 2, ... 왜 이렇게 했냐?
    
    public GameObject currentPlayer;
    public List<GameObject> players;

    public CinemachineVirtualCamera cine;

    public CharacterInfoUI[] infos;

    public List<PlayerDataContainer> playerDataContainers;

    public float[,] CoolTimes;
    private void Start()
    {
        CurrentPlayerNum = 1;

        CoolTimes = new float[5, 5]; // Initialization 

        // DataManager에서 expedition 정보를 로드하여 ExpeditionManaging 객체에서 관리할 수 있게 함...
        for (int i = 0; i < GameManager.Instance.DataManager.expedition.Count; i++)
        {
            var character = Instantiate(GameManager.Instance.DataManager.expedition[i], transform.position,
                Quaternion.identity);
            players.Add(character);
            players[i].transform.SetParent(gameObject.transform);
            players[i].SetActive(false);
            playerDataContainers.Add(players[i].GetComponent<PlayerDataContainer>());
            players[i].GetComponent<PlayerBehavior>().playerNum = i;
            playerDataContainers[i].characterData = GameManager.Instance.DataManager.expeditionData[i];
            playerDataContainers[i].UpdateData();

            for (int j = 0; j < players[i].GetComponent<PlayerDataContainer>().skillImages.Count; j++)
            {
                CoolTimes[i, j] = 0;
            }
        }
        
        currentPlayer = players[0];
        currentPlayer.SetActive(true);
        
        cine.Follow = currentPlayer.transform;
        cine.LookAt = currentPlayer.transform;

        UpdateUI();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerDataContainers[i].UpdateData();
            for (int j = 0; j < players[i].GetComponent<PlayerDataContainer>().skillImages.Count; j++)
            {
                if (CoolTimes[i, j] > 0)
                {
                    CoolTimes[i, j] -= Time.deltaTime;
                    if (CoolTimes[i, j] <= 0)
                    {
                        CoolTimes[i, j] = 0;
                    }
                }
            }
        }
    }


    public void ChangeCharacter(InputAction.CallbackContext value)
    {
        if (value.started && (int)value.ReadValue<float>() != CurrentPlayerNum && (int)value.ReadValue<float>() <= players.Count)
        {
            Vector3 curPo = currentPlayer.transform.position;
            
            currentPlayer.SetActive(false); 
            currentPlayer = players[(int)value.ReadValue<float>() - 1]; 
            Debug.Log("You pressed " + value.ReadValue<float>());
            currentPlayer.SetActive(true); 
            currentPlayer.transform.position = curPo;
            currentPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            
            CurrentPlayerNum = (int)value.ReadValue<float>();
            
            cine.Follow = currentPlayer.transform;
            cine.LookAt = currentPlayer.transform;
            
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (players.Count < infos.Length)
        {
            for (int i = players.Count; i < infos.Length; i++)
            {
                infos[i].gameObject.SetActive(false);
            }
        }
        UpdateCurrentCharacterUI();
        UpdateWatingCharactersUI();
    }

    private void UpdateCurrentCharacterUI()
    {
        infos[0].gameObject.SetActive(true);
        infos[0].SetPlayer(currentPlayer);
    }

    private void UpdateWatingCharactersUI()
    {
        int j = 1;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == currentPlayer) continue;
            infos[i].gameObject.SetActive(true);
            infos[j++].SetPlayer(players[i]);
        }
    }
}
