using System;
using System.IO;

namespace FileReader
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Start?(y/n): ");
                string input = Console.ReadLine();
                while (input != "n")
                {
                    Console.Write("File Location: ");
                    string fLocation = Console.ReadLine();
                    if (fLocation == "exit" || fLocation == "")
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    Console.Write("Full File Name: ");
                    string fName = Console.ReadLine();
                    if (fName == "exit" || fName == "")
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }

                    var dir = new DirectoryInfo(fLocation);
                    foreach (var file in dir.EnumerateFiles(fName, SearchOption.AllDirectories))
                    {
                        ProcessFiles(file.FullName);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Finished.");
                    Console.ReadKey(); //Gets pause at the end of the program
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message + "-- Try again? (y/n)");
                string input = Console.ReadLine();
                if (input == "n")
                {
                    Environment.Exit(0);
                }
                else if (input == "y")
                {
                    Main();
                }
                else
                {
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                }
            }
        }

        static fileEntry ProcessFiles(string fileName)
        {
            fileEntry inputFiles = new fileEntry();
            string fDate; // this is to grab the dates from the file
            string readLine;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    readLine = sr.ReadLine();
                    if (readLine.Length < 1)
                    {

                    }
                    if (readLine.Contains("DATE:"))
                    {
                        fDate = readLine.Substring(0, 25).Trim();
                    }
                    if (readLine.Contains("something like this")) // if it finds the 
                    {
                        Console.WriteLine();
                        Console.WriteLine(runDate);
                        Console.WriteLine();
                        Console.Write("Found this:    ");
                        Console.WriteLine(readLine);
                    }
                }
            }
            return inputFiles; 
        }
    }

    public class fileEntry
    {
        //stores file names and datetimes

        public string FileName { get; set; }

        //public DateTime FileDate { get; set; }
    }

}
