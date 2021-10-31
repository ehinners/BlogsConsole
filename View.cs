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

        public static List<string> getMainMenuOptions()
        {
            return mainMenuOptions;
        }

        public static void listAllBlogs()
        {
            // Display all Blogs from the database
            var query = Model.GetBloggingContext().Blogs.OrderBy(b => b.Name);

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void addBlogPrompt()
        {
            Console.Write("Enter a name for a new Blog: ");
        }

    }
}