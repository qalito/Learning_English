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
    public partial class Form1 : Form
    {
        private int x = 0; private int y = 0;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                e.SuppressKeyPress = true;
                Button1_Click(sender, e);
            }
        }

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
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Select();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        public bool IsAuthenticated { get; private set; }
        string login;
        private void Button1_Click(object sender, EventArgs e)
        {
        
            if ((textBox1.Text == "Admin") && (textBox2.Text == "qwerty_ad"))
            {
                this.Hide(); Form7 fr2 = new Form7();fr2.Show();
            }
           else if ((textBox1.Text == "") ||(textBox2.Text == ""))
            {
                label4.Visible = true;
                MessageBox.Show("Ошибка! Введите данные для входа! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string path = Application.StartupPath + @"\Database1.mdf";
                string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
                string mySelectQuery = "SELECT Логин FROM [Users] WHERE Логин='" + textBox1.Text + "'AND Пароль='" + textBox2.Text + "' ";
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
                try
                {
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == false) { label4.Visible = true; MessageBox.Show("Ошибка! Вход не выполнен, проверьте введённые данные! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                   else { while (myReader.Read()) { login = myReader.GetString(0); }
                        this.Hide(); Form2 fr2 = new Form2(login);
                        fr2.Show();
                    } }
                catch
                {
                    MessageBox.Show("Ошибка! Вход не выполнен, проверьте введённые данные! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                finally { myConnection.Close(); }

            }
            button1.Height = 33; button1.Width = 275;
            button1.Height = 34; button1.Width = 276;
        }


    

    private void Label1_Click(object sender, EventArgs e)
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

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Height = 33; button1.Width = 275;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Height = 33; button1.Width = 275; 
         

        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Height = 34; button1.Width = 276;
        }

        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eng_DataDataSet);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();a.Show();
        }
    }
}
