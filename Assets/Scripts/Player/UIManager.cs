using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public uint InventorySize { get; } = 5;

    [SerializeField]
    private Image[] _inventoryImages;

    [SerializeField]
    private Text[] _inventoryDurabilities;

    public void OnUIRefresh(ItemSO[] inventory)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (inventory[i] == null)
            {
                _inventoryImages[i].sprite = null;
                _inventoryImages[i].color = Color.white;
                _inventoryDurabilities[i].text = string.Empty;
            }
            else
            {
                _inventoryImages[i].sprite = inventory[i].icon;
                _inventoryImages[i].color = inventory[i].tilt;
                _inventoryDurabilities[i].text = inventory[i].durability.ToString();
            }
        }
    }
}
