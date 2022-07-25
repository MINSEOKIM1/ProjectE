using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 _moving;

    private ExpeditionManaging _expeditionManaging;
    private PlayerDataContainer _playerDataContainer;
    private PlayerSkill _playerSkill;
    
    public int playerNum;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerDataContainer = GetComponent<PlayerDataContainer>();
        _playerSkill = GetComponent<PlayerSkill>();
        
        _expeditionManaging = transform.parent.gameObject.GetComponent<ExpeditionManaging>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(_moving.x, 0f, 0f) * (Time.deltaTime * _playerDataContainer.speed));
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMove = value.ReadValue<Vector2>();
        _moving = inputMove;
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 0] <= 0)
        {
            _rigidbody2D.AddForce(Vector2.up * _playerDataContainer.jumpPower, ForceMode2D.Impulse);
            _expeditionManaging.CoolTimes[playerNum, 0] = _playerDataContainer.finalCoolTimes[0]; // 쿨타임 적용
            // _jumpAvailable.Value = false;
        }
    }

    public void OnQ(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 0] <= 0 && _playerDataContainer.skillNums.Count >= 1)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[0]);
            _expeditionManaging.CoolTimes[playerNum, 0] = _playerDataContainer.finalCoolTimes[0]; // 쿨타임 적용
        }
    }
    
    public void OnW(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 1] <= 0 && _playerDataContainer.skillNums.Count >= 2)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[1]);
            _expeditionManaging.CoolTimes[playerNum, 1] = _playerDataContainer.finalCoolTimes[1]; // 쿨타임 적용
        }
    }
    
    public void OnE(InputAction.CallbackContext value)
    {
        if (value.started && _expeditionManaging.CoolTimes[playerNum, 2] <= 0 && _playerDataContainer.skillNums.Count >= 3)
        {
            _playerSkill.Skill(_playerDataContainer.skillNums[2]);
            _expeditionManaging.CoolTimes[playerNum, 2] = _playerDataContainer.finalCoolTimes[2]; // 쿨타임 적용
        }
    }
}
