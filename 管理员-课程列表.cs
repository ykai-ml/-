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
    public partial class 管理员_课程列表 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 管理员_课程列表()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.G_Sno;
            toolStripLabel4.Text = LoadInfor.G_Sname;
        }
        public void InitCourse()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 课程$";
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

        private void 班级列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_班级列表().Show();
        }



        private void 管理员_课程列表_Load(object sender, EventArgs e)
        {
            InitCourse();
        }

        private void button1_Click(object sender, EventArgs e)//录入
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert 课程$ values({0},'{1}','{2}')";
                    strCmd = string.Format(strCmd, textBox1.Text, textBox3.Text, textBox2.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitCourse();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            string id = dataGridView1.CurrentRow.Cells["课程号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "delete from 课程$ where 课程号={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitCourse();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//查找
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 课程$ where 课程号={0}";
                strCmd = string.Format(strCmd, textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)//修改
        {
            string id = dataGridView1.CurrentRow.Cells["课程号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "update 课程$ set 课程名='{0}',学分={1} where 课程号='{2}'";
                    strCmd = string.Format(strCmd, textBox3.Text, textBox2.Text, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitCourse();
                }
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 管理员登录界面().Show();
        }
    }
}
