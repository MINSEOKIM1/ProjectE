using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Buffdata", order = 5)]
// 기본적인 스탯들... 아이템의 효과는 적용되지 않음.
public class Buffdata : ScriptableObject
{
    public string buffName;

    public Sprite buffImage;
    
    public float extraAd, extraAp, extraDef, extraAvd; // 합연산
    public float p_extraAd, p_extraAp, p_extraDef, p_extraAvd; // 곱연산

    public float lifeTime;
}
