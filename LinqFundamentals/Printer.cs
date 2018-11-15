using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqFundamentals
{
    internal static class Printer
    {
        internal static void Print(this object @object)
        {
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(@object, Formatting.Indented));
        }

        internal static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> action)
        {
            List<TResult> result = new List<TResult>();
            foreach (var item in collection)
            {
                result.Add(action(item));
            }

            return result;
        }
    }
}
