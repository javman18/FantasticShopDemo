using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitController : MonoBehaviour
{
    public WearableData equippedWearable;

    private int currentFrame;
    private float timer;
    public float frameRate = .1f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public void SetEquippedOutfit(WearableData data)
    {
        equippedWearable = data;
    }
    public void UpdateOutfitAnimation(string animationState)
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            if (equippedWearable != null)
            {
                currentFrame = (currentFrame + 1) % StateSprites(animationState).Length;
                spriteRenderer.sprite = StateSprites(animationState)[currentFrame];
            }
            
        }
    }

    Sprite[] StateSprites(string animationState)
    {
        ISpriteProvider tmpWearable = GeneralUtilities.Get<ISpriteProvider>(equippedWearable);
        if (tmpWearable != null)
        {
            switch (animationState)
            {
                case "Idle":
                    return tmpWearable.GetIdleSprites();
                case "WalkUp":
                    return tmpWearable.GetWalkUpSprites();
                case "WalkDown":
                    return tmpWearable.GetWalkDownSprites();
                case "WalkLeft":
                    return tmpWearable.GetWalkLeftSprites();
                case "WalkRight":
                    return tmpWearable.GetWalkRightSprites();
            }
        }
        return null;
    }

    
}

