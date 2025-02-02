using System;
using parsable_objects;

namespace DM42_Compiler
{
  public class analyser_error: Exception
  {
    public parsable element;
    public analyser_error(parsable element, string message): base(message) 
    {
      this.element = element;
    }
  }
  
  public class compiler_error: Exception
  {
    public compiler_error(string message): base(message) {}
  }
}
