using System;

namespace Nexd.ESX.Shared
{
    public class Job
    {
        public dynamic Raw;

        public int id
        {
            get
            {
                try
                {
                    return Raw.id;
                }
                catch { }
                return 0;
            }
        }
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
        public string label
        {
            get
            {
                try
                {
                    return Raw.label;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public int grade
        {
            get
            {
                try
                {
                    return Raw.grade;
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public string grade_name
        {
            get
            {
                try
                {
                    return Raw.grade_name;
                }
                catch { }
                return null;
            }
        }
        public string grade_label
        {
            get
            {
                try
                {
                    return Raw.grade_label;
                }
                catch { }
                return null;
            }
        }
        public int grade_salary
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Raw.grade_salary);
                }
                catch
                {
                    throw new Exception("Not found raw value");
                }
            }
        }
        public dynamic skin_male
        {
            get
            {
                try
                {
                    return Raw.skin_male;
                }
                catch { }
                return null;
            }
        }
        public dynamic skin_female
        {
            get
            {
                try
                {
                    return Raw.skin_female;
                }
                catch { }
                return null;
            }
        }
        public Job() { }

        public Job(dynamic data) => Raw = data;
    }
}