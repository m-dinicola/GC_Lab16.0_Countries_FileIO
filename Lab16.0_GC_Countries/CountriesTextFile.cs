using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Lab16._0_GC_Countries
{
    public static class CountriesTextFile
    {
        private static List<Country> _countries;

        public static List<Country> ReadCountries()
        {

            List<Country> countries = new List<Country>();                 //Creates a list of string arrays in which we will collect the values of a csv source
            string[] lines = File.ReadAllLines("countries.txt");           //This string array keeps a string for each line in the source csv
            foreach (string line in lines)                                 //Cycles through each line
            {
                                                                            //splits each line at the pipe, ouputs as a string[4],
                countries.Add(StringArrayToCountry(line.Split('|')));       //uses method to convert string array to country and adds to the list

            }
            _countries = countries;                                         //assigns _countries field to our new list of countries
            return _countries;
        }

        //convert a string array to a country
        public static Country StringArrayToCountry(string[] input)
        {
            List<string> colors = input[2].Split(',').ToList<string>();
            bool hasNuclear = false;
            Continent continent = Continent.Antarctica;
            if(!Enum.TryParse<Continent>(input[1].Trim().Replace(' ','_'),true , out continent))
            {
                Console.WriteLine($"Invalid continent \"{input[1]}\". Used default \"{Continent.Antarctica.ToString().Replace('_', ' ')}\" instead.");
            }
            if (!bool.TryParse(input[4].Trim().ToLower(), out hasNuclear))
            {
                Console.WriteLine($"Invalid entry \"{input[4]}\" for field \"hasNuclear\". Used default \"false\" instead.");
            }
            return new Country(input[0], continent, colors, input[3], hasNuclear);
        }

        //convert a country to a string
        public static string CountryToString(Country c)
        {
            string returnString = $"{c.Name}|{c.Continent}|";
            foreach(string s in c.Colors)
            {
                returnString += s + ",";
            }
            returnString.Remove(returnString.Length - 1);
            returnString += $"|{c.Language}|{c.HasNuclearWMD}\n";

            return returnString;
        }

        //send a country to add it to the current list and write to the file
        public static void WriteCountries(Country c)
        {
            _countries.Add(c);
            if (!File.Exists(@"..\..\countries.txt"))
            {
                File.AppendAllText(@"..\..\countries.txt",CountryToString(c));
            }
        }

        //send a list to overwrite the current list and write to the file
        public static void WriteCountries(List<Country> countries)
        {
            _countries = countries;
            using (StreamWriter fs = new StreamWriter(@"..\..\countries.txt")) {
                foreach (Country c in countries)
                {
                    fs.WriteLine(CountryToString(c));
                }
            }

        }
    }
}
