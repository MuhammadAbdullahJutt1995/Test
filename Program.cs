using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Test
{
    public class Program
    {
       static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                string path = Convert.ToString(args[0]);
                string Index = Convert.ToString(args[1]);
                string ToMatch = Convert.ToString(args[2]);
                StartProcess(path, Index, ToMatch);
            }
            else if (args.Length > 3)
                Console.WriteLine("More than required Arguements Found.");
            else
            {
                Console.WriteLine("No Command Line Arguement found or Arguements Missing.");
            }

            // Console.WriteLine("Hello world");
        }
        public static void StartProcess(string FilePath, string key, string ToMatch)
        {
            try
            {
                //For storing the Filnal result
                List<string> result = new List<string>();

                string[] CSVFileData = System.IO.File.ReadAllLines(FilePath);

                foreach (string z in CSVFileData)
                {
                    string[] Fields = z.Split(',');
                    if (MatchRecords(key, ToMatch, Fields))
                    {
                        result.Add(z);
                    }
                }
                //Displaying Result
                if (result.Count > 0)
                    result.ForEach(Console.WriteLine);
                else
                    Console.WriteLine("No record found(It's case Sensitive Kindly look Carefully)");


            }
            catch (Exception es)
            {
                Console.WriteLine("Error while Fetching Results File Not Found");
            }
        }
        public static bool MatchRecords(string ToMatchindex, string ToMatchkey, string[] FetchedFields)
        {
            if (FetchedFields.Contains(ToMatchkey) && FetchedFields.Contains(ToMatchindex))
            {
                return true;
            }
            else
                return false;
        }
    }
}
