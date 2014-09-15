﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace TextFileReader
{
    /// <summary>
    ///   Utility class for reading text files into a single string.
    /// </summary>
    static class TextFileReader
    {

        public static void Main()
        {
            string content = TextFileReader.ReadFile("TestFile.txt") + "\n\n";

            string keyword = @"**hej";

            //Console.WriteLine(content);
            print(content, createRegex(keyword));
        }

        static string createRegex(string input)
        {
            Match match = Regex.Match(input, @" \+ ");
            if (match.Success)
            {
                return input.Substring(0, match.Index) + " " + input.Substring(match.Index+match.Length);
            }
            match = Regex.Match(input, @"\w+\*{1}");
            if (match.Success)
            {
                return input.Substring(0, match.Length -1) + @"\w*";
            }
            match = Regex.Match(input, @"\*{1}\w+");
            if (match.Success)
            {
                return @"\w*" + input.Substring(match.Index+1);
            }
            return input;
        }


        static void print(string content, string keyword)
        {
            MatchCollection matchesKeywords = Regex.Matches(content, keyword, RegexOptions.IgnoreCase);
            MatchCollection matchesURLs = Regex.Matches(content, @"http(s)?:\/\/([\w\d~\-\?\=]+(\.|\/){0,1})+", RegexOptions.IgnoreCase);
            MatchCollection matchesDates = Regex.Matches(content, @"(\w){3}, (\d){2} (\w){3} (\d){4} (\d){2}:(\d){2}:(\d){2} -?(\d){4}", RegexOptions.IgnoreCase);

            Match[] keyWords = new Match[matchesKeywords.Count];
            matchesKeywords.CopyTo(keyWords, 0);
            Match[] urls = new Match[matchesURLs.Count];
            matchesURLs.CopyTo(urls, 0);
            Match[] dates = new Match[matchesDates.Count];
            matchesDates.CopyTo(dates, 0);
            List<Match> keywordsList = keyWords.ToList();
            List<Match> urlsList = urls.ToList();
            List<Match> datesList = dates.ToList();

            List<Match> sortedMatches = new List<Match>();
            sortedMatches.AddRange(keywordsList);
            sortedMatches.AddRange(urlsList);
            sortedMatches.AddRange(datesList);
            sortedMatches.Sort(Comparison);

            int currentIndex = 0;
            foreach (Match match in sortedMatches)
            {
                if (match.Success && match.Index > currentIndex)
                {
                    Console.Write(content.Substring(currentIndex, match.Index - currentIndex));

                    if (datesList.Contains(match))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(match.ToString());
                    }
                    else if (urlsList.Contains(match))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(match.ToString());
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(match.ToString());
                    }
                    Console.ResetColor();
                    currentIndex = match.Index + match.Length;
                }
            }
            Console.Write(content.Substring(currentIndex));

            Console.WriteLine("\n\n\n\n");

            // second solution - probably slower but can handle two formattings at a time
            for (int i = 0; i < content.Length; i++)
            {
                foreach (Match match in sortedMatches)
                {
                    if (match.Index <= i && match.Index+match.Length > i)
                    {
                        if (datesList.Contains(match))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (urlsList.Contains(match))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                    }
                }
                Console.Write(content.Substring(i,1));
                Console.ResetColor();
            }
        }


        private static int Comparison(Match match, Match match1)
        {
            if (match.Index < match1.Index) return -1;
            if (match.Index > match1.Index) return 1;
            return 0;
        }


        /// <summary>
        /// Reads a text file and returns its content as a string.
        /// </summary>
        /// <param name="filename">The file name to be read, including the path.</param>
        /// <returns>A string representing the content of the file</returns>
        public static string ReadFile(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    //This reads the entire file
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //Might happen if the file is not text or non-existent
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}