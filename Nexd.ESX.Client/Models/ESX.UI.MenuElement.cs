namespace Nexd.ESX.Client
{
    public static partial class ESX
    {
        public static partial class UI
        {
            public class MenuElement
            {
                public dynamic Raw;

                public MenuElement(dynamic data) => Raw = data;

                public MenuElement(dynamic label, dynamic value, dynamic customdata = null, string type = "default")
                {
                    Raw = new System.Dynamic.ExpandoObject();
                    Raw.label = label;
                    Raw.value = value;
                    Raw.type = type;
                    custom = customdata;
                }

                public MenuElement()
                {
                    Raw = new System.Dynamic.ExpandoObject();
                    Raw.label = new System.Dynamic.ExpandoObject();
                    Raw.value = new System.Dynamic.ExpandoObject();
                    Raw.type = "default";

                    custom = new System.Dynamic.ExpandoObject();
                }

                public dynamic label
                {
                    get => Raw.label;
                    set => Raw.label = value;
                }

                public dynamic value
                {
                    get => Raw.value;
                    set => Raw.value = value;
                }

                public string type
                {
                    get => Raw.type;
                    set => Raw.type = value;
                }

                public dynamic custom { get; set; }
            }
        }
    }
}