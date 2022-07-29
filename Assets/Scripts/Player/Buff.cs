using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public Buffdata Buffdata;
    public bool isAvailable;

    public Buff(Buffdata bd)
    {
        Buffdata = bd;
        isAvailable = true;
    }
}
