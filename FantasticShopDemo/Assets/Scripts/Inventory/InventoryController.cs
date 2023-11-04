using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangeCallback;
    [SerializeField]
    private List<IInventoryItem> inventoryItems = new List<IInventoryItem>();

    public void AddItem(IInventoryItem item)
    {
        inventoryItems.Add(item);
        OnItemChangeCallback.Invoke();
    }

    public void RemoveItem(IInventoryItem item)
    {
        inventoryItems.Remove(item);
    }

    public List<IInventoryItem> GetInventoryItems()
    {
        return inventoryItems;
    }
}
