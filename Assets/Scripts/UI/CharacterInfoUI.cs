using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class CharacterInfoUI : MonoBehaviour
{
    public ExpeditionManaging ExpeditionManaging;
    
    public GameObject player;

    public Slider hpBar, mpBar;
    public Image playerImage;
    public Image[] SkillImages;
    public Image[] SkillCoolTimeImages;

    private void FixedUpdate()
    {
        for (int i = 0; i < player.GetComponent<PlayerDataContainer>().skillImages.Count; i++)
        {
            SkillCoolTimeImages[i].fillAmount 
                = ExpeditionManaging.CoolTimes[player.GetComponent<PlayerBehavior>().playerNum, i]/player.GetComponent<PlayerDataContainer>().finalCoolTimes[i];
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerDataContainer playerDataContainer = player.GetComponent<PlayerDataContainer>();
        
        playerImage.sprite = playerDataContainer.playerImage;
        
        for (int i = 0; i < playerDataContainer.skillImages.Count; i++)
        {
            SkillImages[i].transform.parent.parent.gameObject.SetActive(true);
            SkillImages[i].sprite = playerDataContainer.skillImages[i];
        }

        if (SkillImages.Length > playerDataContainer.skillImages.Count)
        {
            for (int i = playerDataContainer.skillImages.Count; i < SkillImages.Length; i++)
            {
                SkillImages[i].transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }
}
