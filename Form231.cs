using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Demo
{
    public partial class Form231 : Form
    {
        //string Tno = Interaction.InputBox("请输入教师号：", "教师登录", "", -1, -1);
        string Tno;
        public Form231()
        {
            InitializeComponent();
            Table();
        }
        public Form231(string str)
        {
            InitializeComponent();
            textBox1.Text = str;
            Table();
        }

        
        public void Table()
        {
            Tno = textBox1.Text;
            dataGridView1.Rows.Clear();
            string sql = "select distinct Course.Cno,Cname,Cabstract from Course where Cno not in (select Cno from SelectCourse where Tno ='" + Tno + "')";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c;
                a = dr["Cno"].ToString();
                b = dr["Cname"].ToString();
                c = dr["Cabstract"].ToString();
                string[] str = { a, b, c };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void Form231_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tno = textBox1.Text;
            string Cno;
            Cno = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "insert into SelectCourse values('" + Cno + "','999999','" + Tno + "','2020-1','0')";
            Dao dao = new Dao();
            dao.Excute(sql);
            Table();
        }
    }
}
