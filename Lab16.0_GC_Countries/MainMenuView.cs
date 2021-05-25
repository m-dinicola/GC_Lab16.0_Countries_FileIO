using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16._0_GC_Countries
{
    public class MainMenuView
    {
        public static List<string> mainMenuOptions = new List<string> { "Display Countries", "Edit Countries", "Exit" };
        public MainMenuView()
        {

        }

        public static void ShowMainMenu() 
        {
            for(int i=0; i<mainMenuOptions.Count; i++)
            {

                Console.WriteLine("Please select the action you would like to perform:");
                Console.WriteLine(string.Format("{0,-3}{1,-19} ",((i+1)+"."),mainMenuOptions[i]));
            }
        }

        public static int GetMenuSelection()
        {
            while (true)
            {
                ShowMainMenu();
                string result = Console.ReadLine();
                if (int.TryParse(Console.ReadLine(), out int intResult) && intResult > 0 && intResult <= mainMenuOptions.Count)
                {
                    return intResult - 1;
                }

                int resultString = mainMenuOptions.FindIndex(x => x.ToLower().StartsWith(result.ToLower()));
                if (resultString != -1)
                {
                    return resultString;
                }

                Console.Write("Invalid entry. ");
            }
        }
    }
}
