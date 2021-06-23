namespace Nexd.ESX.Server
{
    public static partial class ESX
    {
        public static partial class Config
        {
            public static dynamic Raw => ESX.Raw.Config ?? (ESX.Raw.Config);

            public static string Locale => Raw.Locale;

            public static string[] Accounts => new string[] { Raw.Accounts.bank, Raw.Accounts.money, Raw.Accounts.black_money };

            public static dynamic StartingAccountMoney => Raw.StartingAccountMoney;
            public static bool EnableSocietyPayouts => Raw.EnableSocietyPayouts;
            public static bool EnableHud => Raw.EnableHud;
            public static int MaxWeight => Raw.MaxWeight;
            public static int PaycheckInterval => Raw.PaycheckInterval;
            public static bool EnableDebug => Raw.EnableDebug;
        }
    }
}
