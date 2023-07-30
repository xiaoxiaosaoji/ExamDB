using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UI
{
    public partial class TeacharScreen : Form
    {
        public TeacharScreen()
        {
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
        }
        /// <summary>
        /// 用于记录谁登录此窗口
        /// </summary>
        /// <param name="UserName">用户ID</param>
        public string UserName { get; set; }

        private void TeacharScreen_Load(object sender, EventArgs e)
        {
            StudentState studentState = StudentState.CreateFrom();
            studentState.UserName = this.UserName;
            LoadForm(studentState);
            btnStudens.BackColor = Color.FromArgb(240, 240, 240);
        }

        #region 关闭最小化按钮样式功能
        //关闭按钮
        private void Close_MouseDown(object sender, MouseEventArgs e)
        {
            timeClose.Start();
        }
        //时间定时器 虚化效果
        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.30;
            if (this.Opacity == 0)
            {
                timeClose.Stop();
                Application.Exit();
            }
        }
        //移动到控件上
        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.IndianRed;
        }
        //鼠标移开
        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.White;
        }
        //最小化按钮
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //移动到控件上
        private void btnMin_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.DarkGray;
        }
        #endregion

        #region 窗体托动
        Point mouseLocation = new Point(); //鼠标位置
        bool isDragging = false; //标识鼠标是否按下

        //鼠标按下
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = new Point(e.X, e.Y);
                isDragging = true;
            }
        }
        //鼠标移动
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newmouseLocation = new Point();
                newmouseLocation = new Point(e.X + this.Location.X - mouseLocation.X, e.Y + this.Location.Y - mouseLocation.Y);
                this.Location = newmouseLocation;
            }
        }
        //鼠标松开
        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
                isDragging = false;
        }
        #endregion

        #region 侧边按钮
        public void LoadForm(object Form)
        {
            if(panelMain.Controls.Count>0)
                this.panelMain.Controls.Clear();
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelMain.Controls.Add(f);
            //panelMain.Tag = f;
            f.Show();
        }
        public void BtnColor()
        {
            foreach (var item in panelTabControl.Controls)
            {
                if (item is Button)
                {
                    Button button = (Button)item;
                    button.BackColor = Color.White;
                }
            }
        }
        //学员状态
        private void btnStudens_Click(object sender, EventArgs e)
        {
            StudentState studentState = StudentState.CreateFrom();
            studentState.UserName = this.UserName;
            LoadForm(studentState);
            BtnColor();
            btnStudens.BackColor = Color.FromArgb(240, 240, 240);
        }
        
        //试卷管理
        private void btnExam_Click(object sender, EventArgs e)
        {
            ExamManagement examManagement = ExamManagement.CreateFrom();
            examManagement.UserName = this.UserName;
            LoadForm(examManagement);
            BtnColor();
            btnExam.BackColor = Color.FromArgb(240, 240, 240);
        }
        //成绩信息
        private void btnGrade_Click(object sender, EventArgs e)
        {
            TermStatistics termStatistics = TermStatistics.CreateFrom();
            termStatistics.UserName = this.UserName;
            LoadForm(termStatistics);
            BtnColor();
            btnGrade.BackColor = Color.FromArgb(240, 240, 240);
        }
        //设置
        private void btnSet_Click(object sender, EventArgs e)
        {
            BtnColor();
            btnSet.BackColor = Color.FromArgb(240, 240, 240);
        }
        //退出登录
        bool isClose = false;
        private void btnExit_Click(object sender, EventArgs e)
        {
            isClose = true;
            this.Close();
        }
        private void TeacharScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isClose == false)
            {
                Application.Exit();
            }
            if (isClose)
            {
                Login login = new Login();
                login.Show();
            }
        }
        #endregion

    }
}
