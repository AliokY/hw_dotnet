﻿using System.Linq;

namespace HW04.Task5
{
    class LinqUsing
    {
        internal string DelLongestWordLinq(string str)
        {
            var strArray = str.Split(' ');
            var result = strArray.OrderByDescending(s => s.Length).ToList();
            result.RemoveAt(0);
            return string.Join(' ', result);
        }
    }
}
