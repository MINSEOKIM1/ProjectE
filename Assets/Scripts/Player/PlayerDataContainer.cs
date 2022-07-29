using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// PlayerData로 받은 데이터를 처리(아이템 효과, 버프 효과 등 적용)하는 역할.
// Container가 아니라 Processor라고 했어야 했는데...
public class PlayerDataContainer : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterData characterData;

    public Sprite playerImage;
    
    public String characterName;
    
    // 스탯들
    public float hp, maxHp, mp, maxMp, speed, jumpPower;
    public float extraHp, extraMp, extraSpeed, extraJumpPower;

    public float ad, ap, def, avd;
    public float extraAd, extraAp, extraDef, extraAvd;
    
    // 스킬 관련
    public float coolTimeRed; // 쿨타임 감소 [0, 0.5]
    
    public List<float> finalCoolTimes;
    public List<Sprite> skillImages;
    public List<int> skillNums;
    
    // 원정대 정보 (원정대 공동 버프, 원정대 공유 아이템 등)
    
    [SerializeField] private ExpeditionManaging _expeditionManaging;
    
    private void Start()
    {
        finalCoolTimes = playerData.skillCoolTimes.ToList();
        skillImages = playerData.skillImages.ToList();
        skillNums = playerData.skillNums.ToList();

        _expeditionManaging = transform.parent.GetComponent<ExpeditionManaging>();
    }

    private void Update()
    {
        UpdateData();
    }
    public void UpdateData()
    {
        if (_expeditionManaging == null) _expeditionManaging = transform.parent.GetComponent<ExpeditionManaging>();
        
        if (finalCoolTimes.Count == 0) finalCoolTimes = characterData.playerData.skillCoolTimes.ToList();
        if (skillImages.Count == 0) skillImages = characterData.playerData.skillImages.ToList();
        if (skillNums.Count == 0) skillNums = characterData.playerData.skillNums.ToList(); 
        
        playerImage = characterData.playerData.characterImage;
        characterName = characterData.playerData.characterName;
        
        maxHp = characterData.playerData.hp + extraHp;
        maxMp = characterData.playerData.mp + extraMp;
        speed = characterData.playerData.speed + extraSpeed;
        jumpPower = characterData.playerData.jumpPower + extraJumpPower;

        // 버프 + 아이템 효과 적용
        ad = characterData.playerData.ad + characterData.GetExtraAd() + _expeditionManaging.extraAd;
        ap = characterData.playerData.ap + characterData.GetExtraAp() + _expeditionManaging.extraAp;
        def = characterData.playerData.def + characterData.GetExtraDef() + _expeditionManaging.extraDef;
        avd = characterData.playerData.avd + characterData.GetExtraAvd() + _expeditionManaging.extraAvd;

        for (int i = 0; i < characterData.playerData.skillNums.Count; i++)
        {
            finalCoolTimes[i] = characterData.playerData.skillCoolTimes[i] * (1 - coolTimeRed);
            skillImages[i] = characterData.playerData.skillImages[i];
        }
    }
}
