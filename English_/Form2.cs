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
    public partial class Form2 : Form
    {
        int bal;
        private int x = 0; private int y = 0;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }
        string login;
        public Form2(string log)
        {
            login = log;
            InitializeComponent();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eng_DataDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
            string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
            Validate();
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(eng_DataDataSet.Users);

            string mySelectQuery = "SELECT Логин, ФИО, Пол,[Дата рождения],Увлечения,Баллы,Уровень FROM [Users] WHERE Логин='" + login + "' ";
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
            try
            {
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows == false) { };
                while (myReader.Read())
                {
                    label1.Text = "Логин: " + myReader.GetString(0);
                    label2.Text = "ФИО: " + myReader.GetString(1);
                    label3.Text = "Пол: " + myReader.GetString(2);
                    string date = myReader.GetDateTime(3).Date.ToString(); date = date.Remove(11, 7);
                    label4.Text = "Дата рождения: " + date;
                    string hobbi = myReader.GetString(4);
                    label5.Text = "Увлечения: ";
                    if (hobbi != null)
                        for (int i = 0; i < hobbi.Length; i++)
                        {
                            if (hobbi[i] == '1') label5.Text = label5.Text + "\nКино";
                            if (hobbi[i] == '2') label5.Text = label5.Text + "\nМузыка";
                            if (hobbi[i] == '3') label5.Text = label5.Text + "\nПутешествия";
                            if (hobbi[i] == '4') label5.Text = label5.Text + "\nПрирода";
                            if (hobbi[i] == '5') label5.Text = label5.Text + "\nКультура";
                            if (hobbi[i] == '6') label5.Text = label5.Text + "\nТворчество";
                            if (hobbi[i] == '7') label5.Text = label5.Text + "\nСпорт";
                            if (hobbi[i] == '8') label5.Text = label5.Text + "\nIT-Информационные технологии";
                            if (hobbi[i] == '9') label5.Text = label5.Text + "\nЧтение";
                        }
                    else label5.Text = "Увлечения: -";
                    bal = myReader.GetInt32(5);
                    pictureBox2.Width = 2 * (bal % 100);
                    groupBox6.Text = "Текущий уровень:" + Convert.ToString(1 + bal / 100)+ ", Кол-во баллов: "+ Convert.ToString(bal % 100);
                    int lev = Convert.ToInt32(myReader.GetInt32(6));
                    if (lev == 1) label6.Text = "Стартовый уровень: Beginner (начальный уровень)";
                    if (lev == 2) label6.Text = "Стартовый уровень: Elementary (базовый уровень)";
                    if (lev == 3) label6.Text = "Стартовый уровень: Pre-intermediate (ниже среднего)";
                    if (lev == 4) label6.Text = "Стартовый уровень: Intermediate (средний)";
                    if (lev == 5) label6.Text = "Стартовый уровень: Upper-intermediate (выше среднего)";
                    if (lev == 6) label6.Text = "Стартовый уровень: Advanced (продвинутый)";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка вход не выполнен! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                myConnection.Close();
            }

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eng_DataDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
           
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
            Validate();
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(eng_DataDataSet.Users);
            string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + Application.StartupPath + @"\Eng_Data.mdf" + "'; Integrated Security = True";
            string mySelectQuery = "SELECT Логин, ФИО, Пол,[Дата рождения],Увлечения,Баллы,Уровень FROM [Users] WHERE Логин='" + login + "' ";
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
            try
            {
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows == false) {  };
                while (myReader.Read())
                {
                    label1.Text = "Логин: "+myReader.GetString(0);
                    label2.Text = "ФИО: " + myReader.GetString(1);
                    label3.Text = "Пол: " + myReader.GetString(2);
                string date = myReader.GetDateTime(3).Date.ToString(); date=date.Remove(11, 7);
                label4.Text = "Дата рождения: " + date;
                    string hobbi= myReader.GetString(4);
                    label5.Text = "Увлечения: ";
                if(hobbi!=null)
                for (int i = 0; i < hobbi.Length; i++)
                    {
                        if (hobbi[i] == '1') label5.Text = label5.Text + "\nКино";
                        if (hobbi[i] == '2') label5.Text = label5.Text + "\nМузыка";
                        if (hobbi[i] == '3') label5.Text = label5.Text + "\nПутешествия";
                        if (hobbi[i] == '4') label5.Text = label5.Text + "\nПрирода";
                        if (hobbi[i] == '5') label5.Text = label5.Text + "\nКультура";
                        if (hobbi[i] == '6') label5.Text = label5.Text + "\nТворчество";
                        if (hobbi[i] == '7') label5.Text = label5.Text + "\nСпорт";
                        if (hobbi[i] == '8') label5.Text = label5.Text + "\nIT-Информационные технологии";
                        if (hobbi[i] == '9') label5.Text = label5.Text + "\nЧтение";
                    }
                    else label5.Text = "Увлечения: -";
                    bal =  myReader.GetInt32(5);
                    pictureBox2.Width = 2*(bal%100);
                    groupBox6.Text = "Текущий уровень:" + Convert.ToString(1+bal/100);
                    label13.Text = "Кол-во баллов: " + bal % 100;
               int lev = Convert.ToInt32(myReader.GetInt32(6));
                if (lev==1) label6.Text =   "Стартовый уровень: Beginner (начальный уровень)";
                if (lev == 2) label6.Text = "Стартовый уровень: Elementary (базовый уровень)";
                if (lev == 3) label6.Text = "Стартовый уровень: Pre-intermediate (ниже среднего)";
                if (lev == 4) label6.Text = "Стартовый уровень: Intermediate (средний)";
                if (lev == 5) label6.Text = "Стартовый уровень: Upper-intermediate (выше среднего)";
                if (lev == 6) label6.Text = "Стартовый уровень: Advanced (продвинутый)";
            }
            }
              catch
             {
                MessageBox.Show("Ошибка вход не выполнен! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
                finally {
            myConnection.Close();
        }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eng_DataDataSet);

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5("file:///{0}/sourse/htm/Modal_verbs.htm",login);
            frm.Show(); this.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5("file:///{0}/sourse/htm/Non-finite.htm", login);
            frm.Show(); this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5("file:///{0}/sourse/htm/Subjunctive_Mood.htm", login);
            frm.Show(); this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5("file:///{0}/sourse/htm/Conditionals.htm", login);
            frm.Show(); this.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show(); this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
