# BlogsConsole

This project will not be able to successfully connect to a database without an appsettings.json, make sure to add one.

As this file will contain sensitive information (user names and passwords) it is NOT included.

A generic form for such a file should look like this:

{
  "BloggingContext": {
    "ConnectionString": "Server=bitsql.wctc.edu;Database=Blogs_##_XXX;User ID=YYY;Password=ZZZ"
  },
  "_comment": {
    "##": "last 2 digits of CRN",
    "XXX": "your initials"
  }
}
