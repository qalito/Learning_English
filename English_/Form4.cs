using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_
{
    public partial class Form4 : Form
    {
        private int x = 0; private int y = 0;

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
        string login1,fio,passw,pol;
        DateTime date;
        string hobbi;
        public Form4(string log, string f, string pass, DateTime date1, string po, string hob)
        {
            login1 = log;
            InitializeComponent();
            fio = f;
            passw = pass;
            date = date1;
            pol = po;
            hobbi = hob;
          
        }
        int otv;
        StreamReader чтение = new StreamReader(Application.StartupPath + @"\sourse\St_test.rs", Encoding.GetEncoding("windows-1251"));
        string s; int n_v=0;
        private void Button1_Click(object sender, EventArgs e)
        {
           
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Visible = false;

            button7.Visible = false;


            if (чтение != null)
            {
                n_v = 1;
                 s = чтение.ReadLine();
                label5.Text = s;
                label6.Text = "Вопрос " +n_v.ToString() + " из 40";
                label6.Visible = true;
               groupBox1.Visible = true;
                s = чтение.ReadLine();
                s = чтение.ReadLine();
                radioButton1.Visible = true;
                radioButton1.Text = s.Remove(0, 1);
                if (s[0] == '+') otv = 1;
                radioButton2.Visible = true;
                s = чтение.ReadLine();
                radioButton2.Text = s.Remove(0, 1);
                if (s[0] == '+') otv = 2;
                radioButton2.Visible = true;
                s = чтение.ReadLine();
                radioButton3.Visible = true;
                radioButton3.Text = s.Remove(0, 1);
                if (s[0] == '+') otv = 3;
                s = чтение.ReadLine();
                radioButton4.Visible = true;
                radioButton4.Text = s.Remove(0, 1);
                if (s[0] == '+') otv = 4;

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int rez=0;
        int lev;
        string lev_tx;
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
                    n_v += 1 ;
                    label6.Text = "Вопрос " + n_v.ToString() + " из 40";
                    label5.Text = s;
                    s = чтение.ReadLine();
                    radioButton1.Visible = true;
                    radioButton1.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 1;
                    radioButton2.Visible = true;
                    s = чтение.ReadLine();
                    radioButton2.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 2;
                    radioButton2.Visible = true;
                    s = чтение.ReadLine();
                    radioButton3.Visible = true;
                    radioButton3.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 3;
                    s = чтение.ReadLine();
                    radioButton4.Visible = true;
                    radioButton4.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 4;

                }
                else
                {
                    label6.Visible = false;
                    groupBox1.Text = "Отлично!";
                    label5.ForeColor = System.Drawing.Color.Blue;
                    button2.Visible = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    button6.Visible = false;
                    button5.Visible = false;
                    if ((rez>=0)&&(rez<=8)) lev = 1;
                    if ((rez >= 9) && (rez <= 14)) lev = 2;
                    if ((rez >= 15) && (rez <= 22)) lev = 3;
                    if ((rez >= 23) && (rez <= 30)) lev = 4;
                    if ((rez >= 31) && (rez <= 35)) lev = 5;
                    if ((rez >= 36) && (rez <= 40)) lev = 6;
                    button7.Visible = true;
                     lev_tx = "Beginner (начальный уровень)";
                    if (lev == 1) lev_tx = "Beginner (начальный уровень)";
                    if (lev == 2) lev_tx = "Elementary (базовый уровень)";
                    if (lev == 3) lev_tx = "Pre-intermediate (ниже среднего)";
                    if (lev == 4) lev_tx = "Intermediate (средний)";
                    if (lev == 5) lev_tx = "Upper-intermediate (выше среднего)";
                    if (lev == 6) lev_tx = "Advanced (продвинутый)";
                    label5.Text = "Благодорим Вас за уделенное нам время!\nЗа прохождение теста вы получаете -"+Convert.ToString(rez+5)+" Ваших первых стартовых баллов! \nВаш результат:"+lev_tx+ "\nУдачной работы, успехов!";
                  
                }
            }

        }

        private void Button7_Click(object sender, EventArgs e)
        {

            string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
            SqlConnection connect = new SqlConnection(myConnectionString);
            string sql = "INSERT INTO [Users]  (Логин, ФИО, Пол,[Дата рождения],Пароль,Увлечения,Баллы,Уровень) VALUES ( @Логин, @ФИО, @Пол,@Дата_рождения,@Пароль,@Увлечения,@Баллы,@Уровень);";
            SqlCommand cmd_SQL = new SqlCommand(sql, connect);
            cmd_SQL.Parameters.AddWithValue("@Логин", login1);
            cmd_SQL.Parameters.AddWithValue("@ФИО", fio);
            cmd_SQL.Parameters.AddWithValue("@Пароль", passw);
            cmd_SQL.Parameters.AddWithValue("@Дата_рождения", date);
            cmd_SQL.Parameters.AddWithValue("@Пол", pol);
            cmd_SQL.Parameters.AddWithValue("@Увлечения", hobbi);
            cmd_SQL.Parameters.AddWithValue("@Баллы", rez);
            cmd_SQL.Parameters.AddWithValue("@Уровень", lev);
            try
            {
                connect.Open();
                int n = cmd_SQL.ExecuteNonQuery();
                this.Close();
                Form1 frm = new Form1(); frm.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка! Регистрация не выполнена, Попробуйте снова... введите данные корректно! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Form3 frm = new Form3(); frm.Show();

            }
            finally
            {
                this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
                Validate();
                usersBindingSource.EndEdit();
                usersTableAdapter.Update(eng_DataDataSet.Users);
                connect.Close();
            }
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            groupBox1.Visible = true;
               groupBox1.Text = "Отлично!";
            label5.ForeColor = System.Drawing.Color.Blue;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            button6.Visible = false;
            button5.Visible = false;

            rez = 5; lev = 1;
            button7.Visible = true; button2.Visible = false;
            label5.Text = "Благодорим Вас за уделенное нам время при регистрации!\nЗа прохождение регистрации вы получаете 5 стартовых баллов - \nУровень ваших знаний неопределён и принят за Beginner (начальный уровень)!\n Удачной работы, успехов!";
          
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (чтение != null)
            {

                s = чтение.ReadLine();
                if (s != "END")
                {
                    n_v += 1;
                    label6.Text = "Вопрос " + n_v.ToString() + " из 40";
                    label5.Text = s;
                    s = чтение.ReadLine();
                    radioButton1.Visible = true;
                    radioButton1.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 1;
                    radioButton2.Visible = true;
                    s = чтение.ReadLine();
                    radioButton2.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 2;
                    radioButton2.Visible = true;
                    s = чтение.ReadLine();
                    radioButton3.Visible = true;
                    radioButton3.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 3;
                    s = чтение.ReadLine();
                    radioButton4.Visible = true;
                    radioButton4.Text = s.Remove(0, 1);
                    if (s[0] == '+') otv = 4;

                }
                else
                {
                    label6.Visible = false;
                    groupBox1.Text = "Отлично!";
                    label5.ForeColor = System.Drawing.Color.Blue;
                    button2.Visible = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    button6.Visible = false;
                    button5.Visible = false;
                    if ((rez >= 0) && (rez <= 8)) lev = 1;
                    if ((rez >= 9) && (rez <= 14)) lev = 2;
                    if ((rez >= 15) && (rez <= 22)) lev = 3;
                    if ((rez >= 23) && (rez <= 30)) lev = 4;
                    if ((rez >= 31) && (rez <= 35)) lev = 5;
                    if ((rez >= 36) && (rez <= 40)) lev = 6;
                    button7.Visible = true;
                    lev_tx = "Beginner (начальный уровень)";
                    if (lev == 1) lev_tx = "Beginner (начальный уровень)";
                    if (lev == 2) lev_tx = "Elementary (базовый уровень)";
                    if (lev == 3) lev_tx = "Pre-intermediate (ниже среднего)";
                    if (lev == 4) lev_tx = "Intermediate (средний)";
                    if (lev == 5) lev_tx = "Upper-intermediate (выше среднего)";
                    if (lev == 6) lev_tx = "Advanced (продвинутый)";
                    
                    label5.Text = "Благодорим Вас за уделенное нам время!\nЗа прохождение теста вы получаете -" + Convert.ToString(rez + 5) + " Ваших первых стартовых баллов! \nВаш результат:" + lev_tx + "\nУдачной работы, успехов!";
                    rez = rez + 5;
                }
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eng_DataDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eng_DataDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);

        }
    }
}
                        
                   

    


