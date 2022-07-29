using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    void Start()
    {
        Debug.Log("ADSG");
        GameManager.Instance.UIManager.PauseWindow = gameObject;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.UIManager.PauseWindow = gameObject;
    }
}
