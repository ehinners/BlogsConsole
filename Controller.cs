using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;

namespace BlogsConsole
{  
    public static class Controller
    {
        public static void mainLoop()
        {
            bool stillLooping = true;
            string input = "";
            while(stillLooping)
            {
                View.displayMainMenu();
                input = System.Console.ReadLine();
               
                stillLooping = verifyInput(input);                          

                if(input == "1")
                {
                    View.listAllBlogs();
                }

                if(input == "2")
                {
                    addBlog();
                }
            }           
        }

        private static bool verifyInput(string input)
        {
            bool verified = false;
            int value;
            try
            {
                value = int.Parse(input);
                if(value <= Model.getNumMainMenuOptions())
                {
                    verified = true;
                }
            }
            catch
            {
                Model.getLogger().Warn("Not Valid Input");
            }

            return verified;
        }

        private static void addBlog()
        {
            try
            {
                //Model.getLogger();
                // Create and save a new Blog
                View.addBlogPrompt();
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                var db = new BloggingContext();
                db.AddBlog(blog);
                Model.getLogger().Info("Blog added - {name}", name);
            }
            catch (Exception ex)
            {
                Model.getLogger().Error(ex.Message);
            }
        }
    }
}