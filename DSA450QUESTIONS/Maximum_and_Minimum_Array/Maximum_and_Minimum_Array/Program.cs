﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_and_Minimum_Array
{
    class Program
    {
        /* Class Pair is used to return
    two values from getMinMax() */
        class Pair
        {
            public int min;
            public int max;
        }

        static Pair getMinMax(int[] arr, int n)
        {
            Pair minmax = new Pair();
            int i;

            /* If there is only one element
            then return it as min and max both*/
            if (n == 1)
            {
                minmax.max = arr[0];
                minmax.min = arr[0];
                return minmax;
            }

            /* If there are more than one elements,
            then initialize min and max*/
            if (arr[0] > arr[1])
            {
                minmax.max = arr[0];
                minmax.min = arr[1];
            }
            else
            {
                minmax.max = arr[1];
                minmax.min = arr[0];
            }

            for (i = 2; i < n; i++)
            {
                if (arr[i] > minmax.max)
                {
                    minmax.max = arr[i];
                }
                else if (arr[i] < minmax.min)
                {
                    minmax.min = arr[i];
                }
            }
            return minmax;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMax(arr, arr_size);
            Console.Write("Minimum element is {0}",
                                       minmax.min);
            Console.Write("\nMaximum element is {0}",
                                         minmax.max);
            Console.ReadLine();
        }
    }
}
