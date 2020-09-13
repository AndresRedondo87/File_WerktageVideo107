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
            // #1 - Dateiname / Pfad        //am besten immer mit Verbatim String definieren
            string dateiName = @"Testdaten\Werktage September.txt"; 
            //PFAD MUSS EXISTIEREN!! 
            //den Ordner Testdaten muss erst da sein, sonst haben wir exceptions!!

            // #2 - Daten (Text oder Binär?)
            string[] werktageImSeptember = FindeWerktageIn(09, 2020);   //aktualisiert 2020 anstatt 2016

            // #3 - Passende Methode von der Klasse File
            File.WriteAllLines(dateiName, werktageImSeptember);
            ///WriteAllLBytes - schreibt bytes weg
            ///WriteAllLines - schreibt strings weg kann mehrere Strings als parameter bekommen
            ///WriteAllText - schreibt nur ein string. wir bekommen nur ein string parameter     
            ///WriteAll - erzeugt/überschreibt Dateien
            ///AppendAll - fügt an bestehende Dateien an
            ///
            ///Pfade hier auch IMMER ALLE IN VERBATIM!!
            ///
            //string[] dateiInhalt = File.ReadAllLines(@"Testdaten\Werktage mit Umlauten.txt"); probleme mit Umlaute
            //string[] dateiInhalt10 = File.ReadAllLines(@"Testdaten\Werktage mit Umlauten.txt", Encoding.Default);       // Auch Probleme mit umlaute
            string[] dateiInhalt2 = File.ReadAllLines(@"Testdaten\Werktage mit Umlauten.txt", Encoding.ASCII);          // auch Probleme "??"
            string[] dateiInhalt3 = File.ReadAllLines(@"Testdaten\Werktage mit Umlauten.txt", Encoding.UTF8);           // DIESE HAT UMLAUTE richtig gezeigt!
            foreach (var datum in dateiInhalt2)
            {
                Console.WriteLine(datum);
            }
            Console.WriteLine();
            foreach (var datum in dateiInhalt3)
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