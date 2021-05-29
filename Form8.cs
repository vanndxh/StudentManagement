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
    public partial class Form8 : Form
    {
        public Form8()
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

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Course";
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

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 增加课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form81 f = new Form81(this);
            f.ShowDialog();
        }

        private void 修改课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(),
                dataGridView1.SelectedCells[1].Value.ToString(),
                dataGridView1.SelectedCells[2].Value.ToString(),
            };
             Form81 f = new Form81(str, this);
            f.ShowDialog();
        }
    }
}
