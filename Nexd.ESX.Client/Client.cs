using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CitizenFX.Core;
using Nexd.ESX.Shared;

namespace Nexd.ESX.Client
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

        public static void TriggerServerCallback(string name, Action<dynamic> callback, dynamic args = null)
        {
            Raw.TriggerServerCallback(name, callback, args);
        }
        public static PlayerData GetPlayerData()
        {
            return new PlayerData(Raw.GetPlayerData());
        }
        public static bool IsPlayerLoaded()
        {
            return Raw.IsPlayerLoaded();
        }
        public static void SetPlayerData(dynamic key, dynamic value)
        {
            Raw.SetPlayerData(key, value);
        }
        public static void ShowAdvancedNotification(string sender, string subject, string message, NotificationPicture notificationPicture = NotificationPicture.CHAR_MULTIPLAYER, IconType iconType = IconType.ChatBox, bool flash = false, bool savetoBreif = true, HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if (hudColor != HudColor.HUD_COLOUR_DEFAULT)
            {
                Raw.ShowAdvancedNotification(sender, subject, message, notificationPicture.ToString(), (int)iconType, flash, savetoBreif, (int)hudColor);
                return;
            }

            Raw.ShowAdvancedNotification(sender, subject, message, notificationPicture.ToString(), (int)iconType, flash, savetoBreif, null);
        }
        public static void ShowAdvancedNotification(string sender, string subject, string message, string textureDict, IconType iconType, bool flash = false, bool savetoBreif = true, HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if (hudColor != HudColor.HUD_COLOUR_DEFAULT)
            {
                Raw.ShowAdvancedNotification(sender, subject, message, textureDict, (int)iconType, flash, savetoBreif, (int)hudColor);
                return;
            }

            Raw.ShowAdvancedNotification(sender, subject, message, textureDict, (int)iconType, flash, savetoBreif, null);
        }
        public static void ShowHelpNotification(string message, bool thisFrame = false, bool beep = true, int duration = -1)
        {
            Raw.ShowHelpNotification(message, thisFrame, beep, duration);
        }
        public static void ShowInventory()
        {
            Raw.ShowInventory();
        }
        public static void ShowNotification(string message, HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if(hudColor != HudColor.HUD_COLOUR_DEFAULT) CitizenFX.Core.Native.API.ThefeedNextPostBackgroundColor((int)hudColor);
            Raw.ShowNotification(message);
        }

        public class Game
        {
            public static dynamic Raw => ESX.Raw.Game ?? (GetObject().Game);
            public static void DeleteObject(string obj)
            {
                Raw.DeleteObject(obj);
            }
            public static void DeleteVehicle(string vehicle)
            {
                Raw.DeleteVehicle(vehicle);
            }
            public static dynamic GetClosestObject([Optional()]Vector3 coords, [Optional()]dynamic modelFilter)
            {
                return Raw.GetClosestObject(coords, modelFilter);
            }
            public static Ped GetClosestPed([Optional()]Vector3 coords, [Optional()]dynamic modelFilter)
            {
                return new Ped(Raw.GetClosestPed(coords, modelFilter));
            }
            public static Player GetClosestPlayer([Optional()]Vector3 coords)
            {
                return new Player(Raw.GetClosestPlayer(coords));
            }
            public static Vehicle GetClosestVehicle([Optional()]Vector3 coords, [Optional()]dynamic modelFilter)
            {
                return new Vehicle(Raw.GetClosestVehicle(coords, modelFilter));
            }
            public static dynamic GetObjects()
            {
                return Raw.GetObjects();
            }
            public static dynamic GetPedMugshot(string ped, bool transparent = true)
            {
                return Raw.GetPedMugshot(ped, transparent);
            }
            public static List<Ped> GetPeds([Optional()]bool onlyOtherPeds)
            {
                var data = Raw.GetPeds(onlyOtherPeds);
                List<Ped> peds = new List<Ped>();
                foreach (var i in data)
                    peds.Add(new Ped(i));

                return peds;
            }
            public static List<Player> GetPlayers(bool onlyOtherPlayers = false, bool returnKeyValue = false, bool returnPeds = false)
            {
                var data = Raw.GetPlayers(onlyOtherPlayers, returnKeyValue, returnPeds);
                List<Player> players = new List<Player>();
                foreach (var i in data)
                    players.Add(new Player(i));

                return players;
            }
            public static List<Player> GetPlayersInArea([Optional()]Vector3 coords, double maxDistance)
            {
                var data = Raw.GetPlayersInArea(coords, maxDistance);
                List<Player> players = new List<Player>();
                foreach (var i in data)
                    players.Add(new Player(i));

                return players;
            }
            public static Vehicle GetVehicleInDirection()
            {
                return new Vehicle(Raw.GetVehicleInDirection());
            }
            public static VehicleProperties GetVehicleProperties(Vehicle vehicle)
            {
                return new VehicleProperties(Raw.GetVehicleProperties(vehicle.Handle));
            }
            public static VehicleProperties GetVehicleProperties(int vehicle)
            {
                return new VehicleProperties(Raw.GetVehicleProperties(vehicle));
            }
            public static List<Vehicle> GetVehicles()
            {
                var data = Raw.GetVehicles();
                List<Vehicle> vehicles = new List<Vehicle>();
                foreach (var i in data)
                    vehicles.Add(new Vehicle(i));

                return vehicles;
            }
            public static List<Vehicle> GetVehiclesInArea([Optional()]Vector3 coords, double maxDistance)
            {
                var data = Raw.GetVehiclesInArea(coords, maxDistance);
                List<Vehicle> vehicles = new List<Vehicle>();
                foreach (var i in data)
                    vehicles.Add(new Vehicle(i));

                return vehicles;
            }
            public static bool IsSpawnPointClear([Optional()]Vector3 coords, double maxDistance)
            {
                return Raw.IsSpawnPointClear(coords, maxDistance);
            }
            public static void SetVehicleProperties(Vehicle vehicle, VehicleProperties properties)
            {
                Raw.SetVehicleProperties(vehicle.Handle, properties.Raw);
            }
            public static void SpawnLocalObject(string hash, Vector3 coords, [Optional()]Action<int> callback)
            {
                Raw.SpawnLocalObject(hash, coords, callback);
            }
            public static void SpawnLocalObject(int hash, Vector3 coords, [Optional()]Action<int> callback)
            {
                Raw.SpawnLocalObject(hash, coords, callback);
            }
            public static void SpawnObject(string hash, Vector3 coords, [Optional()]Action<int> callback)
            {
                Raw.SpawnObject(hash, coords, callback);
            }
            public static void SpawnObject(int hash, Vector3 coords, [Optional()]Action<int> callback)
            {
                Raw.SpawnObject(hash, coords, callback);
            }
            public static void SpawnLocalVehicle(string hash, Vector3 coords, double heading, [Optional()]Action<int> callback)
            {
                Raw.SpawnLocalVehicle(hash, coords, heading, callback);
            }
            public static void SpawnLocalVehicle(int hash, Vector3 coords, double heading, [Optional()]Action<int> callback)
            {
                Raw.SpawnLocalVehicle(hash, coords, heading, callback);
            }
            public static void SpawnVehicle(string hash, Vector3 coords, double heading, [Optional()]Action<int> callback)
            {
                Raw.SpawnVehicle(hash, coords, heading, callback);
            }
            public static void SpawnVehicle(int hash, Vector3 coords, double heading, [Optional()]Action<int> callback)
            {
                Raw.SpawnVehicle(hash, coords, heading, callback);
            }
            public static void Teleport(string entity, Vector3 coords, [Optional()]Action callback)
            {
                Raw.Teleport(entity, coords, callback);
            }

            public class Utils
            {
                public static dynamic Raw => ESX.Raw.Game.Utils ?? (GetObject().Game.Utils);
                public static void DrawText3D(Vector3 coords, string text, double size, dynamic font)
                {
                    Raw.DrawText3D(coords, text, size, font);
                }
            }
        }
        public class Scaleform
        {
            public static dynamic Raw => ESX.Raw.Scaleform ?? (GetObject().Scaleform);
            public static void ShowBreakingNews(string title, string message, string bottom, int sec)
            {
                Raw.ShowBreakingNews(title, message, bottom, sec);
            }
            public static void ShowFreemodeMessage(string title, string message, int sec)
            {
                Raw.ShowFreemodeMessage(title, message, sec);
            }
            public static void ShowPopupWarning(string title, string message, string footer, int sec)
            {
                Raw.ShowPopupWarning(title, message, footer, sec);
            }
            public static void ShowTrafficMovie(int sec)
            {
                Raw.ShowTrafficMovie(sec);
            }
            public class Utils
            {
                public static dynamic Raw => ESX.Raw.Scaleform.Utils ?? (GetObject().Scaleform.Utils);
                public static void RequestScaleformMovie(string movie)
                {
                    Raw.RequestScaleformMovie(movie);
                }
            }
        }
        public class Streaming
        {
            public static dynamic Raw => ESX.Raw.Streaming ?? (GetObject().Streaming);
            public static void RequestAnimDict(string animDict, [Optional()]Action callback)
            {
                Raw.RequestAnimDict(animDict, callback);
            }
            public static void RequestAnimSet(string animSet, [Optional()]Action callback)
            {
                Raw.RequestAnimSet(animSet, callback);
            }
            public static void RequestModel(string model, [Optional()]Action callback)
            {
                Raw.RequestModel(model, callback);
            }
            public static void RequestNamedPtfxAsset(string assetName, [Optional()]Action callback)
            {
                Raw.RequestNamedPtfxAsset(assetName, callback);
            }
            public static void RequestStreamedTextureDict(string textureDict, [Optional()]Action callback)
            {
                Raw.RequestStreamedTextureDict(textureDict, callback);
            }
            public static void RequestWeaponAsset(string hash, [Optional()]Action callback)
            {
                Raw.RequestWeaponAsset(hash, callback);
            }
        }
        public class UI
        {
            public static dynamic Raw => ESX.Raw.UI ?? (GetObject().UI);
            public class HUD
            {
                public static dynamic Raw => ESX.Raw.UI.HUD ?? (GetObject().UI.HUD);
                public static void RegisterElement(string name, int index, int priority, string html, dynamic data)
                {
                    Raw.RegisterElement(name, index, priority, html, data);
                }
                public static void RemoveElement(string name)
                {
                    Raw.RemoveElement(name);
                }
                public static void SetDisplay(double opacity)
                {
                    Raw.SetDisplay(opacity);
                }
                public static void UpdateElement(string name, dynamic data)
                {
                    Raw.UpdateElement(name, data);
                }
            }
            public class Menu
            {
                public static dynamic Raw => ESX.Raw.UI.Menu ?? (GetObject().UI.Menu);
                public dynamic RawInstance;
                public Menu(dynamic data)
                {
                    RawInstance = data;
                }
                public Menu(string menuType, string nameSpace, string menuName)
                {
                    RawInstance = new System.Dynamic.ExpandoObject();
                    RawInstance.name = menuName;
                    RawInstance.type = menuType;
                    RawInstance.@namespace = nameSpace;

                    RawInstance.data = new MenuData();
                }
                public Menu()
                {
                    RawInstance = new System.Dynamic.ExpandoObject();
                }
                public string type
                {
                    get { return RawInstance.type; }
                    set { RawInstance.type = value; }
                }
                public string @namespace
                {
                    get { return RawInstance.@namespace; }
                    set { RawInstance.@namespace = value; }
                }
                public string name
                {
                    get { return RawInstance.name; }
                    set { RawInstance.name = value; }
                }
                public MenuData data
                {
                    get { return new MenuData(RawInstance.data); }
                    set { RawInstance.data = value; }
                }
#region UNFINISHED
#if DEBUG
                public void AddElement(MenuElement element)
                {
                    data.elements.Add(element);
                }
                public void AddElement(dynamic label, dynamic value, dynamic custom = null, string type = "default")
                {
                    data.elements.Add(new MenuElement
                    {
                        label = label,
                        value = value,
                        type = type,
                        custom = custom
                    });
                }
                public void UpdateElement(MenuElement old, MenuElement @new)
                {
                    data.elements.Insert(data.elements.IndexOf(old), @new);
                }
                public void UpdateElement(MenuElement old, dynamic label, dynamic value, dynamic custom = null, string type = "default")
                {
                    data.elements.Insert(data.elements.IndexOf(old), new MenuElement
                    {
                        label = label,
                        value = value,
                        type = type,
                        custom = custom
                    });
                }
                public void RemoveElement(MenuElement element)
                {
                    data.elements.Remove(element);
                }
                public void RemoveElement(dynamic label, dynamic value)
                {
                    data.elements.RemoveAll(x => x.label == label && x.value == value);
                }
                public void RemoveAllElement()
                {
                    data.elements.Clear();
                }
                public void RemoveElement(int elementindex)
                {
                    data.elements.RemoveAt(elementindex);
                }
                public bool HasElement(MenuElement element)
                {
                    return data.elements.Contains(element);
                }
                public bool HasElement(dynamic label, dynamic value)
                {
                    return data.elements.Exists(x => x.label == label && x.value == value);
                }
                public MenuElement GetElement(dynamic label, dynamic value)
                {
                    return data.elements.Find(x => x.label == label && x.value == value);
                }
                public void SetTitle(string title)
                {
                    data.title = title;
                }
                public void SetAlign(string align)
                {
                    data.align = align;
                }
                public void Close()
                {
                    RawInstance.close();
                }
                public void Refresh()
                {
                    RawInstance.refresh();
                }
                [Obsolete("Not ready for use yet, leads to 'Exception has been thrown by the target of an invocation'", true)]
                public Menu Display([Optional()]Action<dynamic, dynamic> submit, [Optional()]Action<dynamic, dynamic> cancel, [Optional()]Action<dynamic, dynamic> change, [Optional()]Action close)
                {
                    return new Menu(Raw.Open(type, @namespace, name, data.Raw, submit, cancel, change, close));
                }
#endif
#endregion
                public static void Close(string type, string @namespace, string name)
                {
                    Raw.Close(type, @namespace, name);
                }
                public static void Close(Menu menu)
                {
                    Raw.Close(menu.type, menu.@namespace, menu.name);
                }
                public static void CloseAll()
                {
                    Raw.CloseAll();
                }
                public static Menu GetOpened(string type, string @namespace, string name)
                {
                    return new Menu(Raw.GetOpened(type, @namespace, name));
                }
                public static List<Menu> GetOpenedMenus()
                {
                    var data = Raw.GetOpenedMenus();
                    List<Menu> menus = new List<Menu>();
                    foreach (var i in data)
                        menus.Add(new Menu(i));

                    return menus;
                }
                public static bool IsOpen(string type, string @namespace, string name)
                {
                    return Raw.RawIsOpen(type, @namespace, name);
                }
                public static Menu Open(string type, string @namespace, string name, MenuData data, [Optional()]Action<dynamic, dynamic> submit, [Optional()]Action<dynamic, dynamic> cancel, [Optional()]Action<dynamic, dynamic> change, [Optional()]Action close)
                {
                    return new Menu(Raw.Open(type, @namespace, name, data.Raw, submit, cancel, change, close));
                }
                public static void RegisterType(string type, [Optional()]Action<string, string, dynamic> open, [Optional()]Action<string, Menu> close)
                {
                    Raw.RegisterType(type, open, close);
                }
            }

            public class MenuData
            {
                public dynamic Raw;
                public MenuData(dynamic data)
                {
                    Raw = data;
                }
                public MenuData()
                {
                    Raw = new System.Dynamic.ExpandoObject();

                    Raw.title = new System.Dynamic.ExpandoObject();
                    Raw.align = new System.Dynamic.ExpandoObject();
                    Raw.elements = new System.Dynamic.ExpandoObject();
                    Raw.elements.head = new System.Dynamic.ExpandoObject();
                    Raw.elements.rows = new System.Dynamic.ExpandoObject();
                }
                public List<MenuElement> elements
                {
                    get
                    {
                        List<MenuElement> temp = new List<MenuElement>();
                        foreach (var i in Raw.elements)
                            temp.Add(new MenuElement(i));

                        return temp;
                    }
                    set { Raw.elements = value; }
                }
                public string title
                {
                    get { return Raw.title; }
                    set { Raw.title = value; }
                }
                public string align
                {
                    get { return Raw.align; }
                    set { Raw.align = value; }
                }
                public string[] head
                {
                    get { return Raw.elements.head; }
                    set { Raw.elements.head = value; }
                }
                public dynamic rows
                {
                    get { return Raw.elements.rows; }
                    set { Raw.elements.rows = value; }
                }
            }

            public class MenuElement
            {
                public dynamic Raw;
                public MenuElement(dynamic data)
                {
                    Raw = data;
                }
                public MenuElement(dynamic label, dynamic value, dynamic customdata = null, string type = "default")
                {
                    Raw = new System.Dynamic.ExpandoObject();
                    Raw.label = label;
                    Raw.value = value;
                    Raw.type = type;
                    custom = customdata;
                }
                public MenuElement()
                {
                    Raw = new System.Dynamic.ExpandoObject();
                    Raw.label = new System.Dynamic.ExpandoObject();
                    Raw.value = new System.Dynamic.ExpandoObject();
                    Raw.type = "default";

                    custom = new System.Dynamic.ExpandoObject();
                }
                public dynamic label
                {
                    get { return Raw.label; }
                    set { Raw.label = value; }
                }
                public dynamic value
                {
                    get { return Raw.value; }
                    set { Raw.value = value; }
                }
                public string type
                {
                    get { return Raw.type; }
                    set { Raw.type = value; }
                }
                public dynamic custom { get; set; }
            }
        }
    }

    public class PlayerData
    {
        public dynamic Raw;
        public PlayerData(dynamic data)
        {
            Raw = data;
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
        public Job job
        {
            get
            {
                return new Job(Raw.job);
            }
        }
        public Vector3 coords
        {
            get
            {
                return new Vector3((float)Raw.coords.x, (float)Raw.coords.y, (float)Raw.coords.z);
            }
        }
        public double heading
        {
            get { return Raw.coords.heading; }
        }
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
        public double maxWeight
        {
            get
            {
                return Raw.maxWeight;
            }
        }
    }
    public class VehicleProperties
    {
        public dynamic Raw;
        public VehicleProperties(dynamic data)
        {
            Raw = data;
        }
        public VehicleProperties() { }
        public uint model
        {
            get { return Raw.model; }
            set { Raw.model = value; }
        }
        public string plate
        {
            get { return Raw.plate; }
            set { Raw.plate = value; }
        }
        public int plateIndex
        {
            get { return Raw.plateIndex; }
            set { Raw.plateIndex = value; }
        }
        public float bodyHealth
        {
            get { return Raw.bodyHealth; }
            set { Raw.bodyHealth = value; }
        }
        public float engineHealth
        {
            get { return Raw.engineHealth; }
            set { Raw.engineHealth = value; }
        }
        public float tankHealth
        {
            get { return Raw.tankHealth; }
            set { Raw.tankHealth = value; }
        }
        public float fuelLevel
        {
            get { return Raw.fuelLevel; }
            set { Raw.fuelLevel = value; }
        }
        public float dirtLevel
        {
            get { return Raw.dirtLevel; }
            set { Raw.dirtLevel = value; }
        }
        public VehicleColor color1
        {
            get { return (VehicleColor)Raw.color1; }
            set { Raw.color1 = (int)value; }
        }
        public VehicleColor color2
        {
            get { return (VehicleColor)Raw.color2; }
            set { Raw.color2 = (int)value; }
        }
        public VehicleColor pearlescentColor
        {
            get { return (VehicleColor)Raw.pearlescentColor; }
            set { Raw.pearlescentColor = (int)value; }
        }
        public VehicleColor wheelColor
        {
            get { return (VehicleColor)Raw.wheelColor; }
            set { Raw.wheelColor = (int)value; }
        }
        public VehicleWheelType wheels
        {
            get { return (VehicleWheelType)Raw.wheels; }
            set { Raw.wheels = (int)value; }
        }
        public VehicleWindowTint windowTint
        {
            get { return (VehicleWindowTint)Raw.windowTint; }
            set { Raw.windowTint = (int)value; }
        }
        public bool[] neonEnabled
        {
            get { return Raw.neonEnabled; }
            set { Raw.neonEnabled = value; }
        }
        public dynamic neonColor
        {
            get { return Raw.neonColor; }
            set { Raw.neonColor = value; }
        }
        public dynamic extras
        {
            get { return Raw.extras; }
            set { Raw.extras = value; }
        }
        public dynamic tyreSmokeColor
        {
            get { return Raw.tyreSmokeColor; }
            set { Raw.tyreSmokeColor = value; }
        }
        public int modSpoilers
        {
            get { return Raw.modSpoilers; }
            set { Raw.modSpoilers = value; }
        }
        public int modFrontBumper
        {
            get { return Raw.modFrontBumper; }
            set { Raw.modFrontBumper = value; }
        }
        public int modRearBumper
        {
            get { return Raw.modRearBumper; }
            set { Raw.modRearBumper = value; }
        }
        public int modSideSkirt
        {
            get { return Raw.modSideSkirt; }
            set { Raw.modSideSkirt = value; }
        }
        public int modExhaust
        {
            get { return Raw.modExhaust; }
            set { Raw.modExhaust = value; }
        }
        public int modFrame
        {
            get { return Raw.modFrame; }
            set { Raw.modFrame = value; }
        }
        public int modGrille
        {
            get { return Raw.modGrille; }
            set { Raw.modGrille = value; }
        }
        public int modHood
        {
            get { return Raw.modHood; }
            set { Raw.modHood = value; }
        }
        public int modFender
        {
            get { return Raw.modFender; }
            set { Raw.modFender = value; }
        }
        public int modRightFender
        {
            get { return Raw.modRightFender; }
            set { Raw.modRightFender = value; }
        }
        public int modRoof
        {
            get { return Raw.modRoof; }
            set { Raw.modRoof = value; }
        }
        public int modEngine
        {
            get { return Raw.modEngine; }
            set { Raw.modEngine = value; }
        }
        public int modBrakes
        {
            get { return Raw.modBrakes; }
            set { Raw.modBrakes = value; }
        }
        public int modTransmission
        {
            get { return Raw.modTransmission; }
            set { Raw.modTransmission = value; }
        }
        public int modHorns
        {
            get { return Raw.modHorns; }
            set { Raw.modHorns = value; }
        }
        public int modSuspension
        {
            get { return Raw.modSuspension; }
            set { Raw.modSuspension = value; }
        }
        public int modArmor
        {
            get { return Raw.modArmor; }
            set { Raw.modArmor = value; }
        }
        public int modTurbo
        {
            get { return Raw.modTurbo; }
            set { Raw.modTurbo = value; }
        }
        public int modSmokeEnabled
        {
            get { return Raw.modSmokeEnabled; }
            set { Raw.modSmokeEnabled = value; }
        }
        public int modXenon
        {
            get { return Raw.modXenon; }
            set { Raw.modXenon = value; }
        }
        public int modFrontWheels
        {
            get { return Raw.modFrontWheels; }
            set { Raw.modFrontWheels = value; }
        }
        public int modBackWheels
        {
            get { return Raw.modBackWheels; }
            set { Raw.modBackWheels = value; }
        }
        public int modPlateHolder
        {
            get { return Raw.modPlateHolder; }
            set { Raw.modPlateHolder = value; }
        }
        public int modVanityPlate
        {
            get { return Raw.modVanityPlate; }
            set { Raw.modVanityPlate = value; }
        }
        public int modTrimA
        {
            get { return Raw.modTrimA; }
            set { Raw.modTrimA = value; }
        }
        public int modOrnaments
        {
            get { return Raw.modOrnaments; }
            set { Raw.modOrnaments = value; }
        }
        public int modDashboard
        {
            get { return Raw.modDashboard; }
            set { Raw.modDashboard = value; }
        }
        public int modDial
        {
            get { return Raw.modDial; }
            set { Raw.modDial = value; }
        }
        public int modDoorSpeaker
        {
            get { return Raw.modDoorSpeaker; }
            set { Raw.modDoorSpeaker = value; }
        }
        public int modSeats
        {
            get { return Raw.modSeats; }
            set { Raw.modSeats = value; }
        }
        public int modSteeringWheel
        {
            get { return Raw.modSteeringWheel; }
            set { Raw.modSteeringWheel = value; }
        }
        public int modShifterLeavers
        {
            get { return Raw.modShifterLeavers; }
            set { Raw.modShifterLeavers = value; }
        }
        public int modAPlate
        {
            get { return Raw.modAPlate; }
            set { Raw.modAPlate = value; }
        }
        public int modSpeakers
        {
            get { return Raw.modSpeakers; }
            set { Raw.modSpeakers = value; }
        }
        public int modTrunk
        {
            get { return Raw.modTrunk; }
            set { Raw.modTrunk = value; }
        }
        public int modHydrolic
        {
            get { return Raw.modHydrolic; }
            set { Raw.modHydrolic = value; }
        }
        public int modEngineBlock
        {
            get { return Raw.modEngineBlock; }
            set { Raw.modEngineBlock = value; }
        }
        public int modAirFilter
        {
            get { return Raw.modAirFilter; }
            set { Raw.modAirFilter = value; }
        }
        public int modStruts
        {
            get { return Raw.modStruts; }
            set { Raw.modStruts = value; }
        }
        public int modArchCover
        {
            get { return Raw.modArchCover; }
            set { Raw.modArchCover = value; }
        }
        public int modAerials
        {
            get { return Raw.modAerials; }
            set { Raw.modAerials = value; }
        }
        public int modTrimB
        {
            get { return Raw.modTrimB; }
            set { Raw.modTrimB = value; }
        }
        public int modTank
        {
            get { return Raw.modTank; }
            set { Raw.modTank = value; }
        }
        public int modWindows
        {
            get { return Raw.modWindows; }
            set { Raw.modWindows = value; }
        }
        public int modLivery
        {
            get { return Raw.modLivery; }
            set { Raw.modLivery = value; }
        }
    }
    public enum HudColor : int
    {
        HUD_COLOUR_PURE_WHITE,
        HUD_COLOUR_WHITE,
        HUD_COLOUR_BLACK,
        HUD_COLOUR_GREY,
        HUD_COLOUR_GREYLIGHT,
        HUD_COLOUR_GREYDARK,
        HUD_COLOUR_RED,
        HUD_COLOUR_REDLIGHT,
        HUD_COLOUR_REDDARK,
        HUD_COLOUR_BLUE,
        HUD_COLOUR_BLUELIGHT,
        HUD_COLOUR_BLUEDARK,
        HUD_COLOUR_YELLOW,
        HUD_COLOUR_YELLOWLIGHT,
        HUD_COLOUR_YELLOWDARK,
        HUD_COLOUR_ORANGE,
        HUD_COLOUR_ORANGELIGHT,
        HUD_COLOUR_ORANGEDARK,
        HUD_COLOUR_GREEN,
        HUD_COLOUR_GREENLIGHT,
        HUD_COLOUR_GREENDARK,
        HUD_COLOUR_PURPLE,
        HUD_COLOUR_PURPLELIGHT,
        HUD_COLOUR_PURPLEDARK,
        HUD_COLOUR_PINK,
        HUD_COLOUR_RADAR_HEALTH,
        HUD_COLOUR_RADAR_ARMOUR,
        HUD_COLOUR_RADAR_DAMAGE,
        HUD_COLOUR_NET_PLAYER1,
        HUD_COLOUR_NET_PLAYER2,
        HUD_COLOUR_NET_PLAYER3,
        HUD_COLOUR_NET_PLAYER4,
        HUD_COLOUR_NET_PLAYER5,
        HUD_COLOUR_NET_PLAYER6,
        HUD_COLOUR_NET_PLAYER7,
        HUD_COLOUR_NET_PLAYER8,
        HUD_COLOUR_NET_PLAYER9,
        HUD_COLOUR_NET_PLAYER10,
        HUD_COLOUR_NET_PLAYER11,
        HUD_COLOUR_NET_PLAYER12,
        HUD_COLOUR_NET_PLAYER13,
        HUD_COLOUR_NET_PLAYER14,
        HUD_COLOUR_NET_PLAYER15,
        HUD_COLOUR_NET_PLAYER16,
        HUD_COLOUR_NET_PLAYER17,
        HUD_COLOUR_NET_PLAYER18,
        HUD_COLOUR_NET_PLAYER19,
        HUD_COLOUR_NET_PLAYER20,
        HUD_COLOUR_NET_PLAYER21,
        HUD_COLOUR_NET_PLAYER22,
        HUD_COLOUR_NET_PLAYER23,
        HUD_COLOUR_NET_PLAYER24,
        HUD_COLOUR_NET_PLAYER25,
        HUD_COLOUR_NET_PLAYER26,
        HUD_COLOUR_NET_PLAYER27,
        HUD_COLOUR_NET_PLAYER28,
        HUD_COLOUR_NET_PLAYER29,
        HUD_COLOUR_NET_PLAYER30,
        HUD_COLOUR_NET_PLAYER31,
        HUD_COLOUR_NET_PLAYER32,
        HUD_COLOUR_SIMPLEBLIP_DEFAULT,
        HUD_COLOUR_MENU_BLUE,
        HUD_COLOUR_MENU_GREY_LIGHT,
        HUD_COLOUR_MENU_BLUE_EXTRA_DARK,
        HUD_COLOUR_MENU_YELLOW,
        HUD_COLOUR_MENU_YELLOW_DARK,
        HUD_COLOUR_MENU_GREEN,
        HUD_COLOUR_MENU_GREY,
        HUD_COLOUR_MENU_GREY_DARK,
        HUD_COLOUR_MENU_HIGHLIGHT,
        HUD_COLOUR_MENU_STANDARD,
        HUD_COLOUR_MENU_DIMMED,
        HUD_COLOUR_MENU_EXTRA_DIMMED,
        HUD_COLOUR_BRIEF_TITLE,
        HUD_COLOUR_MID_GREY_MP,
        HUD_COLOUR_NET_PLAYER1_DARK,
        HUD_COLOUR_NET_PLAYER2_DARK,
        HUD_COLOUR_NET_PLAYER3_DARK,
        HUD_COLOUR_NET_PLAYER4_DARK,
        HUD_COLOUR_NET_PLAYER5_DARK,
        HUD_COLOUR_NET_PLAYER6_DARK,
        HUD_COLOUR_NET_PLAYER7_DARK,
        HUD_COLOUR_NET_PLAYER8_DARK,
        HUD_COLOUR_NET_PLAYER9_DARK,
        HUD_COLOUR_NET_PLAYER10_DARK,
        HUD_COLOUR_NET_PLAYER11_DARK,
        HUD_COLOUR_NET_PLAYER12_DARK,
        HUD_COLOUR_NET_PLAYER13_DARK,
        HUD_COLOUR_NET_PLAYER14_DARK,
        HUD_COLOUR_NET_PLAYER15_DARK,
        HUD_COLOUR_NET_PLAYER16_DARK,
        HUD_COLOUR_NET_PLAYER17_DARK,
        HUD_COLOUR_NET_PLAYER18_DARK,
        HUD_COLOUR_NET_PLAYER19_DARK,
        HUD_COLOUR_NET_PLAYER20_DARK,
        HUD_COLOUR_NET_PLAYER21_DARK,
        HUD_COLOUR_NET_PLAYER22_DARK,
        HUD_COLOUR_NET_PLAYER23_DARK,
        HUD_COLOUR_NET_PLAYER24_DARK,
        HUD_COLOUR_NET_PLAYER25_DARK,
        HUD_COLOUR_NET_PLAYER26_DARK,
        HUD_COLOUR_NET_PLAYER27_DARK,
        HUD_COLOUR_NET_PLAYER28_DARK,
        HUD_COLOUR_NET_PLAYER29_DARK,
        HUD_COLOUR_NET_PLAYER30_DARK,
        HUD_COLOUR_NET_PLAYER31_DARK,
        HUD_COLOUR_NET_PLAYER32_DARK,
        HUD_COLOUR_BRONZE,
        HUD_COLOUR_SILVER,
        HUD_COLOUR_GOLD,
        HUD_COLOUR_PLATINUM,
        HUD_COLOUR_GANG1,
        HUD_COLOUR_GANG2,
        HUD_COLOUR_GANG3,
        HUD_COLOUR_GANG4,
        HUD_COLOUR_SAME_CREW,
        HUD_COLOUR_FREEMODE,
        HUD_COLOUR_PAUSE_BG,
        HUD_COLOUR_FRIENDLY,
        HUD_COLOUR_ENEMY,
        HUD_COLOUR_LOCATION,
        HUD_COLOUR_PICKUP,
        HUD_COLOUR_PAUSE_SINGLEPLAYER,
        HUD_COLOUR_FREEMODE_DARK,
        HUD_COLOUR_INACTIVE_MISSION,
        HUD_COLOUR_DAMAGE,
        HUD_COLOUR_PINKLIGHT,
        HUD_COLOUR_PM_MITEM_HIGHLIGHT,
        HUD_COLOUR_SCRIPT_VARIABLE,
        HUD_COLOUR_YOGA,
        HUD_COLOUR_TENNIS,
        HUD_COLOUR_GOLF,
        HUD_COLOUR_SHOOTING_RANGE,
        HUD_COLOUR_FLIGHT_SCHOOL,
        HUD_COLOUR_NORTH_BLUE,
        HUD_COLOUR_SOCIAL_CLUB,
        HUD_COLOUR_PLATFORM_BLUE,
        HUD_COLOUR_PLATFORM_GREEN,
        HUD_COLOUR_PLATFORM_GREY,
        HUD_COLOUR_FACEBOOK_BLUE,
        HUD_COLOUR_INGAME_BG,
        HUD_COLOUR_DARTS,
        HUD_COLOUR_WAYPOINT,
        HUD_COLOUR_MICHAEL,
        HUD_COLOUR_FRANKLIN,
        HUD_COLOUR_TREVOR,
        HUD_COLOUR_GOLF_P1,
        HUD_COLOUR_GOLF_P2,
        HUD_COLOUR_GOLF_P3,
        HUD_COLOUR_GOLF_P4,
        HUD_COLOUR_WAYPOINTLIGHT,
        HUD_COLOUR_WAYPOINTDARK,
        HUD_COLOUR_PANEL_LIGHT,
        HUD_COLOUR_MICHAEL_DARK,
        HUD_COLOUR_FRANKLIN_DARK,
        HUD_COLOUR_TREVOR_DARK,
        HUD_COLOUR_OBJECTIVE_ROUTE,
        HUD_COLOUR_PAUSEMAP_TINT,
        HUD_COLOUR_PAUSE_DESELECT,
        HUD_COLOUR_PM_WEAPONS_PURCHASABLE,
        HUD_COLOUR_PM_WEAPONS_LOCKED,
        HUD_COLOUR_END_SCREEN_BG,
        HUD_COLOUR_CHOP,
        HUD_COLOUR_PAUSEMAP_TINT_HALF,
        HUD_COLOUR_NORTH_BLUE_OFFICIAL,
        HUD_COLOUR_SCRIPT_VARIABLE_2,
        HUD_COLOUR_H,
        HUD_COLOUR_HDARK,
        HUD_COLOUR_T,
        HUD_COLOUR_TDARK,
        HUD_COLOUR_HSHARD,
        HUD_COLOUR_CONTROLLER_MICHAEL,
        HUD_COLOUR_CONTROLLER_FRANKLIN,
        HUD_COLOUR_CONTROLLER_TREVOR,
        HUD_COLOUR_CONTROLLER_CHOP,
        HUD_COLOUR_VIDEO_EDITOR_VIDEO,
        HUD_COLOUR_VIDEO_EDITOR_AUDIO,
        HUD_COLOUR_VIDEO_EDITOR_TEXT,
        HUD_COLOUR_HB_BLUE,
        HUD_COLOUR_HB_YELLOW,
        HUD_COLOUR_VIDEO_EDITOR_SCORE,
        HUD_COLOUR_VIDEO_EDITOR_AUDIO_FADEOUT,
        HUD_COLOUR_VIDEO_EDITOR_TEXT_FADEOUT,
        HUD_COLOUR_VIDEO_EDITOR_SCORE_FADEOUT,
        HUD_COLOUR_HEIST_BACKGROUND,
        HUD_COLOUR_VIDEO_EDITOR_AMBIENT,
        HUD_COLOUR_VIDEO_EDITOR_AMBIENT_FADEOUT,
        HUD_COLOUR_GB,
        HUD_COLOUR_G,
        HUD_COLOUR_B,
        HUD_COLOUR_LOW_FLOW,
        HUD_COLOUR_LOW_FLOW_DARK,
        HUD_COLOUR_G1,
        HUD_COLOUR_G2,
        HUD_COLOUR_G3,
        HUD_COLOUR_G4,
        HUD_COLOUR_G5,
        HUD_COLOUR_G6,
        HUD_COLOUR_G7,
        HUD_COLOUR_G8,
        HUD_COLOUR_G9,
        HUD_COLOUR_G10,
        HUD_COLOUR_G11,
        HUD_COLOUR_G12,
        HUD_COLOUR_G13,
        HUD_COLOUR_G14,
        HUD_COLOUR_G15,
        HUD_COLOUR_ADVERSARY,
        HUD_COLOUR_DEGEN_RED,
        HUD_COLOUR_DEGEN_YELLOW,
        HUD_COLOUR_DEGEN_GREEN,
        HUD_COLOUR_DEGEN_CYAN,
        HUD_COLOUR_DEGEN_BLUE,
        HUD_COLOUR_DEGEN_MAGENTA,
        HUD_COLOUR_STUNT_1,
        HUD_COLOUR_STUNT_2,
        HUD_COLOUR_SPECIAL_RACE_SERIES,
        HUD_COLOUR_SPECIAL_RACE_SERIES_DARK,
        HUD_COLOUR_CS,
        HUD_COLOUR_CS_DARK,
        HUD_COLOUR_TECH_GREEN,
        HUD_COLOUR_TECH_GREEN_DARK,
        HUD_COLOUR_TECH_RED,
        HUD_COLOUR_TECH_GREEN_VERY_DARK,
        HUD_COLOUR_DEFAULT //not a real value, used in logic
    }
    public enum IconType : int
    {
        ChatBox = 1,
        Email = 2,
        AddFriendRequest = 3,
        RightJumpingWindow = 7,
        RP = 8,
        Dollar = 9
    }
    public enum NotificationPicture
    {
        CHAR_ABIGAIL,
        CHAR_ALL_PLAYERS_CONF,
        CHAR_AMANDA,
        CHAR_AMMUNATION,
        CHAR_ANDREAS,
        CHAR_ANTONIA,
        CHAR_ARTHUR,
        CHAR_ASHLEY,
        CHAR_BANK_BOL,
        CHAR_BANK_FLEECA,
        CHAR_BANK_MAZE,
        CHAR_BARRY,
        CHAR_BEVERLY,
        CHAR_BIKESITE,
        CHAR_BLANK_ENTRY,
        CHAR_BLIMP,
        CHAR_BLOCKED,
        CHAR_BOATSITE,
        CHAR_BROKEN_DOWN_GIRL,
        CHAR_BUGSTARS,
        CHAR_CALL911,
        CHAR_CARSITE,
        CHAR_CARSITE2,
        CHAR_CASTRO,
        CHAR_CHAT_CALL,
        CHAR_CHEF,
        CHAR_CHENG,
        CHAR_CHENGSR,
        CHAR_CHOP,
        CHAR_CRIS,
        CHAR_DAVE,
        CHAR_DEFAULT,
        CHAR_DENISE,
        CHAR_DETONATEBOMB,
        CHAR_DETONATEPHONE,
        CHAR_DEVIN,
        CHAR_DIAL_A_SUB,
        CHAR_DOM,
        CHAR_DOMESTIC_GIRL,
        CHAR_DREYFUSS,
        CHAR_DR_FRIEDLANDER,
        CHAR_EPSILON,
        CHAR_ESTATE_AGENT,
        CHAR_FACEBOOK,
        CHAR_FILMNOIR,
        CHAR_FLOYD,
        CHAR_FRANKLIN,
        CHAR_FRANK_TREV_CONF,
        CHAR_GAYMILITARY,
        CHAR_HAO,
        CHAR_HITCHER_GIRL,
        CHAR_HUMANDEFAULT,
        CHAR_HUNTER,
        CHAR_JIMMY,
        CHAR_JIMMY_BOSTON,
        CHAR_JOE,
        CHAR_JOSEF,
        CHAR_JOSH,
        CHAR_LAMAR,
        CHAR_LAZLOW,
        CHAR_LESTER,
        CHAR_LESTER_DEATHWISH,
        CHAR_LEST_FRANK_CONF,
        CHAR_LEST_MIKE_CONF,
        CHAR_LIFEINVADER,
        CHAR_LS_CUSTOMS,
        CHAR_LS_TOURIST_BOARD,
        CHAR_MANUEL,
        CHAR_MARNIE,
        CHAR_MARTIN,
        CHAR_MARY_ANN,
        CHAR_MAUDE,
        CHAR_MECHANIC,
        CHAR_MICHAEL,
        CHAR_MIKE_FRANK_CONF,
        CHAR_MIKE_TREV_CONF,
        CHAR_MILSITE,
        CHAR_MINOTAUR,
        CHAR_MOLLY,
        CHAR_MP_ARMY_CONTACT,
        CHAR_MP_BIKER_BOSS,
        CHAR_MP_BIKER_MECHANIC,
        CHAR_MP_BRUCIE,
        CHAR_MP_DETONATEPHONE,
        CHAR_MP_FAM_BOSS,
        CHAR_MP_FIB_CONTACT,
        CHAR_MP_FM_CONTACT,
        CHAR_MP_GERALD,
        CHAR_MP_JULIO,
        CHAR_MP_MECHANIC,
        CHAR_MP_MERRYWEATHER,
        CHAR_MP_MEX_BOSS,
        CHAR_MP_MEX_DOCKS,
        CHAR_MP_MEX_LT,
        CHAR_MP_MORS_MUTUAL,
        CHAR_MP_PROF_BOSS,
        CHAR_MP_RAY_LAVOY,
        CHAR_MP_ROBERTO,
        CHAR_MP_SNITCH,
        CHAR_MP_STRETCH,
        CHAR_MP_STRIPCLUB_PR,
        CHAR_MRS_THORNHILL,
        CHAR_MULTIPLAYER,
        CHAR_NIGEL,
        CHAR_OMEGA,
        CHAR_ONEIL,
        CHAR_ORTEGA,
        CHAR_OSCAR,
        CHAR_PATRICIA,
        CHAR_PEGASUS_DELIVERY,
        CHAR_PLANESITE,
        CHAR_PROPERTY_ARMS_TRAFFICKING,
        CHAR_PROPERTY_BAR_AIRPORT,
        CHAR_PROPERTY_BAR_BAYVIEW,
        CHAR_PROPERTY_BAR_CAFE_ROJO,
        CHAR_PROPERTY_BAR_COCKOTOOS,
        CHAR_PROPERTY_BAR_ECLIPSE,
        CHAR_PROPERTY_BAR_FES,
        CHAR_PROPERTY_BAR_HEN_HOUSE,
        CHAR_PROPERTY_BAR_HI_MEN,
        CHAR_PROPERTY_BAR_HOOKIES,
        CHAR_PROPERTY_BAR_IRISH,
        CHAR_PROPERTY_BAR_LES_BIANCO,
        CHAR_PROPERTY_BAR_MIRROR_PARK,
        CHAR_PROPERTY_BAR_PITCHERS,
        CHAR_PROPERTY_BAR_SINGLETONS,
        CHAR_PROPERTY_BAR_TEQUILALA,
        CHAR_PROPERTY_BAR_UNBRANDED,
        CHAR_PROPERTY_CAR_MOD_SHOP,
        CHAR_PROPERTY_CAR_SCRAP_YARD,
        CHAR_PROPERTY_CINEMA_DOWNTOWN,
        CHAR_PROPERTY_CINEMA_MORNINGWOOD,
        CHAR_PROPERTY_CINEMA_VINEWOOD,
        CHAR_PROPERTY_GOLF_CLUB,
        CHAR_PROPERTY_PLANE_SCRAP_YARD,
        CHAR_PROPERTY_SONAR_COLLECTIONS,
        CHAR_PROPERTY_TAXI_LOT,
        CHAR_PROPERTY_TOWING_IMPOUND,
        CHAR_PROPERTY_WEED_SHOP,
        CHAR_RON,
        CHAR_SAEEDA,
        CHAR_SASQUATCH,
        CHAR_SIMEON,
        CHAR_SOCIAL_CLUB,
        CHAR_SOLOMON,
        CHAR_STEVE,
        CHAR_STEVE_MIKE_CONF,
        CHAR_STEVE_TREV_CONF,
        CHAR_STRETCH,
        CHAR_STRIPPER_CHASTITY,
        CHAR_STRIPPER_CHEETAH,
        CHAR_STRIPPER_FUFU,
        CHAR_STRIPPER_INFERNUS,
        CHAR_STRIPPER_JULIET,
        CHAR_STRIPPER_NIKKI,
        CHAR_STRIPPER_PEACH,
        CHAR_STRIPPER_SAPPHIRE,
        CHAR_TANISHA,
        CHAR_TAXI,
        CHAR_TAXI_LIZ,
        CHAR_TENNIS_COACH,
        CHAR_TOW_TONYA,
        CHAR_TRACEY,
        CHAR_TREVOR,
        CHAR_WADE,
        CHAR_YOUTUBE
    }
}