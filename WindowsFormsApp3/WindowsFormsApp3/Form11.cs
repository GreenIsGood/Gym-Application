using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, richTextBox1.Font.Size);
            String[] allLines = File.ReadAllLines(path1);
            richTextBox1.AppendText(Environment.NewLine + String.Format("{0, -10}{1, -40}{2, -20}{3, -20}{4, -40}{5, -40}", "ID", "Name", "Paid", "Remain", "Start Date", "End Date"));
            for (int i = 0; i < allLines.Length; i++)
            {
                if (int.Parse(allLines[i].Substring(57, 6)) > 0)
                {
                    richTextBox1.AppendText(Environment.NewLine + String.Format("{0, -10}{1, -40}{2, -20}{3, -20}{4, -40}{5, -40}", allLines[i].Substring(0, 6), allLines[i].Substring(6, 30), allLines[i].Substring(51, 6), allLines[i].Substring(57, 6), allLines[i].Substring(63, 30), allLines[i].Substring(93, 30)));
                }
            }
        }
    }
}
