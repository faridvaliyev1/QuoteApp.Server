using System;
using System.Collections.Generic;

namespace EmotionApi.Infrastructure
{
    public static class IListExtensions
    {
        public static Random _rnd = new Random();

        public static T PickRandom<T>(this IList<T> items)
        {
            return items[_rnd.Next(items.Count)];
        }
    }
}
