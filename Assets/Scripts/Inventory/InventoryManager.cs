using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehavior<InventoryManager>
{
    [SerializeField] private SO_ItemList so_ItemList;

    public ItemDetails getItemDetails(int itemCode)
    {
        foreach(ItemDetails itemDetails in so_ItemList.itemDetailsList)
        {
            if (itemDetails.itemCode == itemCode)
            {
                return itemDetails;
            }
        }
        return null;
    }

}
