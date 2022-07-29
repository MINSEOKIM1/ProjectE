using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float lifeTime;
    public float attackTime;
    public Vector2 offset, boxSize, airborne;

    public float damage, stunTime;

    private void Start()
    {
        Invoke("Delete", lifeTime);
        StartCoroutine(Attack(damage, airborne, stunTime));
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube((Vector2) transform.position + offset, boxSize);
    }

    private IEnumerator Attack(float damage, Vector2 airborne, float stunTime)
    {
        yield return new WaitForSeconds(attackTime);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(
            (Vector2)transform.position + offset,
            boxSize, 0);

        foreach (Collider2D item in collider2Ds)
        {
            if (item.tag == "Mob")
            {
                item.gameObject.GetComponent<TestMob>().TakeHit(damage, airborne, stunTime);
            }
        }
    }
    
    private void Delete()
    {
        Destroy(gameObject);
    }
}
