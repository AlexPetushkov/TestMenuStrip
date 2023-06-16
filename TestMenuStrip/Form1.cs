using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TestMenuStrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = DataBase.getConnection();

            var loginUser = textBox1.Text;
            var passwordUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string queryString = $"select loginUser, passwordUser, nameFile from registerTable where loginUser ='{loginUser}' and  passwordUser = '{passwordUser}'";
            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            if(dataTable.Rows.Count == 1)
            {
                string line = dataTable.Rows[0]["nameFile"].ToString();
                Form2 newForm = new Form2(line);
                newForm.ShowDialog();
                this.Hide();
                timer1.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("Неправильные данные, попробуйте ещё раз");
                textBox1.ForeColor = System.Drawing.Color.Red;
                textBox2.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InputLanguage inputLanguage = InputLanguage.CurrentInputLanguage;
            label3.Text = "Язык раскладки " + inputLanguage.LayoutName;
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                label4.Text = "Клавиша CapsLock нажата";
            }
            else
            {
                label4.Text = "Клавиша CapsLock выключена";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Parent = pictureBox2;
            label5.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}