﻿// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Track.Models;

namespace Track.Interfaces
{
    /// <summary>
    /// Interface for the parser
    /// </summary>
    public interface ITalkParser
    {
        /// <summary>
        /// Parse text to return a talk
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Talk Parse(string text);
    }
}