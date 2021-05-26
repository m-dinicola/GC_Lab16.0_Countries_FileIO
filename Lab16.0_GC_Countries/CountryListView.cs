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
                Console.WriteLine(String.Format("{0,-3} {1}",i+".",countries[i].Name));
            }
        }
    }
}
