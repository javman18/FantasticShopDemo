using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private KeyboardInput inputSource;

    public Animator animator;

    private void Update()
    {
        Vector2 input = inputSource.GetInput();
        movement.Move(input);

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);

        animator.SetFloat("Speed", input.sqrMagnitude);
    }
}
