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
    public partial class Form24 : Form
    {

        string Tno = Interaction.InputBox("请输入教师号：", "教师登录", "", -1, -1);

        public Form24()
        {
            InitializeComponent();
            Table();
        }

        

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from SelectCourse where Tno = " +  Tno +"order by Cno";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e;
                a = dr["Cno"].ToString();
                b = dr["Sno"].ToString();
                c = dr["Tno"].ToString();
                d = dr["STime"].ToString();
                e = dr["Score"].ToString();
                string[] str = { a, b, c, d, e};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }
        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string [] str = { dataGridView1.SelectedCells[0].Value.ToString(), 
                dataGridView1.SelectedCells[1].Value.ToString(), 
                dataGridView1.SelectedCells[2].Value.ToString(), 
                dataGridView1.SelectedCells[3].Value.ToString(), 
                dataGridView1.SelectedCells[4].Value.ToString() };
            Form241 f = new Form241(str, this);
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Table();
        }
    }
}
