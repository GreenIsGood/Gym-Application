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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure ?", "Add", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(Box1.Text) || String.IsNullOrEmpty(Box2.Text))
            {
                MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StreamWriter sw = File.AppendText(path3);
            sw.WriteLine(String.Format("{0, -30}{1, -30}{2, -10}", DateTime.Now, Box1.Text, (-int.Parse(Box2.Text))).ToString());
            sw.Close();
            Box1.Text = "";
            Box2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure ?", "Add", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(Box1.Text) || String.IsNullOrEmpty(Box2.Text))
            {
                MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String [] allLines = File.ReadAllLines(path1);
            int idx = int.Parse(Box3.Text) - 1;
            String needed1 = String.Format("{0, -6}", (int.Parse(allLines[idx].Substring(51, 6).Trim()) + int.Parse(Box4.Text)).ToString());
            String needed2 = String.Format("{0, -6}", (int.Parse(allLines[idx].Substring(57, 6).Trim()) - int.Parse(Box4.Text)).ToString());
            StringBuilder sb = new StringBuilder(allLines[idx]);
            for (int i = 51; i < 57; i++)
            {
                sb[i] = needed1[i - 51];
            }
            for(int i = 57; i < 63; i++)
            {
                sb[i] = needed2[i - 57];
            }
            allLines[idx] = sb.ToString();
            File.WriteAllLines(path1, allLines);

            StreamWriter sw = File.AppendText(path3);
            sw.WriteLine(String.Format("{0, -30}Df3 Ba2y {1, -21}{2, -10}", DateTime.Now, idx + 1, (int.Parse(Box4.Text))).ToString());
            sw.Close();
            Box3.Text = "";
            Box4.Text = "";
        }


    }
}
