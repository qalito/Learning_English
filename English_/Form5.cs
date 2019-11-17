using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_
{
    public partial class Form5 : Form
    {
        private int x = 0; private int y = 0;
        string test="";

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }
        string li,login;
        public Form5(string l,string log)
        {
            li = l;login = log;
            string curDir = Directory.GetCurrentDirectory();
            InitializeComponent();
            webBrowser1.Url = new Uri(String.Format(l, curDir));
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            if (l == "file:///{0}/sourse/htm/Modal_verbs.htm") { comboBox1.Visible = true; comboBox1.SelectedIndex = 3; test = "1_T4.rs"; }
            if (l == "file:///{0}/sourse/htm/Non-finite.htm") { comboBox2.Visible = true; comboBox2.SelectedIndex = 5; test = "2_T6.rs"; }
            if (l == "file:///{0}/sourse/htm/Subjunctive_Mood.htm") { comboBox3.Visible = true; comboBox3.SelectedIndex = 0; var x = new Random();
                int n = x.Next(0, 2);
                switch (n)
                {
                    case 0: test = "3_T1.rs"; break;
                    case 1: test = "3_T2.rs"; break;
                    default: test = "3_T1.rs"; break;
                }
            }
            if (l == "file:///{0}/sourse/htm/Conditionals.htm") { comboBox4.Visible = true; comboBox4.SelectedIndex = 0; var x = new Random();
                int n = x.Next(0, 9);
                switch (n)
                {
                    case 0:
                        test = "4_T1.rs"; break;
                    case 1:
                        test = "4_T2.rs"; break;
                    case 2:
                        test = "4_T3.rs"; break;
                    case 3:
                        test = "4_T4.rs"; break;
                    case 4:
                        test = "4_T5.rs"; break;
                    case 5:
                        test = "4_T6.rs"; break;
                    case 6:
                        test = "4_T7.rs"; break;
                    case 7:
                        test = "4_T8.rs"; break;
                    case 8:
                        test = "4_T9.rs"; break;
                    default:
                        test = "4_T1.rs";
                        break;
                }
            }
        }


        public Form5(string l)
        {
            li = l; 
            string curDir = Directory.GetCurrentDirectory();
            InitializeComponent();
            webBrowser1.Url = new Uri(String.Format(l, curDir));
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
          

        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2(login); this.Close(); fr.Show();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = new Random();
            int n = x.Next(0, 9);
            switch (n)
            {
                case 0:
                    test = "4_T1.rs";  break;
                case 1:
                    test = "4_T2.rs"; break;
                case 2:
                    test = "4_T3.rs";  break;
                case 3:
                    test = "4_T4.rs"; break;
                case 4:
                    test = "4_T5.rs"; break;
                case 5:
                    test = "4_T6.rs"; break;
                case 6:
                    test = "4_T7.rs"; break;
                case 7:
                    test = "4_T8.rs"; break;
                case 8:
                    test = "4_T9.rs"; break;
                default:
                    test = "4_T1.rs";
                    break;
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: test = "1_T1.rs"; break;
                case 1: test = "1_T2.rs"; break;
                case 2: test = "1_T3.rs"; break;
                case 3: test = "1_T4.rs"; break;
                default: test = "1_T1.rs"; break;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: test = "2_T1.rs"; break;
                case 1: test = "2_T2.rs"; break;
                case 2: test = "2_T3.rs"; break;
                case 3: test = "2_T4.rs"; break;
                case 4:
                    var x = new Random();
                    int n = x.Next(0, 3);
                    switch (n)
                    {
                        case 0:
                            test = "2_T5_1.rs"; break;
                        case 1:
                            test = "2_T5_2.rs"; break;
                        case 2:
                            test = "2_T5_3.rs"; break;
                        default:
                            test = "2_T5_1.rs";
                            break;
                    }
                    break;
                case 5: test = "2_T6.rs"; break;


                default: test = "2_T1.rs"; break;
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = new Random();
            int n = x.Next(0, 2);
            switch (n)
            {
                case 0:   test = "3_T1.rs"; break;
                case 1:  test = "3_T2.rs"; break;
                default: test = "3_T1.rs"; break;
            }
        }

      

        private void Button1_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(li,login,test); this.Close(); frm.Show();
        }

       
    }
}
