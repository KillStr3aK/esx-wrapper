namespace Nexd.ESX.Client
{
    public static partial class ESX
    {
        public static partial class UI
        {
            public class HUD
            {
                public static dynamic Raw => ESX.Raw.UI.HUD;

                public static void RegisterElement(string name, int index, int priority, string html, dynamic data) => Raw.RegisterElement(name, index, priority, html, data);
                public static void RemoveElement(string name) => Raw.RemoveElement(name);
                public static void SetDisplay(double opacity) => Raw.SetDisplay(opacity);
                public static void UpdateElement(string name, dynamic data) => Raw.UpdateElement(name, data);
            }
        }
    }
}