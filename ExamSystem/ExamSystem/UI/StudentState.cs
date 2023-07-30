using BLL;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class StudentState : Form
    {
        public StudentState()
        {
            InitializeComponent();
        }

        #region 单列模式
        //单例模式
        private static StudentState frm; 
        public static StudentState CreateFrom()
        {
            if (frm == null || frm.IsDisposed)
            {
                //当实例不存在或实例被释放时
                frm = new StudentState();
            }
            return frm;
        }
        #endregion

        /// <summary>
        /// 用于记录谁登录此窗口
        /// </summary>
        /// <param name="UserName">用户ID</param>
        public string UserName { get; set; }

        private void StudentState_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SqlDependency.Start(conn); //传入连接字符串,启动基于数据库的监听
            Update(conn);
            //窗体加载完毕渲染班级
            StudentClass();
            //窗体加载完毕渲染学生
            StudentList();

            panelClassBtn.Controls[0].BackColor = Color.LightGray;
        }

        #region 班级渲染

        TeacherBLL teacherBLL = new TeacherBLL();
        //班级按钮渲染
        public void StudentClass()
        {
            panelClassBtn.Controls.Clear();
            int[] classArr = teacherBLL.TeacherClassList(UserName);
            if (classArr == null)
            {
                labClass.Text = "无所带班级";
                return;
            }
            else
                labClass.Text = classArr[0].ToString();
            for (int i = 0; i < classArr.Length; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i;
                btn.Text = classArr[i].ToString();
                btn.TabIndex = i;
                btn.Height = 40;
                btn.Width = 100;
                btn.TabStop = false;
                btn.Location=new Point(120*i,0);
                //为button添加点击事件
                btn.Click += new EventHandler(StudentClassBtn);
                panelClassBtn.Controls.Add(btn);
            }
        }
        //班级按钮事件
        public void StudentClassBtn(object sender, EventArgs e)
        {
            foreach (Button btn in panelClassBtn.Controls)
            {
                btn.BackColor = Color.White;
            }
            Button button = (Button)sender;
            button.BackColor = Color.LightGray;
            labClass.Text = button.Text;
            StudentList();
        }

        #endregion

        #region 学生渲染

        StudentBLL studentBLL = new StudentBLL();
        //渲染学生列表
        public void StudentList()
        {
            dt = studentBLL.StudentClassListDt(labClass.Text);
            flowLayoutPanelStudent.Controls.Clear();
            List<StudentEntity> students = studentBLL.StudentClassList(labClass.Text);
            int lineSize = 0;
            int cSize = 0;
            for (int i = 0; i < students.Count; i++)
            {
                Panel panel = new Panel();
                panel.Name = students[i].ID;
                panel.Location = new Point(250 * i, 350 * i);    
                panel.Width = 220;
                panel.Height = 220;
                panel.BackColor = Color.White;
                panel.Margin=new Padding(8);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = imageList1.Images[0];
                pictureBox.Width = 85;
                pictureBox.Height = 75;
                pictureBox.Location = new Point(12, 12);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                Label labelOnLine = new Label();
                labelOnLine.Name = students[i].ID+"OnLine";
                labelOnLine.AutoSize = false;
                labelOnLine.Width = 70;
                labelOnLine.Height = 30;
                labelOnLine.ForeColor = Color.White;
                labelOnLine.TextAlign=ContentAlignment.MiddleCenter;
                labelOnLine.Location=new Point(panel.Width-labelOnLine.Width,10);
                if (students[i].Online == true)
                {
                    labelOnLine.BackColor = Color.MediumSeaGreen;
                    labelOnLine.Text = "在线";
                    lineSize++;
                }
                else
                {
                    labelOnLine.BackColor = Color.IndianRed;
                    labelOnLine.Text = "离线";
                }
                cSize++;

                Label labelStuId = new Label();
                labelStuId.AutoSize = true;
                labelStuId.Text = "学号:";
                labelStuId.Location = new Point(10, 100);
                labelStuId.Font = new Font(labelStuId.Font.FontFamily,14,FontStyle.Bold);


                Label labelStuName = new Label();
                labelStuName.AutoSize = true;
                labelStuName.Text = "姓名:";
                labelStuName.Location = new Point(10, 135);
                labelStuName.Font = new Font(labelStuId.Font.FontFamily, 14, FontStyle.Bold);


                Label StuId = new Label();
                StuId.Text = students[i].ID;
                StuId.AutoSize = true;
                StuId.Location = new Point(70,100);
                StuId.Font = new Font(labelStuId.Font.FontFamily, 12, FontStyle.Bold);


                Label StuName = new Label();
                StuName.AutoSize = true;
                StuName.Text = students[i].Name;
                StuName.Location = new Point(70, 135);
                StuName.Font = new Font(labelStuId.Font.FontFamily, 12, FontStyle.Bold);


                Button btnOnline = new Button();
                btnOnline.Name = "btno"+students[i].ID;
                btnOnline.Text = "强制下线";
                btnOnline.Width = panel.Width / 2 - 20;
                btnOnline.Height = 40;
                btnOnline.BackColor = Color.Orange;
                btnOnline.ForeColor = Color.White;
                btnOnline.FlatStyle = FlatStyle.Flat;
                btnOnline.FlatAppearance.BorderSize = 0;
                btnOnline.Cursor = Cursors.Hand;
                btnOnline.Location = new Point(5, panel.Height - btnOnline.Height-5);
                btnOnline.Click +=new EventHandler(BtnOnline_Click);
                btnOnline.Font = new Font(labelStuId.Font.FontFamily, 12, FontStyle.Bold);


                Button btnDetail = new Button();
                btnDetail.Name = "btnd" + students[i].ID;
                btnDetail.Text = "查看信息";
                btnDetail.Width = panel.Width / 2 - 20;
                btnDetail.Height = 40;
                btnDetail.BackColor = Color.DeepSkyBlue;
                btnDetail.ForeColor = Color.White;
                btnDetail.FlatStyle = FlatStyle.Flat;
                btnDetail.FlatAppearance.BorderSize = 0;
                btnDetail.Cursor = Cursors.Hand;
                btnDetail.Location = new Point(35+btnOnline.Width, panel.Height - btnDetail.Height - 5);
                btnDetail.Click += new EventHandler(BtnDetail_Click);
                btnDetail.Font = new Font(labelStuId.Font.FontFamily, 12, FontStyle.Bold);



                panel.Controls.Add(pictureBox);
                panel.Controls.Add(labelOnLine);
                panel.Controls.Add(labelStuId);
                panel.Controls.Add(labelStuName);
                panel.Controls.Add(StuId);
                panel.Controls.Add(StuName);
                panel.Controls.Add(btnDetail);
                panel.Controls.Add(btnOnline);

                flowLayoutPanelStudent.Controls.Add(panel);
            }
            onlieSize.Text = lineSize.ToString();
            classSize.Text = cSize.ToString();
        }
        //强制学生下线
        private void BtnOnline_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string id = button.Name;
            string temp = id.Substring(4);
            StudentEntity student = studentBLL.StudentDetail(temp);
            student.Online = false;
            studentBLL.StudentUpdate(student);
        }
        //查看学生信息
        private void BtnDetail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能未开发");
        }
        #endregion

        #region 监听数据库刷新学生状态
        //监听数据库数据
        DataTable dt = new DataTable();
        string conn = "server=.;database=ExamDB;uid=sa;pwd=123456;";
        SqlDependency dependency;
        public void Update(string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sql = "select Online from dbo.Student";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            Update(conn);
            this.Invoke(new MethodInvoker(delegate
            {
                DataTable tempDt = new DataTable();
                tempDt = studentBLL.StudentClassListDt(labClass.Text);
                string stuId = "";
                bool onLione = false;
                for (int i = 0; i < tempDt.Rows.Count; i++)
                {
                    if (tempDt.Rows[i]["Online"].ToString() != dt.Rows[i]["Online"].ToString())
                    {
                        stuId = tempDt.Rows[i]["ID"].ToString();
                        onLione = bool.Parse(tempDt.Rows[i]["Online"].ToString());
                    }
                }
                Label label = (Label)GetControlInstance(flowLayoutPanelStudent, stuId + "OnLine");
                if (onLione)
                {
                    label.BackColor = Color.MediumSeaGreen;
                    label.Text = "在线";
                    int j = int.Parse(onlieSize.Text);
                    j++;
                    onlieSize.Text = j.ToString();
                }
                else
                {
                    label.BackColor = Color.IndianRed;
                    label.Text = "离线";
                    int j = int.Parse(onlieSize.Text);
                    j--;
                    onlieSize.Text = j.ToString();
                }
                dt = studentBLL.StudentClassListDt(labClass.Text); ;
            })); //委托函数的参数不加之前的定义
            return;
        }
        /// <summary>
        /// 根据指定容器和控件名字，获得控件
        /// </summary>
        /// <param name="obj">容器</param>
        /// <param name="strControlName">控件名字</param>
        /// <returns>控件</returns>
        private object GetControlInstance(object obj, string strControlName)
        {
            IEnumerator Controls = null;//所有控件
            Control c = null;//当前控件
            Object cResult = null;//查找结果
            if (obj.GetType() == this.GetType())//窗体
            {
                Controls = this.Controls.GetEnumerator();
            }
            else//控件
            {
                Controls = ((Control)obj).Controls.GetEnumerator();
            }
            while (Controls.MoveNext())//遍历操作
            {
                c = (Control)Controls.Current;//当前控件
                if (c.HasChildren)//当前控件是个容器
                {
                    cResult = GetControlInstance(c, strControlName);//递归查找
                    if (cResult == null)//当前容器中没有，跳出，继续查找
                        continue;
                    else//找到控件，返回
                        return cResult;
                }
                else if (c.Name == strControlName)//不是容器，同时找到控件，返回
                {
                    return c;
                }
            }
            return null;//控件不存在
        }
    }
    #endregion


}
