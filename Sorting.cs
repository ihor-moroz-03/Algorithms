using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Sorting
    {
        public delegate int DComparer<T>(T obj1, T obj2);

        public static void BubbleSort(this object[] arr, DComparer<object> compare)
        {
            bool flag;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                flag = false;
                for (int j = 0; j < arr.Length - i - 1; ++j)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        flag = true;
                    }
                }
                if (flag == false) break;
            }
        }

        public static void BubbleSort<T>(this T[] arr, DComparer<T> compare)
        {
            bool flag;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                flag = false;
                for (int j = 0; j < arr.Length - i - 1; ++j)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        flag = true;
                    }
                }
                if (flag == false) break;
            }
        }
    }
}
