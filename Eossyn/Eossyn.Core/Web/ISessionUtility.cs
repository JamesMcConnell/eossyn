namespace Eossyn.Core.Web
{
    public interface ISessionUtility
    {
        /// <summary>
        /// Determines whether or not a valid Session exists.
        /// </summary>
        /// <returns>True if Session exists, else false.</returns>
        bool SessionExists();
        /// <summary>
        /// Determines whether or not the item exists in Session for the given key.
        /// </summary>
        /// <param name="key">The key to look for in Session.</param>
        /// <returns>True if the item exists in Session, else false.</returns>
        bool ItemExists(string key);
        /// <summary>
        /// Attempts to retrieve an item from session of type <see cref="{T}" /> for the given key.
        /// </summary>
        /// <typeparam name="T">The type of the object to retrieve.</typeparam>
        /// <param name="key">The key to look for in Session.</param>
        /// <returns>An object of type <see cref="{T}" />.</returns>
        T FetchItem<T>(string key);
        /// <summary>
        /// Adds an item to Session for the given key.
        /// </summary>
        /// <param name="key">The key to use when adding to Session.</param>
        /// <param name="itemToAdd">The item to add to Session</param>
        void AddItem(string key, object itemToAdd);
        /// <summary>
        /// Removes an item from session for the given key, setting it to null.
        /// </summary>
        /// <param name="key">The key to look for in Session.</param>
        void RemoveItem(string key);
    }
}
