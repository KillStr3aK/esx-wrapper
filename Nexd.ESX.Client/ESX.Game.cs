namespace Nexd.ESX.Client
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using CitizenFX.Core;

    public static partial class ESX
    {
        public static partial class Game
        {
            public static dynamic Raw => ESX.Raw.Game;

            public static void DeleteObject(string obj) => Raw.DeleteObject(obj);
            public static void DeleteVehicle(string vehicle) => Raw.DeleteVehicle(vehicle);
            public static dynamic GetClosestObject([Optional()] Vector3 coords, [Optional()] dynamic modelFilter) => Raw.GetClosestObject(coords, modelFilter);
            public static Ped GetClosestPed([Optional()] Vector3 coords, [Optional()] dynamic modelFilter) => new Ped(Raw.GetClosestPed(coords, modelFilter));
            public static Player GetClosestPlayer([Optional()] Vector3 coords) => new Player(Raw.GetClosestPlayer(coords));
            public static Vehicle GetClosestVehicle([Optional()] Vector3 coords, [Optional()] dynamic modelFilter) => new Vehicle(Raw.GetClosestVehicle(coords, modelFilter));
            public static dynamic GetObjects() => Raw.GetObjects();
            public static dynamic GetPedMugshot(string ped, bool transparent = true) => Raw.GetPedMugshot(ped, transparent);
            public static Vehicle GetVehicleInDirection() => new Vehicle(Raw.GetVehicleInDirection());
            public static VehicleProperties GetVehicleProperties(Vehicle vehicle) => new VehicleProperties(Raw.GetVehicleProperties(vehicle.Handle));
            public static VehicleProperties GetVehicleProperties(int vehicle) => new VehicleProperties(Raw.GetVehicleProperties(vehicle));
            public static bool IsSpawnPointClear([Optional()] Vector3 coords, double maxDistance) => Raw.IsSpawnPointClear(coords, maxDistance);
            public static void SetVehicleProperties(Vehicle vehicle, VehicleProperties properties) => Raw.SetVehicleProperties(vehicle.Handle, properties.Raw);
            public static void SpawnLocalObject(string hash, Vector3 coords, [Optional()] Action<int> callback) => Raw.SpawnLocalObject(hash, coords, callback);
            public static void SpawnLocalObject(int hash, Vector3 coords, [Optional()] Action<int> callback) => Raw.SpawnLocalObject(hash, coords, callback);
            public static void SpawnObject(string hash, Vector3 coords, [Optional()] Action<int> callback) => Raw.SpawnObject(hash, coords, callback);
            public static void SpawnObject(int hash, Vector3 coords, [Optional()] Action<int> callback) => Raw.SpawnObject(hash, coords, callback);
            public static void SpawnLocalVehicle(string hash, Vector3 coords, double heading, [Optional()] Action<int> callback) => Raw.SpawnLocalVehicle(hash, coords, heading, callback);
            public static void SpawnLocalVehicle(int hash, Vector3 coords, double heading, [Optional()] Action<int> callback) => Raw.SpawnLocalVehicle(hash, coords, heading, callback);
            public static void SpawnVehicle(string hash, Vector3 coords, double heading, [Optional()] Action<int> callback) => Raw.SpawnVehicle(hash, coords, heading, callback);
            public static void SpawnVehicle(int hash, Vector3 coords, double heading, [Optional()] Action<int> callback) => Raw.SpawnVehicle(hash, coords, heading, callback);
            public static void Teleport(string entity, Vector3 coords, [Optional()] Action callback) => Raw.Teleport(entity, coords, callback);

            public static List<Ped> GetPeds([Optional()] bool onlyOtherPeds)
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

            public static List<Player> GetPlayersInArea([Optional()] Vector3 coords, double maxDistance)
            {
                var data = Raw.GetPlayersInArea(coords, maxDistance);
                List<Player> players = new List<Player>();
                foreach (var i in data)
                    players.Add(new Player(i));

                return players;
            }

            public static List<Vehicle> GetVehicles()
            {
                var data = Raw.GetVehicles();
                List<Vehicle> vehicles = new List<Vehicle>();
                foreach (var i in data)
                    vehicles.Add(new Vehicle(i));

                return vehicles;
            }

            public static List<Vehicle> GetVehiclesInArea([Optional()] Vector3 coords, double maxDistance)
            {
                var data = Raw.GetVehiclesInArea(coords, maxDistance);
                List<Vehicle> vehicles = new List<Vehicle>();
                foreach (var i in data)
                    vehicles.Add(new Vehicle(i));

                return vehicles;
            }
        }
    }
}