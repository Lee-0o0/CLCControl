using CLCControls.Attribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Components
{
    /// <summary>
    /// 可根据数据源实体的标注，自动生成列名
    /// </summary>
    public partial class AutoColumnDataGridView : DataGridView
    {
        private Type type;

        public AutoColumnDataGridView()
        {
            InitializeComponent();
        }

        public AutoColumnDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        /// <summary>
        /// 数据源改变时
        /// </summary>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            AutoGenerateColumns = false;

            Type dataSourceType = DataSource.GetType();
            // 判断数据源是否为可遍历类型
            try
            {
                Type enumerableType= dataSourceType.GetInterface("System.Collections.Generic.IEnumerable`1");
                if (enumerableType == null)
                    throw new Exception();
            }
            catch 
            {
                this.Columns.Clear();
                return;
            }

            // 获取实体的类型
            Type newType;
            if (dataSourceType.IsArray)
                newType = dataSourceType.GetElementType();
            else if (dataSourceType.IsGenericType)
                newType = dataSourceType.GetGenericArguments().First();
            else
                newType = null;

            if (newType == null || type == newType) 
                return;

            this.Columns.Clear();
            type = newType;

            List<DataGridViewColumn> gridViewColumns = new List<DataGridViewColumn>();
            // 根据注解创建列样式
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(ColumnIgnoreAttribute), false).Length != 0)
                    continue;

                DataGridViewColumn dataGridViewColumn;
                object[] attributes = propertyInfo.GetCustomAttributes(typeof(ColumnStyleAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }
                else
                {
                    ColumnStyleAttribute columnStyleAttribute = (ColumnStyleAttribute)attributes[0];
                    ColumnTypeEnum columnTypeEnum = columnStyleAttribute.ColumnType;

                    dataGridViewColumn = new DataGridViewTextBoxColumn();
                    switch (columnTypeEnum)
                    {
                        case ColumnTypeEnum.CheckBoxColumn:
                            dataGridViewColumn = new DataGridViewCheckBoxColumn();
                            break;
                        case ColumnTypeEnum.ButtonColumn:
                            dataGridViewColumn = new DataGridViewButtonColumn();
                            break;
                        case ColumnTypeEnum.ComboBoxColumn:
                            dataGridViewColumn = new DataGridViewComboBoxColumn();
                            break;
                        case ColumnTypeEnum.ImageColumn:
                            dataGridViewColumn = new DataGridViewImageColumn();
                            break;
                        case ColumnTypeEnum.LinkColumn:
                            dataGridViewColumn = new DataGridViewLinkColumn();
                            break;
                    }
                    dataGridViewColumn.HeaderText = columnStyleAttribute.HeaderText;
                    if (string.IsNullOrEmpty(dataGridViewColumn.HeaderText))
                        dataGridViewColumn.HeaderText = propertyInfo.Name;
                    if (!columnStyleAttribute.Visible)
                        dataGridViewColumn.Visible = false;
                }

                dataGridViewColumn.DataPropertyName = propertyInfo.Name;
                dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                gridViewColumns.Add(dataGridViewColumn);
            }

            this.Columns.AddRange(gridViewColumns.ToArray());
        }

        /// <summary>
        /// 在绘制时改变列模式以填充数据表
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            int totalWidth = 0;
            int lastDisplayIndex = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Visible)
                {
                    totalWidth += Columns[i].Width;
                    lastDisplayIndex++;
                }
            }

            if (totalWidth < Width && Columns.Count > 0)
                Columns[lastDisplayIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            base.OnPaint(e);
        }
    }
}
