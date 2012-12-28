namespace Eossyn.Core.Web
{
    using System.Web;

    public class SessionUtility : ISessionUtility
    {
        public bool SessionExists()
        {
            return HttpContext.Current.Session != null;
        }

        public bool ItemExists(string key)
        {
            if (SessionExists())
            {
                return HttpContext.Current.Session[key] != null;
            }
            return false;
        }

        public T FetchItem<T>(string key)
        {
            T itemToReturn = default(T);
            if (SessionExists())
            {
                if (ItemExists(key))
                {
                    itemToReturn = (T)HttpContext.Current.Session[key];
                }
            }
            return itemToReturn;
        }

        public void AddItem(string key, object itemToAdd)
        {
            if (SessionExists())
            {
                if (ItemExists(key))
                {
                    RemoveItem(key);
                }

                HttpContext.Current.Session[key] = itemToAdd;
            }
        }

        public void RemoveItem(string key)
        {
            if (SessionExists())
            {
                if (ItemExists(key))
                {
                    HttpContext.Current.Session[key] = null;
                }
            }
        }
    }
}
