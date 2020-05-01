using System;
using System.Text;
using System.Collections.Generic;

namespace SwiftMessageParser.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertFromUnix(this string value)
        {
            return value.Replace("\n", "\r\n");
        }


        /// <summary>
        /// Gets the substring between the index of string a and b from the source string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static string Between(this string value, string a, string b)
        {
            int startIndex1 = value.IndexOf(a);
            int num = value.IndexOf(b, startIndex1);
            if (startIndex1 == -1 || num == -1)
                return "";
            int startIndex2 = startIndex1 + a.Length;
            if (startIndex2 >= num)
                return "";
            return value.Substring(startIndex2, num - startIndex2);
        }


        /// <summary>
        /// Gets the amount value from field61 of MT942 message.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static string AmountFromField61(this string value, string a, string b)
        {
            int startIndex1 = value.IndexOf(a);
            int num = value.IndexOf(b, startIndex1);
            if (startIndex1 == -1 || num == -1)
                return "";
            int startIndex2 = startIndex1 + a.Length;
            if (startIndex2 >= num)
                return "";
            return value.Substring(startIndex2, num - startIndex2 + 3).Replace(",", ".");
        }

        /// <summary>
        /// Parses from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static string ParseFromString(this string value, string a, string b)
        {
            int num1 = value.IndexOf(a);
            string str = value.Substring(num1 + a.Length);
            int num2 = value.Length - str.Length;
            int length = str.IndexOf(b);
            if (num1 == -1 || length == -1)
                return "";
            return str.Substring(0, length);
        }


        /// <summary>
        /// Parses the index of the with string and.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static string ParseWithStringAndIndex(this string value, string a, int index)
        {
            int num1 = value.IndexOf(a);
            int num2 = index;
            if (num1 == -1 || num2 == -1)
                return "";
            int startIndex = num1 + a.Length;
            return value.Substring(startIndex, index);
        }


        /// <summary>
        /// Gets the substring from the index of string a to end of source string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <returns></returns>
        public static string ToEndOfString(this string value, string a)
        {
            int startIndex = value.IndexOf(a) + a.Length;
            return value.Substring(startIndex);
        }

        /// <summary>
        /// Returns the substring from the Lasts index of the parameter to end of the source string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string LastIndexToEndOfString(this string value, string str)
        {
            int startIndex = value.LastIndexOf(str);
            return value.Substring(startIndex);
        }

        /// <summary>
        /// Trims all new lines.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimAllNewLines(this string value)
        {
            return value.Replace(Environment.NewLine, " ").Trim();
        }

        /// <summary>
        /// Trims the colon.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimColon(this string value)
        {
            value = value.Trim(':');
            return value;
        }

        /// <summary>
        /// Trims the end of swift message.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimEndOfSwift(this string value)
        {
            value = value.Trim('-', '}');
            return value;
        }

        /// <summary>
        /// Gets the swift tag.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="a">a.</param>
        /// <returns></returns>
        public static int GetSwiftTag(this string value, int a)
        {
            int num = 6;
            if (value.Substring(a, 2) == ":")
                ++num;
            if (value.Substring(a, 1) != ":")
                ++num;
            int startIndex = a + num;

            return value.IndexOf(":", startIndex) - a;
        }


        /// <summary>
        /// Trims the excess colon.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimExcessColon(this string value)
        {
            var foundIndexes = new List<int>();
            for (int i = value.IndexOf(':'); i > -1; i = value.IndexOf(':', i + 1))
            {
                foundIndexes.Add(i);
            }
            string tempString = string.Empty;
            foreach (int index in foundIndexes)
            {
                if (Char.IsLetter(Convert.ToChar(value.Substring(index - 2, 1))))
                {
                    tempString = value.Remove(index - 1, 3);
                }
            }
            return tempString;
        }

        /// <summary>
        /// Trims the uneccessary data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TrimUneccessaryData(this string value)
        {
            int length1 = value.Length;
            int num = 0;
            StringBuilder newString = new StringBuilder(value);
            int index = 0;
            while (num < length1)
            {
                index = value.IndexOf(':', num);
                if (index > 0)
                {
                    if (value.Substring(index - 2, 1) == "{")
                        ++index;
                    else if (value.Substring(index - 4, 1) == "{")
                        ++index;
                    else if (value.Substring(index + 3, 1) == ":" || value.Substring(index + 4, 1) == ":")
                        ++index;
                    else if (value.Substring(index - 3, 1) == ":" || value.Substring(index - 4, 1) == ":")
                        ++index;
                    else
                    {
                        newString[index] = ' ';
                        ++index;
                    }

                    num = index;
                }
                else
                    break;
            }

            return newString.ToString();
        }

        /// <summary>
        /// Substring2s the specified start index.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Substring2(this string value, int startIndex, int length)
        {
            if (value.Length <= length)
                return value;
            return value.Substring(startIndex, length);
        }

        /// <summary>
        /// Cleans up file path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string CleanUpFilePath(this string value)
        {
            return value.Replace("/", "").Replace(",", "").Replace("'", "").Replace(".", "");
        }

        /// <summary>
        /// Coverts to date.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="dateFormat">The date format.</param>
        /// <returns></returns>
        public static DateTime CovertToDate(this string value, string dateFormat)
        {
            return DateTime.ParseExact(value, dateFormat, null);
        }
    }
}
