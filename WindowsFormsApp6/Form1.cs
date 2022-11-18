using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        testEntities conn = new testEntities();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login_program login = new Login_program();
            Login_program select = conn.Login_program.Where(c => c.login == textBox1.Text && c.password == textBox2.Text).FirstOrDefault();
            string role = select.role.ToString();
            switch (role)
            {
                case "1":
                    MessageBox.Show("Админ ?");
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    break;
                case "2":
                    MessageBox.Show("Пользователь");
                    Form2 form3 = new Form2();
                    form3.ShowDialog();
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
