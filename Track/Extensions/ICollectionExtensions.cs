using System.Collections.Generic;

namespace Track.Extensions
{
    /// <summary>
    /// Extension methods for collection
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Check if it is empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotEmpty<T>(this ICollection<T> value)
        {
            return value.Count > 0;
        }
    }
}