using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator _animator;
    private PlayerBehavior _playerBehavior;

    public GameObject effect0;
    public GameObject effect1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerBehavior = GetComponent<PlayerBehavior>();
    }

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
            case 3:
                StartCoroutine(Attack0());
                break;
            case 4:
                StartCoroutine(Attack1());
                break;
            case 5:
                StartCoroutine(Attack2());
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

    public IEnumerator Attack0()
    {
        _playerBehavior.OnAttack(28 / 60f);
        _animator.SetTrigger("attack");
        yield break;
    }
    
    public IEnumerator Attack1()
    {
        _playerBehavior.OnAttack(28 / 60f);
        _animator.SetTrigger("attack");

        Vector3 pos = transform.position;
        float dir = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 4; i++)
        {
            var effect = GameObject.Instantiate(effect0, 
                pos + new Vector3((i+1) * 5, dir * 1, 0) * dir,
                Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public IEnumerator Attack2()
    {
        _playerBehavior.OnAttack(28 / 60f);
        _animator.SetTrigger("attack");
        
        yield return new WaitForSeconds(0.3f);
        var effect = GameObject.Instantiate(effect1, 
                transform.position + new Vector3(0, 2, 0),
                Quaternion.identity);
    }
}
