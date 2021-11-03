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
            "1) Display all blogs",
            "2) Add Blog",
            "3) Create Post",
            "4) Display Posts"
        };
        public static void displayMainMenu()
        {
            System.Console.WriteLine("Enter your selection:");
            foreach(string option in mainMenuOptions)
            {
                System.Console.WriteLine(option);
            } 
            System.Console.WriteLine("Enter q to quit");           
        }

        public static List<string> getMainMenuOptions()
        {
            return mainMenuOptions;
        }

        public static void listAllBlogs()
        {
            // Display all Blogs from the database
            Console.WriteLine("{0} Blogs returned", Model.getBlogs().Count());
            foreach (var item in Model.getBlogs())
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void listAllBlogsWithIDs()
        {
            // Display all Blogs from the database
            foreach (var item in Model.getBlogs().OrderBy(b => b.BlogId))
            {
                Console.WriteLine(item.BlogId + ") " + item.Name);
            }
        }

        public static void listAllPosts(Blog blog)
        { 
            System.Console.WriteLine();
            System.Console.Write("For Blog " + blog.Name +": ");    
            System.Console.Write("{0} Posts Returned", Model.GetPosts(blog.BlogId).Count());      
            System.Console.WriteLine(); 
            foreach(Post p in Model.GetPosts(blog.BlogId))
            {
                System.Console.WriteLine("Blog Name: " + p.Blog.Name);
                System.Console.WriteLine("Post Title: " + p.Title);
                System.Console.WriteLine("Post Content: " + p.Content);
                System.Console.WriteLine();
            }
        }

        public static void addBlogPrompt()
        {
            Console.Write("Enter a name for a new Blog: ");
        }

        public static void addPostPrompt()
        {
            System.Console.WriteLine("Select the blog you would like to post to: ");
        }

        public static void addPostTitlePrompt()
        {
            Console.WriteLine("Enter The Post Title");
        }

        public static void addPostContentPrompt()
        {
            Console.WriteLine("Enter The Post Content");
        }

    }
}