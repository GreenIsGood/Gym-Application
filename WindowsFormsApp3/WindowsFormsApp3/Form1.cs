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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");
        String path5 = Path.Combine(Directory.GetCurrentDirectory(), "Deleted.txt");
        Object[] info = new String[10];

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {

        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure ?", "Register", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(Box1.Text) || String.IsNullOrEmpty(Box2.Text) || String.IsNullOrEmpty(Box3.Text) || String.IsNullOrEmpty(Box4.Text) || String.IsNullOrEmpty(Box5.Text))
            {
                MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*take input*/
            info[1] = Box1.Text;
            Box1.Text = "";
            info[2] = Box2.Text;
            Box2.Text = "";
            info[3] = Box3.Text;
            Box3.Text = "";
            info[4] = Box4.Text;
            Box4.Text = "";
            info[5] = date1.Value.ToString();
            date1.Text = "";
            info[7] = Box5.Text;
            Box5.Text = "";
            info[6] = DateTime.Parse(info[5].ToString()).AddMonths(int.Parse(info[7].ToString())).ToString();
            /*take input*/

            StreamWriter sw;

            if (new FileInfo("Deleted.txt").Length != 0)
            {
                StreamReader sr = new StreamReader(path5);
                int curIdx = int.Parse(sr.ReadLine());
                sr.Close();
                var allLines = File.ReadAllLines(path5);
                string[] newLines = new string[allLines.Length - 1];
                for(int i = 0; i < allLines.Length - 1; i++)
                {
                    allLines[i] = allLines[i + 1];
                }
                Array.Copy(allLines, newLines, allLines.Length - 1);
                File.WriteAllLines(path5, newLines);

                allLines = File.ReadAllLines(path1);
                info[0] = (curIdx + 1).ToString();
                allLines[curIdx] = String.Format("{0, -6}{1, -30}{2, -15}{3, -6}{4, -6}{5, -30}{6, -30}{7, -3}", info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7]);
                File.WriteAllLines(path1, allLines);

                Box6.Text = info[0].ToString();
            }
            else
            {
                StreamReader sr = new StreamReader(path2);
                int noOfUsers = int.Parse(sr.ReadLine()) + 1;
                sr.Close();
                var allLines = File.ReadAllLines(path2);
                allLines[0] = noOfUsers.ToString();
                File.WriteAllLines(path2, allLines);
                info[0] = noOfUsers.ToString();

                sw = File.AppendText(path1);
                sw.WriteLine(String.Format("{0, -6}{1, -30}{2, -15}{3, -6}{4, -6}{5, -30}{6, -30}{7, -3}", info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7]));
                sw.Close();


                Box6.Text = noOfUsers.ToString();

            }
            
            sw = File.AppendText(path3);
            sw.WriteLine(String.Format("{0, -30}Eshtrak {1, -22}{2, -10}", DateTime.Now, info[0], info[3]));
            sw.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure ?", "Delete ID", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(Box6.Text))
            {
                MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String[] allLines = File.ReadAllLines(path1);
            int idx = int.Parse(Box6.Text) - 1;
            StreamWriter sw = File.AppendText(path3);
            sw.WriteLine(String.Format("{0, -30}l3'a     {1, -21}{2, -10}", DateTime.Now, idx + 1, (-int.Parse(allLines[idx].Substring(51, 6).Trim())).ToString()));
            sw.Close();
            sw = File.AppendText(path5);
            sw.WriteLine(idx.ToString());
            sw.Close();
            String needed = String.Format("{0, -6}", "0");
            StringBuilder sb = new StringBuilder(allLines[idx]);
            for (int i = 51; i < 57; i++)
            {
                sb[i] = needed[i - 51];
            }
            for (int i = 57; i < 63; i++)
            {
                sb[i] = needed[i - 57];
            }
            String curDate = String.Format("{0, -30}", (DateTime.Now));
            for (int i = 63; i < 93; i++)
            {
                sb[i] = curDate[i - 63];
            }
            for(int i = 93; i < 123; i++)
            {
                sb[i] = curDate[i - 93];
            }
            allLines[idx] = sb.ToString();
            File.WriteAllLines(path1, allLines);
            Box6.Text = "";
        }
    }
}
