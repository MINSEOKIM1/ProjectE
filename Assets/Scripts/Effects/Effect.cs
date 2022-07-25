using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float lifeTime;

    private void Start()
    {
        Invoke("Delete", lifeTime);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
