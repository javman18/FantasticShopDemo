using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string GetItemName();
}

public interface ISpriteProvider 
{ 
    Sprite[] GetIdleSprites();
    Sprite[] GetWalkUpSprites();
    Sprite[] GetWalkDownSprites();
    Sprite[] GetWalkLeftSprites();
    Sprite[] GetWalkRightSprites();

}
