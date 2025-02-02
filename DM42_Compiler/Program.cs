using System;
using System.Windows.Forms;

namespace DM42_Compiler
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new compiler_form());
    }
  }
}
