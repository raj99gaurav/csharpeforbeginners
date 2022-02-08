﻿// A C# program for merging overlapping intervals
using System;
using System.Collections;
using System.Collections.Generic;

public class MergeOverlappingIntervals
{

    // sort the intervals in increasing order of start time
    class sortHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Interval first = (Interval)a;
            Interval second = (Interval)b;
            if (first.start == second.start)
            {
                return first.end - second.end;
            }
            return first.start - second.start;
        }
    }

    // The main function that takes a set of intervals, merges
    // overlapping intervals and prints the result
    public static void mergeIntervals(Interval[] arr)
    {

        // Test if the given set has at least one interval
        if (arr.Length <= 0)
            return;
        Array.Sort(arr, new sortHelper());

        // Create an empty stack of intervals
        Stack stack = new Stack();

        // Push the first interval to stack
        stack.Push(arr[0]);

        // Start from the next interval and merge if necessary
        for (int i = 1; i < arr.Length; i++)
        {

            // get interval from stack top
            Interval top = (Interval)stack.Peek();

            // if current interval is not overlapping with stack top,
            // Push it to the stack
            if (top.end < arr[i].start)
                stack.Push(arr[i]);

            // Otherwise update the ending time of top if ending of current
            // interval is more
            else if (top.end < arr[i].end)
            {
                top.end = arr[i].end;
                stack.Pop();
                stack.Push(top);
            }
        }

        // Print contents of stack
        Console.Write("The Merged Intervals are: ");
        while (stack.Count != 0)
        {
            Interval t = (Interval)stack.Pop();
            Console.Write("[" + t.start + "," + t.end + "] ");
        }
    }

    // Driver code
    public static void Main()
    {

        Interval[] arr = new Interval[4];
        arr[0] = new Interval(6, 8);
        arr[1] = new Interval(1, 9);
        arr[2] = new Interval(2, 4);
        arr[3] = new Interval(4, 7);
        mergeIntervals(arr);
        Console.ReadLine();
    }
}

public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}