namespace Nexd.ESX.Client
{
    public static partial class ESX
    {
        public static partial class Scaleform
        {
            public static dynamic Raw => ESX.Raw.Scaleform;

            public static void ShowBreakingNews(string title, string message, string bottom, int sec) => Raw.ShowBreakingNews(title, message, bottom, sec);
            public static void ShowFreemodeMessage(string title, string message, int sec) => Raw.ShowFreemodeMessage(title, message, sec);
            public static void ShowPopupWarning(string title, string message, string footer, int sec) => Raw.ShowPopupWarning(title, message, footer, sec);
            public static void ShowTrafficMovie(int sec) => Raw.ShowTrafficMovie(sec);
        }
    }
}