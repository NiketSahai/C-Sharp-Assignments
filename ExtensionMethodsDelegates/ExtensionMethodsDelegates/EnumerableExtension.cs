using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegates
{
    public static class EnumerableExtension
    {
        public static bool CustomAll<T>(this IEnumerable<T> enumerableList, Func<T, bool> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            foreach(T value in enumerableList)
            {
                if (!predicate(value))
                    return false;
            }
            return true;
        }

        public static bool CustomAny<T>(this IEnumerable<T> enumerableList, Func<T, bool> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            foreach (T value in enumerableList)
            {
                if (predicate(value))
                    return true;
            }
            return false;
        }

        public static int CustomMax<T>(this IEnumerable<T> enumerableList, Func<T, bool> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            T  max = enumerableList.First();

            foreach(T value in enumerableList)
            {
                if ((Convert.ToInt16(value) > Convert.ToInt16(max)) && predicate(value))
                    max = value;
            }
            return Convert.ToInt16(max);
        }

        public static int CustomMin<T>(this IEnumerable<T> enumerableList, Func<T, bool> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            T min = enumerableList.First();

            foreach (T value in enumerableList)
            {
                if (predicate(value) && (Convert.ToInt16(value) < Convert.ToInt16(min)))
                    min = value;
            }
            return Convert.ToInt16(min);
        }

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> enumerableList, Func<T, bool> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            foreach (T value in enumerableList)
            {
                if (predicate(value)) yield return value;
            }
        }

        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> enumerableList, Func<T, TResult> predicate)
        {
            if (enumerableList is null)
                throw new ArgumentNullException(nameof(enumerableList));

            foreach(T value in enumerableList)
            {
                yield return predicate(value);
            }
        }
    }
}
