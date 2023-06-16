using Microsoft.VisualBasic.ApplicationServices;
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
            if (File.Exists(Environment.CurrentDirectory + "\\������������.txt"))
            {
                List<string> fileLines = File.ReadLines(Environment.CurrentDirectory + "\\������������.txt").ToList();
                if (fileLines.Count == 0)
                {
                    MessageBox.Show("���� � ���������� ����");
                    return;
                }
                string Input = textBox1.Text + " " + textBox2.Text;
                foreach (string b in fileLines)
                {
                    if (b.Contains(Input))
                    {
                        string[] arr = b.Split(' ');
                        Form2 newForm = new Form2(arr[2]);
                        newForm.ShowDialog();
                        this.Hide();
                        timer1.Enabled = false;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("������ ����� �� ���� �������.");
                return;
            }
            MessageBox.Show("������������ ������, ���������� ��� ���");
            textBox1.ForeColor = System.Drawing.Color.Red;
            textBox2.ForeColor = System.Drawing.Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InputLanguage inputLanguage = InputLanguage.CurrentInputLanguage;
            label3.Text = "���� ��������� " + inputLanguage.LayoutName;
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                label4.Text = "������� CapsLock ������";
            }
            else
            {
                label4.Text = "������� CapsLock ���������";
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