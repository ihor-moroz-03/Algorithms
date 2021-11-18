using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Sorting
    {
        public static void Bubble<T>(this T[] arr, Comparison<T> compare)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                bool flag = false;
                for (int j = 0; j < arr.Length - i - 1; ++j)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        flag = true;
                    }
                }
                if (flag == false) break;
            }
        }

        public static void Selection<T>(this T[] arr, Comparison<T> compare)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int extremeIndex = i + 1;
                for (int j = i + 2; j < arr.Length; ++j)
                {
                    if (compare(arr[j], arr[extremeIndex]) < 0)
                        extremeIndex = i;
                }

                if (compare(arr[extremeIndex], arr[i]) < 0)
                    Swap(ref arr[extremeIndex], ref arr[i]);
            }
        }

        public static void Merge<T>(this T[] arr, Comparison<T> compare)
        {
            MergeRec(arr, 0, arr.Length, compare);
        }

        public static void Quick<T>(this T[] arr, Comparison<T> compare)
        {
            QuickRec(arr, 0, arr.Length - 1, compare);
        }

        public static void Shell<T>(this T[] arr, Comparison<T> compare)
        {
            for (int gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i += gap)
                {
                    T val = arr[i];
                    int newPos = i;

                    while (newPos > 0 && compare(val, arr[newPos - gap]) < 0)
                    {
                        arr[newPos] = arr[newPos - gap];
                        newPos -= gap;
                    }
                    arr[newPos] = val;
                }
            }
        }

        public static void Counting<T>(this T[] arr, Comparison<T> compare)
        {
            Dictionary<T, int> dict = new();

            foreach (T item in arr)
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict[item] = 1;
            }

            T[] unique = new T[dict.Keys.Count];
            dict.Keys.CopyTo(unique, 0);

            Quick(unique, compare);

            int index = 0;
            foreach (T item in unique)
                for (int j = 0; j < dict[item]; ++j)
                    arr[index++] = item;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        static void QuickRec<T>(T[] arr, int first, int last, Comparison<T> compare)
        {
            if (last - first < 1) return;

            T pivot = arr[last];
            int partIndex = first;

            for (int i = first; i < last; ++i)
            {
                if (compare(arr[i], pivot) < 0 && i != partIndex++)
                    Swap(ref arr[i], ref arr[partIndex - 1]);
            }

            Swap(ref arr[last], ref arr[partIndex]);

            QuickRec(arr, first, partIndex - 1, compare);
            QuickRec(arr, partIndex + 1, last, compare);

            //T pivot = arr[(first + last) / 2];
            //int left = first, right = last;

            //while (true)
            //{
            //    while (compare(arr[left], pivot) < 0)
            //        left++;

            //    while (compare(arr[right], pivot) > 0)
            //        right--;

            //    if (left == right) break;
            //    if (compare(arr[left], arr[right]) == 0)
            //        left++;
            //    else
            //        Swap(ref arr[left], ref arr[right]);
            //}

            //QuickRec(arr, first, right - 1, compare);
            //QuickRec(arr, right + 1, last, compare);
        }

        static void MergeTwo<T>(T[] arr, int start, int m, int end, Comparison<T> compare)
        {
            T[] sorted = new T[end - start];

            for (int i = 0, l = start, r = m; i < end - start;)
            {
                sorted[i++] = compare(arr[l], arr[r]) < 0 ? arr[l++] : arr[r++];
                if (l == m) while (r != end) sorted[i++] = arr[r++];
                if (r == end) while (l != m) sorted[i++] = arr[l++];
            }

            sorted.CopyTo(arr, start);
        }

        static void MergeRec<T>(T[] arr, int start, int end, Comparison<T> compare)
        {
            if (end - start < 2) return;

            int m = (end - start) / 2 + start;
            MergeRec(arr, start, m, compare);
            MergeRec(arr, m, end, compare);
            MergeTwo(arr, start, m, end, compare);
        }
    }
}
