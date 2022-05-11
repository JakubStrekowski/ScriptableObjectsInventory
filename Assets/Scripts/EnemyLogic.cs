using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public enum EnemyLogicStates
    {
        Idle,
        Follow,
        Attack
    }

    private readonly float MOVE_SPEED = 4f;

    public float ATTACK_RANGE = 8f;

    private EnemyLogicStates _currentState = EnemyLogicStates.Idle;
    private Transform _target;

    private void Update()
    {
        switch (_currentState)
        {
            default:
            case EnemyLogicStates.Idle:
                if (_target != null)
                {
                    _currentState = EnemyLogicStates.Follow;
                    return;
                }
                break;
            case EnemyLogicStates.Follow:
                if (_target == null)
                {
                    _currentState = EnemyLogicStates.Idle;
                    return;
                }

                if (Vector2.Distance(_target.position, transform.position) < ATTACK_RANGE)
                {
                    _currentState = EnemyLogicStates.Attack;
                    return;
                }

                transform.up = _target.position - transform.position;
                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    _target.position,
                    MOVE_SPEED * Time.deltaTime);
                break;
            case EnemyLogicStates.Attack:
                if (_target == null)
                {
                    _currentState = EnemyLogicStates.Idle;
                    return;
                }

                if (Vector2.Distance(_target.position, transform.position) >= ATTACK_RANGE)
                {
                    _currentState = EnemyLogicStates.Follow;
                    return;
                }

                transform.up = _target.position - transform.position;
                break;
        }
    }

    public void SetFollowObject(Transform transform)
    {
        _target = transform;
    }

    public void OnMouseDown()
    {
        //TODO drop items here
        Debug.Log("death");
        Destroy(gameObject);
    }
}
