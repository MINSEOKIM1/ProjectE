using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CharacterInfos characterInfos;
    public EquipmentInfos equipmentInfos;
    public BuffInfos buffInfos;
    
    public List<GameObject> expedition;
    public List<CharacterData> expeditionData;

    public void DeleteExpedition()
    {
        if (expedition.Count > 1)
        { 
            expedition.RemoveAt(expedition.Count - 1);
            expeditionData.RemoveAt(expeditionData.Count - 1);
        }
    }

    public void AddCharacterToExpedition(int n)
    {
        if (expedition.Count < 3)
        {
            expedition.Add(characterInfos.characters[n]);
            expeditionData.Add(new CharacterData(characterInfos.playerDatas[n]));
        }
    }
}
