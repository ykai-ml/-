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
    public partial class 管理员_学生列表 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 管理员_学生列表()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.G_Sno;
            toolStripLabel4.Text = LoadInfor.G_Sname;
        }
        public void InitStudent()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 学生$";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void 班级列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 管理员_班级列表().Show();
        }

        private void 学生列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 管理员_学生列表_Load(object sender, EventArgs e)
        {
            InitStudent();
        }

        private void button1_Click(object sender, EventArgs e)//录入
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert 学生$ values({0},'{1}','{2}','{3}','{4}')";
                    strCmd = string.Format(strCmd, textBox1.Text, textBox3.Text, textBox2.Text,textBox4.Text,textBox5.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitStudent();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            string id = dataGridView1.CurrentRow.Cells["学号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "delete from 学生$ where 学号={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitStudent();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//查找
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 学生$ where 学号={0}";
                strCmd = string.Format(strCmd, textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)//修改
        {
            string id = dataGridView1.CurrentRow.Cells["学号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "update 学生$ set 姓名='{0}',班级号='{1}',密码={2},授权码={3} where 学号='{4}'";
                    strCmd = string.Format(strCmd, textBox3.Text, textBox2.Text, textBox4.Text,textBox5.Text, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitStudent();
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
