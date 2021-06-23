namespace Nexd.ESX.Client
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public static partial class ESX
    {
        public static partial class UI
        {
            public class Menu
            {
                public static dynamic Raw => ESX.Raw.UI.Menu;
                public dynamic RawInstance;

                public Menu(dynamic data) => RawInstance = data;

                public Menu() => RawInstance = new System.Dynamic.ExpandoObject();

                public Menu(string menuType, string nameSpace, string menuName)
                {
                    RawInstance = new System.Dynamic.ExpandoObject();
                    RawInstance.name = menuName;
                    RawInstance.type = menuType;
                    RawInstance.@namespace = nameSpace;

                    RawInstance.data = new MenuData();
                }

                public string type
                {
                    get => RawInstance.type;
                    set => RawInstance.type = value;
                }

                public string @namespace
                {
                    get => RawInstance.@namespace;
                    set => RawInstance.@namespace = value;
                }

                public string name
                {
                    get => RawInstance.name;
                    set => RawInstance.name = value;
                }

                public MenuData data
                {
                    get => new MenuData(RawInstance.data);
                    set => RawInstance.data = value;
                }

                public static void Close(string type, string @namespace, string name) => Raw.Close(type, @namespace, name);

                public static void Close(Menu menu) => Raw.Close(menu.type, menu.@namespace, menu.name);

                public static void CloseAll() => Raw.CloseAll();

                public static Menu GetOpened(string type, string @namespace, string name) => new Menu(Raw.GetOpened(type, @namespace, name));

                public static bool IsOpen(string type, string @namespace, string name) => Raw.RawIsOpen(type, @namespace, name);

                public static Menu Open(
                    string type,
                    string @namespace,
                    string name,
                    MenuData data,
                    [Optional()] Action<dynamic, dynamic> submit,
                    [Optional()] Action<dynamic, dynamic> cancel,
                    [Optional()] Action<dynamic, dynamic> change, [Optional()] Action close) =>
                    new Menu(Raw.Open(type, @namespace, name, data.Raw, submit, cancel, change, close));

                public static void RegisterType(string type, [Optional()] Action<string, string, dynamic> open, [Optional()] Action<string, Menu> close) => Raw.RegisterType(type, open, close);

                public static List<Menu> GetOpenedMenus()
                {
                    var data = Raw.GetOpenedMenus();
                    List<Menu> menus = new List<Menu>();
                    foreach (var i in data)
                        menus.Add(new Menu(i));

                    return menus;
                }
            }
        }
    }
}
