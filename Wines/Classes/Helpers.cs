using System.Globalization;
using WinesApp.Models;

namespace WinesApp.Classes;

public class Helpers
{
    public static List<ElementContainer<T>> RangeDetails<T>(List<T> list) =>
        list.Select((element, index) => new ElementContainer<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(list.Count - index - 1, true),
            Index = index + 1
        }).ToList();
}

