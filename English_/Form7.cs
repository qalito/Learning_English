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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
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
        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eng_DataDataSet);

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eng_DataDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.eng_DataDataSet.Users);
            логинTextBox.ReadOnly = true;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        string pol;
        private void ПолComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (полComboBox.SelectedIndex)
            {
                case 0:
                    pol = "Мужской";

                    break;
                case 1:
                    pol = "Женский"; break;

            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UsersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            полComboBox.Text = usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Database1.mdf";
            string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + path + "'; Integrated Security = True";
            SqlConnection connect = new SqlConnection(myConnectionString);
            string sql = "Update [Users] set ФИО=@ФИО, Пол=@Пол,[Дата рождения]=@Дата,Пароль=@Пароль WHERE Логин=@Логин;";
            SqlCommand cmd_SQL = new SqlCommand(sql, connect);
            cmd_SQL.Parameters.AddWithValue("@Логин", логинTextBox.Text);
            cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox.Text);
            cmd_SQL.Parameters.AddWithValue("@Пол", pol);
            cmd_SQL.Parameters.AddWithValue("@Пароль", парольTextBox.Text);
            cmd_SQL.Parameters.AddWithValue("@Дата", дата_рожденияDateTimePicker.Value);


            try
            {
                connect.Open();
                int n = cmd_SQL.ExecuteNonQuery();
                MessageBox.Show("Запись успешно измененина! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка! Запись не измененина! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
             

            }
            finally
            {
                connect.Close();
                this.usersTableAdapter.Fill(eng_DataDataSet.Users);

            }
            Validate();
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(eng_DataDataSet.Users);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Database1.mdf";
            string myConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + path + "'; Integrated Security = True";
            SqlConnection connect = new SqlConnection(myConnectionString);
            string sql = "Delete from [Users]  WHERE Логин=@Логин;";
            SqlCommand cmd_SQL = new SqlCommand(sql, connect);
            cmd_SQL.Parameters.AddWithValue("@Логин", usersDataGridView.Rows[usersDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            try
            {
                connect.Open();
                int n = cmd_SQL.ExecuteNonQuery();
                MessageBox.Show("Запись успешно Удалена! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка! Запись не удалена! ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

            }
            finally
            {
                connect.Close();
            }
            usersBindingSource.RemoveCurrent();
            Validate();
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(eng_DataDataSet.Users);
        }
        int znach = 0;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if ((znach == 0) && (textBox1.Text != ""))
            {
                for (int i = 0; i < usersDataGridView.RowCount; i++)

                {

                    usersDataGridView.Rows[i].Selected = false;

                    for (int j = 0; j < usersDataGridView.ColumnCount; j++)

                        if (usersDataGridView.Rows[i].Cells[j].Value != null)

                            if (usersDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))

                            {

                                usersDataGridView.Rows[i].Selected = true;


                            }

                }
            }
            else if (textBox1.Text != "") Search(znach);
            else if (textBox1.Text == "") usersDataGridView.ClearSelection();
        }
        private void Search(int znach)
        {
            for (int i = 0; i < usersDataGridView.RowCount; i++)

            {

                usersDataGridView.Rows[i].Selected = false;

                int j = znach - 1;

                if (usersDataGridView.Rows[i].Cells[j].Value != null)

                    if (usersDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))

                    {

                        usersDataGridView.Rows[i].Selected = true;

                        if (textBox1.Text == "") usersDataGridView.ClearSelection();

                    }

            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (textBox2.Text != "")
                filterParts.Add("Логин = '" + textBox2.Text + "'");
            if (textBox3.Text != "")
                filterParts.Add("ФИО = '" + textBox3.Text + "'");
            if (comboBox2.SelectedIndex >= 0)
                filterParts.Add("Пол = '" + comboBox2.Text + "'");
            string filter = string.Join(" AND ", filterParts);
            usersBindingSource.Filter = filter;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fr = new Form1();
            fr.Show();
        }
    }
}
