using AGL.MessageSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AGL.Items
{
    public class MapItemHandler : MonoBehaviour, IMessageBusInitializer
    {
        [SerializeField]
        ItemCollection itemCollection;
        [SerializeField]
        GameObject itemPrefab;

        List<VisualItem> spawnedItems = new();

        private ActionSubscriber actionSubscriber;

        public void Init(IMessageBus bus)
        {
            actionSubscriber = bus.CreateActionSubscriber();

            actionSubscriber.Add<SpawnItemAction>(SpawnItem)
                        .Add<SpawnItemAtPositionAction>(SpawnItemAtPosition); //Add<CollectItemAction>(CollectItem);
        }

        private void OnDestroy()
        {
            actionSubscriber?.Reset();
        }

        private void SpawnItem(SpawnItemAction message)
        {
            if (itemCollection.Contains(message.Item, out ItemObject obj))
                Spawn(message.Item, obj.GetSprite(), transform.position);
        }

        private void SpawnItemAtPosition(SpawnItemAtPositionAction message)
        {
            if (itemCollection.Contains(message.Item, out ItemObject obj))
                Spawn(message.Item, obj.GetSprite(), message.Position);
        }

        private void Spawn(Item item, Sprite sprite, Vector3 position)
        {
            GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity, transform);
            VisualItem inst = newItem.GetComponent<VisualItem>();
            inst.SetupFromOutside(item, sprite);

            spawnedItems.Add(inst);
        }
    }
}