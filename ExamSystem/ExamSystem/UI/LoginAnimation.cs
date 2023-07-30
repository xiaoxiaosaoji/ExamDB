using AxWMPLib;
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
    public partial class LoginAnimation : Form
    {
        public LoginAnimation()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.windowlessVideo = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.enableContextMenu = false;
        }

        private void LoginAnimation_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "C:\\Users\\Ajax\\Desktop\\素材\\未命名草稿.mp4";
            axWindowsMediaPlayer1.settings.volume = 0;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer1.DoubleClickEvent += AxWindowsMediaPlayer1_DoubleClickEvent;
        }

        private void AxWindowsMediaPlayer1_DoubleClickEvent(object sender, _WMPOCXEvents_DoubleClickEvent e)
        {
            axWindowsMediaPlayer1.fullScreen = false; ;
            throw new NotImplementedException();
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            throw new NotImplementedException();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity == 0)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Hide();
        }
    }
}
