using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using parsable_objects;

namespace DM42_Compiler
{
  interface analysable
  {
    void analyse(program_data data);
  }
  
  partial class program: analysable
  {
    public string title;
    
    public void analyse(program_data data)
    {
      title = name.spelling;
      foreach (var p in parameter_list) p.analyse(data);
      definition.analyse(data);
    }
  }
  
  partial class declaration: analysable
  { 
    partial class function_declaration: declaration
    {
      public Dictionary<string, parsable>     previous_scope;
      public Dictionary<string, parsable>     current_scope;
      public declaration.function_declaration previous_function;
      public int                              label;
      public int                              parameters;
      public string                           key;
      public int                              result_size;
      public int                              drop_size;
      public int                              work_size;
      public bool                             has_return;
      
      public override void analyse(program_data data)
      {
        key         = "";
        result_size = void_def.Defined ? 0 : 1;
        drop_size   = 0;
        work_size   = 0;
        data.enter_function(this);
        foreach (var p in parameter_list) p.analyse(data);
        parameters = parameter_list.Count;
        has_return = false;
        definition.analyse(data);
        if (result_size > 0 && !has_return)
          throw new analyser_error(this, "function " + name.spelling + ": Missing return statement");
        else
        {
          data.exit_function(this);
          data.add_function(name.spelling, this);
        }
      }
    }
  
    partial class variable_declaration: declaration
    {
      public int register;
      
      public override void analyse(program_data data)
      {
        value.analyse(data);
        data.add_variable(name.spelling, this);
      }
    }
    
    public virtual void analyse(program_data data)
    {
    }
  }
    
  public partial class parameter_declaration: analysable
  { 
    public void analyse(program_data data)
    {
      if (data.request_parameters && name.spelling.Length > program_data.register_name_limit)
        throw new analyser_error(this, "Parameter name too long when Request Parameters option is selected (max " + program_data.register_name_limit + ")");
      else
        data.add_parameter(name.spelling, this);
    }
  } 
 
}
