using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩录入 : Form
    {
        public 教师端_成绩录入()
        {
            InitializeComponent();//初始化
            toolStripLabel6.Text = LoadInfor.T_Sname;
            toolStripLabel5.Text = LoadInfor.T_Sno;
            populate();//将函数写入
        }
        
        SqlConnection Con = new SqlConnection(@"server=(local);database=学生成绩管理系统;Integrated security=true");
        //底部显示表格
        private void populate()
        {
            Con.Open();
            string query = "select * from 选课$";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);//创建数据的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//组合使用可用来批量处理数据库数据
            //创建虚拟数据库
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩查询().Show();
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



        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //录入保存
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("信息缺失！请检查条件是否完整！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into 选课$ values('"+ textBox1.Text + "' , '"+ textBox2.Text  + "','"+ textBox3.Text+ "')";
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
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            new 教师端登录界面().Show();
        }
    }
}
