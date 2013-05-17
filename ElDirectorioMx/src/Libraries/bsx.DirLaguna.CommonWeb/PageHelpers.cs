using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.UI;

namespace bsx.DirLaguna.CommonWeb
{
    public class PageHelpers
    {
        public static T FindControl<T>(System.Web.UI.ControlCollection Controls, string name) where T : class
        {
            T found = default(T);

            if (Controls == null || Controls.Count <= 0)
                return found;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is T && Controls[i].ID == name)
                {
                    found = Controls[i] as T;
                    break;
                }
                else
                {
                    found = FindControl<T>(Controls[i].Controls, name);
                    if (found != null)
                        break;
                }
            }

            return found;
        }

        public static void FindControlsByType<T>(System.Web.UI.ControlCollection Controls, ref List<T> controlList) where T : class
        {
            if (Controls == null || Controls.Count <= 0)
                return;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is T)
                {
                    controlList.Add(Controls[i] as T);
                }

                FindControlsByType<T>(Controls[i].Controls, ref controlList);
            }
        }

        public static void SetPropertyToControls(System.Web.UI.ControlCollection Controls,
            string propertyName, object value)
        {
            if (Controls == null || Controls.Count <= 0)
                return;

            foreach (Control control in Controls)
            {
                PropertyInfo property = control.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    if (property.CanWrite)
                        property.SetValue(control, value, null);
                }
                SetPropertyToControls(control.Controls, propertyName, value);
            }
        }
    }
}
