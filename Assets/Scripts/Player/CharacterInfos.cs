using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharaterInfos", order = 2)]
public class CharacterInfos : ScriptableObject
{
    public GameObject[] characters;
    public PlayerData[] playerDatas;
}
