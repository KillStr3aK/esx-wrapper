namespace Nexd.ESX.Shared
{
    using System.Collections.Generic;

    public class Weapon
    {
        public dynamic Raw;

        public string name => Raw.name;

        public int ammo => Raw.ammo;

        public string label => Raw.label;

        public int tintIndex => Raw.tintIndex;

        public List<string> components
        {
            get
            {
                List<string> temp = new List<string>();
                foreach (var i in Raw.components)
                {
                    temp.Add(i);
                }

                return temp;
            }
        }

        public Weapon() { }

        public Weapon(dynamic data) => Raw = data;
    }
}