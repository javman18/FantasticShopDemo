using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitController : MonoBehaviour
{
    public WearableData wearable;

    private int currentFrame;
    private float timer;
    public float frameRate = .1f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    public void SetOutfit(string animationState)
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            if (wearable != null)
            {
                currentFrame = (currentFrame + 1) % StateSprites(animationState).Length;
                spriteRenderer.sprite = StateSprites(animationState)[currentFrame];
            }
            
        }
    }

    Sprite[] StateSprites(string animationState)
    {
        ISpriteProvider tmpWearable = Get<ISpriteProvider>();
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

    public T Get<T>()
    {
        if (wearable is T interfaceType)
            return interfaceType;
        return default(T);
    }
}

