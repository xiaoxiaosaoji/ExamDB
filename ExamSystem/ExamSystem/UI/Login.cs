using AxWMPLib;
using BLL;
using Entity;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            //添加焦点事件
            UserName.GotFocus += new EventHandler(UnameGotFocus);
            UserName.LostFocus += new EventHandler(UnameLostFocus);
            //添加焦点事件
            UserPassWord.GotFocus += new EventHandler(UserPassWordGotFocus);
            UserPassWord.LostFocus += new EventHandler(UserPassWordLostFocus);

 
        }
 

        /// <summary>
        /// 窗体点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, EventArgs e)
        {
            //让控件失去焦点
            textBox1.Focus();
            labUserMessg.Visible = false;
            labPwdMessg.Visible = false;
        }

        #endregion

        #region 关闭最小化按钮样式功能
        //关闭按钮
        private void Close_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timerClose.Start(); 
            }
        }
        //时间定时器 虚化效果
        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.30;
            if (this.Opacity == 0)
            {
                timerClose.Stop();
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
            label.BackColor = Color.WhiteSmoke;
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

        #region 输入框样式
        //获取焦点时触发
        public void UnameGotFocus(object sender, EventArgs e)
        {
            if (UserName.Text == "User ID")
            {
                UserName.Text = "";
                UserName.ForeColor = Color.Black;
            }
        }
        //失去焦点时触发
        public void UnameLostFocus(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "User ID";
                UserName.ForeColor = Color.DarkGray;
            }
            labUserMessg.Visible = false;
        }
        //获取焦点时触发
        private void UserPassWordGotFocus(object sender, EventArgs e)
        {
            if (UserPassWord.Text == "PassWord")
            {
                UserPassWord.Text = "";
                UserPassWord.ForeColor = Color.Black;
                UserPassWord.PasswordChar = '*';
            }
        }
        //失去焦点时触发
        private void UserPassWordLostFocus(object sender, EventArgs e)
        {
            if (UserPassWord.Text == "")
            {
                UserPassWord.Text = "PassWord";
                UserPassWord.ForeColor = Color.DarkGray;
                UserPassWord.PasswordChar = '\0';
            }
            labPwdMessg.Visible = false;
        }
        #endregion

        #region 系统托盘右键菜单
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region 登录功能

        TeacherBLL teacherBLL = new TeacherBLL();
        StudentBLL studentBLL = new StudentBLL();

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            //判断账号是否为空
            if(UserName.Text.Equals("User ID") || UserName.Text.Equals(""))
            {
                labUserMessg.Visible = true;
                labUserMessg.Text = "账号为空,请输入";
                return;
            }

            //判断密码是否为空
            if (UserPassWord.Text.Equals("PassWord") || UserPassWord.Text.Equals(""))
            {
                labPwdMessg.Visible = true;
                labPwdMessg.Text = "密码为空,请输入";
                return;
            }

            //传回用户id获取信息
            StudentEntity student = studentBLL.StudentDetail(UserName.Text);
            TeacherEntity teacher = teacherBLL.TeacherDetail(UserName.Text);

            if (student==null && teacher==null)
            {
                labUserMessg.Visible = true;
                labUserMessg.Text = "用户名错误";
                return;
            }

            if (teacher != null)
            {
                if (teacher.Pwd.Equals(UserPassWord.Text))
                {
                    //让所有属于教师的窗口,传入教师ID
                    TeacharScreen teacharScreen = new TeacharScreen();
                    teacharScreen.UserName = UserName.Text;
                    teacharScreen.Show();
                    this.Hide();
                    return;
                }
            }

            if (student != null)
            {
                if (student.Pwd.Equals(UserPassWord.Text))
                {
                    //让所有属于学生的窗口,传入学生ID
                    StudentScreen studentScreen = new StudentScreen();
                    studentScreen.UserName = UserName.Text;
                    studentScreen.Show();
                    this.Hide();
                    return;
                }
            }

            labPwdMessg.Visible = true;
            labPwdMessg.Text = "密码错误";
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            UserName.Text = "User ID";
            UserName.ForeColor = Color.DarkGray;
            UserPassWord.Text = "PassWord";
            UserPassWord.ForeColor = Color.DarkGray;
            UserPassWord.PasswordChar= '\0';
        }

        #endregion

    }
}
