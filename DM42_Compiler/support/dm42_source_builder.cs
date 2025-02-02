using System;
using parsable_objects;

namespace DM42_Compiler
{
  public class dm42_source_builder: source_builder
  {
    public int  register_base;
    public bool named_registers;
    
    public dm42_source_builder(int register_base, bool named_registers): base() 
    {
      this.register_base   = register_base;
      this.named_registers = named_registers;
      named_registers = true;
    }
    
    public string register(int r)
    {
      if (named_registers) return "\"" + r.ToString("00") + "\""; else return r.ToString("00");
    }
    
    public void writeln(string s)
    {
      write(s); new_line();
    }
    
    public void write_number(int n)
    {
      write(n); new_line();
    }
    
    public void write_number(double n)
    {
      write(n); new_line();
    }
    
    public void write_begin_matrix(int rows, int columns)
    {
      write_number(rows   );
      write_number(columns);
      writeln("NEWMAT");
      writeln("EDIT");
    }
    
    public void write_next_row()
    {
      writeln("->");
    }
    
    public void write_end_matrix()
    {
      writeln("EXITALL");
    }
    
    public void write_swap_xy()
    {
      writeln("X<>Y");
    }
    
    public void write_rotate_down()
    {
      writeln("Rv");
    }
    
    public void write_NSTK()
    {
      writeln("NSTK");
    }
    
    public void write_drop()
    {
      writeln("DROP");
    }
    
    public void write_drop(int n)
    {
      if (n > 0) writeln("DROPN " + n);
    }
    
    public void write_negate()
    {
      writeln("+/-");
    }
    
    public void write_plus()
    {
      writeln("+");
    }
    
    public void write_minus()
    {
      writeln("-");
    }
    
    public void write_times()
    {
      writeln("*");
    }
    
    public void write_divide()
    {
      writeln("/");
    }
    
    public void write_mod()
    {
      writeln("MOD");
    }
    
    public void write_to_power()
    {
      writeln("Y^X");
    }
    
    public void write_and()
    {
      writeln("AND");
    }
    
    public void write_or()
    {
      writeln("OR");
    }
    
    public void write_xor()
    {
      writeln("XOR");
    }
    
    public void write_not()
    {
      writeln("NOT");
    }
    
    public void write_label(string name)
    {
      writeln("LBL \"" + name + "\"");
    }
    
    public void write_label(int number)
    {
      writeln("LBL " + number.ToString("00") + "");
    }
    
    public void write_store(int number, bool no_drop)
    {
      writeln("STO " + register(number));
      if (!no_drop) write_drop();
    }
    
    public void write_store(int number)
    {
      writeln("STO " + register(number));
      write_drop();
    }
    
    public void write_store_named_register(string name)
    {
      writeln("STO \"" + name + "\"");
      write_drop();
    }
    
    public void write_store_ignore_error(int number)
    {
      writeln("SF 25");
      writeln("STO " + register(number));
      writeln("SF 25");
      write_drop();
    }
    
    public void write_recall(int number)
    {
      writeln("RCL " + register(number));
    }
    
    public void write_recall_named_register(string name)
    {
      writeln("RCL \"" + name + "\"");
    }
    
    public void write_clear_register(int number)
    {
      writeln("CLV " + register(number));
    }
    
    public void write_prompt(string caption)
    {
      writeln("\"" + caption + "\"");
      writeln("PROMPT");
    }
    
    public void write_input(int number)
    {
      writeln("INPUT " + register(number));
      write_drop();
      writeln("SF 25");
      write_drop();
    }
    
    public void write_view(int number)
    {
      writeln("VIEW " + register(number));
    }
    
    public void write_call(int label)
    {
      writeln("XEQ " + label.ToString("00"));
    }
    
    public void write_external_call(string label)
    {
      writeln("XEQ \"" + label + "\"");
    }
    
    public void write_predefined_call(declaration.function_declaration f)
    {
      if (f.key == "") writeln(f.name.spelling.ToUpper()); else writeln(f.key);
    }
    
    public void write_return()
    {
      writeln("RTN");
    }
    
    public void write_stop()
    {
      writeln("STOP");
    }
    
    public void write_goto(int label)
    {
      writeln("GTO " + label.ToString("00") + "");
    }
    
    public void write_relation(comparison.relation_op op)
    {
      switch (op)
      {
        case comparison.relation_op.equal:              writeln("X=Y?" ); break;
        case comparison.relation_op.not_equal:          writeln("X#Y?" ); break;
        case comparison.relation_op.less:               writeln("X<Y?" ); break;
        case comparison.relation_op.greater:            writeln("X>Y?" ); break;
        case comparison.relation_op.less_than_equal:    writeln("X<=Y?"); break;
        case comparison.relation_op.greater_than_equal: writeln("X>=Y?"); break;
      }
    }
    
    public void write_inverse_relation(comparison.relation_op op)
    {
      switch (op)
      {
        case comparison.relation_op.equal:              writeln("X#Y?" ); break;
        case comparison.relation_op.not_equal:          writeln("X=Y?" ); break;
        case comparison.relation_op.less:               writeln("X>=Y?"); break;
        case comparison.relation_op.greater:            writeln("X<=Y?"); break;
        case comparison.relation_op.less_than_equal:    writeln("X>Y?" ); break;
        case comparison.relation_op.greater_than_equal: writeln("X<Y?" ); break;
      }
    }
    
    public void write_comparison(comparison.relation_op op)
    {
      switch (op)
      {
        case comparison.relation_op.equal:              writeln("X=0?" ); break;
        case comparison.relation_op.not_equal:          writeln("X#0?" ); break;
        case comparison.relation_op.less:               writeln("X<0?" ); break;
        case comparison.relation_op.greater:            writeln("X>0?" ); break;
        case comparison.relation_op.less_than_equal:    writeln("X<=0?"); break;
        case comparison.relation_op.greater_than_equal: writeln("X>=0?"); break;
      }
    }
    
    public void write_inverse_comparison(comparison.relation_op op)
    {
      switch (op)
      {
        case comparison.relation_op.equal:              writeln("X#0?" ); break;
        case comparison.relation_op.not_equal:          writeln("X=0?" ); break;
        case comparison.relation_op.less:               writeln("X>=0?"); break;
        case comparison.relation_op.greater:            writeln("X<=0?"); break;
        case comparison.relation_op.less_than_equal:    writeln("X>0?" ); break;
        case comparison.relation_op.greater_than_equal: writeln("X<0?" ); break;
      }
    }
  }
}
