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
    /// 分类显示、可搜索的数据表
    /// </summary>
    public partial class CategoryDataGridView : UserControlDropDown
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

        Dictionary<string, IList> keyValuePairs;

        /// <summary>
        /// 选中的元素
        /// </summary>
        private object SelectedElement;


        /// <summary>
        /// 实体类型
        /// </summary>
        private Type elementType;

        /// <summary>
        /// 分类属性
        /// </summary>
        private string categoryProperty;
        public string CategoryProperty 
        {
            get
            {
                return categoryProperty;
            }
            set
            {
                categoryProperty = value;
                OnCategoryPropertyChanged();
            }
        }

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

        public CategoryDataGridView()
        {
            InitializeComponent();
        }

        public override void InitOnDisplay()
        {
            searchTxt.Text = "";
            base.InitOnDisplay();
        }

        /// <summary>
        /// 数据源改变时
        /// </summary>
        private void OnDataSourceChanged()
        {
            dataDgv.DataSource = null;
            categoryLst.Items.Clear();

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

            // 给数据表赋值
            GetDictionary();
        }

        /// <summary>
        /// 类别改变时
        /// </summary>
        private void OnCategoryPropertyChanged()
        {
            GetDictionary();
        }

        /// <summary>
        /// 将原始数据源由List<>转换为Dictionary，并赋值
        /// </summary>
        private void GetDictionary()
        {
            keyValuePairs = new Dictionary<string, IList>();
            if (dataSource == null ||
                string.IsNullOrEmpty(CategoryProperty) ||
                elementType == null)
            {
                return;
            }

            keyValuePairs.Add("--全部--", GenericUtil.CreateList(elementType));
            foreach (var i in (IList)dataSource)
            {
                string categoryValue = "";
                if (!string.IsNullOrEmpty(CategoryProperty))
                    categoryValue = elementType.GetProperty(CategoryProperty)?.GetValue(i, null)?.ToString();
                if (categoryValue == null)
                    categoryValue = "";

                if (keyValuePairs.ContainsKey(categoryValue))
                {
                    keyValuePairs[categoryValue].Add(i);
                }
                else
                {
                    IList list = GenericUtil.CreateList(elementType);
                    list.Add(i);
                    keyValuePairs.Add(categoryValue, list);
                }
                keyValuePairs["--全部--"].Add(i);
            }

            categoryLst.Items.Clear();
            categoryLst.Items.AddRange(keyValuePairs.Keys.ToArray());
            categoryLst.SelectedIndex = 0;
        }

        /// <summary>
        /// 选择的类别改变时
        /// </summary>
        private void CategoryLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = categoryLst.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedItem))
                return;

            dataDgv.DataSource = keyValuePairs[selectedItem];
            dataDgv.Refresh();
            SearchTxt_TextChanged(null, null);
        }

        /// <summary>
        /// 清空按钮
        /// </summary>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            if (FatherControl != null && FatherControl is CLCComboBox)
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
            DataGridViewSelectedRowCollection rows = dataDgv.SelectedRows;
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

        /// <summary>
        /// 双击选中
        /// </summary>
        private void DataDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            PopupClosedEvent("关闭", null);
            Popup.Close();
        }

        /// <summary>
        /// 按Enter键选中
        /// </summary>
        private void DataDgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopupClosedEvent("关闭", null);
                Popup.Close();
            }
        }

        /// <summary>
        /// 在搜索框中按下 ↓ 时，焦点移到数据表
        /// </summary>
        private void SearchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                categoryLst.Focus();
        }

        /// <summary>
        /// 在清空按钮中按下 ↓ 时，焦点移到数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                categoryLst.Focus();
        }


        /// <summary>
        /// 搜索框内容改变时
        /// </summary>
        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (elementType == null || SearchPropertyName == null)
                return;

            IList displayDataSource = GenericUtil.CreateList(elementType);

            IList dataSourceList = keyValuePairs[categoryLst.SelectedItem.ToString()];
            foreach (var element in dataSourceList)
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

            dataDgv.DataSource = displayDataSource;
            dataDgv.Refresh();
        }
    }
}
