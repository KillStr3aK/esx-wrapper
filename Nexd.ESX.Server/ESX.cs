namespace Nexd.ESX.Server
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using CitizenFX.Core;

    public static partial class ESX
    {
        private static dynamic Raw;

        static ESX() => BaseScript.TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => { Raw = esx; }) });

        public static xPlayer GetPlayerFromId(int playerid) => new xPlayer(Raw.GetPlayerFromId(playerid));
        public static xPlayer GetPlayerFromIdentifier(string identifier) => new xPlayer(Raw.GetPlayerFromIdentifier(identifier));
        public static dynamic GetPlayerFromIdEx(int playerid) => Raw.GetPlayerFromId(playerid);
        public static dynamic GetPlayerFromIdentifierEx(string identifier) => Raw.GetPlayerFromIdentifier(identifier);
        public static bool DoesJobExist(string job, int grade) => Raw.DoesJobExist(job, grade);
        public static void SavePlayer(xPlayer xPlayer, Action callback = null) => Raw.SavePlayer(xPlayer.Raw, callback);
        public static void SavePlayers(Action callback = null) => Raw.SavePlayers(callback);
        public static void CreatePickup(
            string itemType,
            string itemName,
            int count,
            string label,
            int playerid,
            [Optional, DefaultParameterValue(null)]List<string> components,
            [Optional, DefaultParameterValue(0)]int tintIndex) =>
            Raw.CreatePickup(itemType, itemName, count, label, playerid, components, tintIndex);
        public static void UseItem(int playerid, string itemName) => Raw.UseItem(playerid, itemName);
        public static string GetItemLabel(string item) => Raw.GetItemLabel(item);
        public static void RegisterUsableItem(string item, Action<int> callback = null) => Raw.RegisterUsableItem(item, callback);
        public static void RegisterServerCallback(string name, Action<int, CallbackDelegate, dynamic> callback) => Raw.RegisterServerCallback(name, callback);
        public static void Trace(object args) => Raw.Trace(args);
        public static string GetRandomString(int length) => Raw.GetRandomString(length);
        public static dynamic GetConfig() => Raw.GetConfig();
        public static dynamic GetWeaponFromHash(long hash) => Raw.GetWeaponFromHash(hash);
        public static dynamic GetWeaponList() => Raw.GetWeaponList();
        public static dynamic GetWeaponComponent(string weaponName, string weaponComponent) => Raw.GetWeaponComponent(weaponName, weaponComponent);
        public static dynamic GetWeapon(string itemName) => Raw.GetWeapon(itemName);
        public static dynamic GetWeaponLabel(string weapon) => Raw.GetWeaponLabel(weapon);

        public static List<xPlayer> GetPlayers()
        {
            List<xPlayer> temp = new List<xPlayer>();
            var rawdata = Raw.GetPlayers();
            foreach (var i in rawdata)
            {
                temp.Add(ESX.GetPlayerFromId(i));
            }

            return temp;
        }
    }
}