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
            Console.WriteLine("All blogs in the database:");
            foreach (var item in Model.getBlogs())
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void listAllBlogsWithIDs()
        {
            // Display all Blogs from the database
            foreach (var item in Model.getBlogs())
            {
                Console.WriteLine("Blog ID: " + item.BlogId + " Blog Name: " + item.Name);
            }
        }

        public static void listAllPosts(Blog blog)
        {            
            foreach(Post p in Model.GetPosts(blog.BlogId))
            {
                System.Console.WriteLine(p.Title);
            }
        }

        public static void addBlogPrompt()
        {
            Console.Write("Enter a name for a new Blog: ");
        }

        public static void addPostPrompt()
        {
            System.Console.WriteLine("Enter the ID of a Blog to Post to: ");
        }

        public static void addPostTitlePrompt()
        {
            Console.WriteLine("Enter The Title Of Your Post");
        }

        public static void addPostContentPrompt()
        {
            Console.WriteLine("Enter The Content Of Your Post");
        }

    }
}