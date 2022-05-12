using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ItemSO[] _inventory;

    [SerializeField]
    UIManager _uIManager;

    private void Awake()
    {
        _inventory = new ItemSO[_uIManager.InventorySize];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickable")
        {
            if (TryAddItem(collision.gameObject.GetComponent<Item>().itemData))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private bool TryAddItem(ItemSO newitem)
    {
        for (int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] == null)
            {
                _inventory[i] = newitem;
                _uIManager.OnUIRefresh(_inventory);
                return true;
            }
        }
        return false;

    }    
}
