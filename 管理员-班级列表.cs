using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 管理员_班级列表 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 管理员_班级列表()
        {
            InitializeComponent();
            toolStripLabel5.Text = LoadInfor.G_Sno;
            toolStripLabel6.Text = LoadInfor.G_Sname;
        }
        public void InitClass()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 班级$";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 学生列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_学生列表().Show();
        }

        private void 教师列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_教师列表().Show();
        }

        private void 课程列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_课程列表().Show();
        }


        private void button1_Click(object sender, EventArgs e)//录入
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert 班级$ values({0},'{1}')";
                    strCmd = string.Format(strCmd, textBox1.Text, textBox3.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitClass();
                }
            }
        }

        private void 管理员_班级列表_Load(object sender, EventArgs e)
        {
            InitClass();
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            string id = dataGridView1.CurrentRow.Cells["班级号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "delete from 班级$ where 班级号={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitClass();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//查找
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 班级$ where 班级号={0}";
                strCmd = string.Format(strCmd, textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)//修改
        {
            string id = dataGridView1.CurrentRow.Cells["班级号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "update 班级$ set 班级名='{0}' where 班级号='{1}'";
                    strCmd = string.Format(strCmd, textBox3.Text, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitClass();
                }
            }
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new 管理员登录界面().Show();
        }
    }
}
