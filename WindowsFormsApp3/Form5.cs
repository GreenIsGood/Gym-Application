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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(path3);
            richTextBox1.Clear();
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, richTextBox1.Font.Size);
            String[] allLines = File.ReadAllLines(path3);
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.AddDays(1).Date;
            int st = -1, ed = allLines.Length - 1;
            while(st < ed)
            {
                int mid = st + (ed - st + 1) / 2;
                String ss = allLines[mid].Substring(0, 30);
                DateTime curDate = DateTime.Parse(ss);
                if(curDate < startDate)
                {
                    st = mid;
                }else
                {
                    ed = mid - 1;
                }
            }
            st++;
            int s = -1, ee = allLines.Length - 1;
            while(s < ee)
            {
                int mid = s + (ee - s + 1) / 2;
                String ss = allLines[mid].Substring(0, 30);
                DateTime curDate = DateTime.Parse(ss);
                if(curDate < endDate)
                {
                    s = mid;
                }else
                {
                    ee = mid - 1;
                }
            }
            int Outcome = 0;
            richTextBox1.AppendText(Environment.NewLine + String.Format("{0, -30}{1, -30}{2, -10}", "Date", "Type", "Amount"));
            for (int i = st; i <= s; i++)
            {
                richTextBox1.AppendText(Environment.NewLine + allLines[i]);
                Outcome += int.Parse(allLines[i].Substring(60, 10));
            }
            Box1.Text = Outcome.ToString();
        }

    }
}
