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

        public int money
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Raw.money);
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

        public Account() { }

        public Account(dynamic data) => Raw = data;
    }
}