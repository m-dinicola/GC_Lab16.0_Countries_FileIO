using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    class CountriesController
    {
        public List<Country> CountryDB { get; set; }

        public CountriesController(List<Country> countryDB)
        {
            CountryDB = countryDB;      //constructor stores the countries as a list
        }

        public void CountryAction(Country c)        //country action displays the country passed to it.
        {
            new CountryView(c).Display();           //the countryView method need not be persistent.
        }

        public void WelcomeAction()
        {
            CountryListView countryListView = new CountryListView(CountryDB);   //Starting a countryList view before the loop
            Console.WriteLine("Hello, welcome to the country app. ");           //So that we don't have to make a new one each time
            bool tryAgain = true;
            while (tryAgain)
            {
                Console.WriteLine("Please select a country from the following list:");  //after loop starts, so it will display on tryAgains
                countryListView.Display();                                      //Display the list of countries.
                int selection = -1;                     //selection will remain -1 if output was invalid.
                while (!int.TryParse(Console.ReadLine(), out selection) || selection >= CountryDB.Count || selection < 0)
                {                       //if tryParse fails, or if the int is outside the range of countries this will run.
                    Console.Write($"Invalid entry. Please enter the number of your desired country. ");
                }
                CountryAction(CountryDB[selection]);        //once a valid selection is confirmed, perform country action on the element at the selection's index
                Console.WriteLine("Would you like to learn about another country? (y/n)");
                string input = Console.ReadLine();
                while (input != "y" && input != "yes" && input != "n" && input != "no")
                {       //if the entry was invalid, we will re-prompwt.
                    Console.Write($"Invalid entry \"{input}\". Please try again. ");
                    input = Console.ReadLine();
                }
                tryAgain = input[0] == 'y';     //tryAgain will have the same value as the match between y and char 1 of entry.
            }
        }
    }
}
