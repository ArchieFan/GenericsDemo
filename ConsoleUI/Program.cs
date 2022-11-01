using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ages = new List<int>();

            DemonstrateTextFileStorage();
            
            Console.WriteLine();
            Console.Write("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"C:\Temp\people.csv";
            string logFile = @"C:\Temp\logs.csv";

            PopulateLists(people, logs);

            /****  Old way to doing thing - non-generic *******/

            //OriginalTextFileProcessor.SavePeople(people, peopleFile);
            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            //foreach (var p in newPeople)
            //{
            //    Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            //}

            //OriginalTextFileProcessor.SaveLog(logs, logFile);
            //var newlogs = OriginalTextFileProcessor.LoadLogs(logFile);
            //foreach (var log in newlogs)
            //{
            //    Console.WriteLine($"{log.ErrorCode}: {log.Message} at {log.TimeOfEvent.ToShortDateString()}");
            //}

            /****  New way to doing thing - generic *******/

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);
            foreach (var p in newPeople)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            }

            var newlogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var log in newlogs)
            {
                Console.WriteLine($"{log.ErrorCode}: {log.Message} at {log.TimeOfEvent.ToShortDateString()}");
            }


        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Archie", LastName = "Fan" });
            people.Add(new Person { FirstName = "GuiZhen", LastName = "Liu", IsAlive = false });
            people.Add(new Person { FirstName = "YuKiu", LastName = "Fan" });
            people.Add(new Person { FirstName = "ShunChi", LastName = "Fan" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
