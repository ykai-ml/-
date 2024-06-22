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
    public partial class 管理员_教师列表 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 管理员_教师列表()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.G_Sno;
            toolStripLabel4.Text = LoadInfor.G_Sname;
        }
        public void InitTeacher()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 教师表$";
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

        private void 课程列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_课程列表().Show();
        }

        private void 班级列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_班级列表().Show();
        }


        private void 管理员_教师列表_Load(object sender, EventArgs e)
        {
            InitTeacher();
        }

        private void button1_Click(object sender, EventArgs e)//录入
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert 教师表$ values({0},'{1}','{2}')";
                    strCmd = string.Format(strCmd, textBox1.Text, textBox3.Text, textBox4.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitTeacher();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            string id = dataGridView1.CurrentRow.Cells["教工号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "delete from 教师表$ where 教工号={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitTeacher();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//查找
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 教师表$ where 教工号={0}";
                strCmd = string.Format(strCmd, textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)//修改
        {
            string id = dataGridView1.CurrentRow.Cells["教工号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "update 教师表$ set 教师名='{0}',密码={1} where 教工号='{2}'";
                    strCmd = string.Format(strCmd, textBox3.Text, textBox4.Text, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitTeacher();
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
