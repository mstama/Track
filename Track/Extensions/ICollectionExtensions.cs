// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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