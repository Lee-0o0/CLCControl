using CLCControls.Components;
using CLCControls.Controls;
using CLCControls.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Controls
{
    /// <summary>
    /// 自定义ComboBox，可选择下拉内容
    /// </summary>
    public partial class CLCComboBox : ComboBox
    {
        public delegate QueryResult QueryHandler(Dictionary<string, object> parameters);
        public event QueryHandler QueryEvent;


        /// <summary>
        /// 下拉样式
        /// </summary>
        private DropDownType dropDownType;
        [Category("自定义"), Description("设置下拉样式"), Browsable(true)]
        public DropDownType DropDownType 
        {
            get
            {
                return dropDownType;
            }
            set
            {
                dropDownType = value;
                switch (dropDownType)
                {
                    case DropDownType.CheckedListBoxDropDown:
                        DropDownControl = new CheckedListBoxDropDown();
                        ((CheckedListBoxDropDown)dropDownControl).DisplayMember = CLCDisplayMember;
                        ((CheckedListBoxDropDown)dropDownControl).Separator = Separator;
                        break;
                    case DropDownType.SearchableDataGridView:
                        DropDownControl = new SearchableDataGridView();
                        ((SearchableDataGridView)dropDownControl).SearchTextBoxHint = searchBoxText;
                        ((SearchableDataGridView)dropDownControl).SearchPropertyName = searchProperty;
                        break;
                    case DropDownType.CategoryDataGridView:
                        DropDownControl = new CategoryDataGridView();
                        ((CategoryDataGridView)dropDownControl).SearchTextBoxHint = searchBoxText;
                        ((CategoryDataGridView)dropDownControl).SearchPropertyName = searchProperty;
                        ((CategoryDataGridView)dropDownControl).CategoryProperty = categoryName;
                        break;
                    case DropDownType.PageableDataGridView:
                        DropDownControl = new PageableDataGridView();

                        break;
                    default:
                        DropDownControl = null;
                        break;
                }
            }
        }

        /// <summary>
        /// 搜索框提示文字
        /// </summary>
        private string searchBoxText;
        [Category("自定义"), Description("搜索框提示文字"), Browsable(true)]
        public string SearchBoxHint
        {
            get
            {
                return searchBoxText;
            }
            set
            {
                searchBoxText = value;
                if(dropDownControl != null && dropDownControl is SearchableDataGridView view)
                {
                    view.SearchTextBoxHint = value;
                }
                if (dropDownControl != null && dropDownControl is CategoryDataGridView view1)
                {
                    view1.SearchTextBoxHint = value;
                }
            }
        }

        /// <summary>
        /// 要搜索的属性
        /// </summary>
        private string[] searchProperty;
        [Category("自定义"), Description("要搜索的属性"), Browsable(true)]
        public string[] SearchProperty 
        {
            get
            {
                return searchProperty;
            }
            set
            {
                searchProperty = value;
                if (dropDownControl != null && dropDownControl is SearchableDataGridView view)
                {
                    view.SearchPropertyName = value;
                }
                if (dropDownControl != null && dropDownControl is CategoryDataGridView view1)
                {
                    view1.SearchPropertyName = value;
                }
            } 
        }

        /// <summary>
        /// 分类属性名
        /// </summary>
        private string categoryName;
        [Category("自定义"), Description("分类属性名"), Browsable(true)]
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                if (dropDownControl != null && dropDownControl is CategoryDataGridView view1)
                {
                    view1.CategoryProperty = value;
                }
            }
        }


        /// <summary>
        /// 下拉控件
        /// </summary>
        private UserControlDropDown dropDownControl;
        private UserControlDropDown DropDownControl
        {
            get
            {
                return dropDownControl;
            }
            set
            {
                if (value == null)
                    return;
                dropDownControl = value;
                popup = new Popup(dropDownControl);
                dropDownControl.Popup = popup;
                dropDownControl.FatherControl = this;
                popup.Closed += dropDownControl.PopupClosedEvent;
            }
        }

        /// <summary>
        /// 承载下拉控件的容器
        /// </summary>
        private Popup popup = new Popup();

        /// <summary>
        /// 数据源
        /// </summary>
        private object dataSource;
        [Browsable(false)]
        public object CLCDataSource 
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                if(dropDownControl != null)
                {
                    if (dropDownControl is SearchableDataGridView view)
                        view.DataSource = value;
                    else if (dropDownControl is CheckedListBoxDropDown dropDown)
                        dropDown.DataSource = value;
                    else if (dropDownControl is CategoryDataGridView category)
                        category.DataSource = value;
                }
            } 
        }

        /// <summary>
        /// 显示字段，由于DisplayMember会在DataSource修改时被修改，所以新增该字段
        /// </summary>
        private string clcDisplayMember;
        [Browsable(false)]
        public string CLCDisplayMember
        {
            get
            {
                return clcDisplayMember;
            }
            set
            {
                clcDisplayMember = value;
                DisplayMember = value;
                if (dropDownControl != null && dropDownControl is CheckedListBoxDropDown dropDownC)
                {
                    dropDownC.DisplayMember = value;
                }
            }
        }


        /// <summary>
        /// 多选分隔符
        /// </summary>
        public string separator;
        [Category("自定义"), Description("下拉为多选框时的分隔符"), Browsable(true)]
        public string Separator
        {
            get
            {
                return separator;
            }
            set
            {
                separator = value;
                if (dropDownControl != null && dropDownControl is CheckedListBoxDropDown dropDownC)
                {
                    dropDownC.Separator = value;
                }
            }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        private ToolTip toolTip = new ToolTip();


        public CLCComboBox()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            DropDownHeight = 1;
            //DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void PerformClick()
        {
            OnClick(new EventArgs());
        }

        protected override void OnClick(EventArgs e)
        {
            dropDownControl.InitOnDisplay();
            popup.Show(this);

            base.OnClick(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            toolTip.SetToolTip(this, this.Text);

            base.OnMouseHover(e);
        }

        public void Select(params string[] items)
        {
            if (dropDownControl == null)
                return;
            if(dropDownControl is CheckedListBoxDropDown dropDown)
            {
                dropDown.Select(items);
            }
        }

        public List<object> GetSelectedItem()
        {
            if (dropDownControl == null)
                return null;
            if (dropDownControl is CheckedListBoxDropDown dropDown)
            {
                return dropDown.GetSelectedItem();
            }
            return null;
        }

        public void ClearSelected()
        {
            if (dropDownControl == null)
                return;
            if (dropDownControl is CheckedListBoxDropDown dropDown)
            {
                dropDown.ClearSelected();
            }
        }

        public QueryResult Query(Dictionary<string, object> parameters)
        {
            if (dropDownControl is PageableDataGridView && QueryEvent != null)
            {
                return QueryEvent.Invoke(parameters);
            }
            return null;
        }
    }

    /// <summary>
    /// 下拉样式
    /// </summary>
    public enum DropDownType
    {
        CheckedListBoxDropDown,
        SearchableDataGridView,
        CategoryDataGridView,
        PageableDataGridView
    }
}
