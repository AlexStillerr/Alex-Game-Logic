using AGL.MessageSystem;

namespace AGL.Items
{
    public class CollectItemAction : IAction
    {
        public int ItemId { get; private set; }
        public CollectItemAction(int itemId)
        {
            ItemId = itemId;
        }
    }
}
