using System;
using System.IO;

namespace Statystyka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nazwa;
            Console.Write("Podajnazę pliku: ");
            nazwa = Console.ReadLine() ?? "";
            int ile_linii = 0, ile_liczb = 0;
            double max = double.MinValue;
            double min = double.MaxValue;
            double suma = 0.0;

            if (File.Exists(nazwa))
            {
                StreamReader reader = new StreamReader(nazwa);
                using (reader)
                {
                    double x;
                    while (!reader.EndOfStream)
                    {
                        string linia = reader.ReadLine() ?? "";
                        ile_linii++;
                        if (double.TryParse(linia, out x))
                        {
                            ile_liczb++;
                            suma += x;
                            if (x < min) min = x;
                            if (x > max) max = x;
                        }
                        else
                        {
                            Console.WriteLine("W linii {0} zły format liczby: {1}", ile_linii, linia);
                        }
                    }
                }
            }
            else 
            {
                Console.WriteLine("Plik {0} nie istnieje", nazwa);
                Console.WriteLine("Katalog bieżący: {0}", Directory.GetCurrentDirectory());
            }

            Console.WriteLine("Ile linii: {0}", ile_linii);
            Console.WriteLine("Suma: {0}", suma);
            Console.WriteLine("Średnia: {0}", suma/ile_linii);
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("Min: {0}", min);
        }
    }
}