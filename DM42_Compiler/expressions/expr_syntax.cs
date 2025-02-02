using System.Collections.Generic;
using parsable_objects;

namespace DM42_Compiler
{   
  public partial class comparison: parsable
  {   
    public enum relation_op {equal, not_equal, less, less_than_equal, greater, greater_than_equal};
        
    [Parse(1)                                 ] public expr        operand_1;
    [Parse(2, "=", "!=", "<", "<=", ">", ">=")] public relation_op op;
    [Parse(3)                                 ] public expr        operand_2;
  }
  
  public partial class expr: parsable
  {
    [Parse(1)] public term        term;
    [Parse(2)] public List<terms> terms;
  }
  
  public enum unary_op {plus, minus, none};
  
  public partial class term: parsable
  {   
    [Parse(1, "+", "-", "")] public unary_op       unary;
    [Parse(2)              ] public factor         factor;
    [Parse(3)              ] public List<exponent> exponents;
    [Parse(4)              ] public List<factors>  factors;
  }
  
  public partial class terms: parsable
  { 
    public enum adding_op {plus, minus, or, xor}; 
    
    [Parse(1, "+", "-", "|", "xor")] public adding_op op;
    [Parse(3)                      ] public term      term;
  }
  
  public partial class factors: parsable
  {
    public enum product_op {times, divide, mod, and};
    
    [Parse(1, "*", "/", "%", "&")] public product_op     op;
    [Parse(2, "+", "-", "")      ] public unary_op       unary;
    [Parse(3)                    ] public factor         factor;
    [Parse(4)                    ] public List<exponent> exponents;
  }
  
  public partial class exponent: parsable
  {
    [Parse(1, "^")] public punctuation power_of;
    [Parse(2)     ] public factor      power;
  }
  
  public partial class factor: parsable
  { 
    public partial class integer_factor: factor
    {          
      [Parse(1)] public int value;
    }
    
    public partial class real_factor: factor
    {          
      [Parse(1)] public double value;
    }
    
    public partial class not_factor: factor
    {          
      [Parse(1, "!")] public punctuation not;
      [Parse(2)     ] public factor      expr;
    }
    
    public partial class recall_factor: factor
    {      
      [Parse(1, "recall")] public reserved_word recall;
      [Parse(2, "(")     ] public punctuation   open;
      [Parse(3)          ] public string        id;
      [Parse(4, ")")     ] public punctuation   close;
    }
    
    public partial class matrix_factor: factor
    {      
      [Parse(1, "matrix")] public reserved_word    matrix;
      [Parse(2, "(")     ] public punctuation      open;
      [Parse(7, ",")     ] public List<maxrix_row> rows;
      [Parse(8, ")")     ] public punctuation      close;
    }
    
    public partial class maxrix_row: parsable
    {      
      [Parse(1, "[")] public punctuation open;
      [Parse(2, ",")] public List<expr>  values;
      [Parse(3, "]")] public punctuation close;
    }
    
    public partial class external_factor: factor
    {
      [Parse(1, "external")] public reserved_word     external;
      [Parse(2, "(")       ] public punctuation       open;
      [Parse(3)            ] public string            name;
      [Parse(6, ")")       ] public punctuation       close;
      [Parse(7)            ] public factor.parameters parameter_list;
    }
    
    public partial class sub_expr_factor: factor
    {      
      [Parse(1, "(")] public punctuation open;
      [Parse(2)     ] public expr        expr;
      [Parse(3, ")")] public punctuation close;
    }
    
    public partial class id_factor: factor
    {      
      [Parse(1)] public identifier           id;
      [Parse(2)] public Optional<parameters> parameter_list;
    }
    
    public partial class parameters: parsable
    {
      [Parse(1, "(")]  public punctuation open;
      [Parse(2, ",")]  public List<expr>  arguments;
      [Parse(3, ")")]  public punctuation close;
    }
    
    public int position;

    public override void parsed(source_reader source)
    {
      position = source.position;
    }
  }
}
