using AGL.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AGL.Items
{
    public interface IsCollectionOfItems
    {
        Item GetItem();
        bool Contains(Item item, out ItemObject obj);
    }

    //[Serializable]
    //public class ItemCollection : IsCollectionOfItems
    //{
    //    public List<ItemObject> itemList;


    //}

    [CreateAssetMenu(fileName = "ItemCollection", menuName = MenuPath.ItemPath + "Item Collection", order = 0)]
    public class ItemCollection : ScriptableObject, IsCollectionOfItems
    {
        [SerializeField]
        private List<ItemObject> itemList = new();

        public Item GetItem() => MyRandom.Rand(itemList).CreateInstance();

        public bool Contains(Item item, out ItemObject obj)
        {
            foreach (ItemObject itemObj in itemList)
            {
                if(itemObj.ItemId == item.ItemType)
                {
                    obj = itemObj;
                    return true;
                }
            }
            obj = null;
            return false;
        }
        //    //[SerializeField]
        //    //private List<ItemObject<StackItem>> stackItemList = new();

        //    public string GetItemDescription(string itemName)
        //    {
        //        IDescribable item = GetBaseItemByName(itemName);
        //        if (item != null)
        //            return item.GetDescription();

        //        return "";
        //    }

        //    public string GetItemDescription(Item itemToGrab)
        //    {
        //        IInstanceCreator<Item> item = GetBaseItemByItem(itemToGrab);
        //        if (item != null && item is IDescribable describable)
        //            return describable.GetDescription();

        //        return "";
        //    }

        //    public IDescribable GetBaseItemByName(string itemName)
        //    {
        //        return GetBaseItemByString(itemName) as IDescribable;
        //    }

        //    public CollectableItem GetCollectableItem(Item item)
        //    {
        //        return GetBaseItemByItem(item) as CollectableItem;
        //    }

        //    private IInstanceCreator<Item> GetBaseItemByItem(Item itemToGrab)
        //    {
        //        var itemListItem = SearchListById<Item>(itemList, itemToGrab);
        //        if (itemListItem != null)
        //            return itemListItem;
        //        var itemListItem2 = SearchListById<StackItem>(stackItemList, itemToGrab);
        //        if (itemListItem2 != null)
        //            return itemListItem2;
        //        return null;
        //    }

        //    private IInstanceCreator<Item> GetBaseItemByString(string itemName)
        //    {
        //        var itemListItem = SearchListByName<Item>(itemList, itemName);
        //        if (itemListItem != null)
        //            return itemListItem;
        //        var itemListItem2 = SearchListByName<StackItem>(stackItemList, itemName);
        //        if (itemListItem2 != null)
        //            return itemListItem2;
        //        return null;
        //    }

        //    private ItemObject<T> SearchListById<T>(List<ItemObject<T>> list, Item itemToGrab) where T : Item
        //    {
        //        foreach (ItemObject<T> item in list)
        //            if (item.ItemId == itemToGrab.ItemId)
        //                return item;

        //        return null;
        //    }
        //    private ItemObject<T> SearchListByName<T>(List<ItemObject<T>> list, string itemName) where T : Item
        //    {
        //        foreach (ItemObject<T> item in list)
        //            if (item.GetName().Equals(itemName))
        //                return item;

        //        return null;
        //    }

    }
}