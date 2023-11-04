using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public WearableData wearable;

    private InventoryController inventoryController;


    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }
    
    public void OnItemClick()
    {
       
        inventoryController.AddItem(wearable);
        gameObject.SetActive(false);
    }
}
