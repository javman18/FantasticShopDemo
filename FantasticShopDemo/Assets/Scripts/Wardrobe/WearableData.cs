using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WearableData", menuName = "Wearable Data")]
public class WearableData : ScriptableObject, IInventoryItem, ISpriteProvider
{
    public Sprite[] idleSprites;
    public Sprite[] walkUpSprites;
    public Sprite[] walkDownSprites;
    public Sprite[] walkLeftSprites;
    public Sprite[] walkRightSprites;
    public string wearableType;

    public Sprite[] GetIdleSprites()
    {
        return idleSprites;
    }

    public string GetItemName()
    {
        return wearableType;
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
}
