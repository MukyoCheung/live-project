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

        static string path = "抽奖.txt";
        string[] content = File.ReadAllLines(path);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime result;
            int m;
            string str = null;
            int j=0,k=0;
            int[] p= new int[1000];
            string key = textBox1.Text;
            string time1 = textBox2.Text;
            if (time1.Length == 0)
                time1 = "2018-08-20 16:45:49";
            string time2 = textBox3.Text;
            if (time2.Length == 0)
                time2 = "2018-11-12 21:22:46";
            DateTime dt1 = DateTime.Parse(time1);
            DateTime dt2 = DateTime.Parse(time2);
            for (int i = 0; i <3783; i++)
            {
                string temp = content[i];
                if (temp.Contains(key))
                {
                    p[j] = i;
                    j++;
                }
            }
            for (k = 0; k <j; k++)
            {
                m = 1;
                string time3 = content[p[k]-1].Substring(0,19);
                while (true)
                {
                    if (!DateTime.TryParse(time3, out result))
                    {
                        time3 = content[p[k] - 1 - m].Substring(0, 19);
                        m++;
                    }
                    if (DateTime.TryParse(time3, out result))
                    break;
                }
                DateTime dt3 = DateTime.Parse(time3);
                if (dt3 < dt1)
                    continue;
                if (dt3 > dt2)
                    break;
                string str1 = content[p[k]-1].Remove(0, 19);
                str = str + str1+ "\r\n";
            }
            textBox4.Text = str;


            Console.WriteLine();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
