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
    public partial class Form3 : Form
    {
        string Sno;
        string currentTerm;
        public Form3(string no)
        {

            InitializeComponent();
            Sno = no;
            string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            toolStripStatusLabel3.Text =nowDateTime;
            int term;
            int month = int.Parse(nowDateTime.Substring(5, 2));
            if (month >= 2 && month <= 7)
                term = 1;
            else
                term = 2;

            currentTerm = nowDateTime.Substring(0, 5) + term;
            toolStripStatusLabel1.Text = "欢迎学号为" + Sno + "的同学登入选课系统";
            timer1.Start();
            //MessageBox.Show(currentTerm);
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            /*string sql = "select Course.Cno,Course.Cname,Teacher.Tname,Teacher.Tno,Course.Cabstract "+
                "from Course,SelectCourse,Teacher "+
                "where SelectCourse.Cno=Course.Cno and "+
                "SelectCourse.Tno=Teacher.Tno and "+
                "SelectCourse.Sno='999999' and "+
                "SelectCourse.STime='"+currentTerm+"'";
            */
            string sql = "select * from studentSelectCourse";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string cno, cname, tname,tno, cabstract;
                cno = dr["Cno"].ToString();
                cname = dr["Cname"].ToString();
                tname = dr["Tname"].ToString();
                tno = dr["Tno"].ToString();
                cabstract = dr["cabstract"].ToString();
                string[] str = { cno, cname, tname, tno,cabstract};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 选择该课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Cno = dataGridView1.SelectedCells[0].Value.ToString();
            string Tno = dataGridView1.SelectedCells[3].Value.ToString();
            string repeatSql = "select * " +
                "from SelectCourse " +
                "where SelectCourse.Tno='"+Tno+"' and " +
                "SelectCourse.Sno='" + Sno + "' and " +
                "SelectCourse.Cno='" + Cno + "' and " +
                "SelectCourse.STime='" + currentTerm + "'";
            Dao dao = new Dao();
            IDataReader dc = dao.read(repeatSql);
            if(!dc.Read())
            {
                string sql = "Insert into SelectCourse (Cno,Sno,Tno,STime,Score) values('"+Cno+"','"+Sno+ "','" + Tno + "','" + currentTerm + "',"+(-1.0)+")";
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(Sno);
            f.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 f = new Form32(Sno);
            f.ShowDialog();
        }

        private void 课程查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form33 form33 = new Form33(this);
            form33.Show();
        }
    }
}
