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
        private static CLCMessageBox[] MESSAGE_BOX_POOL;      // 池
        public static int POOL_SIZE = 10;                     // 池的大小
        private static int IDLE_NUM = 0;                      // 当前池中空闲的窗体数量
        #endregion

        #region 窗体字段
        private bool inPool;
        private MessageBoxStatus status;
        private int showSeconds;
        #endregion

        private CLCMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 消息消息提示框
        /// </summary>
        /// <param name="msg">消息内容</param>
        public static void ShowMessageBox(string msg)
        {
            ShowMessageBox(msg, MessageType.INFO);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="type">消息框样式：提醒、成功、警告、失败</param>
        /// <param name="seconds">消息框持续时间(单位秒)，默认3秒</param>
        /// <param name="position">消息框显示位置</param>
        /// <param name="parent">父类界面</param>
        public static void ShowMessageBox(string msg, MessageType type, int showSeconds = 3, MessageBoxPosition position = MessageBoxPosition.SCREEN_CENTER, Form parent = null)
        {
            CLCMessageBox messageBox = GetCLCMessageBox();

            messageBox.showSeconds = showSeconds;
            messageBox.SetMessage(msg, type);
            messageBox.SetPosition(position, parent);

            if (messageBox.inPool)
            {
                IDLE_NUM--;
            }
            messageBox.status = MessageBoxStatus.START;

            messageBox.SetTimer();

            messageBox.Show();
        }

        /// <summary>
        /// 获取消息框
        /// </summary>
        /// <returns></returns>
        private static CLCMessageBox GetCLCMessageBox()
        {
            // 初始化池
            if (MESSAGE_BOX_POOL == null)
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

            return messageBox;
        }

        /// <summary>
        /// 设置消息内容并动态改变窗体的高度
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="type">消息框样式</param>
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

        /// <summary>
        /// 设置消息框位置
        /// </summary>
        /// <param name="position">位置</param>
        /// <param name="parent">父类界面</param>
        private void SetPosition(MessageBoxPosition position, Form parent = null)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            this.StartPosition = FormStartPosition.Manual;

            if (parent != null)
            {
                int parentWidth = parent.Width;
                int parentHeight = parent.Height;
                int x = parent.Left;
                int y = parent.Top;

                switch (position)
                {
                    case MessageBoxPosition.PARENT_CENTER:
                        this.Location = new Point(x + (parentWidth - Width) / 2, y + (parentHeight - Height) / 2);
                        break;
                    case MessageBoxPosition.PARENT_LEFT_TOP:
                        this.Location = new Point(x + 10, y + 10);
                        break;
                    case MessageBoxPosition.PARENT_LETF_BOTTOM:
                        this.Location = new Point(x + 10, y + parentHeight - Height - 10);
                        break;
                    case MessageBoxPosition.PARENT_RIGHT_TOP:
                        this.Location = new Point(x + parentWidth - Width - 10, y + 10);
                        break;
                    case MessageBoxPosition.PARENT_RIGHT_BOTTOM:
                        this.Location = new Point(x + parentWidth - Width - 10, y + parentHeight - Height - 10);
                        break;
                }
                return;
            }

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
                default:
                    this.StartPosition = FormStartPosition.CenterScreen;
                    break;
            }
        }

        /// <summary>
        /// 设置定时器
        /// </summary>
        private void SetTimer()
        {
            System.Windows.Forms.Timer timer = this.GetTimer();
            timer.Enabled = true;
            timer.Interval = 1;
            timer.Start();
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
                this.GetTimer().Stop();
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 获取定时器
        /// </summary>
        /// <returns></returns>
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
                    timer1.Interval = showSeconds*1000;
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
                            this.GetTimer().Stop();
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
