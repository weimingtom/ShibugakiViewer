﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boredbone.Utility.Extensions;
using Boredbone.Utility.Tools;

namespace Database.Search
{
    /// <summary>
    /// SQL function for SQLite
    /// </summary>
    public static class DatabaseFunction
    {
        private static string localTimeOffsetText;

        static DatabaseFunction()
        {
            SetDateOffset(DateTimeOffset.Now.Offset);
        }

        public static void SetDateOffset(TimeSpan offset)
        {
            var localTimeOffsetSecond = (int)(offset.TotalSeconds);

            localTimeOffsetText = localTimeOffsetSecond.ToString();
            if (!localTimeOffsetText.StartsWith("-"))
            {
                localTimeOffsetText = "+" + localTimeOffsetText;
            }
        }

        public static string GetDate(string column)
            => $"({column} - (({column}{localTimeOffsetText}) % 86400))";


        public static string Combine(params string[] columns)
            => $"({columns.Join(" || ")})";


        public static string Divide(string num, string den)
            => $"1.0 * {num} / {den}";

        public static string ToLower(string column)
            => $"LOWER({column})";

        public static string Length(string column)
            => $"LENGTH({column})";

        //public static string DateTimeOffsetToString(DateTimeOffset datetime)
        //    => datetime.ToString("yyyy-MM-dd HH:mm:ss zzz");
        //
        //public static string DateToString(DateTime datetime)
        //    => datetime.ToString("yyyy-MM-dd");

        //private static string ToEscapedString(object obj)
        //    => obj.ToString().Replace("'", "''");

        //public static string ToLowerEqualsString(object obj)
        //    => $"'{ToEscapedString(obj).ToLower()}'";

        //public static string ToEqualsString(object obj)
        //    => $"'{ToEscapedString(obj)}'";

        //public static string AreEqualWithEscape(string column, string reference)
        //    => $"{column} == '{ToEscapedString(reference)}'";
        //
        //public static string AreEqual(string column, string reference)
        //    => $"{column} == {reference}";

        //public static string AreEqual(string column, object reference)
        //    => $"{column} == {reference.ToString()}";


        //public static string ToTextReference(object reference)
        //    => $"'{ToGlobReference(reference.ToString())}'";
        //
        //public static string ToGlobReference(string reference)
        //    => reference.ToLower().Replace("[", "[[]").Replace("'", "''");

        //public static string Match(string column, string reference)
        //    => $"LOWER({column}) {Match(reference)}";

        //public static string Match(string reference)
        //    => $"GLOB '{ToGlobReference(reference)}'";
        //
        //
        //public static string StartsWith(string reference)
        //    => $"GLOB '{ToGlobReference(reference)}*'";
        //
        //
        //public static string EndsWith(string reference)
        //    => $"GLOB '*{ToGlobReference(reference)}'";
        //
        //public static string Contains(string reference)
        //    => $"GLOB '*{ToGlobReference(reference)}*'";

        //public static string DateOffsetReference(DateTimeOffset dateTime)
        //    => UnixTime.FromDateTime(dateTime.ToLocalTime().Date).ToString();
        //public static string DateOffsetReference(DateTimeOffset dateTime, TimeSpan offset)
        //    => UnixTime.FromDateTime(dateTime.ToOffset(offset).ToDate()).ToString();
        //
        //public static string DateTimeOffsetReference(DateTimeOffset dateTime)
        //    => UnixTime.FromDateTime(dateTime).ToString();


        //public static string And(params string[] sqls)
        //    => $"({sqls.Join(" AND ")})";
        //
        //public static string Or(params string[] sqls)
        //    => $"({sqls.Join(" OR ")})";


        //public static string Not(string sql)
        //    => $"NOT {sql}";


        //public static string IsTrue(string column)
        //    => $"{column} != 0";
        //
        //public static string IsFalse(string column)
        //    => $"{column} == 0";
        //
        //public static string IsNull(string column)
        //    => $"{column} IS NULL";
        //
        //public static string IsNotNull(string column)
        //    => $"{column} IS NOT NULL";
        //
        //
        //public static string In(string column, string array)
        //    => $"{column} IN {array}";

    }
}
