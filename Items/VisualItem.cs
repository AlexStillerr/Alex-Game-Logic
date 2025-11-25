using System;
using UnityEngine;

namespace AGL.Items
{
    public class VisualItem : MonoBehaviour
    {
        [SerializeField]
        private ItemObject itemObj;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Item itemInstance;
        private Sprite usedSprite;
        public Item GetItemInstance() => itemInstance;

        void Start()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();

            if(itemObj != null)
                SetupItem(itemObj.CreateInstance(), itemObj.GetSprite());
        }

        private void SetupItem(Item item, Sprite sprite)
        {
            itemInstance = item;
            if(sprite != null)
                usedSprite = sprite;

            if (spriteRenderer != null && usedSprite != null)
                spriteRenderer.sprite = usedSprite;
        }

        public void SetupFromOutside(Item item, Sprite sprite)
        {
            SetupItem(item, sprite);
        }
    }
}