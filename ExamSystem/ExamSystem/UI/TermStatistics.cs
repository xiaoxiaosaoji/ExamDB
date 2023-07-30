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
    public partial class TermStatistics : Form
    {
        public TermStatistics()
        {
            InitializeComponent();
        }

        #region 单列模式
        private static TermStatistics frm;
        public static TermStatistics CreateFrom()
        {
            if (frm == null || frm.IsDisposed)
            {
                //当实例不存在或实例被释放时
                frm = new TermStatistics();
            }
            return frm;
        }
        #endregion

        /// <summary>
        /// 用于记录谁登录此窗口
        /// </summary>
        /// <param name="UserName">用户ID</param>
        public string UserName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public string ClassID { get; set; }

        SubjectBLL subjectBLL = new SubjectBLL();
        StudentBLL studentBLL = new StudentBLL();
        AccountBLL accountBLL = new AccountBLL();

        private void TermStatistics_Load(object sender, EventArgs e)
        {
            //科目渲染
            LearningPhase();
            //班级按钮渲染
            StudentClass();
            //学生成绩
            StudentList();

            panelClassBtn.Controls[0].BackColor = Color.LightGray;
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
        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentList();
        }
        #endregion

        #region 班级渲染

        TeacherBLL teacherBLL = new TeacherBLL();
        //班级按钮渲染
        public void StudentClass()
        {
            panelClassBtn.Controls.Clear();
            int[] classArr = teacherBLL.TeacherClassList(UserName);
            ClassID = classArr[0].ToString();
            if (classArr == null)
            {
                return;
            }
            for (int i = 0; i < classArr.Length; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i;
                btn.Text = classArr[i].ToString();
                btn.TabIndex = i;
                btn.Height = 40;
                btn.Width = 100;
                btn.Location = new Point(120 * i, 0);
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
            ClassID = button.Text;
            StudentList();
        }

        #endregion

        #region 渲染学生和成绩
        public void StudentList()
        {
            flowLayoutPanel1.Controls.Clear();
            List<StudentEntity> students = studentBLL.StudentClassList(ClassID);
            for (int i = 0; i < students.Count; i++)
            {
                Label label = new Label();
                label.AutoSize = false;
                string stuName = students[i].Name;
                if (stuName.Length == 2)
                    stuName += "   ";
                label.Text = stuName + " (" + students[i].ID + ")";
                label.Height = 45;
                label.Width = 300;
                label.TextAlign=ContentAlignment.MiddleLeft;
                label.Location = new Point(200 * i, 30 * i);
                label.Margin = new Padding(5);

                AccountEntity accountEntity = accountBLL.StudentFraction(students[0].ID, comboBoxSubject.SelectedValue.ToString());
                
                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.Height = 45;
                lbl.Width = 50;
                lbl.Location = new Point(label.Width - lbl.Width, 0);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                if (accountEntity == null)
                    lbl.Text = "";
                else
                {
                    lbl.Text = accountEntity.Fraction.ToString();
                    if (accountEntity.Fraction >= 60)
                        lbl.ForeColor = Color.Green;
                    else
                        lbl.ForeColor = Color.Red;
                }

                label.Controls.Add(lbl);

                flowLayoutPanel1.Controls.Add(label);

            }
        }
        #endregion

        //清除考试成绩
        private void button3_Click(object sender, EventArgs e)
        {
            List<StudentEntity> students = studentBLL.StudentClassList(ClassID);
            foreach (StudentEntity item in students)
            {
                accountBLL.DeleteStudentFraction(item.ID, int.Parse(comboBoxSubject.SelectedValue.ToString()));
            }
            StudentList();
        }
    }
}
