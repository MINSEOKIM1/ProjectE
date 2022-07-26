using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EquipmentData", order = 3)]
public class EquipmentData : ScriptableObject
{
    public Sprite equipmentImage;
    
    public string equipmentName;
    public string equipmentDescription;
    
    public float extraAd, extraAp, extraDef, extraAvd; // 합연산
    public float p_extraAd, p_extraAp, p_extraDef, p_extraAvd; // 곱연산
}
