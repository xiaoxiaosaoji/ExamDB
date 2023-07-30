using BLL;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UI
{
    public partial class ExamManagement : Form
    {
        public ExamManagement()
        {
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        #region 单列模式
        private static ExamManagement frm;
        public static ExamManagement CreateFrom()
        {
            if (frm == null || frm.IsDisposed)
            {
                //当实例不存在或实例被释放时
                frm = new ExamManagement();
            }
            return frm;
        }

        #endregion
        /// <summary>
        /// 用于记录谁登录此窗口
        /// </summary>
        /// <param name="UserName">用户ID</param>
        public string UserName { get; set; }

        SubjectBLL subjectBLL = new SubjectBLL();
        TopicBLL topicBLL = new TopicBLL();
        TeacherBLL teacherBLL = new TeacherBLL();
        TitleListBLL titleListBLL = new TitleListBLL();

        private void ExamManagement_Load(object sender, EventArgs e)
        {
            //渲染学习阶段以及科目
            LearningPhase();
            //渲染班级列表
            ClassList();
            //判断班级是否有考试
            Time();
        }

        #region 渲染学习阶段
        
        //学习阶段combox列表渲染
        public void LearningPhase()
        {
            int[] learningPhase = subjectBLL.SubjectGradeLevel();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("GradeLevel", typeof(int));
            dt1.Columns.Add("Name", typeof(string));
            for (int i = 0; i < learningPhase.Length; i++)
            {
                dt1.Rows.Add(new object[] { learningPhase[i], $"第{i + 1}阶段" });
            }
            comboBoxLearningPhase.DisplayMember = "Name";
            comboBoxLearningPhase.ValueMember = "GradeLevel";
            comboBoxLearningPhase.DataSource = dt1;
            comboBoxLearningPhase.SelectedIndex = 0;
        }
        #endregion

        #region 渲染对应学习阶段的科目列表
        //当学习阶段发生改变时重新渲染科目列表
        private void comboBoxLearningPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SubjectEntity> subjects = subjectBLL.SubjectList(int.Parse(comboBoxLearningPhase.SelectedValue.ToString()));
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("SName", typeof(string));
            for (int i = 0; i < subjects.Count; i++)
            {
                dt2.Rows.Add(new object[] { subjects[i].ID, subjects[i].SName });
            }
            comboBoxSubject.DisplayMember = "SName";
            comboBoxSubject.ValueMember = "ID";
            comboBoxSubject.DataSource = dt2;
            comboBoxSubject.SelectedIndex = 0;
        }

        //科目切换时渲染对应的题目
        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {  
            SubjectList();
            if (btnExamStart.Text.Equals("开始考试"))
            {
                labelExamTime.Text = "";
            }
        }
        #endregion

        #region 渲染对应科目的题目
        //渲染题目列表
        public void SubjectList()
        {
            
            flowLayoutPanel1.Controls.Clear();
            List<TopicEntity> topics = topicBLL.TopocList(int.Parse(comboBoxSubject.SelectedValue.ToString()));
            int count = 0;
            numericUpDownCount.Maximum = topics.Count;
            for (int i = 0; i < topics.Count; i++)
            {
                #region 性能要求太大
                //Panel panel = new Panel();
                //panel.Width = flowLayoutPanel1.Width-30;
                //panel.Height = 180;
                //panel.Location = new Point(0, 20*i);
                //panel.Dock = DockStyle.Top;
                //panel.BackColor = Color.White;
                //panel.Margin = new Padding(0,0,0,20);

                //Label labelTopicName = new Label();
                //labelTopicName.Name = topics[i].ID.ToString();
                //labelTopicName.Text = $"{i+1}. "+topics[i].Title;
                //labelTopicName.Width = panel.Width;
                //labelTopicName.Height = 80;
                //labelTopicName.BackColor = Color.LightSkyBlue;
                //labelTopicName.Padding = new Padding(10);
                //labelTopicName.ForeColor= Color.White;
                //labelTopicName.Margin = new Padding(5);
                //labelTopicName.Click += new EventHandler(LabelTopicName_Click);

                //Label labelA = new Label();
                //labelA.Text = "A. "+topics[i].answerA;
                //labelA.AutoSize = false;
                //labelA.Width = panel.Width/2-20;
                //labelA.Height = 40;
                //labelA.Location = new Point(10, labelTopicName.Height + 5);

                //Label labelB = new Label();
                //labelB.Text = "B. " + topics[i].answerB;
                //labelB.AutoSize = false;
                //labelB.Width = panel.Width / 2 - 20;
                //labelB.Height = 40;
                //labelB.Location = new Point(labelA.Width+30, labelTopicName.Height + 5);

                //Label labelC = new Label();
                //labelC.Text = "C. " + topics[i].answerC;
                //labelC.AutoSize = false;
                //labelC.Width = panel.Width / 2 - 20;
                //labelC.Height = 40;
                //labelC.Location = new Point(10, labelTopicName.Height + 15 + labelA.Height);

                //Label labelD = new Label();
                //labelD.Text = "D. " + topics[i].answerD;
                //labelD.AutoSize = false;
                //labelD.Width = panel.Width / 2 - 20;
                //labelD.Height = 40;
                //labelD.Location = new Point(labelA.Width + 30, labelTopicName.Height + 15 + labelB.Height);


                //panel.Controls.Add(labelTopicName);
                //panel.Controls.Add(labelA);
                //panel.Controls.Add(labelB);
                //panel.Controls.Add(labelC);
                //panel.Controls.Add(labelD);
                //flowLayoutPanel1.Controls.Add(panel);
                #endregion

                Label labelTopicName = new Label();
                labelTopicName.Name = topics[i].ID.ToString();
                labelTopicName.Text = $"{i + 1}. " + topics[i].Title;
                labelTopicName.Width = flowLayoutPanel1.Width;
                labelTopicName.Height = 80;
                labelTopicName.BackColor = Color.LightSkyBlue;
                labelTopicName.Padding = new Padding(10);
                labelTopicName.ForeColor = Color.White;
                labelTopicName.Margin = new Padding(5);
                labelTopicName.Click += new EventHandler(LabelTopicName_Click);
                labelTopicName.TextAlign=ContentAlignment.MiddleLeft;
                flowLayoutPanel1.Controls.Add(labelTopicName);
                count++;
            }
            labelCount.Text = count.ToString();
        }

        //获取已选取多少题目
        int countTrue = 0;
        private void LabelTopicName_Click(object sender, EventArgs e)
        {
            if (btnExamStart.Text.Equals("已开考"))
            {
                return;
            }
            Label label = (Label)sender;
            if (label.BackColor == Color.LightSkyBlue)
            {
                label.BackColor = Color.Pink;
                countTrue++;
            }
            else
            {
                label.BackColor = Color.LightSkyBlue;
                countTrue--;
            }
            labelCountTrue.Text = countTrue.ToString();
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
        #endregion

        #region 渲染班级列表
        //渲染班级
        private void ClassList()
        {
            int[] classArr = teacherBLL.TeacherClassList(UserName);
            for (int i = 0; i < classArr.Length; i++)
            {
                comboBoxClassList.Items.Add(classArr[i]);
            }
            comboBoxClassList.SelectedIndex = 0;
        }

        //班级切换
        private void comboBoxClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time();
            if (btnExamStart.Text.Equals("开始考试"))
            {
                labelExamTime.Text = "";
            }
        }
        #endregion

        #region 随机选题
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnExamStart.Text.Equals("已开考"))
                return;
            foreach (Label item in flowLayoutPanel1.Controls)
            {
                item.BackColor = Color.LightSkyBlue;
            }

            if (numericUpDownCount.Value == 0)
                return;

            Random random = new Random();
            int i = 0;
            while (true)
            {
                countTrue = int.Parse(numericUpDownCount.Value.ToString());
                int index = random.Next(0, int.Parse(numericUpDownCount.Maximum.ToString()));
                Label label = (Label)flowLayoutPanel1.Controls[index];
                if (label.BackColor == Color.LightSkyBlue)
                {
                    label.BackColor = Color.Pink;
                    i++;
                }
                if (i == numericUpDownCount.Value)
                {
                    labelCountTrue.Text = numericUpDownCount.Value.ToString();
                    return;
                }
            }
        }
        //取消全选
        private void button4_Click(object sender, EventArgs e)
        {
            if (btnExamStart.Text.Equals("已开考"))
                return;
            foreach (Label item in flowLayoutPanel1.Controls)
            {
                item.BackColor = Color.LightSkyBlue;
            }
        }

        #endregion

        #region 开启考试
        private void btnExamStart_Click(object sender, EventArgs e)
        {
            if (btnExamStart.Text.Equals("已开考"))
            {
                return;
            }
            if (int.Parse(labelCountTrue.Text) == 0)
            {
                MessageBox.Show("未选择任何题目");
                return;
            }
            TitleListEntity titleListEntity = new TitleListEntity();
            titleListEntity.uid = UserName;
            titleListEntity.sid = int.Parse(comboBoxSubject.SelectedValue.ToString());
            string titList = "";
            foreach (Label item in flowLayoutPanel1.Controls)
            {
                if (item.BackColor == Color.Pink)
                {
                    if (titList != "")
                        titList += ",";
                    titList += item.Name;
                }
            }
            titleListEntity.titleList = titList;
            titleListEntity.state = 1;
            titleListEntity.classid = int.Parse(comboBoxClassList.Text);
            titleListEntity.createTime = DateTime.Now;
            titleListEntity.subTime = DateTime.Now.AddMinutes(90);
            if (titleListBLL.TitleListADD(titleListEntity) > 0)
            {
                btnExamStart.Text = "已开考";
                btnExamStart.BackColor = Color.Green;
                labelExamTime.Text = "考试时间:" + titleListEntity.createTime.ToString() + " 至 " + titleListEntity.subTime.ToString();
                MessageBox.Show("当前考试已开始");
            }   
        }

        //考试时间判断
        public void Time()
        {
            TitleListEntity titleListEntity = titleListBLL.Detail(comboBoxClassList.Text, comboBoxSubject.SelectedValue.ToString());
            if (titleListEntity == null)
            {
                btnExamStart.Text = "开始考试";
                btnExamStart.BackColor = Color.OrangeRed;
                return;
            }
            if (titleListEntity.state == 1)
            {
                //时间比较
                if (DateTime.Compare(DateTime.Now, (DateTime)titleListEntity.subTime) > 0)
                {
                    titleListBLL.UpdateState(titleListEntity.id.ToString());
                    return;
                }
                btnExamStart.Text = "已开考";
                btnExamStart.BackColor = Color.Green;
                labelExamTime.Text = "考试时间:"+titleListEntity.createTime.ToString() + " 至 " + titleListEntity.subTime.ToString();
            }   
        }
        #endregion

        
    }
}
