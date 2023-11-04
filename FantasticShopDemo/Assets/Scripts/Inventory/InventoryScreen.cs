using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private string textToDisplay;
    [SerializeField]
    private string startText;

    [SerializeField]
    private TextMeshProUGUI textPlaceholder;
    [SerializeField]
    private Transform contentHolder;
    [SerializeField] 
    private InventoryController myInventory;
    [SerializeField]
    private InventoryController targetInventory;
    [SerializeField]
    private ItemPlaceholder placeHolderPrefab;

    [SerializeField]
    ScriptableObject[] starterItems;

    [SerializeField]
    public ShopTrigger trigger;

    public bool isVisible;
    void Awake()
    {
        startText = textToDisplay;
        myInventory.OnItemChangeCallback += UpdateUiInventory;
    }
    void Start()
    {
        
        for (int i = 0; i < starterItems.Length; i++)
        {
            IInventoryItem itemToAdd = (IInventoryItem)starterItems[i];
            
            myInventory.AddItem(itemToAdd);
            
        }
        
    }
    public void Hide()
    {
        textToDisplay = startText;
        isVisible = false;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        textPlaceholder.text = textToDisplay;
        isVisible = true;
        gameObject.SetActive(true);
    }

    public void SetTextToDisplay(string text)
    {
        textToDisplay = text;
    }

    void UpdateUiInventory()
    {
        ItemPlaceholder tmpPlaceholder = Instantiate(placeHolderPrefab, contentHolder);
        
        tmpPlaceholder.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (trigger.isInTriggerZone)
            {
                targetInventory.AddItem(tmpPlaceholder.wearable);
            }
            tmpPlaceholder.gameObject.SetActive(false);
            if (myInventory.GetInventoryItems().Contains(tmpPlaceholder.wearable))
            {
                myInventory.RemoveItem(tmpPlaceholder.wearable);
            }
            
        });
        for (int i = 0; i < myInventory.GetInventoryItems().Count; i++)
        {
            tmpPlaceholder.AddItem(myInventory.GetInventoryItems()[i]);
        }
    }

    public void OnItemClick()
    {

        
    }
}
