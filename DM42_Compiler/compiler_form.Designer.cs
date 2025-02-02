namespace DM42_Compiler
{
  partial class compiler_form
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(compiler_form));
      this.panel1 = new System.Windows.Forms.Panel();
      this.save_output_button = new System.Windows.Forms.Button();
      this.save_as_button = new System.Windows.Forms.Button();
      this.save_button = new System.Windows.Forms.Button();
      this.open_button = new System.Windows.Forms.Button();
      this.compile_button = new System.Windows.Forms.Button();
      this.source_box = new System.Windows.Forms.TextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.clear_button = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.copy_button = new System.Windows.Forms.Button();
      this.output_tabs = new System.Windows.Forms.TabControl();
      this.output_page = new System.Windows.Forms.TabPage();
      this.output_box = new System.Windows.Forms.TextBox();
      this.info_page = new System.Windows.Forms.TabPage();
      this.information_box = new System.Windows.Forms.TextBox();
      this.grammar_page = new System.Windows.Forms.TabPage();
      this.grammar_box = new System.Windows.Forms.TextBox();
      this.options_page = new System.Windows.Forms.TabPage();
      this.panel5 = new System.Windows.Forms.Panel();
      this.panel7 = new System.Windows.Forms.Panel();
      this.request_parameters_box = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.panel6 = new System.Windows.Forms.Panel();
      this.named_registers_box = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.TextBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.TextBox();
      this.register_base_box = new System.Windows.Forms.NumericUpDown();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.panel8 = new System.Windows.Forms.Panel();
      this.stack_undeflow_box = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.output_tabs.SuspendLayout();
      this.output_page.SuspendLayout();
      this.info_page.SuspendLayout();
      this.grammar_page.SuspendLayout();
      this.options_page.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.register_base_box)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel8.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel1.Controls.Add(this.save_output_button);
      this.panel1.Controls.Add(this.save_as_button);
      this.panel1.Controls.Add(this.save_button);
      this.panel1.Controls.Add(this.open_button);
      this.panel1.Controls.Add(this.compile_button);
      this.panel1.Location = new System.Drawing.Point(12, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(107, 597);
      this.panel1.TabIndex = 0;
      // 
      // save_output_button
      // 
      this.save_output_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.save_output_button.Location = new System.Drawing.Point(8, 133);
      this.save_output_button.Name = "save_output_button";
      this.save_output_button.Size = new System.Drawing.Size(91, 23);
      this.save_output_button.TabIndex = 5;
      this.save_output_button.Text = "Save Output...";
      this.save_output_button.UseVisualStyleBackColor = false;
      this.save_output_button.Click += new System.EventHandler(this.save_output_button_Click);
      // 
      // save_as_button
      // 
      this.save_as_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.save_as_button.Location = new System.Drawing.Point(8, 62);
      this.save_as_button.Name = "save_as_button";
      this.save_as_button.Size = new System.Drawing.Size(91, 23);
      this.save_as_button.TabIndex = 4;
      this.save_as_button.Text = "Save As...";
      this.save_as_button.UseVisualStyleBackColor = false;
      this.save_as_button.Click += new System.EventHandler(this.save_as_button_Click);
      // 
      // save_button
      // 
      this.save_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.save_button.Location = new System.Drawing.Point(8, 33);
      this.save_button.Name = "save_button";
      this.save_button.Size = new System.Drawing.Size(91, 23);
      this.save_button.TabIndex = 3;
      this.save_button.Text = "Save";
      this.save_button.UseVisualStyleBackColor = false;
      this.save_button.Click += new System.EventHandler(this.save_button_Click);
      // 
      // open_button
      // 
      this.open_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.open_button.Location = new System.Drawing.Point(8, 6);
      this.open_button.Name = "open_button";
      this.open_button.Size = new System.Drawing.Size(91, 23);
      this.open_button.TabIndex = 2;
      this.open_button.Text = "Open";
      this.open_button.UseVisualStyleBackColor = false;
      this.open_button.Click += new System.EventHandler(this.open_button_Click);
      // 
      // compile_button
      // 
      this.compile_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.compile_button.Location = new System.Drawing.Point(8, 104);
      this.compile_button.Name = "compile_button";
      this.compile_button.Size = new System.Drawing.Size(91, 23);
      this.compile_button.TabIndex = 1;
      this.compile_button.Text = "Compile";
      this.compile_button.UseVisualStyleBackColor = false;
      this.compile_button.Click += new System.EventHandler(this.compile_button_Click);
      // 
      // source_box
      // 
      this.source_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.source_box.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.source_box.Location = new System.Drawing.Point(3, 48);
      this.source_box.Multiline = true;
      this.source_box.Name = "source_box";
      this.source_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.source_box.Size = new System.Drawing.Size(409, 555);
      this.source_box.TabIndex = 1;
      this.source_box.WordWrap = false;
      this.source_box.TextChanged += new System.EventHandler(this.source_box_TextChanged);
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel2.Controls.Add(this.clear_button);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Location = new System.Drawing.Point(3, 6);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(409, 36);
      this.panel2.TabIndex = 2;
      // 
      // clear_button
      // 
      this.clear_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clear_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.clear_button.Location = new System.Drawing.Point(312, 6);
      this.clear_button.Name = "clear_button";
      this.clear_button.Size = new System.Drawing.Size(83, 23);
      this.clear_button.TabIndex = 3;
      this.clear_button.Text = "Clear";
      this.clear_button.UseVisualStyleBackColor = false;
      this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Source";
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel3.Controls.Add(this.copy_button);
      this.panel3.Controls.Add(this.output_tabs);
      this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.panel3.Location = new System.Drawing.Point(3, 6);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(425, 597);
      this.panel3.TabIndex = 3;
      // 
      // copy_button
      // 
      this.copy_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
      this.copy_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.copy_button.Location = new System.Drawing.Point(5, 6);
      this.copy_button.Name = "copy_button";
      this.copy_button.Size = new System.Drawing.Size(111, 23);
      this.copy_button.TabIndex = 4;
      this.copy_button.Text = "Copy to clipboard";
      this.copy_button.UseVisualStyleBackColor = false;
      this.copy_button.Click += new System.EventHandler(this.copy_button_Click);
      // 
      // output_tabs
      // 
      this.output_tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.output_tabs.Controls.Add(this.output_page);
      this.output_tabs.Controls.Add(this.info_page);
      this.output_tabs.Controls.Add(this.grammar_page);
      this.output_tabs.Controls.Add(this.options_page);
      this.output_tabs.Location = new System.Drawing.Point(3, 33);
      this.output_tabs.Name = "output_tabs";
      this.output_tabs.Padding = new System.Drawing.Point(16, 3);
      this.output_tabs.SelectedIndex = 0;
      this.output_tabs.Size = new System.Drawing.Size(419, 561);
      this.output_tabs.TabIndex = 7;
      this.output_tabs.SelectedIndexChanged += new System.EventHandler(this.output_tabs_SelectedIndexChanged);
      // 
      // output_page
      // 
      this.output_page.BackColor = System.Drawing.Color.Transparent;
      this.output_page.Controls.Add(this.output_box);
      this.output_page.ForeColor = System.Drawing.SystemColors.ControlText;
      this.output_page.Location = new System.Drawing.Point(4, 22);
      this.output_page.Name = "output_page";
      this.output_page.Padding = new System.Windows.Forms.Padding(3);
      this.output_page.Size = new System.Drawing.Size(411, 533);
      this.output_page.TabIndex = 0;
      this.output_page.Text = "Output";
      this.output_page.UseVisualStyleBackColor = true;
      // 
      // output_box
      // 
      this.output_box.BackColor = System.Drawing.SystemColors.Window;
      this.output_box.Dock = System.Windows.Forms.DockStyle.Fill;
      this.output_box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.output_box.Location = new System.Drawing.Point(3, 3);
      this.output_box.Multiline = true;
      this.output_box.Name = "output_box";
      this.output_box.ReadOnly = true;
      this.output_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.output_box.Size = new System.Drawing.Size(405, 527);
      this.output_box.TabIndex = 6;
      this.output_box.WordWrap = false;
      // 
      // info_page
      // 
      this.info_page.Controls.Add(this.information_box);
      this.info_page.Location = new System.Drawing.Point(4, 22);
      this.info_page.Name = "info_page";
      this.info_page.Size = new System.Drawing.Size(411, 533);
      this.info_page.TabIndex = 2;
      this.info_page.Text = "Program Information";
      this.info_page.UseVisualStyleBackColor = true;
      // 
      // information_box
      // 
      this.information_box.BackColor = System.Drawing.SystemColors.Window;
      this.information_box.Dock = System.Windows.Forms.DockStyle.Fill;
      this.information_box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.information_box.Location = new System.Drawing.Point(0, 0);
      this.information_box.Multiline = true;
      this.information_box.Name = "information_box";
      this.information_box.ReadOnly = true;
      this.information_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.information_box.Size = new System.Drawing.Size(411, 533);
      this.information_box.TabIndex = 7;
      this.information_box.WordWrap = false;
      // 
      // grammar_page
      // 
      this.grammar_page.Controls.Add(this.grammar_box);
      this.grammar_page.Location = new System.Drawing.Point(4, 22);
      this.grammar_page.Name = "grammar_page";
      this.grammar_page.Padding = new System.Windows.Forms.Padding(3);
      this.grammar_page.Size = new System.Drawing.Size(411, 533);
      this.grammar_page.TabIndex = 1;
      this.grammar_page.Text = "Grammar";
      this.grammar_page.UseVisualStyleBackColor = true;
      // 
      // grammar_box
      // 
      this.grammar_box.BackColor = System.Drawing.SystemColors.Window;
      this.grammar_box.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grammar_box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.grammar_box.Location = new System.Drawing.Point(3, 3);
      this.grammar_box.Multiline = true;
      this.grammar_box.Name = "grammar_box";
      this.grammar_box.ReadOnly = true;
      this.grammar_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.grammar_box.Size = new System.Drawing.Size(405, 527);
      this.grammar_box.TabIndex = 4;
      this.grammar_box.WordWrap = false;
      // 
      // options_page
      // 
      this.options_page.BackColor = System.Drawing.Color.LightSteelBlue;
      this.options_page.Controls.Add(this.panel5);
      this.options_page.Location = new System.Drawing.Point(4, 22);
      this.options_page.Name = "options_page";
      this.options_page.Padding = new System.Windows.Forms.Padding(3);
      this.options_page.Size = new System.Drawing.Size(411, 535);
      this.options_page.TabIndex = 3;
      this.options_page.Text = "Options";
      this.options_page.UseVisualStyleBackColor = true;
      // 
      // panel5
      // 
      this.panel5.BackColor = System.Drawing.Color.DarkGray;
      this.panel5.Controls.Add(this.panel8);
      this.panel5.Controls.Add(this.panel7);
      this.panel5.Controls.Add(this.panel6);
      this.panel5.Controls.Add(this.panel4);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel5.Location = new System.Drawing.Point(3, 3);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(405, 529);
      this.panel5.TabIndex = 4;
      // 
      // panel7
      // 
      this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel7.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel7.Controls.Add(this.request_parameters_box);
      this.panel7.Controls.Add(this.label6);
      this.panel7.Controls.Add(this.textBox1);
      this.panel7.Location = new System.Drawing.Point(9, 272);
      this.panel7.Name = "panel7";
      this.panel7.Size = new System.Drawing.Size(384, 134);
      this.panel7.TabIndex = 6;
      // 
      // request_parameters_box
      // 
      this.request_parameters_box.AutoSize = true;
      this.request_parameters_box.Location = new System.Drawing.Point(11, 11);
      this.request_parameters_box.Name = "request_parameters_box";
      this.request_parameters_box.Size = new System.Drawing.Size(15, 14);
      this.request_parameters_box.TabIndex = 5;
      this.request_parameters_box.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(30, 12);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(121, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Request Parameters";
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.BackColor = System.Drawing.SystemColors.Window;
      this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(6, 35);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(362, 86);
      this.textBox1.TabIndex = 2;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // panel6
      // 
      this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel6.Controls.Add(this.named_registers_box);
      this.panel6.Controls.Add(this.label4);
      this.panel6.Controls.Add(this.label5);
      this.panel6.Location = new System.Drawing.Point(9, 110);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(384, 156);
      this.panel6.TabIndex = 4;
      // 
      // named_registers_box
      // 
      this.named_registers_box.AutoSize = true;
      this.named_registers_box.Location = new System.Drawing.Point(11, 10);
      this.named_registers_box.Name = "named_registers_box";
      this.named_registers_box.Size = new System.Drawing.Size(15, 14);
      this.named_registers_box.TabIndex = 5;
      this.named_registers_box.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(31, 11);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(103, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Named Registers";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.BackColor = System.Drawing.SystemColors.Window;
      this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(6, 35);
      this.label5.Multiline = true;
      this.label5.Name = "label5";
      this.label5.ReadOnly = true;
      this.label5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.label5.Size = new System.Drawing.Size(362, 108);
      this.label5.TabIndex = 2;
      this.label5.Text = resources.GetString("label5.Text");
      // 
      // panel4
      // 
      this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel4.Controls.Add(this.label2);
      this.panel4.Controls.Add(this.label3);
      this.panel4.Controls.Add(this.register_base_box);
      this.panel4.Location = new System.Drawing.Point(9, 13);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(384, 91);
      this.panel4.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(47, 11);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Register Base";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.BackColor = System.Drawing.SystemColors.Window;
      this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(6, 35);
      this.label3.Multiline = true;
      this.label3.Name = "label3";
      this.label3.ReadOnly = true;
      this.label3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.label3.Size = new System.Drawing.Size(362, 43);
      this.label3.TabIndex = 2;
      this.label3.Text = "The number of the first register used to store program variables.";
      // 
      // register_base_box
      // 
      this.register_base_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.register_base_box.Location = new System.Drawing.Point(6, 9);
      this.register_base_box.Name = "register_base_box";
      this.register_base_box.Size = new System.Drawing.Size(35, 20);
      this.register_base_box.TabIndex = 1;
      this.register_base_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(125, 2);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkGray;
      this.splitContainer1.Panel1.Controls.Add(this.panel2);
      this.splitContainer1.Panel1.Controls.Add(this.source_box);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.panel3);
      this.splitContainer1.Size = new System.Drawing.Size(854, 606);
      this.splitContainer1.SplitterDistance = 415;
      this.splitContainer1.TabIndex = 5;
      // 
      // panel8
      // 
      this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel8.BackColor = System.Drawing.Color.LightSteelBlue;
      this.panel8.Controls.Add(this.stack_undeflow_box);
      this.panel8.Controls.Add(this.label7);
      this.panel8.Controls.Add(this.textBox2);
      this.panel8.Location = new System.Drawing.Point(9, 412);
      this.panel8.Name = "panel8";
      this.panel8.Size = new System.Drawing.Size(384, 103);
      this.panel8.TabIndex = 7;
      // 
      // stack_undeflow_box
      // 
      this.stack_undeflow_box.AutoSize = true;
      this.stack_undeflow_box.Location = new System.Drawing.Point(11, 11);
      this.stack_undeflow_box.Name = "stack_undeflow_box";
      this.stack_undeflow_box.Size = new System.Drawing.Size(15, 14);
      this.stack_undeflow_box.TabIndex = 5;
      this.stack_undeflow_box.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(30, 12);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(141, 13);
      this.label7.TabIndex = 0;
      this.label7.Text = "Check Stack Underflow";
      // 
      // textBox2
      // 
      this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox2.BackColor = System.Drawing.SystemColors.Window;
      this.textBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox2.Location = new System.Drawing.Point(6, 35);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox2.Size = new System.Drawing.Size(362, 65);
      this.textBox2.TabIndex = 2;
      this.textBox2.Text = resources.GetString("textBox2.Text");
      // 
      // compiler_form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkGray;
      this.ClientSize = new System.Drawing.Size(984, 611);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.panel1);
      this.MinimumSize = new System.Drawing.Size(1000, 650);
      this.Name = "compiler_form";
      this.Text = "DM42 Compiler";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.compiler_form_FormClosing);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.output_tabs.ResumeLayout(false);
      this.output_page.ResumeLayout(false);
      this.output_page.PerformLayout();
      this.info_page.ResumeLayout(false);
      this.info_page.PerformLayout();
      this.grammar_page.ResumeLayout(false);
      this.grammar_page.PerformLayout();
      this.options_page.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.register_base_box)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button compile_button;
    private System.Windows.Forms.TextBox source_box;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.TextBox grammar_box;
    private System.Windows.Forms.TextBox output_box;
    private System.Windows.Forms.TabControl output_tabs;
    private System.Windows.Forms.TabPage output_page;
    private System.Windows.Forms.TabPage grammar_page;
    private System.Windows.Forms.TabPage info_page;
    private System.Windows.Forms.TextBox information_box;
    private System.Windows.Forms.Button copy_button;
    private System.Windows.Forms.Button save_as_button;
    private System.Windows.Forms.Button save_button;
    private System.Windows.Forms.Button open_button;
    private System.Windows.Forms.Button clear_button;
    private System.Windows.Forms.Button save_output_button;
    private System.Windows.Forms.TabPage options_page;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown register_base_box;
    private System.Windows.Forms.TextBox label3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox label5;
    private System.Windows.Forms.CheckBox named_registers_box;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Panel panel7;
    private System.Windows.Forms.CheckBox request_parameters_box;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Panel panel8;
    private System.Windows.Forms.CheckBox stack_undeflow_box;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox textBox2;
  }
}

