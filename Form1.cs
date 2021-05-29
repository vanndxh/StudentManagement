using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            SoundPlayer sp = new SoundPlayer("qinchen.wav");
            sp.Play();
            InitializeComponent();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                timer1.Stop();
                if (comboBox1.Text=="学生")
                {
                    string sql = "select * from Student where SuserName='" + textBox1.Text + "'and  Spassword='" + textBox2.Text + "'";
                    Dao dao = new Dao();
                    IDataReader dr = dao.read(sql);
                    dr.Read();

                    MessageBox.Show("学生登录成功");
                    string Sno = dr["Sno"].ToString();
                    Form3 form3 = new Form3(Sno);
                    form3.Show();
                    this.Hide();

                }
                else
                {
                    if (comboBox1.Text=="教师")
                    {
                        MessageBox.Show("教师登录成功！");
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (comboBox1.Text=="管理员")
                        {
                            MessageBox.Show("管理员登录成功！");
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();
                        }
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
        }
        private bool login()
        {
            if(textBox1.Text==""||textBox2.Text==""||comboBox1.Text=="")
            {
                MessageBox.Show("输入不完整,请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if(comboBox1.Text=="学生")
            {
                string sql = "select * from Student where SuserName='" + textBox1.Text + "'and  Spassword='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if(dr.Read() && string.Compare(dr["SuserName"].ToString(), "imBot") != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    return false;
                }
            }
            if(comboBox1.Text=="教师")
            {
                string sql = "select * from Teacher where TuserName='" + textBox1.Text + "'and Tpassword='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    return false;
                }
            }
            if(comboBox1.Text=="管理员")
            {
                string sql = "select * from Administrator where AuserName='" + textBox1.Text + "'and Apassword='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    return false;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }
    }
}
