// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
internal static class IListExtensions
{
    public static IList<string> NotEmptyValues(this IList<string> values)
    {
        return values == null 
            ? new List<string>() 
            : values.Where(v => v.IsNonEmpty()).Select(v=>v.Trim()).ToList();
    }
}