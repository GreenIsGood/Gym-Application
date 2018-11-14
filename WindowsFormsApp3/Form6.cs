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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");
        Object[] info = new String[5];
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure ?", "Renew", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(Box1.Text) || String.IsNullOrEmpty(Box2.Text) || String.IsNullOrEmpty(Box3.Text) || String.IsNullOrEmpty(Box4.Text))
            {
                MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            


            String[] allLines = File.ReadAllLines(path1);
            int idx = int.Parse(Box1.Text) - 1;

            /*take input*/
            Box1.Text = "";
            info[0] = Box2.Text;
            Box2.Text = "";
            info[1] = Box3.Text;
            Box3.Text = "";
            info[2] = date1.Value.ToString();
            date1.Text = "";
            info[3] = date2.Value.ToString();
            date2.Text = "";
            info[4] = Box4.Text;
            Box4.Text = "";
            /*take input*/

            int value = int.Parse(allLines[idx].Substring(57, 6));
            if (value != 0)
            {
                MessageBox.Show("The debit is not 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String needed = String.Format("{0, -6}{1, -6}{2, -30}{3, -30}{4, -3}", info[0], info[1], info[2], info[3], info[4]);
            StringBuilder sb = new StringBuilder(allLines[idx]);
            for(int i = 51; i < 126; i++)
            {
                sb[i] = needed[i - 51];
            }
            allLines[idx] = sb.ToString();
            File.WriteAllLines(path1, allLines);

            StreamWriter sw = File.AppendText(path3);
            sw.WriteLine(String.Format("{0, -30}tgdeed   {1, -21}{2, -10}", DateTime.Now, idx + 1, info[0].ToString()));
            sw.Close();
        }

    }
}
