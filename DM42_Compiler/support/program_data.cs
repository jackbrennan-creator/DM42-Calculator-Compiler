using System;
using System.Collections.Generic;
using System.Linq;
using parsable_objects;

namespace DM42_Compiler
{
  using var_dec  = declaration.variable_declaration;
  using func_dec = declaration.function_declaration;
  
  public class program_data
  {
    public const int register_name_limit =  7;
    public const int label_name_limit    =  7;
    public const int alpha_limit         = 44;
    
    protected Dictionary<string, parsable> declarations;
    public    func_dec                     current_function  { get; private set; }
    protected func_dec                     previous_function;
    private   int                          next_register;
    private   int                          next_label;
    private   int                          variables;
    private   int                          functions;
    private   int                          predefined_variables;
    private   int                          temp_register;
    public    dm42_source_builder          output             { get; private set; }
    public    bool                         request_parameters { get; private set; }             
    public    bool                         named_registers    { get; private set; }           
    public    int                          register_base      { get; private set; }           
    public    bool                         check_stack        { get; private set; }
    private   int                          stack_size;
    private   int                          max_stack; 
    private   List<string>                 complex_ops;
    private   List<string>                 matrix_ops;          
    
    public program_data(int register_base, bool named_registers, bool request_parameters, bool check_stack)
    {
      this.register_base      = register_base;
      this.named_registers    = named_registers;
      this.request_parameters = request_parameters;
      this.check_stack = check_stack;
      declarations            = new Dictionary<string, parsable>();
      next_register           = register_base + predefined_variables;
      next_label              = 0;
      variables               = 0;
      functions               = 0;
      stack_size              = 0;
      max_stack               = 0;
      output                  = new dm42_source_builder(register_base,  named_registers);
      current_function        = null;
      previous_function       = null;
      complex_ops             = new List<string>(){"complex", "re",   "im"};
      matrix_ops              = new List<string>(){"matrix",  "determinant", "inverse", "transpose"};
      add_predefined_variables();
      add_predefined_functions();
    }
    
    public void write_prefix()
    {
    }
    
    public void write_parameter_input(List<parameter_declaration> parameter_list)
    {
      foreach (var p in parameter_list)
      {
        output.writeln("INPUT " + "\"" + p.name.spelling + "\"");
        output.writeln("SF 25");
        output.writeln("DROPN 2");
        output.writeln("RCL " + "\"" + p.name.spelling + "\"");
        output.writeln("STO " + output.register(p.register));
        output.writeln("DROP");
      }
    }
    
    public void write_postfix()
    {
      if (named_registers) for (int r = register_base; r < next_register; r = r + 1) output.write_clear_register(r);
    }
    
    public void add_variable(string name, var_dec v)
    {
      if (declarations.Keys.Contains(name)) throw new analyser_error(v, "Identifier " + name + " already declared");
      else 
      {
        declarations.Add(name, v); 
        variables  = variables + 1;
        v.register = allocate_register();
      }
    }
    
    public void add_parameter(string name, parameter_declaration p)
    {
      if (declarations.Keys.Contains(name)) throw new analyser_error(p, "Identifier " + name + " already declared");
      else 
      {
        var_dec v = make_variable(p.name.spelling, allocate_register()); 
        declarations.Add(name, v); 
        variables  = variables + 1;
        p.register = v.register;
      }
    }
    
    public var_dec add_loop_variable(statement s, string name)
    {
      if (declarations.Keys.Contains(name)) throw new analyser_error(s, "Identifier " + name + " already declared");
      else 
      {
        var_dec v = make_variable(name, allocate_register()); 
        declarations.Add(name, v); 
        variables  = variables + 1;
        return v;
      }
    }
    
    public void add_function(string name, func_dec f)
    {
      if (declarations.Keys.Contains(name)) throw new analyser_error(f, "Identifier " + name + " already declared");
      else 
      {
        declarations.Add(name, f); 
        functions    = functions + 1;
        f.label      = allocate_label();
      }
    }
    
    public void enter_function(func_dec f)
    {
      f.previous_scope    = declarations;
      f.previous_function = current_function;
      current_function    = f;
      declarations        = new Dictionary<string, parsable>();
      f.current_scope     = declarations;
    }
    
    public void exit_function(func_dec f)
    {
      declarations     = f.previous_scope;
      current_function = f.previous_function;
    }
    
    public void init_stack()
    {
      stack_size = 0;
    }
    
    public void advance_stack(int amount)
    {
      stack_size = stack_size + amount;
      max_stack  = Math.Max(max_stack, stack_size);
    }
    
    public void reclaim_stack(int amount)
    {
      stack_size = stack_size - amount;
      if (check_stack && stack_size < 0) throw new compiler_error("Stack underflow " + stack_size);
    }
    
    public void check_operation(parsable item, string op)
    {
      if      (complex_op(op) && !named_registers) throw new analyser_error(item, "The Named Registers option must be enabled to use " + op);
      else if (matrix_op(op)  && !named_registers) throw new analyser_error(item, "The Named Registers option must be enabled to use " + op);
    }
    
    public bool complex_op(string op)
    {
      return complex_ops.Contains(op);
    }
    
    public bool matrix_op(string op)
    {
      return matrix_ops.Contains(op);
    }
    
