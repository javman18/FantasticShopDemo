using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField]
    InventoryScreen inventoryUI;

    public static int wallet = 100;
    public TextMeshProUGUI walletText;

    Vector2 input;
    private void Update()
    {
        walletText.text = wallet.ToString();
        input = inputSource.GetInput();
        movement.Move(input);

        playerAnimator.SetFloat("Horizontal", input.x);
        playerAnimator.SetFloat("Vertical", input.y);
        playerAnimator.SetFloat("Speed", input.sqrMagnitude);
        SetState();
        outfitController.UpdateOutfitAnimation(currentState);
        headwearController.UpdateOutfitAnimation(currentState);
        ShowInventory();
        
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

    public void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryUI.isVisible)
            {
                inventoryUI.SetTextToDisplay("Wear something");
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.SetTextToDisplay("Want to sell something?");
                inventoryUI.Hide();
            }
        }
    }
}
