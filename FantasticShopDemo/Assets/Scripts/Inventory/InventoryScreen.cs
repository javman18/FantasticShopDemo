using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum InventoryType{
    Shop,
    Sell,
    Player
}
public class InventoryScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private string textToDisplay;
    [SerializeField]
    private string startText;

    [SerializeField]
    InventoryType type;
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

    private ItemPlaceholder storePlaceholder;
    [SerializeField]
    ScriptableObject[] starterItems;

    [SerializeField]
    private ShopTrigger trigger;

    [SerializeField]
    private OutfitController outfitController;
    [SerializeField]
    private OutfitController hatController;

    public bool isVisible;
    void Awake()
    {
        myInventory.OnItemChangeCallback += UpdateUiInventory;
        startText = textToDisplay;
       
    }
    void Start()
    {
        gameObject.SetActive(false);
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

                if (type == InventoryType.Shop)
                {
                    Buy(tmpPlaceholder);
                }
                else if(type == InventoryType.Sell)
                {
                    Sell(tmpPlaceholder);
                }
                

                
            }
            
            if (!trigger.isInTriggerZone)
            {
                if (outfitController != null)
                {
                    storePlaceholder = tmpPlaceholder;
                    if (tmpPlaceholder.wearable.GetItemType() == "Outfit")
                    {
                        tmpPlaceholder.wearable.Use(EquipOutfit);
                    }
                    else if (tmpPlaceholder.wearable.GetItemType() == "Hat")
                    {
                        tmpPlaceholder.wearable.Use(EquipHat);
                    }
                    
                    
                }
                
            }
            
            
        });
        for (int i = 0; i < myInventory.GetInventoryItems().Count; i++)
        {
            tmpPlaceholder.AddItem(myInventory.GetInventoryItems()[i]);
        }
    }

    public void EquipOutfit()
    {
        outfitController.SetEquippedOutfit((WearableData)storePlaceholder.wearable);

    }

    public void EquipHat()
    {
        hatController.SetEquippedOutfit((WearableData)storePlaceholder.wearable);

    }

    void Buy(ItemPlaceholder item)
    {
        if (TopDownCharacterController.wallet >= item.wearable.GetBuyPrice())
        {
            TopDownCharacterController.wallet -= item.wearable.GetBuyPrice();
            item.gameObject.SetActive(false);
            if (myInventory.GetInventoryItems().Contains(item.wearable))
            {
                myInventory.RemoveItem(item.wearable);
                
            }
            targetInventory.AddItem(item.wearable);
        }
    }

    void Sell(ItemPlaceholder item)
    {
        TopDownCharacterController.wallet += item.wearable.GetSellPrice();
        Debug.Log(targetInventory.GetInventoryItems().Count);
        item.gameObject.SetActive(false);
        if (myInventory.GetInventoryItems().Contains(item.wearable))
        {
            myInventory.RemoveItem(item.wearable);
        }
        if (storePlaceholder != null)
        {
            if (outfitController.EquipedOutfit((WearableData)storePlaceholder.wearable))
            {
                outfitController.equippedWearable = null;
                outfitController.GetComponent<SpriteRenderer>().sprite = null;
            }
            else if (hatController.EquipedOutfit((WearableData)storePlaceholder.wearable))
            {
                hatController.equippedWearable = null;
                hatController.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        targetInventory.AddItem(item.wearable);
        
    }

    
}
