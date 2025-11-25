using System;
using System.Collections.Generic;
using UnityEngine;

namespace AGL.Items
{

    [Serializable]
    public class Loot
    {
        [Range(0f, 100f)]
        public float spawnPercent = 50f;
        public ItemObject item;
    }

    [Serializable]
    public class LootTable : IsCollectionOfItems
    {
        public List<Loot> itemList;

        public bool Contains(Item item, out ItemObject obj)
        {
            throw new NotImplementedException();
        }

        public Item GetItem()
        {
            throw new NotImplementedException();
        }
    }
}
