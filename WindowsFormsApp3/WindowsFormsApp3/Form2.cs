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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        String path1 = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        String path2 = Path.Combine(Directory.GetCurrentDirectory(), "ID.txt");
        String path3 = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
        String path4 = Path.Combine(Directory.GetCurrentDirectory(), "SearchLog.txt");


        bool exist(int id)
        {
            String[] allLines = File.ReadAllLines(path4);
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(1).Date;
            int st = -1, ed = allLines.Length - 1;
            while (st < ed)
            {
                int mid = st + (ed - st + 1) / 2;
                String ss = allLines[mid].Substring(0, 30);
                DateTime curDate = DateTime.Parse(ss);
                if (curDate < startDate)
                {
                    st = mid;
                }
                else
                {
                    ed = mid - 1;
                }
            }
            st++;
            int s = -1, ee = allLines.Length - 1;
            while (s < ee)
            {
                int mid = s + (ee - s + 1) / 2;
                String ss = allLines[mid].Substring(0, 30);
                DateTime curDate = DateTime.Parse(ss);
                if (curDate < endDate)
                {
                    s = mid;
                }
                else
                {
                    ee = mid - 1;
                }
            }
            for (int i = st; i <= s; i++)
            {
                if (id == int.Parse(allLines[i].Substring(30, 6)))
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Box1.Text);
            Box1.Text = "";
            StreamReader sr = new StreamReader(path2);
            int noOfUsers = int.Parse(sr.ReadLine());
            sr.Close();
            if (ID > noOfUsers)
            {
                MessageBox.Show("ID doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String line = File.ReadLines(path1).Skip(ID - 1).Take(1).First();
            Box3.Text = line.Substring(0, 6).Trim();
            Box4.Text = line.Substring(6, 30).Trim();
            Box5.Text = line.Substring(36, 15).Trim();
            Box6.Text = line.Substring(123, 3).Trim();
            Box7.Text = line.Substring(51, 6).Trim();
            Box8.Text = line.Substring(57, 6).Trim();
            Box9.Text = line.Substring(63, 30).Trim();
            Box10.Text = line.Substring(93, 30).Trim();
            if(exist(ID))
            {
                MessageBox.Show("You searched for this id today!", "Twice a day!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StreamWriter sw = File.AppendText(path4);
                sw.WriteLine(String.Format("{0, -30}{1, -6}", DateTime.Now, ID.ToString()));
                sw.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String word1 = Box2.Text;
            Box2.Text = "";
            String word2 = "";
            StreamReader sr = new StreamReader(path1);
            String line = null;
            while (word1 != word2 && (line = sr.ReadLine()) != null)
            {
                word2 = line.Substring(36, 15).Trim();
                if (line == null)
                {
                    break;
                }
            }
            sr.Close();
            if(word1 == word2)
            {
                Box3.Text = line.Substring(0, 6).Trim();
                Box4.Text = line.Substring(6, 30).Trim();
                Box5.Text = line.Substring(36, 15).Trim();
                Box6.Text = line.Substring(123, 3).Trim();
                Box7.Text = line.Substring(51, 6).Trim();
                Box8.Text = line.Substring(57, 6).Trim();
                Box9.Text = line.Substring(63, 30).Trim();
                Box10.Text = line.Substring(93, 30).Trim();
                if (exist(int.Parse(line.Substring(0, 6))))
                {
                    MessageBox.Show("You searched for this id today!", "Twice a day!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    StreamWriter sw = File.AppendText(path4);
                    sw.WriteLine(String.Format("{0, -30}{1, -6}", DateTime.Now, line.Substring(0, 6)));
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("Number Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
