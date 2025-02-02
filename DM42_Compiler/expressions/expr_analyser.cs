namespace DM42_Compiler
{  
   public partial class comparison: analysable
  {   
    public void analyse(program_data data)
    {
      operand_1.analyse(data);
      operand_2.analyse(data);
    }
  }
  
  public partial class expr: analysable
  {
    public void analyse(program_data data)
    {
      term.analyse(data);
      foreach (terms t in terms) t.analyse(data);
    }
  }
  
  public partial class term: analysable
  {   
    public void analyse(program_data data)
    {
      factor.analyse(data);
      foreach (var ex in exponents) ex.analyse(data);
      foreach (factors f in factors) f.analyse(data);
    }
  }
  
  public partial class terms: analysable
  { 
    public void analyse(program_data data)
    {
      term.analyse(data);
    }
  }
  
  public partial class factors: analysable
  {
    public void analyse(program_data data)
    {
      factor.analyse(data);
      foreach (var ex in exponents) ex.analyse(data);
    }
  }
  
  public partial class exponent: analysable
  {
    public void analyse(program_data data)
    {
      power.analyse(data);
    }
  }
  
  public partial class factor: analysable
  { 
    public partial class integer_factor: factor
    {      
      public override void analyse(program_data data)
      {
      }     
    }
    
    public partial class real_factor: factor
    {  
      public override void analyse(program_data data)
      {
      }         
    }
    
    public partial class not_factor: factor
    {  
      public override void analyse(program_data data)
      {
        expr.analyse(data);
      }         
    }
    
    public partial class sub_expr_factor: factor
    {  
      public override void analyse(program_data data)
      {
        expr.analyse(data);
      }     
    }
    
    public partial class recall_factor: factor
    {  
      public override void analyse(program_data data)
      {
        if (id.Length > program_data.register_name_limit) throw new analyser_error(this, "Register name too long");
      }     
    }
    
    public partial class matrix_factor: factor
    { 
      public int row_count;
      public int column_count;
      
      public override void analyse(program_data data)
      {
        data.check_operation(this, "matrix");
        row_count = rows.Count;
        if (row_count == 0) throw new analyser_error(this, "A matrix must have at least 1 row");
        else
        {
          column_count = rows[0].values.Count;
          foreach (var r in rows) 
          {
            if      (r.values.Count == 0           ) throw new analyser_error(this, "A matrix row must have at least 1 element");
            else if (r.values.Count != column_count) throw new analyser_error(this, "A matrix row must have the same number of elements in each row");
            else r.analyse(data);
          }
        }
      }     
    }
    
    public partial class maxrix_row: analysable
    {
      public void analyse(program_data data)
      {
        foreach (var e in values) e.analyse(data);
      }
    }
    
    public partial class external_factor: factor
    {
      public override void analyse(program_data data)
      {
        if (name.Length > program_data.label_name_limit)
          throw new analyser_error(this, "External name " + name + " too long(max "+program_data.label_name_limit.ToString() + ")");
        else parameter_list.analyse(data);
      }
    }
    
    public partial class id_factor: factor
    {    
      public declaration definition;
      
      public override void analyse(program_data data)
      {
        definition = data.get_declaration(id.spelling) as declaration;
        if (!parameter_list.Defined)
        {
          var v = definition as declaration.variable_declaration;
          if (v == null) throw new analyser_error(this, "Identifier " + id.spelling + " does not refer to a variable");
        }
        else
        {
          var f = definition as declaration.function_declaration;
          if (f == null) throw new analyser_error(this, "Identifier " + id.spelling + " does not refer to a function");
          else
          {
            data.check_operation(this, f.name.spelling);
            parameter_list.Value.analyse(data);
            if (f.result_size == 0)
              throw new analyser_error(this, id.spelling +  " cannot been used in an expression");
            else if (parameter_list.Value.arguments.Count != f.parameters) 
              throw new analyser_error(this, "Function " + id.spelling +  " requires " + f.parameters + " argument(s)");
          }
        }
      }   
    }
    
    public partial class parameters: analysable
    {
      public void analyse(program_data data)
      {
        foreach (var e in arguments) e.analyse(data);
      }
    }
    
    public virtual void analyse(program_data data)
    {
    }
  }
}
