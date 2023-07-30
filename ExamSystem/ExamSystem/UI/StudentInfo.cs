using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class StudentInfo : Form
    {
        public StudentInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用于记录谁登录此窗口
        /// </summary>
        /// <param name="UserName">用户ID</param>
        public string UserName { get; set; }

    }
}
