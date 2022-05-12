using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyLogic : MonoBehaviour
{
    public enum EnemyLogicStates
    {
        Idle,
        Follow,
        Attack
    }
    private readonly float MOVE_SPEED = 4f;


    public float attackRange = 8f;
    public float attackCooldown = 1.5f;
    public ItemSO[] inventory;
    public ItemSO equippedWeapon;

    [SerializeField]
    private GameObject _itemShell;

    [SerializeField]
    private GameObject _projectile;

    private EnemyLogicStates _currentState = EnemyLogicStates.Idle;
    private Transform _target;
    private bool _isAttackReady;

    private void Start()
    {
        _isAttackReady = true;
        inventory = ItemFactory.GetRandomInventory();
        equippedWeapon = ItemSO.CreateInstance(equippedWeapon);
        equippedWeapon.durability = Random.Range(40, 101);
        Debug.Log("Equipped weapon with " + equippedWeapon.durability + "durability");
    }
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

                if (Vector2.Distance(_target.position, transform.position) < attackRange)
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

                if (Vector2.Distance(_target.position, transform.position) >= attackRange)
                {
                    _currentState = EnemyLogicStates.Follow;
                    return;
                }

                if (IsAbleToAttack())
                {
                    StartCoroutine(nameof(Attack));
                }

                transform.up = _target.position - transform.position;
                break;
        }
    }

    public void SetFollowObject(Transform transform)
    {
        _target = transform;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Deadly")
        {
            DropItems();
            Destroy(gameObject);
        }
    }

    private bool IsAbleToAttack()
    {
        if (equippedWeapon == null)
        {
            return false;
        }
        if (equippedWeapon.durability <= 0 ||
            !_isAttackReady)
        {
            return false;
        }
        return true;
    }
    private IEnumerator Attack()
    {
        _isAttackReady = false;

        Instantiate(_projectile, transform.position, transform.rotation);

        equippedWeapon.OnItemUsed();
        if (equippedWeapon.durability == 0)
        {
            equippedWeapon = null;
        }

        yield return new WaitForSeconds(attackCooldown);
        _isAttackReady = true;
    }

    private void DropItems()
    {
        foreach (ItemSO itemData in inventory)
        {
            GameObject droppedItem = Instantiate(
                _itemShell,
                transform.position,
                Quaternion.identity);

            droppedItem.GetComponent<Item>().itemData = itemData;
            droppedItem.GetComponent<Item>().InitItemData();
        }

        if (equippedWeapon != null)
        {
            GameObject droppedItem = Instantiate(
                _itemShell,
                transform.position,
                Quaternion.identity);

            droppedItem.GetComponent<Item>().itemData = equippedWeapon;
            droppedItem.GetComponent<Item>().InitItemData();
            Debug.Log("Dropped weapon with " + equippedWeapon.durability + "durability");
        }
    }
}
