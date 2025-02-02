using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using parsable_objects;

namespace DM42_Compiler
{
  public partial class compiler_form : Form
  {
    private string current_file;
    private string current_title;
    private string output_file;
    private bool   source_changed;
    
    public compiler_form()
    {
      InitializeComponent();
      this.CenterToScreen();
      current_file   = "";
      current_title  = "";
      output_file    = "";
      source_changed = false;
      configure_ui();
      load_settings();
    }

    private void load_settings()
    {
      register_base_box.Value        = Properties.Settings.Default.register_base;
      named_registers_box.Checked    = Properties.Settings.Default.named_registers;
      request_parameters_box.Checked = Properties.Settings.Default.request_parameters;
      stack_undeflow_box.Checked     = Properties.Settings.Default.check_stack;
    }

    private void save_settings()
    {
      Properties.Settings.Default.register_base      = (int)register_base_box.Value;
      Properties.Settings.Default.named_registers    = named_registers_box.Checked;
      Properties.Settings.Default.request_parameters = request_parameters_box.Checked;
      Properties.Settings.Default.check_stack        = stack_undeflow_box.Checked;
      Properties.Settings.Default.Save();
    }

    private void compile_button_Click(object sender, EventArgs e)
    {
      var source = new source_reader(source_box.Text); source.set_comment_ch('@');
      try
      {
        parse_analyse_and_compile(source);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Program Error");
      }
      configure_ui();
    }

    private void parse_analyse_and_compile(source_reader source)
    {
      try
      {
        var p = parsable.parse<program>(source);
        if (p != null)
        {
          show_grammar();
          var data = new program_data((int)register_base_box.Value, named_registers_box.Checked, request_parameters_box.Checked, stack_undeflow_box.Checked);
          if (analyse(p, data)) generate(p, data);
        }        
      }
      catch (parsable_objects.parse_error ex)
      {
        MessageBox.Show(ex.Message, "Syntax Error");
        source_box.SelectionStart  = source.position;
        source_box.SelectionLength = 1;
        source_box.Focus();
      }
    }

    private bool analyse(program p, program_data data)
    {
      bool ok = true;
      try
      {
        p.analyse(data);
        current_title = p.title;
      }
      catch (analyser_error ex)
      {
        MessageBox.Show(ex.Message, "Semantic Error");
        if (ex.element is statement)
        {
          statement s = ex.element as statement;
          source_box.SelectionStart  = s.position;
        }
        else if (ex.element is declaration)
        {
          declaration d = ex.element as declaration;
          source_box.SelectionStart  = d.position;
        }
        else if (ex.element is factor)
        {
          factor f = ex.element as factor;
          source_box.SelectionStart  = f.position;
        }
        else source_box.SelectionStart = 0;
        source_box.SelectionLength = 1;
        source_box.Focus();
        ok = false;
      }
      return ok;
    }

    private bool generate(program p, program_data data)
    {
      bool ok = true;
      try
      {
        p.generate(data);
        show_output(data);
        show_program_information(data);
        output_tabs.SelectedTab = output_page;
      }
      catch (compiler_error ex)
      {
        MessageBox.Show(ex.Message, "Compile Error");
        ok = false;
      }
      return ok;
    }

    private void show_grammar()
    {
      source_builder grammar = new source_builder();
      parsable.unparse_grammar(grammar);
      grammar_box.Text = grammar.ToString();
      grammar_box.SelectionLength = 0;
      grammar_box.SelectionStart = 0;
    }

    private void show_output(program_data data)
    {
      output_box.Text = data.output.ToString();
      output_box.SelectionLength = 0;
      output_box.SelectionStart = 0;
    }
    
    private void show_program_information(program_data data)
    {
      int min_register = (int)data.get_statistic("min_register");
      int max_register = (int)data.get_statistic("max_register");
      int min_label    = (int)data.get_statistic("min_label"   );
      int max_label    = (int)data.get_statistic("max_label"   );
      information_box.Clear();
      append_info("functions   : " + data.get_statistic("functions"),  0);
      append_info("variables   : " + data.get_statistic("variables"),  0);
      append_info("instructions: " + output_box.Lines.Length,          0);
      append_info("min_register: " + min_register,                     0);
      append_info("max_register: " + max_register,                     0);
      append_info("min_label   : " + min_label,                        0);
      append_info("max_label   : " + max_label,                        0);
      append_info("max_stack   : " + data.get_statistic("max_stack" ), 0);
      show_variable_info(data, min_register, max_register, null, 0);
      show_function_info(data, min_label,    max_label, min_register, max_register, 0);
    }

    private void show_variable_info(program_data data, int min_register, int max_register, declaration.function_declaration f, int indent)
    {
      if (indent == 0)
      {
        append_info("",          indent);
        append_info("variables", indent);
        append_info("---------", indent);
      }
      for (int r = min_register; r <= max_register; r = r + 1)
      {
        declaration.variable_declaration v = data.variable_from_register(r, f);
        if (v != null) append_info(v.name.spelling.PadRight(10) + " -> " + "register " + r.ToString("00"), indent);
      }
    }

    private void show_function_info(program_data data, int min_label, int max_label, int min_register, int max_register, int indent)
    {
      append_info("",          indent);
      append_info("functions", indent);
      append_info("---------", indent);
      for (int l = min_label; l <= max_label; l = l + 1)
      {
        declaration.function_declaration f = data.function_from_label(l);
        if (f != null) 
        {
          append_info(f.name.spelling.PadRight(10) + "label " + " -> " + l.ToString("00"), indent);
          show_variable_info(data, min_register, max_register, f, 1);
        }
      }
    }
    
