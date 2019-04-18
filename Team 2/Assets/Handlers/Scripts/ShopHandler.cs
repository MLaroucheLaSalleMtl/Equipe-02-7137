using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 18 AVR 2019
/// @description Handles everything related to shops
/// </summary>
public class ShopHandler : MonoBehaviour
{

    public Image sellingIcon;
    public Text sellingCost;
    public bool IsShopping = false;
    public Transform shopParentObject;
    InventorySlot[] shopSlots;
    ItemData sellingItem;
    GameManager manager;
    MenuNavigator navigator;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        navigator = FindObjectOfType<MenuNavigator>();
        shopSlots = shopParentObject.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateShopUI()
    {
        for (int index = 0; index < shopSlots.Length; index++)
        {
            if (index < manager.player.PlayerInventory.items.Count)
            {
                shopSlots[index].AddItem(manager.player.PlayerInventory.items[index]);
            }
            else
            {
                shopSlots[index].ClearSlot();
            }
        }
    }

    public void SelectItem (ItemData item)
    {
        sellingItem = item;
        sellingIcon.sprite = sellingItem.icon;
        sellingIcon.enabled = true;
        sellingCost.text = $"{sellingItem.value} $";
    }

    public void OpenShop ()
    {
        navigator.SelectPanel("Shop");
        IsShopping = true;
        UpdateShopUI();
    }

    public void CloseShop ()
    {
        navigator.ReturnToPrevPanel();
        IsShopping = false;
    }

    public void SellItemClick()
    {
        SellItem();
    }

    public void SellItem ()
    {
        if (sellingItem == null || !manager.player.PlayerInventory.items.Contains(sellingItem) || !IsShopping)
        {
            return;
        }
        
        manager.player.Money += sellingItem.value;
        manager.player.PlayerInventory.Remove(sellingItem);
        sellingItem = null;
        sellingIcon.enabled = false;
        sellingIcon.sprite = null;
        sellingCost.text = " ";
        manager.playerHandler.UpdatePlayerBarUI();
        UpdateShopUI();
    }

}
