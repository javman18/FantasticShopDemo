using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private KeyboardInput inputSource;

    private void Update()
    {
        Vector2 input = inputSource.GetInput();
        movement.Move(input);
    }
}
