using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace csharp_test
{
    class Program
    {
        static class Delimeter{
            public const string SEPARATOR = "|";
            public const string TABLE = "(@TABLE@[^@+)";
            public const string JOIN = "(@JOIN@[^@]+)";
            public const string CONDITION = "(@CONDITION@[^@]+)";
            public const string GROUP_BY = "(@GROUP_BY@[^@]+)";
            public const string GET_ITEM = "(@GET_ITEM@)";
            public const string SUBQUERY = @"(@SUBQUERY.+@ \()";
            public const string ENDING_SUBQUERY = @"(\s\)\r?\n)";
        }
        static void Main(string[] args)
        {
            string inputText = System.IO.File.ReadAllText(@"/home/thehien/Desktop/TrialTechnology/csharp-test/input.txt");
            string regexTerm = new StringBuilder()
                                    .Append(Delimeter.TABLE)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.JOIN)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.CONDITION)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.GROUP_BY)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.GET_ITEM)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.SUBQUERY)
                                    .Append(Delimeter.SEPARATOR)
                                    .Append(Delimeter.ENDING_SUBQUERY)
                                    .ToString();
            //Split the long text to separate parts
            
            var queryParts = Regex.Split(inputText, regexTerm)
                                        .Select(part => part.Trim())
                                        .Where(part => part.Length > 0).ToList();
           
            // int i = 0;
            // var finalSqlString = queryParts.Where(part => Regex.IsMatch(part, regexTerm))
            //                             .Select(key => new {
            //                               QueryKey = key,
            //                               Content = ResolveTermsToSQL(key, i++, queryParts)
            //                             })
            //                             .ToDictionary(
            //                                 key => key.QueryKey, 
            //                                 value => value.Content
            //                             );
            
            

        }

        private static string ResolveTermsToSQL(string key, int currentIndex, List<string> queryParts) {
            string content = queryParts[currentIndex + 1];
            if(Regex.IsMatch(key, Delimeter.TABLE)){
                string[] resultArr = content.Split(Environment.NewLine)
                            .Select(part => part + ", ")
                            .ToArray();
                return string.Join(Environment.NewLine, resultArr);
            }
            
            return "";
        }

        // private static string ResolveTable(string part){

        // }

        // private static string ResolveJoin(string part){

        // }
        
    }
}
