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
    public partial class Form21 : Form
    {
        Form6 form6;
        string[] str=new string[9];
        public Form21(Form6 f)
        {
            InitializeComponent();
            button3.Visible = false;
            form6 = f;
        }
        public Form21(string[] a,Form6 f)
        {
            InitializeComponent();
            button1.Visible = false;
            for(int i=0;i<9;i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
            textBox7.Text = str[6];
            textBox8.Text = str[7];
            textBox9.Text = str[8];
            form6 = f;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == ""|| textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("输入不完整,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Student values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','123456')";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功！");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    textBox7.Text = null;
                    textBox8.Text = null;
                    textBox9.Text = null;
                }
                form6.Table();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("修改后有空项,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(textBox1.Text != str[0])
                {
                    string sql = "update Student set Sno='"+textBox1.Text+"'where Sno='"+str[0]+"'and Sname='"+str[1]+"'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;
                }
                if(textBox2.Text != str[1])
                {
                    string sql = "update Student set Sname='" + textBox2.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update Student set Ssex='" + textBox3.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update Student set Sage='" + textBox4.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update Student set Sgrade='" + textBox5.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[4] = textBox5.Text;
                }
                if (textBox6.Text != str[5])
                {
                    string sql = "update Student set Sdept='" + textBox6.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[5] = textBox6.Text;
                }
                if (textBox7.Text != str[6])
                {
                    string sql = "update Student set SuserName='" + textBox7.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[6] = textBox7.Text;
                }
                if (textBox8.Text != str[7])
                {
                    string sql = "update Student set Spassword='" + textBox8.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[7] = textBox8.Text;
                }
                if (textBox9.Text != str[8])
                {
                    string sql = "update Student set SGPA='" + textBox9.Text + "'where Sno='" + str[0] + "'and Sname='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[8] = textBox9.Text;
                }
                MessageBox.Show("修改成功！");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox8.Text = null;
                textBox9.Text = null;
                this.Hide();
                form6.Table();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""
               || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("输入不完整,请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Student values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text 
                    + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" 
                    + textBox8.Text + "','" + textBox9.Text + "')";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功！");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    textBox7.Text = null;
                    textBox8.Text = null;
                    textBox9.Text = null;
                }
                form6.Table();
            }
        }
    }
}
