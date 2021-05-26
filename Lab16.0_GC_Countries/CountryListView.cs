using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    static class CountryListView
    {

        public static void Display(List<Country> countries)
        {
            for (int i = 0; i < countries.Count; i++)
            {
                Console.WriteLine($"{i}. {countries[i].Name}");
            }
        }
    }
}
