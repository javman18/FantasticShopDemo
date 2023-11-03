using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private KeyboardInput inputSource;

    public Animator playerAnimator;

    [SerializeField]
    private OutfitController outfitController;
    [SerializeField]
    private OutfitController headwearController;
    [SerializeField]
    private string currentState;

    Vector2 input;
    private void Update()
    {
        input = inputSource.GetInput();
        movement.Move(input);

        playerAnimator.SetFloat("Horizontal", input.x);
        playerAnimator.SetFloat("Vertical", input.y);
        playerAnimator.SetFloat("Speed", input.sqrMagnitude);
        SetState();
        outfitController.SetOutfit(currentState);
        headwearController.SetOutfit(currentState);
        //outfitAnimator.SetFloat("Horizontal", input.x);
        //outfitAnimator.SetFloat("Vertical", input.y);
        //outfitAnimator.SetFloat("Speed", input.sqrMagnitude);
    }

    private void SetState()
    {
        if (input == Vector2.zero)
        {
            currentState = "Idle";
        }
        if (input.x > 0)
        {
            currentState = "WalkRight";
        }
        if (input.x < 0)
        {
            currentState = "WalkLeft";
        }
        if (input.y > 0)
        {
            currentState = "WalkUp";
        }
        if (input.y < 0)
        {
            currentState = "WalkDown";
        }
       
    }
}
