using System.Collections.Generic;

namespace Nexd.ESX.Shared
{
    public class Job
    {
        public dynamic Raw;
        public int id
        {
            get { return Raw.id; }
        }
        public string name
        {
            get { return Raw.name; }
        }
        public string label
        {
            get { return Raw.label; }
        }
        public int grade
        {
            get { return Raw.grade; }
        }
        public string grade_name
        {
            get { return Raw.grade_name; }
        }
        public string grade_label
        {
            get { return Raw.grade_label; }
        }
        public int grade_salary
        {
            get { return Raw.grade_salary; }
        }
        public dynamic skin_male
        {
            get { return Raw.skin_male; }
        }
        public dynamic skin_female
        {
            get { return Raw.skin_female; }
        }

        public Job() { }
        public Job(dynamic data)
        {
            Raw = data;
        }
    }
    public class Weapon
    {
        public dynamic Raw;
        public string name
        {
            get { return Raw.name; }
        }
        public int ammo
        {
            get { return Raw.ammo; }
        }
        public string label
        {
            get { return Raw.label; }
        }
        public int tintIndex
        {
            get { return Raw.tintIndex; }
        }
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
        public Weapon(dynamic data)
        {
            Raw = data;
        }
    }
    public class Account
    {
        public enum AccountType : int
        {
            Cash = 0,
            Bank = 1,
            Black = 2
        }

        public dynamic Raw;
        public string name
        {
            get { return Raw.name; }
        }
        public uint money
        {
            get { return Raw.money; }
        }
        public string label
        {
            get { return Raw.label; }
        }
        public Account(dynamic data)
        {
            Raw = data;
        }
    }
    public class InventoryItem
    {
        public dynamic Raw;
        public string name
        {
            get { return Raw.name; }
        }
        public int count
        {
            get { return Raw.count; }
        }
        public string label
        {
            get { return Raw.labe; }
        }
        public double weight
        {
            get { return Raw.weight; }
        }
        public bool usable
        {
            get { return Raw.usable; }
        }
        public bool rare
        {
            get { return Raw.rare; }
        }
        public bool canRemove
        {
            get { return Raw.canRemove; }
        }
        public InventoryItem(dynamic data)
        {
            Raw = data;
        }
    }
}