using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    Consumable,
    Equippable,
    Wearable
}

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public new string name = "Default Item";
    public EItemType type;
    public Sprite icon;
    public Color tilt = new Color(1,1,1);
    public int baseCost = 10;
    public float durability = 100;
    public float durabilityPerUse = 10;

    public void OnItemUsed()
    {
        durability -= durabilityPerUse;
        if (durability < 0) durability = 0; 
    }
}
