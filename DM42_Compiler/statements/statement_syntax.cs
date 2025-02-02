using System.Collections.Generic;
using parsable_objects;

namespace DM42_Compiler
{  
  public partial class statement: parsable
  {
    public partial class skip_statement: statement
    {
      [Parse(1, "skip")] public reserved_word skip;
      [Parse(2, ";")   ] public punctuation   semi_colon;
    }
    
    public partial class stop_statement: statement
    {
      [Parse(1, "stop")] public reserved_word stop;
      [Parse(2, ";")   ] public punctuation   semi_colon;
    }
    
    public partial class prompt_statement: statement
    {
      [Parse(1, "prompt")] public reserved_word store;
      [Parse(2, "(")     ] public punctuation   open;
      [Parse(3)          ] public string        caption;
      [Parse(4, ")")     ] public punctuation   close;
      [Parse(5, ";")     ] public punctuation   semi_colon;
    }
    
    public partial class store_statement: statement
    {
      [Parse(1, "store")] public reserved_word store;
      [Parse(2, "(")    ] public punctuation   open;
      [Parse(3)         ] public expr          value;
      [Parse(4, ",")    ] public punctuation   comma;
      [Parse(5)         ] public string        id;
      [Parse(6, ")")    ] public punctuation   close;
      [Parse(7, ";")    ] public punctuation   semi_colon;
    }
    
    public partial class input_statement: statement
    {
      [Parse(1, "input")] public reserved_word view;
      [Parse(2, "(")    ] public punctuation   open;
      [Parse(3)         ] public identifier    variable;
      [Parse(4, ")")    ] public punctuation   close;
      [Parse(5, ";")    ] public punctuation   semi_colon;
    }
    
    public partial class view_statement: statement
    {
      [Parse(1, "view")] public reserved_word view;
      [Parse(2, "(")   ] public punctuation   open;
      [Parse(3)        ] public identifier    variable;
      [Parse(4, ")")   ] public punctuation   close;
      [Parse(5, ";")   ] public punctuation   semi_colon;
    }
    
    public partial class external_statement: statement
    {
      [Parse(1, "external")] public reserved_word     external;
      [Parse(2, "(")       ] public punctuation       open;
      [Parse(3)            ] public string            name;
      [Parse(6, ")")       ] public punctuation       close;
      [Parse(7)            ] public factor.parameters parameter_list;
      [Parse(8, ";")       ] public punctuation       semi_colon;
    }
    
    public partial class id_statement: statement
    {
      [Parse(1)      ] public identifier         target;
      [Parse(2)      ] public assignment_or_call operation;
      [Parse(4, ";") ] public punctuation        semi_colon;
    }
    
    public partial class for_statement: statement
    {
      [Parse(1, "for")] public reserved_word      for_word;
      [Parse(2)       ] public identifier         id;
      [Parse(3, "=")  ] public punctuation        equals;
      [Parse(4)       ] public expr               initial;
      [Parse(5, "to") ] public reserved_word      to_word;
      [Parse(6)       ] public expr               final;
      [Parse(7)       ] public Optional<for_step> step;
      [Parse(8, "do") ] public reserved_word      do_word;
      [Parse(9)       ] public statement          controlled_statement;
    }
    
    public partial class for_step: parsable
    {
      [Parse(1, "step")] public reserved_word step_word;
      [Parse(2)        ] public expr          amount;
    }
    
    public partial class while_statement: statement
    {
      [Parse(1, "while")] public reserved_word while_word;
      [Parse(2, "(")    ] public punctuation   open;
      [Parse(3)         ] public comparison    condition;
      [Parse(4, ")")    ] public punctuation   close;
      [Parse(5)         ] public statement     controlled_statement;
    }
    
    public partial class if_statement: statement
    {
      [Parse(1, "if")] public reserved_word            if_word;
      [Parse(2, "(") ] public punctuation              open;
      [Parse(3)      ] public comparison               condition;
      [Parse(4, ")") ] public punctuation              close;
      [Parse(5)      ] public statement                then_part;
      [Parse(6)      ] public Optional<else_statement> else_part;
    }
    
    public partial class else_statement: parsable
    {
      [Parse(1, "else")] public reserved_word else_word;
      [Parse(2)        ] public statement     else_part;
    }
    
    public partial class block_statement: statement
    {
      [Parse(1)] public block block;
    }
    
    public partial class return_statement: statement
    {
      [Parse(1, "return")] public reserved_word return_word;
      [Parse(2)          ] public expr          value;
      [Parse(3, ";")     ] public punctuation   semi_colon;
    }
    
    public int position;
    
    public override void  parsed(source_reader source)
    {
      position = source.position;
    }
  }
  
  public partial class block: parsable
  {
    [Parse(1, "{")] public punctuation       open;
    [Parse(2 )    ] public List<declaration> declarations;
    [Parse(3)     ] public List<statement>   statement;
    [Parse(4, "}")] public punctuation       close;
  }
    
  public partial class assignment_or_call: parsable
  {
    public partial class assignment: assignment_or_call
    {
      [Parse(1, "=")] public punctuation becomes;
      [Parse(2)     ] public expr        value;
    }
    
    public partial class call: assignment_or_call
    {
      [Parse(1)] public factor.parameters parameters;
    }
  }
}
