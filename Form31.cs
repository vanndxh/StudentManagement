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
    public partial class Form31 : Form
    {
        string Sno;
        public Form31(string no)
        {
            Sno = no;
            InitializeComponent();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select Course.Cno,Course.Cname,Teacher.Tname,Teacher.Tno,SelectCourse.STime,SelectCourse.Score " +
                "from Course,SelectCourse,Teacher " +
                "where SelectCourse.Cno=Course.Cno and " +
                "SelectCourse.Tno=Teacher.Tno and " +
                "SelectCourse.Sno='"+Sno+"'" ;


            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            double sumScore = 0;
            double count = 0;
            while(dr.Read())
            {
                string Cno, Cname, Tname,Tno, STime, Score;
                Cno = dr["Cno"].ToString();
                Cname= dr["Cname"].ToString();
                Tname= dr["Tname"].ToString();
                Tno = dr["Tno"].ToString();
                STime = dr["STime"].ToString();
                double  scoreNum = double.Parse(dr["Score"].ToString());
                if (scoreNum < 0)
                    Score = "未打分";
                else
                {
                    Score = dr["Score"].ToString();
                    sumScore = scoreNum + sumScore;
                    count++;
                }
                    
                string[] str = { Cno, Cname, Tname, Tno, STime, Score };
                dataGridView1.Rows.Add(str);
                
            }
            dr.Close();
            double mScore;
            if (count == 0)
                mScore = 0;
            else
                mScore = sumScore / count;
            meanScore.Text = "您的GPA为："+mScore.ToString();
            string insql = "Insert into Student (SGPA) values("+mScore+")";
            dao.Excute(sql);
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void 取消这门课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Cno = dataGridView1.SelectedCells[0].Value.ToString();
            string Tno= dataGridView1.SelectedCells[3].Value.ToString();
            string STime= dataGridView1.SelectedCells[4].Value.ToString();
            string sql = "delete SelectCourse where Sno='" + Sno +
                "'and Cno='" + Cno +
                "' and Tno='" + Tno +
                "' and STime='" + STime + "'"; ;
            Dao dao = new Dao();
            dao.Excute(sql);
            Table();
        }
    }
}
