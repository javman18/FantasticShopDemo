using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyboardInput : MonoBehaviour, IPlayerInput
{
    public Vector2 GetInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        return new Vector2(horizontalInput, verticalInput);
    }

    
}
