using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Components
{
    public partial class Popup : ToolStripDropDown
    {
        private Control childControl;

        public Popup() : base()
        {
            /*
            * 设置1px的内边距用于显示边框
            */
            Padding = new Padding(1);

        }

        public Popup(Control childControl) : this()
        {
            if (childControl == null)
                return;
            this.childControl = childControl;
            childControl.Dock = DockStyle.Fill;
            /*
             * ToolStripDropDown的Items可以通过ToolStripControlHost放置自定义控件
             */
            ToolStripControlHost toolStripControlHost = new ToolStripControlHost(childControl)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty
            };
            toolStripControlHost.AutoSize = false;
            this.Items.Add(toolStripControlHost);
        }

        /// <summary>
        /// 显示popup界面
        /// </summary>
        /// <param name="parent">父类控件</param>
        public void Show(Control parent)
        {
            // 以父控件的location为原点，参数点p的值是相对于原点的，计算参数点的屏幕坐标
            // 此处就是计算父控件左上角的屏幕坐标
            Point parentScreenLocation = parent.PointToScreen(new Point(0, 0));

            Point pt = parentScreenLocation;
            pt.Offset(0, parent.Height + 3);

            Size dropdownSize = GetPreferredSize(Size.Empty);
            Rectangle dropdownBounds = new Rectangle(pt, dropdownSize);

            if (dropdownBounds.Bottom <= Screen.GetWorkingArea(dropdownBounds).Bottom)
            {
                // 在父控件的下面显示
                base.Show(parent, new Point(0, parent.Height + 3), ToolStripDropDownDirection.BelowRight);
            }
            else
            {
                // 在父控件的上面显示
                base.Show(parent, new Point(0, -3), ToolStripDropDownDirection.AboveRight);
            }
            // 焦点自动移动到popup界面
            Focus();
        }
    }
}
