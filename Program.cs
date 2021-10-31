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

            // TODO
            // Add Post function
            // Add list all posts function        

            Model.getLogger().Info("NLOG Loaded");

            Controller.mainLoop();

            Model.getLogger().Info("Program ended");
        }
    }
}