    private void append_info(string line, int indent)
    {
      information_box.AppendText("".PadLeft(2 * indent) + line + Environment.NewLine);
    }
    
    private void copy_button_Click(object sender, EventArgs e)
    {
      string text = "";
      if      (output_tabs.SelectedTab == output_page ) text = output_box.Text;
      else if (output_tabs.SelectedTab == info_page   ) text = information_box.Text;
      else if (output_tabs.SelectedTab == grammar_page) text = grammar_box.Text;
      if (text != "") Clipboard.SetText(text);
    }

    private void clear_button_Click(object sender, EventArgs e)
    {
      if (source_box.Text.Trim() == "" || MessageBox.Show("Clear Source?", "DM42 Compiler", MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        source_box.Clear();
        output_box.Clear();
        information_box.Clear();
        source_changed = false;
        current_file   = "";
        current_title  = "";
        output_file    = "";
        configure_ui();
      }
    }

    private void source_box_TextChanged(object sender, EventArgs e)
    {
      source_changed = true;
      configure_ui();
    }

    private void configure_ui()
    {
      if (current_file == "") this.Text = "DM42 Compiler"; 
      else this.Text = "DM42 Compiler - " + Path.GetFileNameWithoutExtension(current_file);
      clear_button.Enabled       = source_box.Text != "";
      save_button.Enabled        = source_box.Text != "" && source_changed;// && current_title != "";
      save_as_button.Enabled     = source_box.Text != "";
      compile_button.Enabled     = source_box.Text != "";
      save_output_button.Enabled = output_box.Text != "" && current_title != "";
    }

    private void open_button_Click(object sender, EventArgs e)
    {
      bool do_open = true;
      if (source_box.Text.Trim() != "" && source_changed)
        do_open = MessageBox.Show("Disgard Existing Source?", "DM42 Compiler", MessageBoxButtons.OKCancel) == DialogResult.OK;
      if (do_open)
      {
        output_box.Clear();
        information_box.Clear();
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Title          = "Save DM42 Program";
        dialog.Filter         = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        if (current_file != "")
        {
          dialog.FileName         = Path.GetFileName(current_file);
          dialog.InitialDirectory = Path.GetDirectoryName(current_file);
        }
        if (dialog.ShowDialog() == DialogResult.OK) 
        {
          current_file  = dialog.FileName;
          read_file(dialog);
          current_title  = "";
          output_file    = "";
          source_changed = false;
        }
      }
      configure_ui();
    }

    private void save_button_Click(object sender, EventArgs e)
    {
      if (current_file == "")
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Title          = "Save DM42 Program";
        dialog.Filter         = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        dialog.FileName       = Path.GetFileName(current_title + ".txt");
        if (dialog.ShowDialog() == DialogResult.OK) current_file = dialog.FileName;
      }
      save_file(current_file, source_box.Text);
      configure_ui();
    }

    private void save_as_button_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.Title          = "Save DM42 Program As";
      dialog.Filter         = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
      if (current_file != "")
      {
        dialog.FileName         = Path.GetFileName(current_file);
        dialog.InitialDirectory = Path.GetDirectoryName(current_file);
      }
      if (dialog.ShowDialog() == DialogResult.OK) 
      {
        current_file = dialog.FileName;
        save_file(current_file, source_box.Text);
      }
      configure_ui();
    }

    private void read_file(OpenFileDialog dialog)
    {
      if (current_file != "")
        try
        {
          using (StreamReader f = new StreamReader(current_file))
          {
            source_box.Text = f.ReadToEnd();
            current_file = dialog.FileName;
            f.Close();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Unable to read file" + Environment.NewLine + Environment.NewLine + ex.Message, "Open File");
        }
    }

    private void save_output_button_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.Title          = "Save DM42 Output As";
      dialog.Filter         = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
      if (output_file != "")
      {
        dialog.FileName         = Path.GetFileName(output_file);
        dialog.InitialDirectory = Path.GetDirectoryName(output_file);
      }
      else dialog.FileName = current_title + "(out)";
      if (dialog.ShowDialog() == DialogResult.OK) 
      {
        output_file = dialog.FileName;
        save_file(output_file, output_box.Text);
      }
      configure_ui();
    }

    private void compiler_form_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (source_box.Text.Trim() != "" && source_changed)
        switch (MessageBox.Show("Save Changes?", "DM42 Compiler", MessageBoxButtons.YesNoCancel))
        {
          case DialogResult.Yes   : 
            if (current_file != "")
              save_button.PerformClick(); 
            else
              save_as_button.PerformClick();
            e.Cancel = source_changed;
            break;
          case DialogResult.No    : e.Cancel = false;           break;
          case DialogResult.Cancel: e.Cancel = true;            break;
          default                 : e.Cancel = false;           break;
        }
      if (!e.Cancel) save_settings();
    }

    private void save_file(string file_path, string contents)
    {
      if (file_path != "")
        try
        {
          using (StreamWriter f = new StreamWriter(file_path))
          {
            f.Write(contents);
            f.Close();
            if (file_path == current_file) source_changed = false;
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Unable to save file" + Environment.NewLine + Environment.NewLine + ex.Message, "Save File");
        }
    }

    private void output_tabs_SelectedIndexChanged(object sender, EventArgs e)
    {
      copy_button.Enabled = output_tabs.SelectedTab == output_page
                            |
                            output_tabs.SelectedTab == info_page
                            |
                            output_tabs.SelectedTab == grammar_page;

    }
  }
}
