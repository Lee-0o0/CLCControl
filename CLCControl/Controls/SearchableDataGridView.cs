using CLCControls.Components;
using CLCControls.Utils;
using System;
using System.Collections;
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
    /// <summary>
    /// 带搜索功能的DataGridView
    /// </summary>
    public partial class SearchableDataGridView : UserControlDropDown
    {
        /// <summary>
        /// 数据源
        /// </summary>
        private object dataSource;
        public object DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                OnDataSourceChanged();
            }
        }

        /// <summary>
        /// 实体类型
        /// </summary>
        private Type elementType;

        private object SelectedElement;


        /// <summary>
        /// 搜索框提示内容
        /// </summary>
        public string SearchTextBoxHint 
        { 
            set
            {
                searchTxt.WatermarkText = value;
            }
        }

        /// <summary>
        /// 搜索属性名
        /// </summary>
        public string[] SearchPropertyName { get; set; } 


        public SearchableDataGridView()
        {
            InitializeComponent();
        }

        public override void InitOnDisplay()
        {
            searchTxt.Text = "";
            
            base.InitOnDisplay();
        }

        private void OnDataSourceChanged()
        {
            acDgv.DataSource = dataSource;
            if (FatherControl != null && FatherControl is CLCComboBox)
            {
                ((CLCComboBox)FatherControl).DataSource = null;
            }

            if (dataSource == null)
                return;

            // 判断数据源是否为List
            // 判断数据源是否为可遍历类型
            Type dataSourceType = dataSource.GetType();
            try
            {
                Type enumerableType = dataSourceType.GetInterface("System.Collections.Generic.IEnumerable`1");
                if (enumerableType == null)
                    throw new Exception();
            }
            catch
            {
                elementType = null;
                return;
            }

            // 获取实体类型
            Type newType;
            if (dataSourceType.IsArray)
                newType = dataSourceType.GetElementType();
            else if (dataSourceType.IsGenericType)
                newType = dataSourceType.GetGenericArguments().First();
            else
                newType = null;

            elementType = newType;
        }


        /// <summary>
        /// 搜索框内容改变时
        /// </summary>
        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (elementType == null || SearchPropertyName == null)
                return;

            IList displayDataSource = GenericUtil.CreateList(elementType);

            IList dataSourceList = (IList)dataSource;
            foreach(var element in dataSourceList)
            {
                string text = "";
                foreach (string propertyName in SearchPropertyName)
                {
                    PropertyInfo propertyInfo = elementType.GetProperty(propertyName);
                    text += propertyInfo?.GetValue(element, null)?.ToString() + "&";
                }
                if (text.Contains(searchTxt.Text.Trim()))
                    displayDataSource.Add(element);
            }

            acDgv.DataSource = displayDataSource;
            acDgv.Refresh();
        }

        /// <summary>
        /// 在搜索框中按下 ↓ 时，焦点移到数据表
        /// </summary>
        private void SearchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                acDgv.Focus();
        }

        /// <summary>
        /// 在清空按钮中按下 ↓ 时，焦点移到数据表
        /// </summary>
        private void ClearBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                acDgv.Focus();
        }

        /// <summary>
        /// 清空
        /// </summary>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            if(FatherControl != null && FatherControl is CLCComboBox)
            {
                ((CLCComboBox)FatherControl).DataSource = null;
                ((CLCComboBox)FatherControl).DisplayMember = ((CLCComboBox)FatherControl).CLCDisplayMember;
            }
        }

        /// <summary>
        /// 下拉控件关闭时
        /// </summary>
        public override void PopupClosedEvent(object sender, ToolStripDropDownClosedEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = acDgv.SelectedRows;
            if (rows.Count != 1)
                return;

            if ("关闭".Equals(sender.ToString()))
            {
                SelectedElement = rows[0].Cells[0].Value;
                if (FatherControl is CLCComboBox comboBox)
                {
                    if (SelectedElement.GetType() == elementType)
                    {
                        IList list = GenericUtil.CreateList(elementType);
                        list.Add(SelectedElement);
                        comboBox.DataSource = list;
                    }
                    else
                    {
                        comboBox.DataSource = new List<string>() { SelectedElement.ToString() };
                    }
                    comboBox.DisplayMember = comboBox.CLCDisplayMember;
                    comboBox.SelectedIndex = 0;
                }
            }
        }


        private void AcDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            PopupClosedEvent("关闭", null);
            Popup.Close();
        }

        private void AcDgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopupClosedEvent("关闭", null);
                Popup.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && acDgv.Focused)
                return true;
            else
                return false;
        }

    }
}
