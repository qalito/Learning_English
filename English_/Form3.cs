using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_
{
    public partial class Form3 : Form
    {
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
        string pol, hobbi;
        public Form3()
        {
           
            InitializeComponent();
          

        }
        string login;
     
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eng_DataDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                     pol= "Мужской";

                    break;
                case 1:
                     pol= "Женский"; break;

            }
        }

            private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (comboBox1.SelectedText.Length == 0))
            {
              
                string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
                string mySelectQuery = "SELECT Логин FROM [Users]   WHERE Логин='" + textBox2.Text + "' ";
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                try
                {
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    string log = textBox2.Text; string fio = textBox1.Text; string par = textBox3.Text;
                    if (myReader.HasRows == false) { this.Close(); Form4 fr4 = new Form4(log, fio, par, dateTimePicker1.Value, pol, hobbi); fr4.Show(); }
                  else label9.Text = "Логин занят! Попробуйте снова!";




            }
                catch
                {
                    MessageBox.Show("Ошибка! Регистрация не выполнена, Попробуйте снова... введите данные корректно! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                   
                    myConnection.Close();
                } }
            else
            {
                label9.Visible = true; label9.Text = "Все поля должны быть заполнены\nкорректно!";
            }

          
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1(); frm.Show();
        }
        int vs;
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if(hobbi!=null)
            for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '1')
                {
                    v = false;
                    vs = i;
                }
                

            }
            if (v) hobbi = hobbi + '1';else hobbi.Remove(vs, 1);

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '2')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '2'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '3')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '3'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '4')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '4'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '5')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '5'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '6')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '6'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '7')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '7'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '8')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '8'; else hobbi.Remove(vs, 1);
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (hobbi != null) for (int i = 0; i < hobbi.Length; i++)
            {
                if (hobbi[i] == '9')
                {
                    v = false;
                    vs = i;
                }


            }
            if (v) hobbi = hobbi + '9'; else hobbi.Remove(vs, 1);
        }

        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eng_DataDataSet);

        }

        private void Button5_Click(object sender, EventArgs e)
        { 

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (comboBox1.SelectedText.Length == 0))
            {

                string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
                string mySelectQuery = "SELECT Логин FROM [Users]   WHERE Логин='" + textBox2.Text + "' ";
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                try
                {
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    string log = textBox2.Text; string fio = textBox1.Text; string par = textBox3.Text;
                    if (myReader.HasRows == false)
                    {
                      
                        SqlCommand myCommand2 = new SqlCommand(mySelectQuery, myConnection);
                        SqlConnection connect = new SqlConnection(myConnectionString);
                        string sql = "Update [Users] set [Логин]=@Логин,[ФИО]=@ФИО,[Пол]=@Пол,[Пароль]=@Пароль,[Дата рождения]=@Дата WHERE[Логин]=@Логин;";
                        SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                        cmd_SQL.Parameters.AddWithValue("@Логин",textBox2.Text);
                        cmd_SQL.Parameters.AddWithValue("@ФИО", textBox1.Text);
                        cmd_SQL.Parameters.AddWithValue("@Пароль", textBox3.Text);
                        cmd_SQL.Parameters.AddWithValue("@Дата", dateTimePicker1.Value);
                        cmd_SQL.Parameters.AddWithValue("@Пол", pol );
                        try
                        {
                            connect.Open();
                            int n = cmd_SQL.ExecuteNonQuery();
                            Form2 frm = new Form2(login);
                            frm.Show(); this.Close();
                        }

                        finally
                        {
                            connect.Close();
                        }

                    }
                    else label9.Text = "Логин занят! Попробуйте снова!";




                }
                catch
                {
                    MessageBox.Show("Ошибка! Регистрация не выполнена, Попробуйте снова... введите данные корректно! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {

                    myConnection.Close();
                }
            }
            else
            {
                label9.Visible = true; label9.Text = "Все поля должны быть заполнены\nкорректно!";
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
