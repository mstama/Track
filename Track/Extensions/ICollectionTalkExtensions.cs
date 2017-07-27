// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;

namespace Track.Extensions
{
    /// <summary>
    /// Extension methods for generic collections of talks
    /// </summary>
    public static class ICollectionTalkExtensions
    {
        /// <summary>
        /// Check if talk should be added to collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="item"></param>
        public static void AddCheck<T>(this ICollection<T> value, T item) where T:Talk
        {
            if (item.Duration > 0)
            {
                value.Add(item);
            }
        }
    }
}
