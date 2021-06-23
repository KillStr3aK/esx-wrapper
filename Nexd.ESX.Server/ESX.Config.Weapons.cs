namespace Nexd.ESX.Server
{
    public static partial class ESX
    {
        public static partial class Config
        {
            public static class Weapons
            {
                public static dynamic Raw => Config.Raw.Weapons;

                public static string[] DefaultWeaponTints => Raw.DefaultWeaponTints;
            }
        }
    }
}