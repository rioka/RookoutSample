using System;
using Microsoft.Extensions.Configuration;

namespace RookoutSample.App
{
  internal class Foo
  {
    private readonly IConfiguration _config;
    private readonly Bar _bar;

    public Foo(IConfiguration config, Bar bar)
    {
      _config = config;
      _bar = bar;
    }

    public int Run(string reason)
    {
      var who = Environment.UserName;
      var guess = _bar.Guess(reason);
      Console.WriteLine($"{who}, guess what? {guess}");

      return guess;
    }
  }
}