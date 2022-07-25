using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMob : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody2D;

    private float _stunTime;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        _stunTime -= Time.deltaTime;
        if (_stunTime > 0)
        {
            _animator.SetBool("isStun", true);
            _sprite.color = Color.gray;
        }
        else
        {
            _animator.SetBool("isStun", false);
            _sprite.color = Color.white;
        }

        _animator.SetBool("isJump", _rigidbody2D.velocity.y != 0);
    }

    public void TakeHit(float damage, Vector2 airborne, float stunTime)
    {
        _animator.SetTrigger("hit");
        _rigidbody2D.AddForce(airborne, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _animator.SetBool("isJump", false);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _animator.SetBool("isJump", false);
        }
    }
}
