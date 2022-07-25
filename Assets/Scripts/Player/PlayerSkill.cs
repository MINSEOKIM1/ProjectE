using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public void Skill(int n)
    {
        switch (n)
        {
            case 0:
                Skill0();
                break;
            case 1:
                Skill1();
                break;
            case 2:
                Skill2();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Skill0()
    {
        Debug.Log("SKILL0 called!");
    }
    
    public void Skill1()
    {
        Debug.Log("SKILL1 called!");
    }
    
    public void Skill2()
    {
        Debug.Log("SKILL2 called!");
    }
}
