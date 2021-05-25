using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    class CountryListView
    {
        public List<Country> Countries;

        public CountryListView(List<Country> countries)
        {
            Countries = countries;
        }

        public void Display()
        {
            for (int i = 0; i < Countries.Count; i++)
            {
                Console.WriteLine($"{Countries[i].Name} {i}");
            }
        }
    }
}
