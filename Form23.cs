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
    public partial class Form23 : Form
    {
        public string Tno = Interaction.InputBox("请输入教师号：", "教师登录", "", -1, -1);
        public Form23()
        {
            InitializeComponent();
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select Course.Cno,Cname,Cabstract from SelectCourse, Course where SelectCourse.Cno = Course.cno and Tno='" + Tno + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c;
                a = dr["Cno"].ToString();
                b = dr["Cname"].ToString();
                c = dr["Cabstract"].ToString();
                string[] str = { a, b, c};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string Cno, Cname;
                Cno = dataGridView1.SelectedCells[0].Value.ToString();
                Cname = dataGridView1.SelectedCells[1].Value.ToString();
                //Cabstract = dataGridView1.SelectedCells[2].Value.ToString();
                string sql = "delete from SelectCourse where Cno='" + Cno + "'";
                Dao dao = new Dao();
                dao.Excute(sql);
                Table();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form231 f = new Form231(Tno);
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Table();
        }
    }
}
