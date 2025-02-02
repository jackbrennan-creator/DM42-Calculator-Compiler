namespace DM42_Compiler
{
  interface generable
  {
    void generate(program_data data);
  }
  
  partial class program: generable
  {    
    public void generate(program_data data)
    {
      data.init_stack();
      if (title.Length > program_data.register_name_limit)
        data.output.write_label(title.Substring(0, program_data.label_name_limit));
      else
        data.output.write_label(title);
      data.output.write_NSTK();
      data.write_prefix();
      if (data.request_parameters) data.write_parameter_input(parameter_list);
      else
      {
        parameter_list.Reverse();
        data.advance_stack(parameter_list.Count);
        foreach (var p in parameter_list) p.generate(data);
        data.reclaim_stack(parameter_list.Count);
      }
      definition.generate(data);
      data.write_postfix();
    }
  } 
  
  partial class declaration: generable
  {
    partial class function_declaration: generable
    {
      public override void generate(program_data data)
      {
        int skip_label = data.allocate_label();
        data.output.write_goto(skip_label);
        data.output.write_label(label);
        parameter_list.Reverse();
        foreach (var p in parameter_list) p.generate(data);
        definition.generate(data);
        data.output.write_label(skip_label);
      }
    }
    
    partial class variable_declaration: generable
    {
      public override void generate(program_data data)
      {
        value.generate(data);
        data.output.write_store(register);
        data.reclaim_stack(1);
      }
    }
    
    public virtual void generate(program_data data)
    {
    }
  }
    
  public partial class parameter_declaration: generable
  { 
    public void generate(program_data data)
    {
      data.output.write_store(register);
    }
  } 
}
