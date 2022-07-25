using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment
{
    public EquipmentData equipmentData;
    
    public float extraAd, extraAp, extraDef, extraAvd; // 합연산
    public float p_extraAd, p_extraAp, p_extraDef, p_extraAvd; // 곱연산

    public Equipment(EquipmentData ed)
    {
        equipmentData = ed;
        
        extraAd = equipmentData.extraAd;
        extraAp = equipmentData.extraAp;
        extraDef = equipmentData.extraDef;
        extraAvd = equipmentData.extraAvd;
    }
}
