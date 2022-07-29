using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator _animator;
    private PlayerBehavior _playerBehavior;
    private PlayerDataContainer _playerDataContainer;

    public Vector2 boxOffset, boxSize;

    public GameObject effect0;
    public GameObject effect1;
    public GameObject effect2;

    public float optionDamage;

    public ExpeditionManaging ExpeditionManaging;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerBehavior = GetComponent<PlayerBehavior>();
        _playerDataContainer = GetComponent<PlayerDataContainer>();
        
        ExpeditionManaging = transform.parent.GetComponent<ExpeditionManaging>();
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
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxOffset, boxSize);
    }


    private void AttackBoundaryCheck(Vector2 offset, Vector2 boxSize, float damage, Vector2 airborne, float stunTime)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(
            (Vector2)gameObject.transform.position + offset,
            boxSize, 0);

        foreach (Collider2D item in collider2Ds)
        {
            if (item.tag == "Mob")
            {
                item.gameObject.GetComponent<TestMob>().TakeHit(damage, airborne, stunTime);
            }
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
        yield return new WaitForSeconds(20 / 60f);
        AttackBoundaryCheck(new Vector2(7.4f * transform.localScale.x, 7.4f), new Vector2(10, 7),
            _playerDataContainer.ad, Vector2.up * 10, 0);

        
    }
    
    public IEnumerator Attack1()
    {
        _playerBehavior.OnAttack(28 / 60f);
        _animator.SetTrigger("attack");

        Vector3 pos = transform.position;
        float dir = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        yield return new WaitForSeconds(0.3f);
        ExpeditionManaging.AddBuff(0);
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
        ExpeditionManaging.AddBuff(1);
        
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 4; i++)
        {
            AttackBoundaryCheck(new Vector2(0, 2.5f), new Vector2(20, 20),
                _playerDataContainer.ap * 1.5f, Vector2.up * 14, 3);
            yield return new WaitForSeconds(0.1f);
        }

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
        ExpeditionManaging.AddBuff(2);
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
