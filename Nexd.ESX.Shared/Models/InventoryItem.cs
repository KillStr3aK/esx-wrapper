namespace Nexd.ESX.Shared
{
    public class InventoryItem
    {
        public dynamic Raw;

        public string name => Raw.name;

        public int count => Raw.count;

        public string label => Raw.label;

        public double weight => Raw.weight;

        public bool usable => Raw.usable;

        public bool rare => Raw.rare;

        public bool canRemove => Raw.canRemove;

        public InventoryItem() { }

        public InventoryItem(dynamic data) => Raw = data;
    }
}