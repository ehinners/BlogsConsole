﻿using System;
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

            Model.setLogger(logger);

            logger.Info("NLOG Loaded");
            
            Controller.mainLoop();

            logger.Info("Program ended");
        }
    }
}
