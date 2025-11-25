using System;
using UnityEngine;

namespace AGL.Items
{
    [Serializable]
    public class Item
    {
        private static int TEMP; // No way....
        [SerializeField]
        [HideInInspector]
        private int itemId;
        [SerializeField]
        [HideInInspector]
        private int uniqueId;
        // perhaps later needed
        // private Guid uniqueId;

        [SerializeField]
        protected string name;

        public string Name => name;
        public int ItemType => itemId;
        public int UniqueId => uniqueId;

        public Item(int itemId)
        {
            this.itemId = itemId;
            uniqueId = TEMP;
            TEMP++;
        }

        internal virtual void CopyValues(Item other)
        {
            name = other.name;
        }

        public bool SameType(Item other) => other.itemId == itemId;
        public bool Equals(Item other) => other.uniqueId == uniqueId;
    }
}