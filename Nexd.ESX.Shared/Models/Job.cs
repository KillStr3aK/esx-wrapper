namespace Nexd.ESX.Shared
{
    public class Job
    {
        public dynamic Raw;

        public int id => Raw.id;

        public string name => Raw.name;

        public string label => Raw.label;

        public int grade => Raw.grade;

        public string grade_name => Raw.grade_name;

        public string grade_label => Raw.grade_label;

        public int grade_salary => Raw.grade_salary;

        public dynamic skin_male => Raw.skin_male;

        public dynamic skin_female => Raw.skin_female;

        public Job() { }

        public Job(dynamic data) => Raw = data;
    }
}