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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Teacher";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d,g;
                a = dr["Tno"].ToString();
                b = dr["Tname"].ToString();
                c = dr["Tpassword"].ToString();
                d = dr["Tdept"].ToString();
                g = dr["TuserName"].ToString();
                string[] str = { a, b, c, d , g};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void 添加教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 f = new Form41(this);
            f.ShowDialog();
        }

        private void 修改教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a, b, c, d, g;
            a = dataGridView1.SelectedCells[0].Value.ToString();
            b = dataGridView1.SelectedCells[1].Value.ToString();
            c = dataGridView1.SelectedCells[2].Value.ToString();
            d = dataGridView1.SelectedCells[3].Value.ToString();
            g = dataGridView1.SelectedCells[4].Value.ToString();
            string[] str = { a, b, c, d, g };
            Form41 f = new Form41(str, this);
            f.ShowDialog();
        }

        private void 删除教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r=MessageBox.Show("确认删除吗?","", MessageBoxButtons.OKCancel);
            if(r==DialogResult.OK)
            {
                string tID = dataGridView1.SelectedCells[0].Value.ToString();
                string tName = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Teacher where Tno='" + tID + "' and Tname='" + tName + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                }
            }
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 查询教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form42 form42 = new Form42(this);
            form42.Show();
        }
    }
}
