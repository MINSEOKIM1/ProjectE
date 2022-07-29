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

   public void DeleteEquipment()
   {
      if (equipments.Count > 0)
      {
         equipments.RemoveAt(equipments.Count - 1);
      }
   }

   public float GetExtraAd()
   {
      float extra = 0;
      float p_extra = 0;
      foreach (var i in equipments)
      {
         extra += i.extraAd;
         p_extra += i.p_extraAd;
      }

      extra += playerData.ad * p_extra;

      return extra;
   }
   public float GetExtraAp()
   {
      float extra = 0;
      float p_extra = 0;
      foreach (var i in equipments)
      {
         extra += i.extraAp;
         p_extra += i.p_extraAp;
      }

      extra += playerData.ap * p_extra;

      return extra;
   }
   public float GetExtraDef()
   {
      float extra = 0;
      float p_extra = 0;
      foreach (var i in equipments)
      {
         extra += i.extraDef;
         p_extra += i.p_extraDef;
      }

      extra += playerData.def * p_extra;

      return extra;
   }
   public float GetExtraAvd()
   {
      float extra = 0;
      float p_extra = 0;
      foreach (var i in equipments)
      {
         extra += i.extraAvd;
         p_extra += i.p_extraAvd;
      }

      extra += playerData.avd * p_extra;

      return extra;
   }
}
