namespace Nexd.ESX.Client
{
    using System;
    using CitizenFX.Core;

    public static partial class ESX
    {
        private static dynamic Raw;

        static ESX() => BaseScript.TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => { Raw = esx; }) });

        public static void TriggerServerCallback(string name, Action<dynamic> callback, dynamic args = null) => Raw.TriggerServerCallback(name, callback, args);
        public static PlayerData GetPlayerData() => new PlayerData(Raw.GetPlayerData());
        public static bool IsPlayerLoaded() => Raw.IsPlayerLoaded();
        public static void SetPlayerData(dynamic key, dynamic value) => Raw.SetPlayerData(key, value);
        public static void ShowInventory() => Raw.ShowInventory();
        public static void ShowHelpNotification(string message, bool thisFrame = false, bool beep = true, int duration = -1) => Raw.ShowHelpNotification(message, thisFrame, beep, duration);

        public static void ShowAdvancedNotification(
            string sender,
            string subject,
            string message,
            NotificationPicture notificationPicture = NotificationPicture.CHAR_MULTIPLAYER,
            IconType iconType = IconType.ChatBox,
            bool flash = false,
            bool savetoBreif = true,
            HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if (hudColor != HudColor.HUD_COLOUR_DEFAULT)
            {
                Raw.ShowAdvancedNotification(sender, subject, message, notificationPicture.ToString(), (int)iconType, flash, savetoBreif, (int)hudColor);
                return;
            }

            Raw.ShowAdvancedNotification(sender, subject, message, notificationPicture.ToString(), (int)iconType, flash, savetoBreif, null);
        }

        public static void ShowAdvancedNotification(
            string sender,
            string subject,
            string message,
            string textureDict,
            IconType iconType,
            bool flash = false,
            bool savetoBreif = true,
            HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if (hudColor != HudColor.HUD_COLOUR_DEFAULT)
            {
                Raw.ShowAdvancedNotification(sender, subject, message, textureDict, (int)iconType, flash, savetoBreif, (int)hudColor);
                return;
            }

            Raw.ShowAdvancedNotification(sender, subject, message, textureDict, (int)iconType, flash, savetoBreif, null);
        }

        public static void ShowNotification(string message, HudColor hudColor = HudColor.HUD_COLOUR_DEFAULT)
        {
            if(hudColor != HudColor.HUD_COLOUR_DEFAULT) CitizenFX.Core.Native.API.ThefeedNextPostBackgroundColor((int)hudColor);
            Raw.ShowNotification(message);
        }
    }
}