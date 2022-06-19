using System;

namespace RookoutSample.App
{
  internal class Bar
  {
    public Guid Id { get; }
    public Bar()
    {
      Id = Guid.NewGuid();
    }
    
    public int Guess(string target)
    {
      return target switch {
        "life" => 42,
        _ => DateTime.UtcNow.Millisecond
      };
    }    
  }
}