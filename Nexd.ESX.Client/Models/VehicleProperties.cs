namespace Nexd.ESX.Client
{
    using CitizenFX.Core;

    public class VehicleProperties
    {
        public dynamic Raw;

        public VehicleProperties() { }

        public VehicleProperties(dynamic data) => Raw = data;

        public uint model
        {
            get => Raw.model;
            set => Raw.model = value;
        }

        public string plate
        {
            get => Raw.plate;
            set => Raw.plate = value;
        }

        public int plateIndex
        {
            get => Raw.plateIndex;
            set => Raw.plateIndex = value;
        }

        public float bodyHealth
        {
            get => Raw.bodyHealth;
            set => Raw.bodyHealth = value;
        }

        public float engineHealth
        {
            get => Raw.engineHealth;
            set => Raw.engineHealth = value;
        }

        public float tankHealth
        {
            get => Raw.tankHealth;
            set => Raw.tankHealth = value;
        }

        public float fuelLevel
        {
            get => Raw.fuelLevel;
            set => Raw.fuelLevel = value;
        }

        public float dirtLevel
        {
            get => Raw.dirtLevel;
            set => Raw.dirtLevel = value;
        }

        public VehicleColor color1
        {
            get => (VehicleColor)Raw.color1;
            set => Raw.color1 = (int)value;
        }

        public VehicleColor color2
        {
            get => (VehicleColor)Raw.color2;
            set => Raw.color2 = (int)value;
        }

        public VehicleColor pearlescentColor
        {
            get => (VehicleColor)Raw.pearlescentColor;
            set => Raw.pearlescentColor = (int)value;
        }

        public VehicleColor wheelColor
        {
            get => (VehicleColor)Raw.wheelColor;
            set => Raw.wheelColor = (int)value;
        }

        public VehicleWheelType wheels
        {
            get => (VehicleWheelType)Raw.wheels;
            set => Raw.wheels = (int)value;
        }

        public VehicleWindowTint windowTint
        {
            get => (VehicleWindowTint)Raw.windowTint;
            set => Raw.windowTint = (int)value;
        }

        public bool[] neonEnabled
        {
            get => Raw.neonEnabled;
            set => Raw.neonEnabled = value;
        }

        public dynamic neonColor
        {
            get => Raw.neonColor;
            set => Raw.neonColor = value;
        }

        public dynamic extras
        {
            get => Raw.extras;
            set => Raw.extras = value;
        }

        public dynamic tyreSmokeColor
        {
            get => Raw.tyreSmokeColor;
            set => Raw.tyreSmokeColor = value;
        }

        public int modSpoilers
        {
            get => Raw.modSpoilers;
            set => Raw.modSpoilers = value;
        }

        public int modFrontBumper
        {
            get => Raw.modFrontBumper;
            set => Raw.modFrontBumper = value;
        }

        public int modRearBumper
        {
            get => Raw.modRearBumper;
            set => Raw.modRearBumper = value;
        }

        public int modSideSkirt
        {
            get => Raw.modSideSkirt;
            set => Raw.modSideSkirt = value;
        }

        public int modExhaust
        {
            get => Raw.modExhaust;
            set => Raw.modExhaust = value;
        }

        public int modFrame
        {
            get => Raw.modFrame;
            set => Raw.modFrame = value;
        }

        public int modGrille
        {
            get => Raw.modGrille;
            set => Raw.modGrille = value;
        }

        public int modHood
        {
            get => Raw.modHood;
            set => Raw.modHood = value;
        }

        public int modFender
        {
            get => Raw.modFender;
            set => Raw.modFender = value;
        }

        public int modRightFender
        {
            get => Raw.modRightFender;
            set => Raw.modRightFender = value;
        }

        public int modRoof
        {
            get => Raw.modRoof;
            set => Raw.modRoof = value;
        }

        public int modEngine
        {
            get => Raw.modEngine;
            set => Raw.modEngine = value;
        }

        public int modBrakes
        {
            get => Raw.modBrakes;
            set => Raw.modBrakes = value;
        }

        public int modTransmission
        {
            get => Raw.modTransmission;
            set => Raw.modTransmission = value;
        }

        public int modHorns
        {
            get => Raw.modHorns;
            set => Raw.modHorns = value;
        }

        public int modSuspension
        {
            get => Raw.modSuspension;
            set => Raw.modSuspension = value;
        }

        public int modArmor
        {
            get => Raw.modArmor;
            set => Raw.modArmor = value;
        }

        public int modTurbo
        {
            get => Raw.modTurbo;
            set => Raw.modTurbo = value;
        }

        public int modSmokeEnabled
        {
            get => Raw.modSmokeEnabled;
            set => Raw.modSmokeEnabled = value;
        }

        public int modXenon
        {
            get => Raw.modXenon;
            set => Raw.modXenon = value;
        }

        public int modFrontWheels
        {
            get => Raw.modFrontWheels;
            set => Raw.modFrontWheels = value;
        }

        public int modBackWheels
        {
            get => Raw.modBackWheels;
            set => Raw.modBackWheels = value;
        }

        public int modPlateHolder
        {
            get => Raw.modPlateHolder;
            set => Raw.modPlateHolder = value;
        }

        public int modVanityPlate
        {
            get => Raw.modVanityPlate;
            set => Raw.modVanityPlate = value;
        }

        public int modTrimA
        {
            get => Raw.modTrimA;
            set => Raw.modTrimA = value;
        }

        public int modOrnaments
        {
            get => Raw.modOrnaments;
            set => Raw.modOrnaments = value;
        }

        public int modDashboard
        {
            get => Raw.modDashboard;
            set => Raw.modDashboard = value;
        }
        public int modDial
        {
            get => Raw.modDial;
            set => Raw.modDial = value;
        }

        public int modDoorSpeaker
        {
            get => Raw.modDoorSpeaker;
            set => Raw.modDoorSpeaker = value;
        }

        public int modSeats
        {
            get => Raw.modSeats;
            set => Raw.modSeats = value;
        }

        public int modSteeringWheel
        {
            get => Raw.modSteeringWheel;
            set => Raw.modSteeringWheel = value;
        }

        public int modShifterLeavers
        {
            get => Raw.modShifterLeavers;
            set => Raw.modShifterLeavers = value;
        }

        public int modAPlate
        {
            get => Raw.modAPlate;
            set => Raw.modAPlate = value;
        }

        public int modSpeakers
        {
            get => Raw.modSpeakers;
            set => Raw.modSpeakers = value;
        }

        public int modTrunk
        {
            get => Raw.modTrunk;
            set => Raw.modTrunk = value;
        }

        public int modHydrolic
        {
            get => Raw.modHydrolic;
            set => Raw.modHydrolic = value;
        }

        public int modEngineBlock
        {
            get => Raw.modEngineBlock;
            set => Raw.modEngineBlock = value;
        }

        public int modAirFilter
        {
            get => Raw.modAirFilter;
            set => Raw.modAirFilter = value;
        }

        public int modStruts
        {
            get => Raw.modStruts;
            set => Raw.modStruts = value;
        }

        public int modArchCover
        {
            get => Raw.modArchCover;
            set => Raw.modArchCover = value;
        }

        public int modAerials
        {
            get => Raw.modAerials;
            set => Raw.modAerials = value;
        }

        public int modTrimB
        {
            get => Raw.modTrimB;
            set => Raw.modTrimB = value;
        }

        public int modTank
        {
            get => Raw.modTank;
            set => Raw.modTank = value;
        }

        public int modWindows
        {
            get => Raw.modWindows;
            set => Raw.modWindows = value;
        }

        public int modLivery
        {
            get => Raw.modLivery;
            set => Raw.modLivery = value;
        }
    }
}