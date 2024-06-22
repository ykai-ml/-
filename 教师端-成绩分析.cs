using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩分析 : Form
    {
        public 教师端_成绩分析()
        {
            InitializeComponent();
            toolStripLabel6.Text = LoadInfor.T_Sname;
            toolStripLabel5.Text = LoadInfor.T_Sno;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩查询().Show();
        }

        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩录入().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_个人信息().Show();
        }



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 教师端登录界面().Show();
        }
    }
}
