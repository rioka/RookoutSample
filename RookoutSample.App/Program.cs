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
      var foo = new Foo(config, new Bar());
      
      while (true)
      {
        Console.Write("What do you want an answer for? (Enter 'Q' to quit)");
        var reason = Console.ReadLine();

        if (reason.Equals("Q", StringComparison.OrdinalIgnoreCase))
        {
          break;
        }

        Console.WriteLine($"Mhh... maybe the answer to {reason} is {foo.Run(reason)}");
      } 
    }
  }
}