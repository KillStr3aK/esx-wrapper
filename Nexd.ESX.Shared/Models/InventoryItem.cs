using System;

namespace Nexd.ESX.Shared
{
    public class InventoryItem
    {
        public dynamic Raw;

        public string name
        {
            get
            {
                try
                {
                    return Raw.name;
                }
                catch { }
                return null;
            }
        }
        public int count
        {
            get
            {
                try
                {
                    return Raw.count;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public string label
        {
            get
            {
                try
                {
                    return Raw.label;
                }
                catch { }
                return null;
            }
        }
        public double weight
        {
            get
            {
                try
                {
                    return Raw.weight;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public bool usable
        {
            get
            {
                try
                {
                    return Raw.usable;
                }
                catch { }
                return false;
            }
        }
        public bool rare
        {
            get
            {
                try
                {
                    return Raw.rare;
                }
                catch { }
                return false;
            }
        }
        public bool canRemove
        {
            get
            {
                try
                {
                    return Raw.canRemove;
                }
                catch { }
                return false;
            }
        }
        public InventoryItem() { }

        public InventoryItem(dynamic data) => Raw = data;
    }
}