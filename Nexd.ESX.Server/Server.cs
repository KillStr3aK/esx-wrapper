using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CitizenFX.Core;
using Nexd.ESX.Shared;

namespace Nexd.ESX.Server
{
    public class ESX
    {
        private static dynamic _Raw;
        public static dynamic Raw => _Raw ?? (GetObject());

        private static dynamic GetObject()
        {
            BaseScript.TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => {
                _Raw = esx;
            })});

            return _Raw;
        }

        public static xPlayer GetPlayerFromId(int playerid)
        {
            return new xPlayer(Raw.GetPlayerFromId(playerid));
        }
        public static xPlayer GetPlayerFromIdentifier(string identifier)
        {
            return new xPlayer(Raw.GetPlayerFromIdentifier(identifier));
        }
        public static dynamic GetPlayerFromIdEx(int playerid)
        {
            return Raw.GetPlayerFromId(playerid);
        }
        public static dynamic GetPlayerFromIdentifierEx(string identifier)
        {
            return Raw.GetPlayerFromIdentifier(identifier);
        }
        public static List<xPlayer> GetPlayers()
        {
            List<xPlayer> temp = new List<xPlayer>();
            var rawdata = Raw.GetPlayers();
            foreach(var i in rawdata)
            {
                temp.Add(ESX.GetPlayerFromId(i));
            }

            return temp;
        }
        public static bool DoesJobExist(string job, int grade)
        {
            return Raw.DoesJobExist(job, grade);
        }
        public static void SavePlayer(xPlayer xPlayer, Action callback = null)
        {
            Raw.SavePlayer(xPlayer.Raw, callback);
        }
        public static void SavePlayers(Action callback = null)
        {
            Raw.SavePlayers(callback);
        }
        public static void CreatePickup(string itemType, string itemName, int count, string label, int playerid, [Optional, DefaultParameterValue(null)]List<string> components, [Optional, DefaultParameterValue(0)]int tintIndex)
        {
            Raw.CreatePickup(itemType, itemName, count, label, playerid, components, tintIndex);
        }
        public static void UseItem(int playerid, string itemName)
        {
            Raw.UseItem(playerid, itemName);
        }
        public static dynamic GetItemLabel(int item)
        {
            return Raw.GetItemLabel(item);
        }
        public static void RegisterUsableItem(string item, Action<int> callback = null)
        {
            Raw.RegisterUsableItem(item, callback);
        }
        public static void RegisterServerCallback(string name, Action<int, CallbackDelegate, dynamic> callback)
        {
            Raw.RegisterServerCallback(name, callback);
        }
        public static void Trace(object args)
        {
            Raw.Trace(args);
        }
        public static string GetRandomString(int length)
        {
            return Raw.GetRandomString(length);
        }
        public static dynamic GetConfig()
        {
            return Raw.GetConfig();
        }
        public static dynamic GetWeaponFromHash(long hash)
        {
            return Raw.GetWeaponFromHash(hash);
        }
        public static dynamic GetWeaponList()
        {
            return Raw.GetWeaponList();
        }
        public static dynamic GetWeaponComponent(string weaponName, string weaponComponent)
        {
            return Raw.GetWeaponComponent(weaponName, weaponComponent);
        }
        public static dynamic GetWeapon(string itemName)
        {
            return Raw.GetWeapon(itemName);
        }
        public static dynamic GetWeaponLabel(string weapon)
        {
            return Raw.GetWeaponLabel(weapon);
        }

        public static class Config
        {
            public static dynamic Raw => ESX.Raw.Config ?? (GetObject().Config);
            public static string Locale
            {
                get { return Raw.Locale; }
            }
            public static string[] Accounts
            {
                get
                {
                    return new string[] { Raw.Accounts.bank, Raw.Accounts.money, Raw.Accounts.black_money };
                }
            }
            public static dynamic StartingAccountMoney
            {
                get { return Raw.StartingAccountMoney; }
            }
            public static bool EnableSocietyPayouts
            {
                get { return Raw.EnableSocietyPayouts; }
            }
            public static bool EnableHud
            {
                get { return Raw.EnableHud; }
            }
            public static int MaxWeight
            {
                get { return Raw.MaxWeight; }
            }
            public static int PaycheckInterval
            {
                get { return Raw.PaycheckInterval; }
            }
            public static bool EnableDebug
            {
                get { return Raw.EnableDebug; }
            }

            public static class Weapons
            {
                public static dynamic Raw => ESX.Raw.Config.Weapons ?? (GetObject().Config.Weapons);
                public static string[] DefaultWeaponTints
                {
                    get { return ESX.Raw.Config.DefaultWeaponTints; }
                }
            }
        }
    }

    public class xPlayer
    {
        public dynamic Raw;

        public int Index
        {
            get { return Raw.source; }
        }
        public xPlayer(dynamic data)
        {
            Raw = data;
        }
        public void TriggerEvent(string eventName, dynamic args = null)
        {
            Raw.triggerEvent(eventName, args);
        }
        public void SetCoords(Vector3 coords)
        {
            dynamic table = new
            {
                x = coords.X,
                y = coords.Y,
                z = coords.Z,
                heading = 0.0f
            };

            Raw.setCoords(table);
        }
        public void SetCoords(Vector3 coords, float heading)
        {
            dynamic table = new
            {
                x = coords.X,
                y = coords.Y,
                z = coords.Z,
                heading = heading
            };

            Raw.setCoords(table);
        }
        public void UpdateCoords(Vector3 coords)
        {
            dynamic table = new
            {
                x = coords.X,
                y = coords.Y,
                z = coords.Z,
                heading = 0.0f
            };

            Raw.updateCoords(table);
        }

        public void UpdateCoords(Vector3 coords, float heading)
        {
            dynamic table = new
            {
                x = coords.X,
                y = coords.Y,
                z = coords.Z,
                heading = heading
            };

            Raw.updateCoords(table);
        }
        public Vector3 GetCoords(bool vector)
        {
            return Raw.getCoords(vector);
        }
        public Vector3 GetCoords(bool vector, ref float heading)
        {
            dynamic data = Raw.getCoords(vector);
            Vector3 coords = new Vector3(data.X, data.Y, data.Z);
            heading = data.heading;
            return coords;
        }
        public float GetHeading()
        {
            return Raw.getCoords(true).heading;
        }
        public void Kick(string reason)
        {
            Raw.kick(reason);
        }
        public void SetMoney(int money)
        {
            Raw.setMoney(money);
        }
        public uint GetMoney()
        {
            return Raw.getMoney();
        }
        public void AddMoney(int amount)
        {
            Raw.addMoney(amount);
        }
        public void RemoveMoney(int amount)
        {
            Raw.removeMoney(amount);
        }
        public string GetIdentifier()
        {
            return Raw.getIdentifier();
        }
        public void SetGroup(string newgroup)
        {
            Raw.setGroup(newgroup);
        }
        public string GetGroup()
        {
            return Raw.getGroup();
        }
        public void Set(dynamic key, dynamic value)
        {
            Raw.set(key, value);
        }
        public dynamic Get(dynamic key)
        {
            return Raw.get(key);
        }
        public Account[] GetAccounts(bool minimal)
        {
            Account[] accounts = new Account[3];
            var raw = Raw.getAccounts(minimal);
            for(int i = 0; i < 3; i++)
                accounts[i] = new Account(raw[i]);

            return accounts;
        }
        public Account GetAccount(string name)
        {
            return new Account(Raw.getAccount(name));
        }
        public List<InventoryItem> GetInventory(bool minimal)
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            var rawdata = Raw.getInventory(minimal);
            foreach (var i in rawdata)
            {
                inventory.Add(new InventoryItem(i));
            }

            return inventory;
        }
        public Job GetJob()
        {
            return new Job(Raw.getJob());
        }
        public List<Weapon> GetLoadout(bool minimal)
        {
            List<Weapon> temp = new List<Weapon>();
            var loadout = Raw.getLoadout(minimal);

            foreach(var i in loadout)
            {
                temp.Add(new Weapon(i));
            }

            return temp;
        }
        public string GetName()
        {
            return Raw.getName();
        }
        public void SetName(string newname)
        {
            Raw.setName(newname);
        }
        public void SetAccountMoney(string account, int money)
        {
            Raw.setAccountMoney(account, money);
        }
        public void AddAccountMoney(string account, int amount)
        {
            Raw.addAccountMoney(account, amount);
        }
        public void RemoveAccountMoney(string account, int amount)
        {
            Raw.removeAccountMoney(account, amount);
        }
        public InventoryItem GetInventoryItem(string name)
        {
            return new InventoryItem(Raw.getInventoryItem(name));
        }
        public void AddInventoryItem(string name, int count)
        {
            Raw.addInventoryItem(name, count);
        }
        public void RemoveInventoryItem(string name, int count)
        {
            Raw.removeInventoryItem(name, count);
        }
        public void SetInventoryItem(string name, int count)
        {
            Raw.setInventoryItem(name, count);
        }
        public double GetWeight()
        {
            return Raw.getWeight();
        }
        public double GetMaxWeight()
        {
            return Raw.getMaxWeight();
        }
        public bool CanCarryItem(string name, int count)
        {
            return Raw.canCarryItem(name, count);
        }
        public bool CanSwapItem(string firstitem, int firstitemcount, string testitem, int testitemcount)
        {
            return Raw.canSwapItem(firstitem, firstitemcount, testitem, testitemcount);
        }
        public void SetMaxWeight(double newWeight)
        {
            Raw.setMaxWeight(newWeight);
        }
        public void SetJob(string job, int grade)
        {
            Raw.setJob(job, grade);
        }
        public void AddWeapon(string weaponName, int ammo)
        {
            Raw.addWeapon(weaponName, ammo);
        }
        public void AddWeaponComponent(string weaponName, string weaponComponent)
        {
            Raw.addWeaponComponent(weaponName, weaponComponent);
        }
        public void AddWeaponAmmo(string weaponName, int ammoCount)
        {
            Raw.addWeaponAmmo(weaponName, ammoCount);
        }
        public void UpdateWeaponAmmo(string weaponName, int ammoCount)
        {
            Raw.updateWeaponAmmo(weaponName, ammoCount);
        }
        public void SetWeaponTint(string weaponName, int weaponTintIndex)
        {
            Raw.setWeaponTint(weaponName, weaponTintIndex);
        }
        public int GetWeaponTint(string weaponName)
        {
            return Raw.getWeaponTint(weaponName);
        }
        public void RemoveWeapon(string weaponName)
        {
            Raw.removeWeapon(weaponName);
        }
        public void RemoveWeaponComponent(string weaponName, string weaponComponent)
        {
            Raw.removeWeaponComponent(weaponName, weaponComponent);
        }
        public void RemoveWeaponAmmo(string weaponName, int ammoCount)
        {
            Raw.removeWeaponAmmo(weaponName, ammoCount);
        }
        public bool HasWeaponComponent(string weaponName, string weaponComponent)
        {
            return Raw.hasWeaponComponent(weaponName, weaponComponent);
        }
        public bool HasWeapon(string weaponName)
        {
            return Raw.hasWeapon(weaponName);
        }
        public Weapon GetWeapon(string weaponName)
        {
            return GetLoadout(false).Find(x => x.name == weaponName);
        }
        public int GetWeaponLoadoutNum(string weaponName)
        {
            return GetLoadout(false).FindIndex(x => x.name == weaponName);
        }
        public void ShowNotification(string message)
        {
            Raw.showNotification(message);
        }
        public void ShowHelpNotification(string message, bool thisframe = false, bool beep = true, int duration = -1)
        {
            Raw.showHelpNotification(message, thisframe, beep, duration);
        }
    }
}
