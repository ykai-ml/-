﻿using System;
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
    public partial class 学生端_课程信息 : Form
    {
        public 学生端_课程信息()
        {
            InitializeComponent();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端个人信息().Show();
        }

        private void 综测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_综测().Show();
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_管理().Show();
        }
    }
}
