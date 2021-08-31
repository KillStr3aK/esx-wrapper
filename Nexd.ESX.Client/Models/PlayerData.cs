namespace Nexd.ESX.Client
{
    using System;
    using System.Collections.Generic;

    using CitizenFX.Core;
    using Nexd.ESX.Shared;

    public class PlayerData
    {
        public dynamic Raw;

        public PlayerData() { }
        public PlayerData(dynamic data) => Raw = data;

        public Job job
        {
            get
            {
                try
                {
                    return new Job(Raw.job);
                }
                catch { }
                return null;
            }
        }

        public Vector3 coords
        {
            get
            {
                try
                {
                    return new Vector3((float)Raw.coords.x, (float)Raw.coords.y, (float)Raw.coords.z);
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }

        public double heading
        {
            get
            {
                try
                {
                    return Raw.coords.heading;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public double maxWeight
        {
            get
            {
                try
                {
                    return Raw.maxWeight;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public List<Shared.Weapon> loadout
        {
            get
            {
                List<Shared.Weapon> temp = new List<Shared.Weapon>();
                try
                {
                    var loadout = Raw.loadout;
                    foreach (var i in loadout)
                    {
                        temp.Add(new Shared.Weapon(i));
                    }
                }
                catch { }

                return temp;
            }
        }

        public Account[] accounts
        {
            get
            {
                Account[] accounts = new Account[3];
                try
                {
                    var raw = Raw.accounts;
                    for (int i = 0; i < 3; i++)
                    {
                        accounts[i] = new Account(raw[i]);
                    }
                }
                catch { }
                return accounts;
            }
        }

        public List<InventoryItem> inventory
        {
            get
            {
                List<InventoryItem> inventory = new List<InventoryItem>();
                try
                {
                    var rawdata = Raw.inventory;
                    foreach (var i in rawdata)
                    {
                        inventory.Add(new InventoryItem(i));
                    }
                }
                catch { }
                return inventory;
            }
        }
    }
}