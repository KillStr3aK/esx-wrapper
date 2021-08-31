namespace Nexd.ESX.Shared
{
    using System;
    using System.Collections.Generic;

    public class Weapon
    {
        public dynamic Raw;

        public string name
        {
            get
            {
                try
                {
                    return Raw.name;
                }
                catch { }
                return null;
            }
        }
        public int ammo
        {
            get
            {
                try
                {
                    return Raw.ammo;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }

        public string label
        {
            get
            {
                try
                {
                    return Raw.label;
                }
                catch { }
                return null;
            }
        }
        public int tintIndex
        {
            get
            {
                try
                {
                    return Raw.tintIndex;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public List<string> components
        {
            get
            {
                List<string> temp = new List<string>();
                try
                {
                    var components = Raw.components;
                    foreach (var i in components)
                    {
                        temp.Add(i);
                    }
                }
                catch { }
                return temp;
            }
        }

        public Weapon() { }

        public Weapon(dynamic data) => Raw = data;
    }
}