/*
 *  This file contains random examples for ESX.Client features.
 *  You may want to do extra pre-checks before doing things.
 *  Don't forget about references otherwise you won't be able to compile.
*/

using System;
using System.Collections.Generic;

using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

using Nexd.ESX.Client;
using Nexd.ESX.Shared;

namespace TestClient
{
    public class TestClient : BaseScript
    {
        public TestClient()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            RegisterCommand("TestTrigger", new Action<int, List<object>, string>(TestTrigger), false);
            RegisterCommand("GetPlayerData", new Action<int, List<object>, string>(GetPlayerData), false);
            RegisterCommand("VehicleInfo", new Action<int, List<object>, string>(VehicleInfo), false);

            RegisterCommand("GetPlayers", new Action<int, List<object>, string>(GetPlayers), false);
            RegisterCommand("GetPeds", new Action<int, List<object>, string>(GetPeds), false);
            RegisterCommand("GetVehicles", new Action<int, List<object>, string>(GetVehicles), false);
            RegisterCommand("SpawnVehicle", new Action<int, List<object>, string>(SpawnVehicle), false);

            RegisterCommand("HudTest", new Action<int, List<object>, string>(HudTest), false);
            RegisterCommand("AdvancedHudTest", new Action<int, List<object>, string>(AdvancedHudTest), false);

            RegisterCommand("DefaultMenuTest", new Action<int, List<object>, string>(DefaultMenuTest), false);
            RegisterCommand("DialogMenuTest", new Action<int, List<object>, string>(DialogMenuTest), false);
            RegisterCommand("ListMenuTest", new Action<int, List<object>, string>(ListMenuTest), false); //This one not works as intended, will be fixed in the future
        }

