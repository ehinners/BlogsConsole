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

                if(input == "3")
                {
                    addPost();
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

        public static void addPost()
        {
            /*
            int PostId 
            string Title 
            string Content 
            int BlogId 
            Blog Blog */
            
            Post post = new Post();
            post.Blog = selectBlog();
            post.BlogId = post.Blog.BlogId;
            View.addPostTitlePrompt();
            post.Title = Console.ReadLine();
            View.addPostContentPrompt();
            post.Content = Console.ReadLine();          

            try
            {
                //Model.getLogger();
                // Create and save a new Post         
                
                Model.GetBloggingContext().AddPost(post);
                Model.getLogger().Info("Post added - {name}", post.Title);
            }
            catch (Exception ex)
            {
                Model.getLogger().Error(ex.Message);
            }

        }

        private static Blog selectBlog()
        {            
            string input = "";
            bool validInput = false;
            int blogID = 0;
            while(!validInput)
            {
                View.addPostPrompt();
                View.listAllBlogsWithIDs();
                input = Console.ReadLine();
                try
                {
                    blogID = int.Parse(input);

                    foreach (var item in Model.getBlogs())
                    {
                        if(blogID == item.BlogId)
                        {
                            validInput = true;
                        }
                    }
                    if(!validInput)
                    {
                        Model.getLogger().Warn("Blog Not Found");
                    }
                }
                catch
                {
                    Model.getLogger().Warn("Not vald int");
                }
                
            } 

            return Model.GetBloggingContext().getBlog(blogID);
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

                Model.GetBloggingContext().AddBlog(blog);
                Model.getLogger().Info("Blog added - {name}", name);
            }
            catch (Exception ex)
            {
                Model.getLogger().Error(ex.Message);
            }
        }
    }
}