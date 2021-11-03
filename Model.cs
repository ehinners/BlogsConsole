using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using NLog.Web;

namespace BlogsConsole
{  
    public static class Model
    {
        
        // static instance of logger held so multiple instances don't have to be created
        private static NLog.Logger logger;
        private static BloggingContext db;

        public static NLog.Logger getLogger()
        {
            if(logger == null)
            {
               // create instance of Logger
                logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
            }
            return logger;
        }

        public static IEnumerable<Blog> getBlogs()
        {
            // Display all Blogs from the database
            var query = Model.GetBloggingContext().Blogs.OrderBy(b => b.Name);
            return query;
        }

        public static IEnumerable<Post> GetSelectedPosts(int searchID)
        {
            // Display all Posts from the database
            var query = Model.GetBloggingContext().Posts.Where(p => p.BlogId.Equals(searchID));
            return query;
        }

        public static IEnumerable<Post> GetPosts()
        {
            // Display all Posts from the database
            var query = Model.GetBloggingContext().Posts.OrderBy(p => p.PostId);
            return query;
        }

        public static BloggingContext GetBloggingContext()
        {
            if(db==null)
            {
                db = new BloggingContext();
            }
            return db;
        }

        public static int getNumMainMenuOptions()
        {
            return View.getMainMenuOptions().Count;
        }

    }
}