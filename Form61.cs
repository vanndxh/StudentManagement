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
    public partial class Form61 : Form
    {
        DataGridView dg1;
        public Form61(Form6 f)
        {
            InitializeComponent();
            dg1 = f.dataGridView1;
        }

        public Form61(Form2 f)
        {
            InitializeComponent();
            dg1 = f.dataGridView1;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dg1.Rows.Clear();
            string sql1 = "select * from Student where Sname like '%" + textBox1.Text + "%'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql1);
            while (dr.Read())
            {
                string a, b, c, d, g, h, x, y, z;
                a = dr["Sno"].ToString();
                b = dr["Sname"].ToString();
                c = dr["Ssex"].ToString();
                d = dr["Sage"].ToString();
                g = dr["Sgrade"].ToString();
                h = dr["Sdept"].ToString();
                x = dr["SuserName"].ToString();
                y = dr["Spassword"].ToString();
                z = dr["SGPA"].ToString();
                string[] str = { a, b, c, d, g, h, x, y, z };
                dg1.Rows.Add(str);
            }
            dr.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                label2.Visible = true;
            }
        }
    }
}
