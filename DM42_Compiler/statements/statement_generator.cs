using System;

namespace DM42_Compiler
{
  public partial class statement: generable
  {
    public partial class stop_statement: statement
    {
      public override void generate(program_data data)
      {
        data.output.write_stop();
      }
    }
    
    public partial class prompt_statement: statement
    {
      
      public override void generate(program_data data)
      {
        data.output.write_prompt(caption);
      }
    }
    
    public partial class store_statement: statement
    {
      public override void generate(program_data data)
      {
        value.generate(data);
        data.output.write_store_named_register(id);
      }
    }
    
    public partial class input_statement: statement
    {
      public override void generate(program_data data)
      {
        data.advance_stack(2);
        data.output.write_input(definition.register);
        data.reclaim_stack(2);
      }
    }
    
    public partial class view_statement: statement
    {
      public override void generate(program_data data)
      {
        data.output.write_view(definition.register);
      }
    }
    
    public partial class external_statement: statement
    {
      public override void generate(program_data data)
      {
        parameter_list.generate(data);
        data.output.write_external_call(name);
        data.reclaim_stack(parameter_list.arguments.Count);
      }
    }
    
    public partial class id_statement: statement
    {
      public override void generate(program_data data)
      {
        operation.generate(data);
      }
    }
    
    public partial class for_statement: statement
    {     
      public override void generate(program_data data)
      {
        int loop = data.allocate_label();
        int end  = data.allocate_label();
        initial.generate(data);
        data.output.write_label(loop);
        data.output.write_store(v.register, true);
        final.generate(data);
        data.output.write_minus();
        data.reclaim_stack(1);
        data.output.write_comparison(comparison.relation_op.greater);
        data.output.write_goto(end);
        data.output.write_drop();
        data.reclaim_stack(1);
        controlled_statement.generate(data);
        data.advance_stack(2);
        data.output.write_recall(v.register);
        if (step.Defined) step.Value.generate(data);
        else data.output.write_number(1);
        data.output.write_plus();
        data.reclaim_stack(1);
        data.output.write_goto(loop);
        data.output.write_label(end);
        data.output.write_drop();
        data.reclaim_stack(1);
      }
    }
    
    public partial class for_step: generable
    {
      public void generate(program_data data)
      {
        amount.generate(data);
      }
    }
    
    public partial class while_statement: statement
    {
      public override void generate(program_data data)
      {
        int end_label      = data.allocate_label();
        int continue_label = data.allocate_label();
        data.output.write_label(continue_label);
        condition.generate(data);
        data.output.write_goto(end_label);
        data.output.write_drop();
        data.reclaim_stack(1);
        controlled_statement.generate(data);
        data.output.write_goto(continue_label);
        data.output.write_label(end_label);
        data.output.write_drop();
      }
    }
    
    public partial class if_statement: statement
    {
      public override void generate(program_data data)
      {
        int end_label = data.allocate_label();
        condition.generate(data);
        if (!else_part.Defined) 
        {
          data.output.write_goto(end_label);
          data.output.write_drop();
          data.reclaim_stack(1);
          then_part.generate(data);
        }
        else
        {
          int else_label = data.allocate_label();
          data.output.write_goto(else_label);
          data.output.write_drop();
          data.reclaim_stack(1);
          then_part.generate(data);
          data.output.write_goto(end_label);
          data.output.write_label(else_label);
          data.output.write_drop();
          else_part.Value.generate(data);
        }
        data.output.write_label(end_label);
      }
    }
    
    public partial class else_statement: generable
    {
      public virtual void generate(program_data data)
      {
        else_part.generate(data);
      }
    }
    
    public partial class block_statement: statement
    {
      public override void generate(program_data data)
      {
        block.generate(data);
      }
    }
    
    public partial class return_statement: statement
    {
      public override void generate(program_data data)
      {
        value.generate(data);
        if (function_return) data.output.write_return();
      }
    }
    
    public virtual void generate(program_data data)
    {
    }
  }
  
  partial class block: generable
  {
    public void generate(program_data data)
    {
      data.init_stack();
      foreach (declaration variable in declarations) variable.generate(data);
      foreach (statement   s        in statement   ) 
      {
        s.generate(data);
      }
    }
  }
    
  public partial class assignment_or_call: generable
  {
    public partial class assignment: assignment_or_call
    {
      public override void generate(program_data data)
      {
        int register = data.get_register(definition);
        value.generate(data);
        data.output.write_store(register);
        data.reclaim_stack(1);
      }
    }
    
    public partial class call: assignment_or_call
    {
      public override void generate(program_data data)
      {
        parameters.generate(data);
        data.advance_stack(definition.work_size);
        if (definition.label < 0)
          data.output.write_predefined_call(definition);
        else
          data.output.write_call(definition.label);
        data.output.write_drop(definition.drop_size);
        data.reclaim_stack(definition.parameters + definition.work_size);
      }
    }
    
    public virtual void generate(program_data data)
    {
    }
  }
}
