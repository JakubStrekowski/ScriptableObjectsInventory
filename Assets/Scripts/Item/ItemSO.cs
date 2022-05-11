using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public new string name = "Default Item";
    public Sprite icon;
    public Color tilt = new Color(1,1,1);
    public int baseCost = 10;
    public float durability = 100;
}
