﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Learn.Core.Common.Extensions
{
    public static class ObservableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            var collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}