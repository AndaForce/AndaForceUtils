using System;
using System.Collections.Generic;
using System.Linq;
using AndaForceUtils.Internal;

namespace AndaForceUtils.Collections.Generic.Extension
{
    public static class ListExtension
    {
        #region Random 
        public static TValue GetRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                return list[InternalRandomHelper.Rnd.Next(0, list.Count)];
            }
            return default(TValue);
        }

        public static TValue RemoveRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                var value = list[InternalRandomHelper.Rnd.Next(0, list.Count)];
                list.Remove(value);

                return value;
            }
            return default(TValue);
        }
        #endregion


        #region QuckSort
        public static void QuickSort<T>(this List<T> list, params Comparison<T>[] comparisons)
        {
            Sort(list, 0, list.Count - 1, comparisons);
        }

        private static void Sort<T>(List<T> list, int a, int b, params Comparison<T>[] comparisons)
        {
            if (a >= b) return;
            int c = Part(list, a, b, comparisons); // Делим массив на 2, возвращаем индекс центрального элемента
            Sort(list, a, c - 1, comparisons); // Сортируем левую половину
            Sort(list, c + 1, b, comparisons); // Сортируем правую половину
        }

        private static int Part<T>(List<T> list, int a, int b, params Comparison<T>[] comparisons)
        {
            // Опорный элемент для разделения - последний элемент массива
            int i = a; // Индекс центра массива (для разделения)
            for (int j = a; j <= b; j++)
            {
                foreach (var comparison in comparisons)
                {
                    var compareResult = comparison.Invoke(list[j], list[b]);

                    // Значение меньше - переносим элемент налево
                    if (compareResult < 0 ||
                        (compareResult == 0 && comparison == comparisons.Last())) // Значения равны, но компараторы кончились, считаем что структуры равны
                    {
                        T v = list[i];
                        list[i] = list[j];
                        list[j] = v;
                        i++; // Увеличиваем индекс

                        break;
                    }
                   
                    // Значение больше - компаратор использован, другие не нужны
                    if (compareResult > 0)
                    {
                        break;
                    }

                    // compareResult == 0, значения равны, нужен другой компаратор
                }
            }

            return i - 1; // Возвращаем индекс центра разделения
        }
        #endregion
    }
}