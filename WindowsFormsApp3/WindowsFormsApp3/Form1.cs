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
            timer1.Enabled = true;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           
            System.DateTime currentTime = new System.DateTime();
            int sec = currentTime.Second;
            int g=0;
            DateTime result;
            string str5=null;
            int m;
            string str = null;
            int j=0,k=0;
            int[] p= new int[1000];
            string key = textBox1.Text;
            string strText = textBox7.Text;
            int num = 0;
            int.TryParse(strText, out num);
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
                while (true)
                {

                    if (str1 == " 系统消息(10000)" || str1 == " 系统消息(1000000)" || str1 == " (80000000)")
                        break;
                    if (str == null)
                    {
                        if (str1 == " 系统消息(10000)" || str1 == " 系统消息(1000000)" || str1 == " (80000000)")
                            break;
                        str = str + str1 + "\r\n";
                        break;
                    }
                    if (str.Contains(str1))
                    {
                        if (radioButton1.Checked == true)
                        {
                            str = str + str1 + "\r\n";
                            break;
                        }
                        break;
                    }
                    str =str + str1 + "\r\n";
                    g++;
                }
            }
            string[] member= str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int n=0;n<num;n++)
            {
                Random rd = new Random();
                int d=rd.Next(0,g+1);
                str5 = str5 + member[(d+n*n+sec)%g]+" "+gift[n]+"\r\n";
            }
            currentTime = System.DateTime.Now;
            string time5 = textBox2.Text;
            if (time5.Length == 0)
                time5 = "2020-08-20 16:45:49";
            DateTime dt6 = DateTime.Parse(time5);
           
               
               
                    textBox4.Text = str5;
                    
                
                
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        string str10 = null;
        string[] gift;
        private void button2_Click(object sender, EventArgs e)
        {
           
            
            string temp = textBox5.Text;
            str10 = str10 + temp+ "\r\n";
            textBox6.Text = str10;
            gift= str10.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
      
       
            int ii = 10;
            private void timer1_Tick(object sender, EventArgs e)
            {
                string s1 = ii.ToString();
                label11.Text = s1;
                if (s1 == "0")
                    timer1.Enabled = false;
                ii--;

            }
        

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
