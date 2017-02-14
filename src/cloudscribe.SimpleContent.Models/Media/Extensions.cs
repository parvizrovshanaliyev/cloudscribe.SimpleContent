﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.SimpleContent.Models.Media
{
    public static  class Extensions
    {
        public static string ToCleanFileName(this string s, bool forceLowerCase = true)
        {
            if (string.IsNullOrEmpty(s)) { return s; }

            if (forceLowerCase)
            {
                return s.ToLower().RemoveInvalidPathChars().RemoveLineBreaks().Replace("'", string.Empty).Replace("  ", " ").Replace(" ", "-").Replace("&", string.Empty).Replace("@", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
            }

            return s.RemoveInvalidPathChars().RemoveLineBreaks().Replace("'", string.Empty).Replace(" ", string.Empty).Replace("&", string.Empty).Replace("@", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

        }

        public static string ToCleanFolderName(this string s, bool forceLowerCase = true)
        {
            if (string.IsNullOrEmpty(s)) { return s; }

            if (forceLowerCase)
            {
                return s.ToLower().RemoveInvalidPathChars().RemoveLineBreaks().Replace("'", string.Empty).Replace("  ", " ").Replace(" ", "-").Replace(".", string.Empty).Replace(",", string.Empty).Replace("&", string.Empty).Replace("@", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty);
            }

            return s.RemoveInvalidPathChars().RemoveLineBreaks().Replace("'", string.Empty).Replace(" ", string.Empty).Replace(".", string.Empty).Replace(",", string.Empty).Replace("&", string.Empty).Replace("@", string.Empty).Replace("$", string.Empty).Replace("#", string.Empty);

        }

        public static string RemoveInvalidPathChars(this string s)
        {
            if (string.IsNullOrEmpty(s)) { return s; }

            char[] invalidPathChars = Path.GetInvalidPathChars();
            char[] result = new char[s.Length];
            int resultIndex = 0;
            foreach (char c in s)
            {
                if (!invalidPathChars.Contains(c))
                    result[resultIndex++] = c;
            }
            if (0 == resultIndex)
                s = string.Empty;
            else if (result.Length != resultIndex)
                s = new string(result, 0, resultIndex);

            return s;


        }

        public static string RemoveLineBreaks(this string s)
        {
            if (string.IsNullOrEmpty(s)) { return s; }

            return s.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
        }
    }
}
