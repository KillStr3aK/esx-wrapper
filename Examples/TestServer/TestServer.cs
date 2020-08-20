/*
 *  This file contains random examples for ESX.Server features.
 *  You may want to do extra pre-checks before doing things.
 *  Don't forget about references otherwise you won't be able to compile.
*/

using System;
using System.Collections.Generic;

using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

using Nexd.ESX.Server;
using Nexd.ESX.Shared;

namespace TestServer
{
    public class TestServer : BaseScript
    {
        public TestServer()
        {
            EventHandlers["onResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            RegisterCommand("JobInfo", new Action<int, List<object>, string>(JobInfo), false);
            RegisterCommand("JobExist", new Action<int, List<object>, string>(JobExist), false);

            RegisterCommand("SaveMe", new Action<int, List<object>, string>(SaveMe), false);
            RegisterCommand("SaveAll", new Action<int, List<object>, string>(SaveAll), false);

            RegisterCommand("AddWeapon", new Action<int, List<object>, string>(AddWeapon), false);
            RegisterCommand("DelWeapon", new Action<int, List<object>, string>(DelWeapon), false);

            RegisterCommand("GiveWeaponAmmo", new Action<int, List<object>, string>(GiveWeaponAmmo), false);

            RegisterCommand("WeaponInfo", new Action<int, List<object>, string>(WeaponInfo), false);
            RegisterCommand("LoadoutInfo", new Action<int, List<object>, string>(LoadoutInfo), false);
            RegisterCommand("SetWeaponTint", new Action<int, List<object>, string>(SetWeaponTint), false);

            RegisterCommand("GetAccounts", new Action<int, List<object>, string>(GetAccounts), false);

            RegisterCommand("UseItem", new Action<int, List<object>, string>(UseItem), false);

            RegisterCommand("GetPosition", new Action<int, List<object>, string>(GetPosition), false);

            ESX.RegisterUsableItem("testItem", new Action<int>((int source) => {
                Debug.WriteLine(ESX.GetPlayerFromId(source).GetName() + " used 'testItem'");
            }));
            ESX.RegisterUsableItem("testItem2", new Action<int>((source) =>
            {
                Debug.WriteLine(ESX.GetPlayerFromId(source).GetName() + " used 'testItem2'");
            }));

            ESX.RegisterServerCallback("esx_testScript:testCallBack", new Action<int, CallbackDelegate, dynamic>(TestCallback));
        }

        private void JobInfo(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            Job Job = xPlayer.GetJob();
            xPlayer.TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[JobInfo]", $"Your Job is {Job.name}. Your Grade Is {Job.grade_name}. Your Salary is {Job.grade_salary}" }
            });
        }
        private void JobExist(int source, List<object> args, string raw)
        {
            bool exist = ESX.DoesJobExist(args[0].ToString(), Convert.ToInt32(args[1]));
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            xPlayer.Raw.triggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[JobInfo]", $"{args[0]} ({args[1]}) {exist}" }
            });
        }
        private void SaveMe(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            ESX.SavePlayer(xPlayer, new Action(() => {
                Debug.WriteLine("ESX.SavePlayer->SavePlayerCallback()");
            }));
        }
        private void SaveAll(int source, List<object> args, string raw)
        {
            ESX.SavePlayers(new Action(() => {
                Debug.WriteLine("ESX.SavePlayers->SavePlayerCallback()");
            }));
        }
        private void AddWeapon(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            xPlayer.AddWeapon(args[0].ToString(), Convert.ToInt32(args[1]));
            xPlayer.ShowNotification($"You have got {args[0]}");
        }
        private void DelWeapon(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            xPlayer.RemoveWeapon(args[0].ToString());
            xPlayer.ShowNotification($"Deleted {args[0]}");
        }
        private void WeaponInfo(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);

            if (args.Count > 0)
            {
                Weapon weapon = xPlayer.GetWeapon(args[0].ToString());
                xPlayer.ShowNotification($"Found weapon: {weapon.name} Tint: {weapon.Raw.tintIndex} Loadoutnum: {xPlayer.GetWeaponLoadoutNum(weapon.name)}");

                if (weapon.components.Count > 0)
                {
                    foreach (string i in weapon.components)
                    {
                        xPlayer.ShowNotification(i);
                    }
                }
                else
                {
                    xPlayer.ShowNotification("This weapon have 0 components");
                }
            }
            else xPlayer.ShowNotification("Usage: !WeaponInfo weaponName");
        }
        private void LoadoutInfo(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            List<Weapon> loadout = xPlayer.GetLoadout(false);
            foreach(Weapon i in loadout)
            {
                xPlayer.ShowNotification($"Weapon: {i.name} Ammo: {i.ammo}");
            }
        }
        private void SetWeaponTint(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            xPlayer.SetWeaponTint(args[0].ToString(), Convert.ToInt32(args[1]));
        }
        private void GetAccounts(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);

            foreach(Account i in xPlayer.GetAccounts(false))
            {
                xPlayer.ShowNotification($"Account: {i.name} Label: {i.label} Money: {i.money}");
            }
        }
        private void UseItem(int source, List<object> args, string raw)
        {
            ESX.UseItem(source, args[0].ToString());
        }
        private void GetPosition(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            Debug.WriteLine(xPlayer.GetCoords(true).ToString());
        }
        private void GiveWeaponAmmo(int source, List<object> args, string raw)
        {
            xPlayer xPlayer = ESX.GetPlayerFromId(source);
            xPlayer.AddWeaponAmmo(args[0].ToString(), Convert.ToInt32(args[1]));
        }
        private void TestCallback(int source, CallbackDelegate cb, dynamic args)
        {
            var data = args; //parsed from the client
            Debug.WriteLine($"SERVER.TESTCALLBACK {source} {data.cucc[0]} {data.cucc[1]}");

            //random things to test that every kind of shit can be passed to the callback
            List<string> tempData = new List<string>();
            tempData.Add("a");
            tempData.Add("b");
            tempData.Add("c");

            cb.Invoke(new
            {
                test = new[] { "testData", "128asua" },
                other = 15,
                tempData
            });
        }
    }
}