using System;
using UnityEngine;

namespace AGL.Items
{    
    public static class MenuPath
    {
        public const string ItemPath = "Items/";
    }

    public abstract class ItemObjectBase<T> : ScriptableObject, IDescribable, IInstanceCreator<T> where T : Item
    {
        [SerializeField]
        protected T item;

        [SerializeField]
        protected string description;

        [SerializeField]
        protected Sprite icon;

        public int ItemId => GetInstanceID();
        public virtual string GetDescription()
        {
            //return string.Format("<color=#{0}>{1}</color>", color, Title);
            return $"{GetName()} {description}";
        }

        public T CreateInstance()
        {
            T newInstance = Activator.CreateInstance(typeof(T), GetInstanceID()) as T;
            newInstance.CopyValues(item);
            return newInstance;
        }

        public string GetName() => item.Name;
    }


    [CreateAssetMenu(fileName = "Item", menuName = MenuPath.ItemPath + "Item Object", order = 0)]
    public class ItemObject : ItemObjectBase<Item>
    {
        public Sprite GetSprite() => icon;
    }
}