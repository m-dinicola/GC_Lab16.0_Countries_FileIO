using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    public enum Continent
    {
        Africa,
        Antarctica,
        Asia,
        Australia,
        Europe,
        North_America,
        South_America
    }


    public class Country
    {
        public string Name { set; get; }
        public Continent Continent { set; get; }
        public List<string> Colors { set; get; }
        public string Language { set; get; }
        public bool HasNuclearWMD { set; get; }

        public Country(string name, Continent continent, List<string> colors, string language, bool hasNuclear)
        {
            Name = name;
            Continent = continent;                          //continent is an Enum
            Colors = colors.ConvertAll(x => x.ToLower());   //stores as lower, because why not
            Language = language;
            HasNuclearWMD = hasNuclear;
        }
    }
}
