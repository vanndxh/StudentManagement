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
    public partial class Form33 : Form
    {
        DataGridView dg2;
        public Form33(Form3 f)
        {
            InitializeComponent();
            dg2 = f.dataGridView1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dg2.Rows.Clear();
            string sql1 = "select *  from studentSelectCourse where Cname like '%" + textBox1.Text + "%'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql1);
            while (dr.Read())
            {
                string a, b, c, d, g;
                a = dr["Cno"].ToString();
                b = dr["Cname"].ToString();
                c = dr["TName"].ToString();
                d = dr["Tno"].ToString();
                g = dr["Cabstract"].ToString();
                string[] str = { a, b, c, d, g };
                dg2.Rows.Add(str);
            }
            dr.Close();
        }
    }
}
