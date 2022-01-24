using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLCControls.Attribute
{
    /// <summary>
    /// 列样式
    /// </summary>
    public class ColumnStyleAttribute : System.Attribute
    {
        public bool Visible { get; set; } = true;

        public string HeaderText { get; set; }

        public ColumnTypeEnum ColumnType { get; set; } = ColumnTypeEnum.TextBoxColumn;
    }

    /// <summary>
    /// 列类型
    /// </summary>
    public enum ColumnTypeEnum
    {
        TextBoxColumn,
        ButtonColumn,
        CheckBoxColumn,
        ComboBoxColumn,
        ImageColumn,
        LinkColumn
    }
}
