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
    public partial class Form32 : Form
    {
        string Sno;
        public Form32()
        {
            InitializeComponent();
        }
        public Form32(string no)
        {
            InitializeComponent();
            Sno = no;
            //string sql = "select * from Student where Id='" + Sno + "'";
            //Dao dao = new Dao();
            //IDataReader dr = dao.read(sql);
            //dr.Read();
            //textBox1.Text = dr["PassWord"].ToString();
            //dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "Update Student set SpassWord='" + textBox2.Text + "',SuserName='" + textBox1.Text + "' where Sno='" + Sno + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("修改成功");
                }
            }
            catch(System.Data.SqlClient.SqlException )
            {
                MessageBox.Show("用户名或密码不符合要求！");
            }

        }
    }
}
