using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {
        testEntities conn = new testEntities();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_program select = conn.Login_program.Where(c => c.login == textBox1.Text && c.password == textBox2.Text).FirstOrDefault();
            string role = select.role.ToString();
            switch (role)
            {
                case "1":
                    MessageBox.Show("Админ");
                    Form4 form2 = new Form4();
                    form2.ShowDialog();
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if  (checkBox1.Checked)
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
