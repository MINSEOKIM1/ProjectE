using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private Vector2 _moving;

    private float _attackTime;

    private Rigidbody2D _rigidbody2D;
    private ExpeditionManaging _expeditionManaging;
    private PlayerDataContainer _playerDataContainer;
    private PlayerSkill _playerSkill;
    private Animator _animator;

    public int playerNum;

    private void Start()
    {
        _attackTime = 0f;
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _expeditionManaging = transform.parent.gameObject.GetComponent<ExpeditionManaging>();
        _playerDataContainer = GetComponent<PlayerDataContainer>();
        _playerSkill = GetComponent<PlayerSkill>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _attackTime -= Time.deltaTime;
        if (_attackTime < 0) _attackTime = 0;
        if (_attackTime == 0)
        transform.Translate(new Vector3(_moving.x, 0f, 0f) * (Time.deltaTime * _playerDataContainer.speed)); // 이동 적용
        
        if (_rigidbody2D.velocity.y != 0)
        {
            _animator.SetBool("isJump", true); 
        }
        _animator.SetBool("isRun", _moving.x != 0);
        if (_moving.x * transform.localScale.x < 0 && _attackTime == 0)
            transform.localScale
                = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMove = value.ReadValue<Vector2>();
        _moving = inputMove;
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started && _attackTime == 0)
        {
            if (!_animator.GetBool("isJump"))
                _rigidbody2D.AddForce(Vector2.up * _playerDataContainer.jumpPower, ForceMode2D.Impulse);
        }
    }

    public void OnQ(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 0] <= 0 &&
            _playerDataContainer.skillNums.Count >= 1 && _attackTime == 0)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[0]);
            _expeditionManaging.CoolTimes[playerNum, 0] = _playerDataContainer.finalCoolTimes[0]; // 쿨타임 적용
        }
    }

    public void OnW(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 1] <= 0 &&
            _playerDataContainer.skillNums.Count >= 2 && _attackTime == 0)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[1]);
            _expeditionManaging.CoolTimes[playerNum, 1] = _playerDataContainer.finalCoolTimes[1]; // 쿨타임 적용
        }
    }

    public void OnE(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 2] <= 0 &&
            _playerDataContainer.skillNums.Count >= 3 && _attackTime == 0)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[2]);
            _expeditionManaging.CoolTimes[playerNum, 2] = _playerDataContainer.finalCoolTimes[2]; // 쿨타임 적용
        }
    }

    public void OnAttack(float attackTime)
    {
        _attackTime = attackTime;
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