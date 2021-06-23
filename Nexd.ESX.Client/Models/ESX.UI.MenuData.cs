namespace Nexd.ESX.Client
{
    using System.Collections.Generic;

    public static partial class ESX
    {
        public static partial class UI
        {
            public class MenuData
            {
                public dynamic Raw;

                public MenuData(dynamic data) => Raw = data;

                public MenuData()
                {
                    Raw = new System.Dynamic.ExpandoObject();

                    Raw.title = new System.Dynamic.ExpandoObject();
                    Raw.align = new System.Dynamic.ExpandoObject();
                    Raw.elements = new System.Dynamic.ExpandoObject();
                    Raw.elements.head = new System.Dynamic.ExpandoObject();
                    Raw.elements.rows = new System.Dynamic.ExpandoObject();
                }

                public List<MenuElement> elements
                {
                    get
                    {
                        List<MenuElement> temp = new List<MenuElement>();
                        foreach (var i in Raw.elements)
                            temp.Add(new MenuElement(i));

                        return temp;
                    }
                    set => Raw.elements = value;
                }

                public string title
                {
                    get => Raw.title;
                    set => Raw.title = value;
                }

                public string align
                {
                    get => Raw.align;
                    set => Raw.align = value;
                }

                public string[] head
                {
                    get => Raw.elements.head;
                    set => Raw.elements.head = value;
                }

                public dynamic rows
                {
                    get => Raw.elements.rows;
                    set => Raw.elements.rows = value;
                }
            }
        }
    }
}
