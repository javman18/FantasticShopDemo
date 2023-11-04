using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private Transform contentHolder;
    [SerializeField] 
    private InventoryController myInventory;

    [SerializeField]
    private ItemPlaceholder placeHolderPrefab;

    [SerializeField]
    ScriptableObject[] starterItems;

    void Awake()
    {
        Debug.Log("ffff");
        myInventory.OnItemChangeCallback += UpdateUiInventory;
    }
    void Start()
    {
        Debug.Log("jjjj");

        for (int i = 0; i < starterItems.Length; i++)
        {
            IInventoryItem itemToAdd = (IInventoryItem)starterItems[i];
            
            myInventory.AddItem(itemToAdd);
            
        }
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            myInventory.AddItem((IInventoryItem)starterItems[0]);
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    void UpdateUiInventory()
    {
        ItemPlaceholder tmpPlaceholder = Instantiate(placeHolderPrefab, contentHolder);
        for (int i = 0; i < myInventory.GetInventoryItems().Count; i++)
        {
            tmpPlaceholder.AddItem(myInventory.GetInventoryItems()[i]);
        }
    }
}
