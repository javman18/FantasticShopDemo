using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInventoryItem
{
    string GetItemType();

    string GetItemName();

    int GetBuyPrice();

    int GetSellPrice();
    Sprite GetIcon();

    void Use(UnityAction action);
}

public interface ISpriteProvider 
{ 
    Sprite[] GetIdleSprites();
    Sprite[] GetWalkUpSprites();
    Sprite[] GetWalkDownSprites();
    Sprite[] GetWalkLeftSprites();
    Sprite[] GetWalkRightSprites();

}
