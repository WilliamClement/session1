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
    public partial class Form4 : Form
    {
        testEntities conn = new testEntities();
        public Form4()
        {
            InitializeComponent();
            dataGridView1.DataSource = conn.Login_program.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_program add = new Login_program();
            add.login = textBox1.Text;
            add.password = textBox2.Text;
            add.role = Convert.ToInt32(textBox3.Text);
            conn.Login_program.Add(add);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Login_program.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string remove = dataGridView1.SelectedCells[0].Value.ToString();
            //remove = conn.Login_program.Where(c => c.login.ToString().Contains)
            Login_program del = conn.Login_program.Where(c => c.login == remove).FirstOrDefault();
            conn.Login_program.Remove(del);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Login_program.ToArray();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Login_program.Where(c => c.login.ToString().Contains(textBox4.Text)).ToList();
        }
    }
}
