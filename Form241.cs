using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form241 : Form
    {
        Form24 form24;
        string[] str = new string[5];
        public Form241(Form24 f)
        {
            InitializeComponent();
            form24 = f;
        }
        public Form241(string[] a, Form24 f)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[4];
            label6.Text = str[0];
            label7.Text = str[1];
            label8.Text = str[2];
            label9.Text = str[3];
            form24 = f;
        }
        private void Form241_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            label6.Text = null;
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("修改后有空项,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(textBox1.Text != str[4])
            {
                string sql = "update SelectCourse set Score='" + textBox1.Text + "'where Cno='" + str[0] + "'and Sno='" + str[1] + "'";
                Dao dao = new Dao();
                dao.Excute(sql);
                str[4] = textBox1.Text;
            }
            form24.Table();
        }
    }
}
