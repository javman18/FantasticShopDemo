using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "OutfitData", menuName = "Outfit Data")]
public class OutfitData : ScriptableObject
{
    public Sprite[] idleSprites;
    public Sprite[] walkUpSprites;
    public Sprite[] walkDownSprites;
    public Sprite[] walkLeftSprites;
    public Sprite[] walkRightSprites;
}
