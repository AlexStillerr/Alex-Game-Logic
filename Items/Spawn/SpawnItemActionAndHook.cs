using AGL.MessageSystem;
using UnityEngine;

namespace AGL.Items
{

    public class SpawnItemAction : IAction
    {
        public Item Item { get; }
        public SpawnItemAction(Item item)
        {
            Item = item;
        }
    }

    public class SpawnItemAtPositionAction : SpawnItemAction
    {
        public Vector3 Position { get; }
        public SpawnItemAtPositionAction(Item item, Vector3 pos) : base(item)  
        { 
            Position = pos;
        }
    }
}
