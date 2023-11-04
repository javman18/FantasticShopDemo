using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPlaceholder : MonoBehaviour
{
    [SerializeField]
    Image iconPlaceholder;
    public IInventoryItem wearable;

    public void AddItem(IInventoryItem item)
    {
        wearable = item;

        iconPlaceholder.sprite = item.GetIcon();

    }
    
    
}
