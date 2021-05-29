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
    public partial class Form42 : Form
    {
        DataGridView dg;
        public Form42(Form4 f)
        {
            InitializeComponent();
  
            dg = f.dataGridView1;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dg.Rows.Clear();
            string sql1 = "select * from Teacher where Tname like '%"+textBox1.Text+"%'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql1);
            while (dr.Read())
            {
                string a, b, c, d,g;
                a = dr["Tno"].ToString();
                b = dr["Tname"].ToString();
                c = dr["TuserName"].ToString();
                d = dr["Tpassword"].ToString();
                g = dr["Tdept"].ToString();
                string[] str = { a, b, c ,d,g};
                dg.Rows.Add(str);
            }
            dr.Close();
        }
    }
}
