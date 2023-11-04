using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public bool CanBuy(IInventoryItem item)
    {
        if (TopDownCharacterController.wallet >= item.GetBuyPrice())
        {
            return true;
        }
        return false;
    }
}
