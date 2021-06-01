using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    public static class CountriesApp
    {
        private static List<Country> countryDB;
        public static void WelcomeAction()
        {
            while (true)
            {
                UpdateCountries();
                Console.WriteLine("Hello, welcome to the country app. ");
                int menuSelection = MainMenuView.GetMenuSelection();
                switch (menuSelection)
                {
                    case 1:
                        ViewCountries();
                        break;
                    case 2:
                        AddRemoveCountries();
                        break;
                    case 3:
                        return;
                }
            }
        }

        public static void ViewCountries()
        {
                Console.WriteLine("These are the countries currently recorded:");  //after loop starts, so it will display on tryAgains
                CountryListView.Display(countryDB);                                     //Display the list of countries.
                int selection = -1;                     //selection will remain -1 if output was invalid.
                while (!int.TryParse(PromptForString("Please enter the number of your desired country."), out selection) || selection >= countryDB.Count || selection < 0)
                {                       //if tryParse fails, or if the int is outside the range of countries this will run.
                    Console.Write($"Invalid entry. ");
                }
                CountryView.Display(countryDB[selection]);        //once a valid selection is confirmed, perform country action on the element at the selection's index
        }

        public static void UpdateCountries()
        {
            countryDB = CountriesTextFile.ReadCountries();
        }

        public static void AddRemoveCountries()
        {
            Console.Write("To add or remove a country to/from the list, type the country's name: ");
            string name = Console.ReadLine();
            if (countryDB.Exists(x => x.Name.ToLower() == name.ToLower()))
            {
                countryDB.Remove(countryDB.Find(x => x.Name.ToLower() == name.ToLower()));
                CountriesTextFile.WriteCountries(countryDB);
                Console.WriteLine($"{name} has been removed from the list.");
                return;
            }
            Continent continent = PromptForContinent($"Please enter the continent on which {name} sits:");
            List<string> colors = PromptForStringList($"Please enter a color for {name}: ", $"If {name} has another color, enter it here.\nIf there are no more colors, simply enter nothing to move on.");
            string language = PromptForString($"What language is most commonly spoken or official in {name}?");
            bool hasNuclearWMD = PromptForBool($"Does {name} have nuclear weapons?");
            CountriesTextFile.WriteCountries(new Country(name, continent, colors, language, hasNuclearWMD));
            UpdateCountries();
            
        }

        private static string PromptForString(string message)
        {
            Console.Write(message+" ");
            return Console.ReadLine().Trim();
        }

        private static int PromptForInt(string message)
        {
            int returnVal;
            while (!int.TryParse(PromptForString(message), out returnVal))
            {
                Console.Write("Invalid entry. ");
            }
            return returnVal;
        }

        private static bool PromptForBool(string message)
        {
            string input = PromptForString($"{message} (y/n)");
            while (input != "y" && input != "yes" && input != "n" && input != "no")
            {       //if the entry was invalid, we will re-prompwt.
                input = PromptForString($"Invalid entry \"{input}\". Please try again. ");
            }
            return input[0] == 'y';     //will return the same value as the match between y and char 1 of entry.
        }

        private static Continent PromptForContinent(string message)
        {
            Continent returnVal;
            while (!Enum.TryParse<Continent>(PromptForString(message).Replace(' ','_'),true ,out returnVal))
            {
                Console.Write("Invalid entry. ");
            }
            return returnVal;
        }

        private static List<string> PromptForStringList(string message1, string message2)
        {
            List<string> returnList = new List<string>();
            string nextString = PromptForString(message1);
            while(nextString != "")
            {
                returnList.Add(nextString);
                nextString = PromptForString(message2);
            }
            return returnList;

        }
    }
}
