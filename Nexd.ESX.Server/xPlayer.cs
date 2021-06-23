namespace Nexd.ESX.Server
{
    using System.Collections.Generic;

    using CitizenFX.Core;
    using Nexd.ESX.Shared;

    public class xPlayer
    {
        public dynamic Raw;

        public int Index => Raw.source;

        public xPlayer() { }

        public xPlayer(dynamic data) => Raw = data;

        public void TriggerEvent(string eventName, dynamic args = null) => Raw.triggerEvent(eventName, args);
        public float GetHeading() => Raw.getCoords(true).heading;
        public void Kick(string reason) => Raw.kick(reason);
        public void SetMoney(int money) => Raw.setMoney(money);
        public uint GetMoney() => Raw.getMoney();
        public void AddMoney(int amount) => Raw.addMoney(amount);
        public void RemoveMoney(int amount) => Raw.removeMoney(amount);
        public string GetIdentifier() => Raw.getIdentifier();
        public void SetGroup(string newgroup) => Raw.setGroup(newgroup);
        public string GetGroup() => Raw.getGroup();
        public void Set(dynamic key, dynamic value) => Raw.set(key, value);
        public dynamic Get(dynamic key) => Raw.get(key);
        public string GetName() => Raw.getName();
        public void SetName(string newname) => Raw.setName(newname);
        public void SetAccountMoney(string account, int money) => Raw.setAccountMoney(account, money);
        public void AddAccountMoney(string account, int amount) => Raw.addAccountMoney(account, amount);
        public void RemoveAccountMoney(string account, int amount) => Raw.removeAccountMoney(account, amount);
        public InventoryItem GetInventoryItem(string name) => new InventoryItem(Raw.getInventoryItem(name));
        public void AddInventoryItem(string name, int count) => Raw.addInventoryItem(name, count);
        public void RemoveInventoryItem(string name, int count) => Raw.removeInventoryItem(name, count);
        public void SetInventoryItem(string name, int count) => Raw.setInventoryItem(name, count);
        public double GetWeight() => Raw.getWeight();
        public double GetMaxWeight() => Raw.getMaxWeight();
        public bool CanCarryItem(string name, int count) => Raw.canCarryItem(name, count);
        public bool CanSwapItem(string firstitem, int firstitemcount, string testitem, int testitemcount) => Raw.canSwapItem(firstitem, firstitemcount, testitem, testitemcount);
        public void SetMaxWeight(double newWeight) => Raw.setMaxWeight(newWeight);
        public void SetJob(string job, int grade) => Raw.setJob(job, grade);
        public void AddWeapon(string weaponName, int ammo) => Raw.addWeapon(weaponName, ammo);
        public void AddWeaponComponent(string weaponName, string weaponComponent) => Raw.addWeaponComponent(weaponName, weaponComponent);
        public void AddWeaponAmmo(string weaponName, int ammoCount) => Raw.addWeaponAmmo(weaponName, ammoCount);
        public void UpdateWeaponAmmo(string weaponName, int ammoCount) => Raw.updateWeaponAmmo(weaponName, ammoCount);
        public void SetWeaponTint(string weaponName, int weaponTintIndex) => Raw.setWeaponTint(weaponName, weaponTintIndex);
        public int GetWeaponTint(string weaponName) => Raw.getWeaponTint(weaponName);
        public void RemoveWeapon(string weaponName) => Raw.removeWeapon(weaponName);
        public void RemoveWeaponComponent(string weaponName, string weaponComponent) => Raw.removeWeaponComponent(weaponName, weaponComponent);
        public void RemoveWeaponAmmo(string weaponName, int ammoCount) => Raw.removeWeaponAmmo(weaponName, ammoCount);
        public bool HasWeaponComponent(string weaponName, string weaponComponent) => Raw.hasWeaponComponent(weaponName, weaponComponent);
        public bool HasWeapon(string weaponName) => Raw.hasWeapon(weaponName);
        public Weapon GetWeapon(string weaponName) => GetLoadout().Find(x => x.name == weaponName);
        public int GetWeaponLoadoutNum(string weaponName) => GetLoadout().FindIndex(x => x.name == weaponName);
        public void ShowNotification(string message) => Raw.showNotification(message);
        public void ShowHelpNotification(string message, bool thisframe = false, bool beep = true, int duration = -1) => Raw.showHelpNotification(message, thisframe, beep, duration);
        public Job GetJob() => new Job(Raw.getJob());
        public Account GetAccount(string name) => new Account(Raw.getAccount(name));
        public Vector3 GetCoords(bool vector) => Raw.getCoords(vector);

        public Vector3 GetCoords(bool vector, ref float heading)
        {
            dynamic data = Raw.getCoords(vector);
            Vector3 coords = new Vector3(data.X, data.Y, data.Z);
            heading = data.heading;
            return coords;
        }

        public Account[] GetAccounts(bool minimal)
        {
            Account[] accounts = new Account[3];
            var raw = Raw.getAccounts(minimal);
            for (int i = 0; i < 3; i++)
                accounts[i] = new Account(raw[i]);

            return accounts;
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

        public List<Weapon> GetLoadout()
        {
            List<Weapon> temp = new List<Weapon>();
            var loadout = Raw.getLoadout();

            foreach (var i in loadout)
            {
                temp.Add(new Weapon(i));
            }

            return temp;
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
    }
}