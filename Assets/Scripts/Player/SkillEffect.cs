using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public int dir;
    public float damage;
    
    public GameObject[] effects;

    public void Skill(int n)
    {
        switch (n)
        {
            case 0:
                StartCoroutine("Attack1");
                break;
            case 1:
                StartCoroutine("Attack3");
                break;
        }
    }
    public IEnumerator Attack1()
    {
        for (int i = 0; i < 4; i++)
        {
            var effect = GameObject.Instantiate(effects[0], 
                transform.position + new Vector3((i+1) * 5, dir * 1, 0) * dir,
                Quaternion.identity);
            effect.GetComponent<Effect>().damage = damage;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public IEnumerator Attack3()
    {
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

                    var effect = GameObject.Instantiate(effects[1], hitPos, Quaternion.identity);
                    effect.GetComponent<Effect>().damage = damage;
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
