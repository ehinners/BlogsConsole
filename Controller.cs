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
        private static string menuEscape = "q";
        public static void mainLoop()
        {
            bool stillLooping = true;
            string input = "";
            while(stillLooping)
            {
                View.displayMainMenu();
                input = System.Console.ReadLine();
               
                if(input.ToUpper() != menuEscape.ToUpper())
                {
                    verifyInput(input);   
                }
                else
                {
                    stillLooping = false;
                }
                                       

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

                if(input == "4")
                {
                    viewPosts();
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
                else
                {
                    Model.getLogger().Warn("Command Not Found");
                }
            }
            catch
            {
                Model.getLogger().Error("Not Valid Input");
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
            bool validPostName = false;
            
            Post post = new Post();
            post.Blog = selectBlogAddPost();
            post.BlogId = post.Blog.BlogId;

            while(!validPostName)
            {
                View.addPostTitlePrompt();
                post.Title = Console.ReadLine();
                if(post.Title.Length > 0)
                {
                    validPostName = true;
                }
                else
                {
                    Model.getLogger().Error("Post title cannot be null");
                }
            }
            
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

        private static void viewPosts()
        {
            //Blog blog = selectBlog();
            //View.listAllPosts(blog);

            string input = "";
            bool validInput = false;
            int blogID = 0;
            Blog tempblog = new Blog();
            while(!validInput)
            {
                View.viewPostPrompt();
                View.promptAllPosts();
                View.listAllBlogsWithIDs();
                input = Console.ReadLine();
                try
                {
                    blogID = int.Parse(input);

                    if(blogID != 0)
                    {
                        foreach (var item in Model.getBlogs())
                        {
                            if(blogID == item.BlogId)
                            {
                                validInput = true;
                            }
                        }
                        if(!validInput)
                        {
                            Model.getLogger().Error("There are no Blogs saved with that Id");
                        }
                    }
                    else if(blogID == 0)
                    {
                        validInput = true;                        
                    }

                    
                }
                catch
                {
                    Model.getLogger().Error("Invalid Blog Id");
                }
                
            }


            if(blogID == 0) 
            {
                View.listAllPosts();
            }
            else
            {
                foreach(Blog b in Model.GetBloggingContext().Blogs.Where(b => b.BlogId.Equals(blogID)))
                {
                    tempblog = b;
                }
                View.listSelectedPosts(tempblog);
            }            
        }

        private static Blog selectBlogAddPost()
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
                        Model.getLogger().Error("There are no Blogs saved with that Id");
                    }
                }
                catch
                {
                    Model.getLogger().Error("Invalid Blog Id");
                }
                
            } 

            foreach(Blog b in Model.GetBloggingContext().Blogs.Where(b => b.BlogId.Equals(blogID)))
            {
                return b;
            }
            Blog blog = new Blog();
            return blog;
        }

        private static bool isBlogNameDuplicate(string blogName)
        {
            bool uniqueName = Model.getBlogs().Where(bn => bn.Name == blogName).Count() == 0 ? true : false;

            return uniqueName;
        }

        private static void addBlog()
        {
            try
            {
                bool validName = false;
                var name = "";
                while(!validName)
                {
                    // Create and save a new Blog
                    View.addBlogPrompt();
                    name = Console.ReadLine();
                    if(name.Length > 0)
                    {
                        validName = isBlogNameDuplicate(name);
                        if(!validName)
                        {
                            Model.getLogger().Error("Blog Name Not Unique");
                        }
                    }
                    else
                    {
                        Model.getLogger().Error("Blog Name cannot be null");
                    }
                    
                }
                //Model.getLogger();
                

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