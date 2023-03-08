using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 2f;

    private void Update()
    {
        FindItem();
    }

    private void FindItem()
    {
        ItemMap itemMap = ItemMapManager.Instance.findItemMap(transform.position, pickUpRange);
        if (itemMap != null)
        {
            PickUp(itemMap);
        }
    }

    private void PickUp(ItemMap itemMap)
    {
        switch(itemMap.itemDetails.itemType)
        {
            case ItemType.Energy:
                PickUpEnegy(itemMap);
                break;

            default:
                break;
        }

        ItemMapManager.Instance.RemoveItemMap(itemMap);
    }

    private void PickUpEnegy(ItemMap itemMap)
    {
        int energy;
        switch(itemMap.itemDetails.itemLevel)
        {
            case 1:
                energy = 10;
                break;
            case 2:
                energy = 100;
                break;
            case 3:
                energy = 500;
                break;
            default:
                energy = 0;
                break;
        }
        Player.Instance.score.IncreaseEnergy(energy);
    }
}
