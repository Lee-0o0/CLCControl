using CLCControls.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Controls
{
    public partial class UserControlDropDown : UserControl
    {
        public object FatherControl { get; set; }
        public Popup Popup { get; set; }

        public UserControlDropDown()
        {
            InitializeComponent();
        }

        public virtual void PopupClosedEvent(object sender, ToolStripDropDownClosedEventArgs e)
        {

        }

        public virtual void InitOnDisplay()
        {

        }
    }
}
