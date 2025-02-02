using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using parsable_objects;

namespace DM42_Compiler
{
  public partial class program: parsable
  {
    [Parse(1, "program")] public reserved_word               program_word;
    [Parse(2)           ] public identifier                  name;
    [Parse(3, "(")      ] public punctuation                 open;
    [Parse(4, ",")      ] public List<parameter_declaration> parameter_list;
    [Parse(5, ")")      ] public punctuation                 close;
    [Parse(6)           ] public block                       definition;
  }
  
  public partial class declaration: parsable
  {   
    public partial class function_declaration: declaration
    {
      [Parse(1, "func")] public reserved_word               func;
      [Parse(2)        ] public Optional<void_part>         void_def;
      [Parse(3)        ] public identifier                  name;
      [Parse(4, "(")   ] public punctuation                 open;
      [Parse(5, ",")   ] public List<parameter_declaration> parameter_list;
      [Parse(6, ")")   ] public punctuation                 close;
      [Parse(7)        ] public block                       definition;
    } 
    
    public partial class void_part: parsable
    {
      [Parse(1, "void")] public reserved_word void_word;
    }
    
    public partial class variable_declaration: declaration
    {
      [Parse(1, "var")] public reserved_word var_word;
      [Parse(2)       ] public identifier    name;
      [Parse(3, "=")  ] public punctuation   becomes;
      [Parse(4)       ] public expr          value;
      [Parse(5, ";")  ] public punctuation   semi_colon;
    }
    
    public int position;
    
    public override void  parsed(source_reader source)
    {
      position = source.position;
    }
  }
    
  public partial class parameter_declaration: parsable
  {
    public int register;
    
    [Parse(1)] public identifier name;
  } 
}
