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
    public partial class Form2 : Form
    {
        testEntities conn = new testEntities();
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = conn.Login_program.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_program add = new Login_program();
            add.login = textBox1.Text;
            add.password = textBox2.Text;
            add.role = Convert.ToInt32(textBox3.Text);
            conn.Login_program.Add(add);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Login_program.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Login_program del = new Login_program();
            //string remore = conn.Login_program.ToString();
            string del = dataGridView1.SelectedCells[0].Value.ToString();
            Login_program delete = conn.Login_program.Where(c => c.login == del).FirstOrDefault();
            conn.Login_program.Remove(delete);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Login_program.ToArray();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.SaveChanges();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Login_program.Where(c => c.login.ToString().Contains(textBox4.Text)).ToList();
        }
    }
}
