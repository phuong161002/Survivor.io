using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMapManager : SingletonMonobehavior<ItemMapManager>
{
    private List<ItemMap> itemMapList;

    protected override void Awake()
    {
        base.Awake();

        itemMapList = new List<ItemMap>();
    }

    private void Start()
    {
        itemMapList.Clear();
    }

    public ItemMap CreateItemMap(Vector2 position, int itemCode)
    {
        GameObject gO = PoolManager.Instance.ReuseObject(GameAssets.Instance.itemMapPrefab, position, Quaternion.identity);
        ItemMap itemMap = gO.GetComponent<ItemMap>();
        itemMap.Setup(itemCode);
        itemMapList.Add(itemMap);
        gO.SetActive(true);
        return itemMap;
    }

    public void RemoveItemMap(ItemMap itemMap)
    {
        itemMapList.Remove(itemMap);
        itemMap.gameObject.SetActive(false);
    }

    public ItemMap findItemMap(Vector2 position, float radius)
    {
        return itemMapList.Find(i => Vector2.Distance(position, i.transform.position) <= radius);
    }
}
