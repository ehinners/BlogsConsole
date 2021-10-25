using System;
using System.IO;
using NLog.Web;
using System.Linq;
using System.Collections.Generic;

namespace BlogsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("");

            //////////////////////////////
            //      NLOG Instantiation  //
            //////////////////////////////

            //dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.11
            //dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.11
            //dotnet tool update --global dotnet-ef
            //dotnet tool install --global dotnet-ef
            //dotnet ef migrations add CreateDatabase
            //dotnet ef database update
            //bitsql.wctc.edu
            //dotnet add package Microsoft.Extensions.Configuration --version 5.0.0

            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

            logger.Info("NLOG Loaded");
            try
            {

                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                var db = new BloggingContext();
                db.AddBlog(blog);
                logger.Info("Blog added - {name}", name);

                // Display all Blogs from the database
                var query = db.Blogs.OrderBy(b => b.Name);

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            logger.Info("Program ended");
        }
    }
}