    public parsable get_declaration(string name)
    {
      declaration d = get_declaration(name, current_function, declarations) as declaration;
      return d;
    }
    
    public int get_register(var_dec v)
    {
      return v.register;//.ToString("00");
    }
    
    public string get_label(func_dec f)
    {
      if (f.label < 0) return ""; else return f.label.ToString("00");
    }
    
    public int allocate_label()
    {
      int l      = next_label;
      next_label = next_label + 1;
      return l;
    }
    
    public object get_statistic(string name)
    {
      switch (name)
      {
        case "min_register": return 0;
        case "max_register": if (next_register > 0) return next_register - 1; else return 0;
        case "min_label"   : return 0;
        case "max_label"   : if (next_label > 0) return (next_label - 1); else return 0;
        case "variables"   : return variables;
        case "functions"   : return functions;
        case "max_stack"   : return max_stack;
        default            : return null;
      }
    }
    
    public var_dec variable_from_register(int r)
    { 
      return variable_from_register(r, null);
    }
    
    public var_dec variable_from_register(int r, func_dec f)
    { 
      if (f == null) 
        return declarations.Values.FirstOrDefault((d) =>  (d is var_dec) && ((var_dec)d).register == r) as var_dec;
      else
      {
        var_dec local  = f.current_scope. Values.FirstOrDefault((d) =>  (d is var_dec) && ((var_dec)d).register == r) as var_dec;
        var_dec global = f.previous_scope.Values.FirstOrDefault((d) =>  (d is var_dec) && ((var_dec)d).register == r) as var_dec;
        if (global != null) return null; else return local;
      }
    }
    
    public func_dec function_from_label(int l)
    {
      return declarations.Values.FirstOrDefault((d) =>  (d is func_dec) && ((func_dec)d).label == l) as func_dec;
    }
    
    private void add_predefined_variables()
    {
      predefined_variables = 0;
      temp_register        = allocate_register();
    }
    
    private void add_predefined_functions()
    {
      read_predefined_functions("standard.ini");
    }
    
    private parsable get_declaration(string name, func_dec current_function, Dictionary<string, parsable> scope)
    {
      if      (scope.Keys.Contains(name)                                          ) return scope[name];
      else if (current_function != null && current_function.previous_scope != null) return get_declaration(name, current_function.previous_function, current_function.previous_scope) as declaration;
      else                                                                          return null;
    }
    
    private int allocate_register()
    {
      int r         = next_register;
      next_register = next_register + 1;
      return r;
    }
    
    private var_dec make_variable(string name, int register)
    {
      var v      = new var_dec();
      v.name     = new identifier(name);
      v.register = register;
      return v;
    }
    
    private void new_variable(string name, int register)
    {
      var v      = new var_dec();
      v.name     = new identifier(name);
      v.register = register;
      declarations.Add(name, v);
      predefined_variables = predefined_variables + 1;
    }
    
    private void new_function(string name, int parameters)
    {
      new_function(name, parameters, "", 1, 1);
    }
    
    private void new_function(string name, int parameters, string key)
    {
      new_function(name, parameters, key, 1, 1);
    }
    
    private void new_function(string name, int parameters, string key, int result_size, int drop_size)
    {
      new_function(name, parameters, key, result_size, drop_size, 0);
    }
    
    private void new_function(string name, int parameters, string key, int result_size, int drop_size, int work_size)
    {
      var f         = new func_dec();
      f.name        = new identifier(name);
      f.parameters  = parameters;
      f.key         = key;
      f.label       = -1;
      f.result_size = result_size;
      f.drop_size   = drop_size;
      f.work_size   = work_size;
      declarations.Add(name, f);
    }
    
    private void read_predefined_functions(string path)
    {
      try
      {
        using (System.IO.StreamReader f = new System.IO.StreamReader(path))
        {
          string line = f.ReadLine();
          if (line != null) line = f.ReadLine();
          while (line != null)
          {
            line = line.Trim();
            if (line.Length > 0) create_definition(line);
            line = f.ReadLine();
          }
          f.Close();
        }
      }
      catch (Exception ex)
      {
        throw new compiler_error("Error reading function definitions file." + Environment.NewLine + Environment.NewLine + ex.Message);
      }
    }
    
    private void create_definition(string line)
    {
      string[] args = line.Split(',');
      string function_name = "";
      int    parameters    = 0;
      string keys          = "";
      int    result_size   = args.Length <= 2 ? 1 : 0;
      int    drop_size     = args.Length <= 2 ? 1 : 0;
      int    work_size     = 0;
      for (int i = 0; i < args.Length; i = i + 1)
        switch (i)
        {
          case 0: function_name = args[i].Trim();                                   break;
          case 1: parameters    = int.Parse(args[i].Trim());                        break;
          case 2: keys          = args[i].Trim().Replace("|", Environment.NewLine); break;
          case 3: result_size   = int.Parse(args[i].Trim());                        break;
          case 4: drop_size     = int.Parse(args[i].Trim());                        break;
          case 5: work_size     = int.Parse(args[i].Trim());                        break;
        }
      if (keys == "") keys = function_name.ToUpper();
      new_function(function_name, parameters, keys, result_size, drop_size, work_size);
    }
  }
}
