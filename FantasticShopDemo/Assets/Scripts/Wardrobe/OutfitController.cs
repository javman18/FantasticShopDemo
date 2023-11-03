using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitController : MonoBehaviour
{
    public OutfitData currentOutfit;

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
            currentFrame = (currentFrame + 1) % StateSprites(animationState).Length;
            spriteRenderer.sprite = StateSprites(animationState)[currentFrame];
        }
    }

    Sprite[] StateSprites(string animationState)
    {
        if (currentOutfit != null)
        {
            switch (animationState)
            {
                case "Idle":
                    return currentOutfit.idleSprites;
                case "WalkUp":
                    return currentOutfit.walkUpSprites;
                case "WalkDown":
                    return currentOutfit.walkDownSprites;
                case "WalkLeft":
                    return currentOutfit.walkLeftSprites;
                case "WalkRight":
                    return currentOutfit.walkRightSprites;
            }
        }
        return null;
    }
}

