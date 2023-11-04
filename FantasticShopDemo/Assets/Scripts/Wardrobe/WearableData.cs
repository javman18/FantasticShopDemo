using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "WearableData", menuName = "Wearable Data")]
public class WearableData : ScriptableObject, IInventoryItem, ISpriteProvider
{
    public Sprite[] idleSprites;
    public Sprite[] walkUpSprites;
    public Sprite[] walkDownSprites;
    public Sprite[] walkLeftSprites;
    public Sprite[] walkRightSprites;
    public string wearableType;
    public string itemName;
    public Sprite icon;
    public int buyPrice;
    public int sellPrice;


    public Sprite GetIcon()
    {
        return icon;
    }

    public Sprite[] GetIdleSprites()
    {
        return idleSprites;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemType()
    {
        return wearableType;
    }

    public int GetBuyPrice()
    {
        return buyPrice;
    }

    public Sprite[] GetWalkDownSprites()
    {
        return walkDownSprites;
    }

    public Sprite[] GetWalkLeftSprites()
    {
        return walkLeftSprites;
    }

    public Sprite[] GetWalkRightSprites()
    {
        return walkRightSprites;
    }

    public Sprite[] GetWalkUpSprites()
    {
        return walkUpSprites;
    }

    public void Use(UnityAction action)
    {
        action?.Invoke();
    }

    public int GetSellPrice()
    {
        return sellPrice;
    }
}
