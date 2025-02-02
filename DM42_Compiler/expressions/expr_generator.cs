namespace DM42_Compiler
{
  public partial class comparison: generable
  {   
    public void generate(program_data data)
    {
      operand_1.generate(data);
      operand_2.generate(data);
      data.output.write_minus();
      data.reclaim_stack(1);
      data.output.write_inverse_comparison(op);
    }
  }
  
  public partial class expr: generable
  {
    public void generate(program_data data)
    {
      term.generate(data);
      foreach (terms t in terms) t.generate(data);
    }
  }
  
  public partial class term: generable
  {   
    public void generate(program_data data)
    {
      factor.generate(data);
      switch (unary)
      {
        case unary_op.minus: data.output.write_negate(); break;
      }
      foreach (var ex in exponents) ex.generate(data);
      foreach (factors f in factors) f.generate(data);
    }
  }
  
  public partial class terms: generable
  { 
    public void generate(program_data data)
    {
      term.generate(data);
      switch (op)
      {
        case adding_op.plus : data.output.write_plus (); break;
        case adding_op.minus: data.output.write_minus(); break;
        case adding_op.or   : data.output.write_or   (); break;
        case adding_op.xor  : data.output.write_xor  (); break;
      }
      data.reclaim_stack(1);
    }
  }
  
  public partial class factors: generable
  {
    public void generate(program_data data)
    {
      factor.generate(data);
      switch (unary)
      {
        case unary_op.minus: data.output.write_negate(); break;
      }
      foreach (var ex in exponents) ex.generate(data);
      switch (op)
      {
        case product_op.times : data.output.write_times (); break;
        case product_op.divide: data.output.write_divide(); break;
        case product_op.mod   : data.output.write_mod   (); break;
        case product_op.and   : data.output.write_and   (); break;
      }
      data.reclaim_stack(1);
    }
  }
  
  public partial class exponent: generable
  {
    public void generate(program_data data)
    {
      power.generate(data);
      data.output.write_to_power();
      data.reclaim_stack(1);
    }
  }
  
  public partial class factor: generable
  { 
    public partial class integer_factor: factor
    {      
      public override void generate(program_data data)
      {
        data.advance_stack(1);
        data.output.write_number(value);
      }     
    }
    
    public partial class real_factor: factor
    {  
      public override void generate(program_data data)
      {
        data.advance_stack(1);
        data.output.write_number(value);
      }         
    }
    
    public partial class not_factor: factor
    {  
      public override void generate(program_data data)
      {
        expr.generate(data);
        data.output.write_not();
      }         
    }
    
    public partial class sub_expr_factor: factor
    {  
      public override void generate(program_data data)
      {
        expr.generate(data);
      }     
    }
    
    public partial class matrix_factor: factor
    {       
      public override void generate(program_data data)
      {
        data.advance_stack(2);
        data.output.write_begin_matrix(row_count, column_count);
        data.reclaim_stack(1);
        bool first_value = true;
        foreach (var r in rows) 
        {
          foreach (var e in r.values) 
          {
            if (!first_value) data.output.write_next_row(); else first_value = false;
            e.generate(data);
            data.reclaim_stack(1);
          }
        }
        data.output.write_end_matrix();
      }     
    }
    
    public partial class maxrix_row: generable
    {
      public void generate(program_data data)
      {
      }
    }
    
    public partial class external_factor: factor
    {
      public override void generate(program_data data)
      {
        parameter_list.generate(data);
        data.output.write_external_call(name);
        data.reclaim_stack(parameter_list.arguments.Count - 1);
      }
    }
    
    public partial class recall_factor: factor
    {  
      public override void generate(program_data data)
      {
        data.advance_stack(1);
        data.output.write_recall_named_register(id);
      }     
    }
    
    public partial class id_factor: factor
    {    
      public override void generate(program_data data)
      {
        if (!parameter_list.Defined)
        {
          int register = data.get_register((declaration.variable_declaration)definition);
          data.output.write_recall(register);
          data.advance_stack(1);
        }
        else
        {
          string label = data.get_label((declaration.function_declaration)definition);
          var    f     = definition as declaration.function_declaration;
          parameter_list.Value.generate(data);
          if (f.label < 0) data.output.write_predefined_call(f); else data.output.write_call(f.label);
          data.reclaim_stack(f.parameters - f.result_size);
        }
      }   
    }
    
    public partial class parameters: generable
    {
      public void generate(program_data data)
      {
        foreach (var e in arguments) e.generate(data);
      }
    }
    
    public virtual void generate(program_data data)
    {
    }
  }
}
