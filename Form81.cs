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
    public partial class Form81 : Form
    {
        Form8 form8;
        string[] str = new string[3];
        public Form81(Form8 f)
        {
            InitializeComponent();
            button3.Visible = false;
            form8 = f;
        }
        public Form81(string[] a, Form8 f)
        {
            InitializeComponent();
            button1.Visible = false;
            for (int i = 0; i < 3; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            form8 = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("输入不完整,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Course values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功！");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;    
                }
                form8.Table();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("修改后有空项,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])
                {
                    string sql = "update Course set Cno='" + textBox1.Text + "'where Cno='" + str[0] + "'and Cname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;
                }
                if (textBox2.Text != str[1])
                {
                    string sql = "update Course set Cname='" + textBox2.Text + "'where Cno='" + str[0] + "'and Cname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update Course set Cabstract='" + textBox3.Text + "'where Cno='" + str[0] + "'and Cname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                }
                MessageBox.Show("修改成功！");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                this.Hide();
                form8.Table();
            }
        }
    }
}
