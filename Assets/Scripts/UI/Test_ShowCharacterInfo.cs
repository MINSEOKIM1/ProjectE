using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test_ShowCharacterInfo : MonoBehaviour
{
    public Image characterImage;
    public List<Image> equipmentImages;
    public TMP_Text description;

    public Sprite nullSprite;

    public int currentCharacterNum;

    public void ShowCharacter(int n)
    {
        if (n >= GameManager.Instance.DataManager.expeditionData.Count) return;
        currentCharacterNum = n;
        Debug.Log(n);
        
        characterImage.sprite = GameManager.Instance.DataManager.expeditionData[n].playerData.characterImage;
        Debug.Log( GameManager.Instance.DataManager.expeditionData[n].equipments.Count);
        for (int i = 0; i < GameManager.Instance.DataManager.expeditionData[n].equipments.Count; i++)
        {
            equipmentImages[i].sprite = GameManager.Instance.DataManager.expeditionData[n].equipments[i].equipmentData
                .equipmentImage;
        }
        for (int i = GameManager.Instance.DataManager.expeditionData[n].equipments.Count; i < 4; i++)
        {
            equipmentImages[i].sprite = nullSprite;
        }
    }

    public void AddEquipment(int n)
    {
        GameManager.Instance.DataManager.expeditionData[currentCharacterNum].AddEquipment(n);
    }
}
