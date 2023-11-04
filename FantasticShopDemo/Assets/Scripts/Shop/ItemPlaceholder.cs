using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPlaceholder : MonoBehaviour
{
    [SerializeField]
    Image iconPlaceholder;
    [SerializeField]
    private TextMeshProUGUI text;
    public IInventoryItem wearable;

    public void AddItem(IInventoryItem item)
    {
        wearable = item;
        text.text = item.GetItemName();
        iconPlaceholder.sprite = item.GetIcon();

    }
    
    
}
