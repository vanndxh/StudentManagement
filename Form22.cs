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
    public partial class Form22 : Form
    {
        //Form2 form2;
        string[] str = new string[5];

        public Form22()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(textBox1.Text == textBox3.Text && textBox2.Text == textBox4.Text)
            {
                MessageBox.Show("数据未变化，请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string sql1 = "update Teacher set TuserName='" + textBox3.Text + 
                    "'where TuserName='" + textBox1.Text + "'and Tpassword='" + textBox2.Text + "'";
                string sql2 = "update Teacher set Tpassword='" + textBox4.Text + 
                    "'where TuserName='" + textBox1.Text + "'and Tpassword='" + textBox2.Text + "'";
                Dao dao = new Dao();
                dao.Excute(sql1);
                dao.Excute(sql2);
                MessageBox.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            this.Hide();
        }
    }
}
