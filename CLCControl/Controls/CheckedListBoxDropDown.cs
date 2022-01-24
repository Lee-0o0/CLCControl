using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Controls
{
    public partial class CheckedListBoxDropDown : UserControlDropDown
    {
        public object DataSource
        {
            get
            {
                return checkedListBox.DataSource;
            }
            set
            {
                checkedListBox.DataSource = value;
            }
        }

        public string DisplayMember
        {
            get
            {
                return checkedListBox.DisplayMember;
            }
            set
            {
                checkedListBox.DisplayMember = value;
            }
        }

        public string Separator { get; set; } = " , ";


        /// <summary>
        /// 构造方法
        /// </summary>
        public CheckedListBoxDropDown()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            checkedListBox.CheckOnClick = true;
            checkedListBox.IntegralHeight = false;
        }


        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="items">要选中的项</param>
        public void Select(params string[] items)
        {
            ClearSelected();
            foreach (string item in items)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    PropertyInfo propertyInfo = checkedListBox.Items[i].GetType().GetProperty(DisplayMember);
                    if (propertyInfo == null)
                        continue;
                    object value = propertyInfo.GetValue(checkedListBox.Items[i], null);
                    if (item.Equals(value.ToString()))
                    {
                        checkedListBox.SetItemChecked(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns></returns>
        public List<object> GetSelectedItem()
        {
            List<object> res = new List<object>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                res.Add(item);
            }
            return res;
        }

        /// <summary>
        /// 当父控件隐藏时触发
        /// </summary>
        public override void PopupClosedEvent(object sender, ToolStripDropDownClosedEventArgs e)
        {
            Type comboBoxType = typeof(CLCComboBox);
            if (comboBoxType.IsInstanceOfType(FatherControl))
            {
                ((CLCComboBox)FatherControl).DataSource = new List<string>() { GetShowText() };
                ((CLCComboBox)FatherControl).DisplayMember = DisplayMember;
                ((CLCComboBox)FatherControl).SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取选中项的表示文本
        /// </summary>
        /// <returns></returns>
        public string GetShowText()
        {
            List<string> res = new List<string>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                Type type = item.GetType();
                PropertyInfo propertyInfo = type.GetProperty(DisplayMember);
                if (propertyInfo != null)
                    res.Add(propertyInfo.GetValue(item, null)?.ToString());
            }
            return string.Join(Separator, res.ToArray());
        }

        /// <summary>
        /// 清空选中项
        /// </summary>
        public void ClearSelected()
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }
    }
}
