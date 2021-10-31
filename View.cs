using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;

namespace BlogsConsole
{  
    public static class View
    {
        
        private static List<string> mainMenuOptions = new List<string>()
        {
            "1. Display all blogs",
            "2. Add Blog",
            "3. Create Post",
            "4. Display Posts"
        };
        public static void displayMainMenu()
        {
            foreach(string option in mainMenuOptions)
            {
                System.Console.WriteLine(option);
            }            
        }

    }
}