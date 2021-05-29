using System;
using System.Data;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            //Form21 f = new Form21(this);
            //f.ShowDialog();
        }

        public void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), 
                dataGridView1.SelectedCells[1].Value.ToString(), 
                dataGridView1.SelectedCells[2].Value.ToString(), 
                dataGridView1.SelectedCells[3].Value.ToString(), 
                dataGridView1.SelectedCells[4].Value.ToString(),
                dataGridView1.SelectedCells[5].Value.ToString(),
                dataGridView1.SelectedCells[6].Value.ToString(),
                dataGridView1.SelectedCells[7].Value.ToString(),
                dataGridView1.SelectedCells[8].Value.ToString()
            };
           // Form21 f = new Form21(str, this);
           // f.ShowDialog();
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Table();
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23();
            f.ShowDialog();
        }


        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Form24 f = new Form24();
            f.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Table();
        }

        public void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form61 form61 = new Form61(this);
            form61.Show();
        }
    }
}
