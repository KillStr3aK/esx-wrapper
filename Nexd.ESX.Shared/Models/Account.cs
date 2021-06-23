namespace Nexd.ESX.Shared
{
    using System;

    public class Account
    {
        public enum AccountType : int
        {
            Cash = 0,
            Bank = 1,
            Black = 2
        }

        public dynamic Raw;

        public string name => Raw.name;

        public int money => Convert.ToInt32(Raw.money);

        public string label => Raw.label;

        public Account() { }

        public Account(dynamic data) => Raw = data;
    }
}