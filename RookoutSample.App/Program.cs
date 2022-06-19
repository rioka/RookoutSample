using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace RookoutSample.App
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<Program>()
        .Build();
      
      var options = new Rook.RookOptions() {
        token = config.GetSection("Rookout:ApiKey").Value,
        labels = new Dictionary<string, string>() { 
          ["env"] = "Playground"
        }
      };
      Rook.API.Start(options);

      Console.WriteLine("Hi there!");
      Console.WriteLine("Press any key to quit");

      Console.ReadKey();
    }
  }
}