namespace UI
{
    partial class StudentScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timeClose = new System.Windows.Forms.Timer(this.components);
            this.Close = new System.Windows.Forms.Label();
            this.panelTabControl = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnGrade = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeClose
            // 
            this.timeClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.ForeColor = System.Drawing.Color.Gray;
            this.Close.Location = new System.Drawing.Point(938, 0);
            this.Close.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(63, 50);
            this.Close.TabIndex = 1;
            this.Close.Text = "X";
            this.Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Close_MouseDown);
            this.Close.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            this.Close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Close_MouseMove);
            // 
            // panelTabControl
            // 
            this.panelTabControl.BackColor = System.Drawing.Color.White;
            this.panelTabControl.Controls.Add(this.btnExit);
            this.panelTabControl.Controls.Add(this.btnSet);
            this.panelTabControl.Controls.Add(this.btnGrade);
            this.panelTabControl.Controls.Add(this.btnExam);
            this.panelTabControl.Controls.Add(this.pictureBox1);
            this.panelTabControl.Controls.Add(this.label2);
            this.panelTabControl.Controls.Add(this.label1);
            this.panelTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelTabControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTabControl.Location = new System.Drawing.Point(0, 0);
            this.panelTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.Size = new System.Drawing.Size(200, 800);
            this.panelTabControl.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.DimGray;
            this.btnExit.Image = global::UI.Properties.Resources.退出;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 231);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnExit.Size = new System.Drawing.Size(200, 60);
            this.btnExit.TabIndex = 7;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "退出登录";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSet
            // 
            this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnSet.ForeColor = System.Drawing.Color.DimGray;
            this.btnSet.Image = global::UI.Properties.Resources.设置;
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.Location = new System.Drawing.Point(0, 171);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSet.Name = "btnSet";
            this.btnSet.Padding = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnSet.Size = new System.Drawing.Size(200, 60);
            this.btnSet.TabIndex = 6;
            this.btnSet.TabStop = false;
            this.btnSet.Text = "系统设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnGrade
            // 
            this.btnGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrade.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrade.FlatAppearance.BorderSize = 0;
            this.btnGrade.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnGrade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrade.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnGrade.ForeColor = System.Drawing.Color.DimGray;
            this.btnGrade.Image = global::UI.Properties.Resources.jxiao;
            this.btnGrade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrade.Location = new System.Drawing.Point(0, 111);
            this.btnGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.Padding = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnGrade.Size = new System.Drawing.Size(200, 60);
            this.btnGrade.TabIndex = 5;
            this.btnGrade.TabStop = false;
            this.btnGrade.Text = "成绩信息";
            this.btnGrade.UseVisualStyleBackColor = true;
            this.btnGrade.Click += new System.EventHandler(this.btnGrade_Click);
            // 
            // btnExam
            // 
            this.btnExam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExam.FlatAppearance.BorderSize = 0;
            this.btnExam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnExam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnExam.ForeColor = System.Drawing.Color.DimGray;
            this.btnExam.Image = global::UI.Properties.Resources.星途学堂_考试_试卷;
            this.btnExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExam.Location = new System.Drawing.Point(0, 51);
            this.btnExam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExam.Name = "btnExam";
            this.btnExam.Padding = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnExam.Size = new System.Drawing.Size(200, 60);
            this.btnExam.TabIndex = 4;
            this.btnExam.TabStop = false;
            this.btnExam.Text = "阶段测试";
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.ExamLogo48x481;
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "考试系统";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 51);
            this.label1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Controls.Add(this.Close);
            this.panel2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 50);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            // 
            // btnMin
            // 
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMin.ForeColor = System.Drawing.Color.Gray;
            this.btnMin.Location = new System.Drawing.Point(876, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(63, 50);
            this.btnMin.TabIndex = 1;
            this.btnMin.Text = "—";
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            this.btnMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMin_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 750);
            this.panelMain.TabIndex = 4;
            // 
            // StudentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StudentScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacharScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeacharScreen_FormClosed);
            this.Load += new System.EventHandler(this.StudentScreen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            this.panelTabControl.ResumeLayout(false);
            this.panelTabControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timeClose;
        private System.Windows.Forms.Label Close;
        private System.Windows.Forms.Panel panelTabControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnMin;
        private System.Windows.Forms.Button btnGrade;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Panel panelMain;
    }
}