using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemData;

    [SerializeField]
    private SpriteRenderer sr;

    public void InitItemData()
    {
        sr.sprite = itemData.icon;
        sr.color = itemData.tilt;
    }
}
