using System.Collections.Generic;
using parsable_objects;

namespace DM42_Compiler
{
  public partial class statement: analysable
  {
    public partial class stop_statement: statement
    {
      public override void analyse(program_data data)
      {
      }
    }
    
    public partial class prompt_statement: statement
    {
      public override void analyse(program_data data)
      {
        if (caption.Length > program_data.alpha_limit) throw new analyser_error(this, "Promp string is too long");
      }
    }
    
    public partial class store_statement: statement
    {
      public override void analyse(program_data data)
      {
        value.analyse(data);
        if (id.Length > program_data.register_name_limit) throw new analyser_error(this, "Register name too long");
      }
    }
    
    public partial class input_statement: statement
    {
      declaration.variable_declaration definition;
      
      public override void analyse(program_data data)
      {
        definition = data.get_declaration(variable.spelling) as declaration.variable_declaration;
        if (definition == null)
          throw new analyser_error(this, "Identifier " + variable.spelling + " does not refer to a variable");
      }
    }
    
    public partial class view_statement: statement
    {
      declaration.variable_declaration definition;
      
      public override void analyse(program_data data)
      {
        definition = data.get_declaration(variable.spelling) as declaration.variable_declaration;
        if (definition == null)
          throw new analyser_error(this, "Identifier " + variable.spelling + " does not refer to a variable");
      }
    }
    
    public partial class external_statement: statement
    {
      public override void analyse(program_data data)
      {
        if (name.Length > program_data.label_name_limit)
          throw new analyser_error(this, "External name " + name + " too long(max "+program_data.label_name_limit.ToString() + ")");
        else parameter_list.analyse(data);
      }
    }
    
    public partial class id_statement: statement
    { 
      public override void analyse(program_data data)
      {
        operation.analyse(this, data);
      }
    }
    
    public partial class for_statement: statement
    {
      public declaration.variable_declaration v;
      
      public override void analyse(program_data data)
      {
        v = data.add_loop_variable(this, id.spelling);
        initial.analyse(data);
        final.analyse(data);
        if (step.Defined) step.Value.analyse(data);
        controlled_statement.analyse(data);
      }
    }
    
    public partial class for_step: analysable
    {
      public void analyse(program_data data)
      {
        amount.analyse(data);
      }
    }
    
    public partial class while_statement: statement
    {
      public override void analyse(program_data data)
      {
        condition.analyse(data);
        controlled_statement.analyse(data);
      }
    }
    
    public partial class if_statement: statement
    {
      public override void analyse(program_data data)
      {
        condition.analyse(data);
        then_part.analyse(data);
        if (else_part.Defined) else_part.Value.analyse(data);
      }
    }
    
    public partial class else_statement: analysable
    {
      public virtual void analyse(program_data data)
      {
        else_part.analyse(data);
      }
    }
    
    public partial class block_statement: statement
    {
      public override void analyse(program_data data)
      {
        block.analyse(data);
      }
    }
    
    public partial class return_statement: statement
    {
      public bool function_return; 
      
      public override void analyse(program_data data)
      {
        if (data.current_function != null && data.current_function.result_size == 0)
          throw new analyser_error(this, "Void function " + data.current_function.name.spelling + " cannot return a result");
        else
        {
          function_return = data.current_function != null;
          if (function_return) data.current_function.has_return = true;  
          value.analyse(data);
        }
      }
    }
    
    public virtual void analyse(program_data data)
    {
    }
  }
  
  partial class block: analysable
  {
    public void analyse(program_data data)
    {
      foreach (declaration d in declarations) d.analyse(data);
      foreach (statement   s in statement   ) s.analyse(data);
    }
  }
    
  public partial class assignment_or_call: analysable
  {
    public partial class assignment: assignment_or_call
    {
      public declaration.variable_declaration definition;
      
      public override void analyse(statement.id_statement s, program_data data)
      {
        definition = data.get_declaration(s.target.spelling) as declaration.variable_declaration;
        if (definition == null) throw new analyser_error(s, "Identifier " + s.target.spelling + " does not refer to a variable");
        else value.analyse(data);
      }
    }
    
    public partial class call: assignment_or_call
    {  
      public declaration.function_declaration definition;
          
      public override void analyse(statement.id_statement s, program_data data)
      {
        definition = data.get_declaration(s.target.spelling) as declaration.function_declaration;
        if (definition == null) throw new analyser_error(s, "Identifier " + s.target.spelling + " does not refer to a function");
        else
        {
          data.check_operation(this, definition.name.spelling);
          parameters.analyse(data);
          if (definition.result_size > 0) 
            throw new analyser_error(s, "Function " + definition.name.spelling + ": Only functions which do not return results can be called");
          else if (parameters.arguments.Count != definition.parameters)
            throw new analyser_error(s, "Function " + definition.name.spelling + " requires " + definition.parameters + " argument(s)");
        }
      }
    }
    
    public virtual void analyse(program_data data)
    {
    }
    
    public virtual void analyse(statement.id_statement s, program_data data)
    {
    }
  }
}
