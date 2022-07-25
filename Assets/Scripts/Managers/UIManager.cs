using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // For Test
    public void AddCharacterToExpedition(int n)
    {
        GameManager.Instance.DataManager.AddCharacterToExpedition(n);
    }
    public void DeleteCharacter()
    {
        GameManager.Instance.DataManager.DeleteExpedition();
    }

    // End

    public void GotoDungeon()
    {
        SceneManager.LoadScene("TestDungeon");
    }
    
    public void GotoMain()
    {
        SceneManager.LoadScene("TestMain");
    }
}
