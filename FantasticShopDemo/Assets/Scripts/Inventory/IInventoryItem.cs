using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string GetItemName();
    Sprite GetIcon();
}

public interface ISpriteProvider 
{ 
    Sprite[] GetIdleSprites();
    Sprite[] GetWalkUpSprites();
    Sprite[] GetWalkDownSprites();
    Sprite[] GetWalkLeftSprites();
    Sprite[] GetWalkRightSprites();

}
