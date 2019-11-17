using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace English_
{
    public partial class Form6 : Form
    {
        string l, login, test; int bal;
        static string filename="";
        StreamReader чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\1_T1.rs", Encoding.GetEncoding("windows-1251"));
        public Form6(string li,string log, string tes)
        {
            InitializeComponent(); l = li; login = log; test = tes;
            switch (test)
            {
                case "1_T1.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\1_T1.rs", Encoding.GetEncoding("windows-1251")); break;
                case "1_T2.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\1_T2.rs", Encoding.GetEncoding("windows-1251")); break;
                case "1_T3.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\1_T3.rs", Encoding.GetEncoding("windows-1251")); break;
                case "1_T4.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\1_T4.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T1.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T1.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T2.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T2.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T3.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T3.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T4.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T4.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T5_1.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T5_1.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T5_2.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T5_2.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T5_3.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T5_3.rs", Encoding.GetEncoding("windows-1251")); break;
                case "2_T6.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\2_T6.rs", Encoding.GetEncoding("windows-1251")); break;
                case "3_T1.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\3_T1.rs", Encoding.GetEncoding("windows-1251")); break;
                case "3_T2.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\3_T2.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T1.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T1.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T2.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T2.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T3.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T3.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T4.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T4.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T5.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T5.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T6.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T6.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T7.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T7.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T8.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T8.rs", Encoding.GetEncoding("windows-1251")); break;
                case "4_T9.rs": чтение = new StreamReader(Application.StartupPath + @"\sourse\qthew\4_T9.rs", Encoding.GetEncoding("windows-1251")); break;
                default: MessageBox.Show("Ошибка тестирование невозвожно! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Form5 frm = new Form5(l, login);
                frm.Show();
                break;
            }
        }
        private int x = 0; private int y = 0;

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

      
        string s; int n_v = 0; int otv, rez=0;
        private void Form6_Load(object sender, EventArgs e)
        {
            if (чтение != null)
            {
                s = чтение.ReadLine();
                label1.Text = s;
                n_v = 1;
                s = чтение.ReadLine();
                label5.Text = s;
                label6.Text = "Вопрос " + n_v.ToString() + " из 20";
                label6.Visible = true;
                groupBox1.Visible = true;
                s = чтение.ReadLine();
                if (radioButton1.Text == "") { radioButton1.Visible = false; }else {radioButton1.Visible = true;}
                if (radioButton1.Text == "") { radioButton1.Visible = false; }
                else if (s.Length != 0) if (s[0] == '+') { otv = 1; radioButton1.Text = s.Remove(0, 1); }
                else { radioButton1.Text = s; }
                if (s.Length == 0) radioButton1.Visible = false;
                s = чтение.ReadLine();
                if (radioButton2.Text == "") { radioButton2.Visible = false; } else radioButton2.Visible = true;
                if (radioButton1.Text == "") { radioButton2.Visible = false; }
                else if (s.Length != 0)
                if (s[0] == '+') { otv = 2; radioButton2.Text = s.Remove(0, 1); }
                else { radioButton2.Text = s; }
                if (s.Length == 0) radioButton2.Visible = false;
                s = чтение.ReadLine();
                if (radioButton3.Text == "") { radioButton3.Visible = false; }
                else radioButton3.Visible = true;
                if (radioButton1.Text == "") { radioButton3.Visible = false; }
                else if (s.Length != 0) if (s[0] == '+') { otv = 3; radioButton3.Text = s.Remove(0, 1); }
                else { radioButton3.Text = s; }
                if (s.Length == 0) radioButton3.Visible = false;
                s = чтение.ReadLine();
                if (radioButton4.Text == "") { radioButton4.Visible = false; }
                else radioButton4.Visible = true;
                if (radioButton1.Text == "") { radioButton4.Visible = false; }
                else if (s.Length != 0) if (s[0] == '+') { otv = 4; radioButton3.Text = s.Remove(0, 1); }
                else { radioButton4.Text = s; }
                if (s.Length == 0) radioButton4.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 frm = new Form5(l,login);
            frm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (чтение != null)
            {

                s = чтение.ReadLine();
                if (s != "END")
                {
                    n_v += 1;
                    label6.Text = "Вопрос " + n_v.ToString() + " из 20";
                    label5.Text = s;
                    s = чтение.ReadLine();
                    if (radioButton1.Text == "") { radioButton1.Visible = false; }
                    else radioButton1.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 1; radioButton1.Text = s.Remove(0, 1); }
                        else { radioButton1.Text = s; }
                    if (s.Length == 0) radioButton1.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton2.Text == "") { radioButton2.Visible = false; }
                    else radioButton2.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 2; radioButton2.Text = s.Remove(0, 1); }
                        else { radioButton2.Text = s; }
                    if (s.Length == 0) radioButton2.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton3.Text == "") { radioButton3.Visible = false; }
                    else radioButton3.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 3; radioButton3.Text = s.Remove(0, 1); }
                        else { radioButton3.Text = s; }
                    if (s.Length == 0) radioButton3.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton4.Text == "") { radioButton4.Visible = false; }
                    else radioButton4.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 4; radioButton3.Text = s.Remove(0, 1); }
                        else { radioButton4.Text = s; }
                    if (s.Length == 0) radioButton4.Visible = false;
                }
                else
                {

                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    label2.Text = "Тест выполнен успешно!\nВаша отметка - " + (rez / 2 + rez % 2).ToString() + "\nНабрано балов из 20-и - " + rez;
                    chart1.Series.Clear();
                    // Форматировать диаграмму
                    chart1.BackColor = Color.Transparent;
                    chart1.BackSecondaryColor = Color.Transparent;



                    chart1.BorderlineColor = Color.Transparent;
                    chart1.BorderSkin.SkinStyle = BorderSkinStyle.None;

                    // Форматировать область диаграммы
                    chart1.ChartAreas[0].BackColor = Color.Transparent;



                    Series s = chart1.Series.Add("Pie");
                    s.ChartType = SeriesChartType.Pie;
                    s.IsValueShownAsLabel = true;
                    double re = ((double)rez / 20) * 100;
                    double rezz = 100 - ((double)rez / 20) * 100;
                    s.Points.AddXY(0, re);
                    s.Points.AddXY(1, rezz);


                    s.Points[0].LegendText = "Верно - %";
                    s.Points[1].LegendText = "Ошибочно - %";
                }
            }
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(l, login, test); this.Close(); frm.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 frm = new Form5(l, login);
            frm.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            label2.Text = "Тест выполнен успешно!\nВаша отметка - " + (rez / 2 + rez % 2).ToString() + "\nНабрано балов из 20-и - " + rez;
            chart1.Series.Clear();
            // Форматировать диаграмму
            chart1.BackColor = Color.Transparent;
            chart1.BackSecondaryColor = Color.Transparent;



            chart1.BorderlineColor = Color.Transparent;
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.None;

            // Форматировать область диаграммы
            chart1.ChartAreas[0].BackColor = Color.Transparent;



            Series s = chart1.Series.Add("Pie");
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            double re = ((double)rez / 20) * 100;
            double rezz = 100 - ((double)rez / 20) * 100;
            s.Points.AddXY(0, re);
            s.Points.AddXY(1, rezz);


            s.Points[0].LegendText = "Верно - %";
            s.Points[1].LegendText = "Ошибочно - %";
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 frm = new Form5(l,login);
            frm.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked) && (otv == 1)) { rez++; }
            if ((radioButton2.Checked) && (otv == 2)) { rez++; }
            if ((radioButton3.Checked) && (otv == 3)) { rez++; }
            if ((radioButton4.Checked) && (otv == 4)) { rez++; }

            if (чтение != null)
            {

                s = чтение.ReadLine();
                if (s != "END")
                {
                    n_v += 1;
                    label6.Text = "Вопрос " + n_v.ToString() + " из 20";
                    label5.Text = s;
                    s = чтение.ReadLine();
                    if (radioButton1.Text == "") { radioButton1.Visible = false; }
                    else radioButton1.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 1; radioButton1.Text = s.Remove(0, 1); }
                        else { radioButton1.Text = s; }
                    if (s.Length == 0) radioButton1.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton2.Text == "") { radioButton2.Visible = false; }
                    else radioButton2.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 2; radioButton2.Text = s.Remove(0, 1); }
                        else { radioButton2.Text = s; }
                    if (s.Length == 0) radioButton2.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton3.Text == "") { radioButton3.Visible = false; }
                    else radioButton3.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 3; radioButton3.Text = s.Remove(0, 1); }
                        else { radioButton3.Text = s; }
                    if (s.Length == 0) radioButton3.Visible = false;
                    s = чтение.ReadLine();
                    if (radioButton4.Text == "") { radioButton4.Visible = false; }
                    else radioButton4.Visible = true;
                    if (radioButton1.Text == "") { }
                    else if (s.Length != 0) if (s[0] == '+') { otv = 4; radioButton3.Text = s.Remove(0, 1); }
                        else { radioButton4.Text = s; }
                    if (s.Length == 0) radioButton4.Visible = false;
                }
                else
                {
                    string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
                    string mySelectQuery = "SELECT Баллы  FROM [Users] WHERE Логин='" + login + "' ";
                    SqlConnection myConnection = new SqlConnection(myConnectionString);
                    SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                    try
                    {
                        myConnection.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        if (myReader.HasRows == false) { };
                        while (myReader.Read()) { bal = myReader.GetInt32(0); }
                   }

                  finally
                  {
                        myConnection.Close();

                   }



                   
                    SqlCommand myCommand2 = new SqlCommand(mySelectQuery, myConnection);
                    SqlConnection connect = new SqlConnection(myConnectionString);
                    string sql = "Update [Users] set [Баллы]=@Баллы WHERE[Логин]=@Логин;";
                    SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                    cmd_SQL.Parameters.AddWithValue("@Логин", login);
                    cmd_SQL.Parameters.AddWithValue("@Баллы", bal + rez);
                    try
                    {
                        connect.Open();
                        int n = cmd_SQL.ExecuteNonQuery();

                   }

                    finally
                    {
                        connect.Close();
                    }
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    label2.Text = "Тест выполнен успешно!\nВаша отметка - " + (rez / 2 + rez % 2).ToString() + "\nНабрано балов из 20-и - " + rez;
                    chart1.Series.Clear();
                    // Форматировать диаграмму
                    chart1.BackColor = Color.Transparent;
                    chart1.BackSecondaryColor = Color.Transparent;



                    chart1.BorderlineColor = Color.Transparent;
                    chart1.BorderSkin.SkinStyle = BorderSkinStyle.None;

                    // Форматировать область диаграммы
                    chart1.ChartAreas[0].BackColor = Color.Transparent;



                    Series s = chart1.Series.Add("Pie");
                    s.ChartType = SeriesChartType.Pie;
                    s.IsValueShownAsLabel = true;
                    double re = ((double)rez / 20) * 100;
                    double rezz = 100 - ((double)rez / 20) * 100;
                    s.Points.AddXY(0, re);
                    s.Points.AddXY(1, rezz);


                    s.Points[0].LegendText = "Верно - %";
                    s.Points[1].LegendText = "Ошибочно - %";
                }
            }
        }
    }
}

