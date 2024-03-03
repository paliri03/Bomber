using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private ItemPrefab inventoryItemPrefab;
    [SerializeField] private Transform inventoryContent;

    private readonly Dictionary<ItemPrefab, Item> items = new();
    private ItemPrefab activeItem;

    public void InitInventory(List<Item> itemObjects)
    {
        foreach (var item in itemObjects)
        {
            var inventoryItem = Instantiate(inventoryItemPrefab, inventoryContent);
            inventoryItem.SetIcon(item.InventoryIcon);
            inventoryItem.Button.onClick.AddListener(() => ItemClickEvent(inventoryItem));

            items.Add(inventoryItem, item);
        }
    }

    public void DropItem(Vector3 spawnPosition)
    {
        if (activeItem == null)
            return;

        var item = Instantiate(items[activeItem], spawnPosition, Quaternion.identity);
        item.Init();
    }

    public void ItemClickEvent(ItemPrefab inventoryItem)
    {
        if (inventoryItem == activeItem)
            return;
        else
        {
            if(activeItem != null)
                activeItem.SetDefaultColor();

            activeItem = inventoryItem;
            activeItem.SetSelectedColor();
        }
    } 
}
