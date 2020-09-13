using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File_WerkTage
{
    class Program
    {
        static void Main(string[] args)
        {
            // #1 - Dateiname / Pfad
            string dateiName = @"Testdaten\Werktage September.txt";

            // #2 - Daten (Text oder Binär?)
            string[] werktageImSeptember = FindeWerktageIn(09, 2016);

            // #3 - Passende Methode von der Klasse File
            File.WriteAllLines(dateiName, werktageImSeptember);

            string[] dateiInhalt = File.ReadAllLines(@"Testdaten\Werktage mit Umlauten.txt", Encoding.Default);
            foreach (var datum in dateiInhalt)
            {
                Console.WriteLine(datum);
            }

            Console.ReadLine();
        }

        static string[] FindeWerktageIn(int monat, int jahr)
        {
            var werktage = new List<string>();
            DateTime ersterTag = new DateTime(jahr, monat, 1);
            int anzahlTageImMonate = DateTime.DaysInMonth(jahr, monat);

            for (int i = 0; i < anzahlTageImMonate; i++)
            {
                DateTime tag = ersterTag.AddDays(i);

                // Samstag und Sonntag sind natürlich keine Werktage
                if ((tag.DayOfWeek != DayOfWeek.Sunday)
                    && (tag.DayOfWeek != DayOfWeek.Saturday))
                {
                    werktage.Add(tag.ToLongDateString());
                }
            }

            return werktage.ToArray();
        }

    }
}