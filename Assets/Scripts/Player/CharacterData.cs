using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 객체 고유의 Datas
[System.Serializable]
public class CharacterData
{
   public PlayerData playerData;
   public List<Equipment> equipments;

   public CharacterData(PlayerData pd)
   {
      this.playerData = pd;
      equipments = new List<Equipment>();
   }

   public void AddEquipment(int n)
   {
      if (equipments.Count < 4)
      {
         equipments.Add(new Equipment(GameManager.Instance.DataManager.equipmentInfos.equipmentDatas[n]));
      }
      else
      {
         Debug.Log("There is no space to take more Equipment!");
      }
   }
}
