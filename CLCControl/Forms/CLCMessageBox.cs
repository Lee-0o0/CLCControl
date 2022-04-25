using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLCControl.Forms
{
    public partial class CLCMessageBox : Form
    {
        /// <summary>
        /// 消息框类型
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// 成功
            /// </summary>
            SUCCESS,
            /// <summary>
            /// 提示
            /// </summary>
            INFO,
            /// <summary>
            /// 警告
            /// </summary>
            WARN,
            /// <summary>
            /// 错误
            /// </summary>
            ERROR
        }

        /// <summary>
        /// 消息框的状态
        /// </summary>
        private enum MessageBoxStatus
        {
            /// <summary>
            /// 开始，准备显示
            /// </summary>
            START,
            /// <summary>
            /// 正在显示
            /// </summary>
            SHOW,
            /// <summary>
            /// 关闭，准备隐藏
            /// </summary>
            CLOSE,
            /// <summary>
            /// 隐藏，空闲状态
            /// </summary>
            IDLE
        }

        /// <summary>
        /// 消息框的位置
        /// </summary>
        public enum MessageBoxPosition
        {
            /// <summary>
            /// 屏幕中间
            /// </summary>
            SCREEN_CENTER,
            /// <summary>
            /// 屏幕左上角
            /// </summary>
            SCREEN_LEFT_TOP,
            /// <summary>
            /// 屏幕左下角
            /// </summary>
            SCREEN_LETF_BOTTOM,
            /// <summary>
            /// 屏幕右上角
            /// </summary>
            SCREEN_RIGHT_TOP,
            /// <summary>
            /// 屏幕右下角
            /// </summary>
            SCREEN_RIGHT_BOTTOM,
            /// <summary>
            /// 父窗体中间
            /// </summary>
            PARENT_CENTER,
            /// <summary>
            /// 父窗体左上角
            /// </summary>
            PARENT_LEFT_TOP,
            /// <summary>
            /// 父窗体左下角
            /// </summary>
            PARENT_LETF_BOTTOM,
            /// <summary>
            /// 父窗体右上角
            /// </summary>
            PARENT_RIGHT_TOP,
            /// <summary>
            /// 父窗体右下角
            /// </summary>
            PARENT_RIGHT_BOTTOM
        }

        #region 池的相关设置
        public static int POOL_SIZE = 10;

        private static int IDLE_NUM = 0;

        private static CLCMessageBox[] MESSAGE_BOX_POOL;
        #endregion

        private bool inPool;
        private MessageBoxStatus status;


        private CLCMessageBox()
        {
            InitializeComponent();
        }

        public static void ShowMessageBox(string msg, MessageType type, MessageBoxPosition position = MessageBoxPosition.SCREEN_CENTER)
        {
            // 初始化池
            if(MESSAGE_BOX_POOL == null)
            {
                MESSAGE_BOX_POOL = new CLCMessageBox[POOL_SIZE];
                IDLE_NUM = POOL_SIZE;
                for (int i = 0; i < POOL_SIZE; i++)
                {
                    MESSAGE_BOX_POOL[i] = new CLCMessageBox();
                    MESSAGE_BOX_POOL[i].Name = "messageBox" + i.ToString();
                    MESSAGE_BOX_POOL[i].status = MessageBoxStatus.IDLE;
                    MESSAGE_BOX_POOL[i].inPool = true;
                }
            }

            // 要显示的消息框
            CLCMessageBox messageBox = null;

            if (IDLE_NUM > 0)
            {
                // 池中有空闲的消息框
                for (int i = 0; i < POOL_SIZE; i++)
                {
                    messageBox = MESSAGE_BOX_POOL[i];
                    if (messageBox.status == MessageBoxStatus.IDLE)
                    {
                        break;
                    }
                }
            }
            else
            {
                // 池中没有空闲的消息框
                messageBox = new CLCMessageBox();
                messageBox.inPool = false;
            }

            messageBox.SetMessage(msg, type);
            messageBox.SetPosition(position);

            if (messageBox.inPool)
            {
                IDLE_NUM--;
            }
            messageBox.status = MessageBoxStatus.START;

            messageBox.GetTimer().Enabled = true;
            messageBox.GetTimer().Interval = 1;
            messageBox.GetTimer().Start();

            messageBox.Show();
        }

        private void SetMessage(string msg, MessageType type)
        {
            // 根据消息类型设置背景色及图标
            switch (type)
            {
                case MessageType.SUCCESS:
                    this.msgLbl.BackColor = this.BackColor = Color.DarkSeaGreen;
                    this.logoPic.Image = Properties.Resources.success;
                    break;
                case MessageType.INFO:
                    this.msgLbl.BackColor = this.BackColor = Color.DeepSkyBlue;
                    this.logoPic.Image = Properties.Resources.info;
                    break;
                case MessageType.WARN:
                    this.msgLbl.BackColor = this.BackColor = Color.Orange;
                    this.logoPic.Image = Properties.Resources.warn;
                    break;
                case MessageType.ERROR:
                    this.msgLbl.BackColor = this.BackColor = Color.Red;
                    this.logoPic.Image = Properties.Resources.error;
                    break;
            }

            msgLbl.Text = msg;

            // 计算msgLbl的高度，动态改变窗体的高度
            Graphics g = msgLbl.CreateGraphics();
            SizeF size = g.MeasureString(msgLbl.Text, msgLbl.Font, msgLbl.Width);
            
            int height = (int)size.Height;
            msgLbl.Height = (height == 0 ? msgLbl.Height : height);
            msgLbl.AutoSize = false;

            this.Height = msgLbl.Height + 40;

            this.logoPic.Location = new Point(this.logoPic.Location.X, (this.Height - this.logoPic.Height) / 2);
            this.msgLbl.Location = new Point(this.msgLbl.Location.X, (this.Height - this.msgLbl.Height) / 2);
            this.closePic.Location = new Point(this.closePic.Location.X, (this.Height - this.closePic.Height) / 2);
        }

        private void SetPosition(MessageBoxPosition position)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            this.StartPosition = FormStartPosition.Manual;
            switch (position)
            {
                case MessageBoxPosition.SCREEN_CENTER:
                    this.Location = new Point((screenWidth - Width) / 2,(screenHeight - Height) / 2);
                    break;
                case MessageBoxPosition.SCREEN_LEFT_TOP:
                    this.Location = new Point(10, 10);
                    break;
                case MessageBoxPosition.SCREEN_LETF_BOTTOM:
                    this.Location = new Point(10, screenHeight - Height - 10);
                    break;
                case MessageBoxPosition.SCREEN_RIGHT_TOP:
                    this.Location = new Point(screenWidth - Width - 10,10);
                    break;
                case MessageBoxPosition.SCREEN_RIGHT_BOTTOM:
                    this.Location = new Point(screenWidth - Width - 10, screenHeight - Height - 10);
                    break;
                case MessageBoxPosition.PARENT_CENTER:
                    
                    break;
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void ClosePic_Click(object sender, EventArgs e)
        {
            while (this.Opacity > 0)
            {
                Thread.Sleep(10);
                Opacity -= 0.1;
            }
            if (this.inPool)
            {
                this.status = MessageBoxStatus.IDLE;
                IDLE_NUM++;
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }

        private System.Windows.Forms.Timer GetTimer()
        {
            return timer1;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (this.status)
            {
                case MessageBoxStatus.START:
                    timer1.Interval = 10;
                    this.Opacity += 0.1;
                    if(this.Opacity == 1)
                    {
                        this.status = MessageBoxStatus.SHOW;
                    }
                    break;
                case MessageBoxStatus.SHOW:
                    timer1.Interval = 3500;
                    this.status = MessageBoxStatus.CLOSE;
                    break;
                case MessageBoxStatus.CLOSE:
                    timer1.Interval = 10;
                    this.Opacity -= 0.1;
                    if((int)(this.Opacity * 10) == 0)
                    {
                        if (this.inPool)
                        {
                            this.status = MessageBoxStatus.IDLE;
                            IDLE_NUM++;
                            this.Hide();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    break;
            }
        }
    }
}
