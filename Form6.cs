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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Student";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h, i;
                a = dr["Sno"].ToString();
                b = dr["Sname"].ToString();
                c = dr["Ssex"].ToString();
                d = dr["Sage"].ToString();
                e = dr["Sgrade"].ToString();
                f = dr["Sdept"].ToString();
                g = dr["SuserName"].ToString();
                h = dr["Spassword"].ToString();
                i = dr["SGPA"].ToString();
                string[] str = { a, b, c, d, e, f, g, h, i };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21(this);
            f.ShowDialog();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = {
                dataGridView1.SelectedCells[0].Value.ToString(),
                dataGridView1.SelectedCells[1].Value.ToString(),
                dataGridView1.SelectedCells[2].Value.ToString(),
                dataGridView1.SelectedCells[3].Value.ToString(),
                dataGridView1.SelectedCells[4].Value.ToString(),
                dataGridView1.SelectedCells[5].Value.ToString(),
                dataGridView1.SelectedCells[6].Value.ToString(),
                dataGridView1.SelectedCells[7].Value.ToString(),
                dataGridView1.SelectedCells[8].Value.ToString()
            };
            Form21 f = new Form21(str, this);
            f.ShowDialog();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string Sno, Sname;
                Sno = dataGridView1.SelectedCells[0].Value.ToString();
                Sname = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Student where Sno='" + Sno + "'and Sname='" + Sname + "'";
                Dao dao = new Dao();
                dao.Excute(sql);
                Table();
            }
        }

        private void 推出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 查询学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form61 form61 = new Form61(this);
            form61.Show();
        }
    }
}
