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
    public GameObject effect2;

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
            case 6:
                StartCoroutine(Attack3());
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

    public IEnumerator Attack3()
    {
        _playerBehavior.OnAttack(1f);
        _animator.SetTrigger("cast");

        yield return new WaitForSeconds(0.3f);

        Vector3 target;
        Vector3 hitPos;
        for (int i = 1; i < 10; i++)
        {
            for (int j = -1; j <= 1; j += 2)
            {
                target = transform.position + new Vector3(j*i*5, 30, 0);
                RaycastHit2D hitData = Physics2D.Raycast(target, Vector3.down, Mathf.Infinity, (1 << 6));
                if (hitData)
                {
                    hitPos = hitData.point;

                    var effect = GameObject.Instantiate(effect2, hitPos, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
