using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    public int itemCode;
    public ItemDetails itemDetails;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(int itemCode)
    {
        this.itemCode = itemCode;
        itemDetails = InventoryManager.Instance.getItemDetails(itemCode);
        if(itemDetails != null)
        {
            spriteRenderer.sprite = itemDetails.itemSprite;
        }
    }
}
