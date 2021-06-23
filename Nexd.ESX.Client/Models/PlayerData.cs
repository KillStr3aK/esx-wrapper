namespace Nexd.ESX.Client
{
    using System.Collections.Generic;

    using CitizenFX.Core;
    using Nexd.ESX.Shared;

    public class PlayerData
    {
        public dynamic Raw;

        public PlayerData() { }
        public PlayerData(dynamic data) => Raw = data;

        public Job job => new Job(Raw.job);

        public Vector3 coords => new Vector3((float)Raw.coords.x, (float)Raw.coords.y, (float)Raw.coords.z);

        public double heading => Raw.coords.heading;

        public double maxWeight => Raw.maxWeight;

        public List<Shared.Weapon> loadout
        {
            get
            {
                List<Shared.Weapon> temp = new List<Shared.Weapon>();
                var loadout = Raw.loadout;

                foreach (var i in loadout)
                {
                    temp.Add(new Shared.Weapon(i));
                }

                return temp;
            }
        }

        public Account[] accounts
        {
            get
            {
                Account[] accounts = new Account[3];
                var raw = Raw.accounts;
                for (int i = 0; i < 3; i++)
                    accounts[i] = new Account(raw[i]);

                return accounts;
            }
        }

        public List<InventoryItem> inventory
        {
            get
            {
                List<InventoryItem> inventory = new List<InventoryItem>();
                var rawdata = Raw.inventory;
                foreach (var i in rawdata)
                {
                    inventory.Add(new InventoryItem(i));
                }

                return inventory;
            }
        }
    }
}