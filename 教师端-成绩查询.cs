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
    public partial class 教师端_成绩查询 : Form
    {
        
        public 教师端_成绩查询()
        {
            InitializeComponent();
            toolStripLabel6.Text = LoadInfor.T_Sname;
            toolStripLabel5.Text = LoadInfor.T_Sno;
            populate();
        }
        SqlConnection Con = new SqlConnection(@"server=(local);database=学生成绩管理系统;Integrated security=true");
        private void populate()
        {
            Con.Open();
            string query = "select * from 选课$";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//组合使用可用来批量处理数据库数据
            //创建虚拟数据库
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "")
            {
                try
                {
                    Con.Open();
                    string query = "select  班级名,学号,成绩 from 选课$,学生$,班级$ where ";
                    SqlCommand cmd = new SqlCommand(query, Con);//cmd对象向数据库发送增删改查操作的sql语句
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("该条信息保存成功！！");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            }
            else
            {
               }
            */
        }


        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩录入().Show();
        }

        private void 成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩分析().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_个人信息().Show();
        }



        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 教师端登录界面().Show();
        }
    }
}