        private void TestTrigger(int source, List<object> args, string raw)
        {
            ESX.TriggerServerCallback("esx_testScript:testCallBack", new Action<dynamic>((param) =>//param is parsed from the server
            {
                Debug.WriteLine($"CLIENT.TESTCALLBACK {param.test[0]} {param.test[1]} {param.other} {param.tempData.Count}");
            }), new {
                cucc = new[] { "asd", "sad" }
            });
        }
        private void GetPlayerData(int source, List<object> args, string raw)
        {
            PlayerData data = ESX.GetPlayerData();

            foreach (Account i in data.accounts)
                ESX.ShowNotification($"{i.name}: {i.money}");

            if (data.loadout.Count > 0)
            {
                foreach (Nexd.ESX.Shared.Weapon i in data.loadout)
                    ESX.ShowNotification($"{i.name} {i.ammo}");
            } else ESX.ShowNotification("Your loadout is empty");

            if (data.inventory.Count > 0)
            {
                foreach (InventoryItem i in data.inventory)
                    ESX.ShowNotification($"{i.name} {i.count}");
            } else ESX.ShowNotification("Your inventory is empty");

            ESX.ShowNotification($"{data.coords.X} {data.coords.Y} {data.coords.Z} {data.heading}");
            ESX.ShowNotification($"{data.job.name} Salary: {data.job.grade_salary}");
        }
        private void VehicleInfo(int source, List<object> args, string raw)
        {
            Vehicle vehicle = new Vehicle(GetVehiclePedIsIn(GetPlayerPed(source), false));
            ESX.ShowNotification($"{ESX.Game.GetVehicleProperties(vehicle).plate}");
        }
        private void GetPlayers(int source, List<object> args, string raw)
        {
            foreach (Player i in ESX.Game.GetPlayers())
            {
                ESX.ShowNotification($"{i.Name} ({i.ServerId})");
            }
        }
        private void GetPeds(int source, List<object> args, string raw)
        {
            foreach (Ped i in ESX.Game.GetPeds())
            {
                ESX.ShowNotification($"{i.Handle} ({i.Gender})");
            }
        }
        private void GetVehicles(int source, List<object> args, string raw)
        {
            foreach (Vehicle i in ESX.Game.GetVehicles())
            {
                ESX.ShowNotification($"{i.Handle} ({i.Mods.LicensePlate})");
            }
        }
        private void SpawnVehicle(int source, List<object> args, string raw)
        {
            string model = "zentorno";
            if (args.Count > 0)
                model = args[0].ToString();

            int hash = GetHashKey(model);

            Ped PlayerPed = new Ped(GetPlayerPed(source));
            ESX.Game.SpawnVehicle(hash, PlayerPed.Position, PlayerPed.Heading, new Action<int>((vehicleHandle) => {
                Vehicle vehicle = new Vehicle(vehicleHandle);
                VehicleProperties vehicleProperties = ESX.Game.GetVehicleProperties(vehicleHandle);//or vehicle.Handle

                vehicleProperties.color1 = VehicleColor.Blue;
                ESX.Game.SetVehicleProperties(vehicle, vehicleProperties);
                ESX.ShowNotification($"{vehicle.Handle} {vehicle.Mods.LicensePlate} {vehicleProperties.color1}");
            }));
        }
        private async void HudTest(int source, List<object> args, string raw)
        {
            for (int i = 0; i < 224; i++)
            {
                ESX.ShowNotification($"{i}", (HudColor)i);
                await Delay(1000);
            }
        }
        private async void AdvancedHudTest(int source, List<object> args, string raw)
        {
            IconType[] icons = { IconType.ChatBox, IconType.AddFriendRequest, IconType.Dollar, IconType.Email, IconType.RightJumpingWindow, IconType.RP };

            for (int i = 0; i < 166; i++)
            {
                NotificationPicture pic = (NotificationPicture)i;
                ESX.ShowAdvancedNotification("Nexd", "~h~F*!K YOU~h~", $"N: ~h~{i}~h~~n~~h~~g~{pic}~h~", pic, icons[GetRandomIntInRange(0, 6)], true, true, (HudColor)i);
                await Delay(2000);
            }
        }
        private void DefaultMenuTest(int source, List<object> args, string raw)
        {
            ESX.UI.Menu.CloseAll();

            List<ESX.UI.MenuElement> menuElements = new List<ESX.UI.MenuElement>();
            menuElements.Add(new ESX.UI.MenuElement
            {
                label = "First label",
                value = "First value",
                custom = new //custom data that we want to pass to the callbacks
                {
                    test = new[] { "asd", "sad" },
                    tap = "tap"
                }
            });
            menuElements.Add(new ESX.UI.MenuElement
            {
                label = "Second label",
                value = "Second value"
            });
            for (int i = 0; i < 10; i++) //random elements
            {
                menuElements.Add(new ESX.UI.MenuElement
                {
                    label = $"{i} item",
                    value = $"{i} value"
                });
            }

            ESX.UI.Menu.Open("default", GetCurrentResourceName(), "default_menu", new ESX.UI.MenuData
            {
                title = "Default Menu Title",
                align = "top-right",
                elements = menuElements
            }, new Action<dynamic, dynamic>((data, menu) => { //Submit
                if(data.current.value == "First value")
                {
                    ESX.ShowNotification($"{data.current.custom.test[0]} {data.current.custom.test[1]}"); //output: asd sad
                    ESX.ShowNotification($"{data.current.custom.tap}"); //output: tap
                }
            }), new Action<dynamic, dynamic>((data, menu) => { //Cancel
                menu.close();
            }));
        }
        private void DialogMenuTest(int source, List<object> args, string raw)
        {
            ESX.UI.Menu.CloseAll();

            ESX.UI.Menu.Open("dialog", GetCurrentResourceName(), "dialog_menu", new ESX.UI.MenuData
            {
                title = "Dialog Menu Title"
            }, new Action<dynamic, dynamic>((data, menu) => { //Submit
                ESX.ShowNotification($"{data.value}");
            }), new Action<dynamic, dynamic>((data, menu) => { //Cancel
                menu.close();
            }));
        }
        private void ListMenuTest(int source, List<object> args, string raw)
        {
            ESX.UI.Menu.CloseAll();

            ESX.UI.Menu.Open("list", GetCurrentResourceName(), "list_menu", new ESX.UI.MenuData(new
            {
                title = "List Menu Title",
                head = new[] { "First", "Second", "Third" },
                rows = new
                {
                    data = "Random",
                    cols = new[]
                    {
                        "WILL", "BE", "{{FINISHED|OnFinished()}} {{SOON|OnSoon()}}"
                    }
                }
            }), new Action<dynamic, dynamic>((data, menu) => { //Submit
                ESX.ShowNotification($"{data.value}");
            }), new Action<dynamic, dynamic>((data, menu) => { //Cancel
                menu.close();
            }));
        }
    }
}