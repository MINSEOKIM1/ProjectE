using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_CharacterImage : MonoBehaviour
{
    public int n;
    void Update()
    {
        if (GameManager.Instance.DataManager.expedition.Count <= n)
        {
            GetComponent<Image>().sprite = null;
            return;
        }
        GetComponent<Image>().sprite = GameManager.Instance.DataManager.expedition[n].GetComponent<PlayerDataContainer>().playerData.characterImage;
    }
}
