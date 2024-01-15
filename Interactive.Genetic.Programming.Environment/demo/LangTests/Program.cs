﻿var intList = new List<int> { 1, 2, 3, 4, 5 };

intList.Set(3, 666);

Console.Out.WriteLine("intList: " + string.Join(", ", intList));

public static class ListExtensions
{
    public static void Set<T>(this List<T> list, T toRemove, T item)
    {
        var idx = list.IndexOf(toRemove);
        list.RemoveAt(idx);
        list.Insert(idx, item);
    }
}