using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
// 기본적인 스탯들... 아이템의 효과는 적용되지 않음.
public class PlayerData : ScriptableObject
{
    public string characterName;

    public Sprite characterImage;
    
    public float hp, mp, speed, jumpPower;
    public float ad, ap, def, avd; // 물리 공격, 마법 공격, 방어력, 회피 확률 ([0, 1))
    
    public List<Sprite> skillImages;
    public List<int> skillNums;
    public List<float> skillCoolTimes;
}
