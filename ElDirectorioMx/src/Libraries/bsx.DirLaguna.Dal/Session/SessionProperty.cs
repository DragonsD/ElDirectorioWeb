using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace bsx.DirLaguna.CommonWeb.Session
{
    public class SessionProperty<T>
    {
        private readonly string sessionKey;
        private readonly T defaultValue;

        public SessionProperty(string sessionKey)
        {
            this.sessionKey = sessionKey;
            this.defaultValue = default(T);

            HttpContext.Current.Session[sessionKey] = this.defaultValue;
        }

        public SessionProperty(string sessionKey, T defaultValue)
        {
            this.sessionKey = sessionKey;
            this.defaultValue = defaultValue;

            HttpContext.Current.Session[sessionKey] = this.defaultValue;
        }

        public T Value
        {
            get
            {
                object value = HttpContext.Current.Session[sessionKey];
                if (value == null)
                    return default(T);

                return (T)value;
            }
            set
            {
                HttpContext.Current.Session[sessionKey] = value;
            }
        }
    }
}