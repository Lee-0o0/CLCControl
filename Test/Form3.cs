using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Model;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Name = "测试";

            var buttons = propertyGrid1.Controls.OfType<ToolStrip>().FirstOrDefault()?.Items;
            if (buttons != null &&
                buttons.Count >= 2 &&
                buttons[buttons.Count - 1] is ToolStripButton && // could test Text...
                buttons[buttons.Count - 2] is ToolStripSeparator)
            {
                buttons[buttons.Count - 1].Visible = false;
                buttons[buttons.Count - 2].Visible = false;
            }

            ToolStrip toolStrip= propertyGrid1.Controls.OfType<ToolStrip>().FirstOrDefault();
            if(toolStrip != null)
            {
                toolStrip.CanOverflow = true;
                toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                toolStrip.GripStyle = ToolStripGripStyle.Visible;
            }

            for (int i = 0; i < 5; i++)
            {
                ToolStripButton toolStripButton = new ToolStripButton();
                toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
                toolStripButton.Text = "测试"+i;
                buttons.Add(toolStripButton);
            }

            propertyGrid1.SelectedObject = student;
        }
    }
}
