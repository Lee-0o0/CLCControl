using CLCControls.Model;
using CLCControls.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CLCControls.Controls
{
    public partial class PageableDataGridView : UserControlDropDown
    {
        /// <summary>
        /// 总页数
        /// </summary>
        private int totalPage;
        /// <summary>
        /// 当前页
        /// </summary>
        private int currentPage;

        /// <summary>
        /// 查询结果
        /// </summary>
        private QueryResult data;
        public QueryResult Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                if (data != null && data.Result)
                {
                    totalPage = data.TotalPage;
                    currentPage = data.PageNum;
                    elementType = data.ElementType;
                    totalPageLbl.Text = "/ " + data.TotalPage + " 页";
                    totalLbl.Text = data.TotalSize + "条";
                    dataDgv.DataSource = data.Data;
                    dataDgv.Refresh();
                }
            }
        }

        /// <summary>
        /// 选择的元素
        /// </summary>
        private object SelectedElement;
        /// <summary>
        /// 元素类型
        /// </summary>
        private Type elementType;

        public PageableDataGridView()
        {
            InitializeComponent();
        }

        public override void InitOnDisplay()
        {
            searchTxt.Text = "";

            pageSizeCbo.Items.Clear();
            pageSizeCbo.Items.AddRange(new string[] { "20", "50", "200", "500" });
            pageSizeCbo.SelectedIndex = 0;

            pageNumTxt.Text = "1";

            Query();

            base.InitOnDisplay();
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e)
        {
            Query();
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
        /// 获取查询参数
        /// </summary>
        public Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("key", searchTxt.Text?.Trim());
            if (int.TryParse(pageNumTxt.Text.Trim(), out int i))
            {
                parameters.Add("page", i);
            }
            else
            {
                pageNumTxt.Text = "1";
                parameters.Add("page", 1);
            }

            if (int.TryParse(pageSizeCbo.SelectedItem.ToString().Trim(), out int i1))
            {
                parameters.Add("pageSize", i1);
            }
            else
            {
                pageSizeCbo.SelectedIndex = 0;
                parameters.Add("pageSize", 20);
            }
            return parameters;
        }


        /// <summary>
        /// 在搜索框中按下Enter键
        /// </summary>
        private void SearchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryBtn_Click(null, null);
            }
            else if (e.KeyCode == Keys.Down)
            {
                dataDgv.Focus();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            if(FatherControl != null && FatherControl is CLCComboBox)
            {
                Data = ((CLCComboBox)FatherControl).Query(GetParameters());
                dataDgv.Focus();
            }
        }

        /// <summary>
        /// 第一页
        /// </summary>
        private void FirstPageBtn_Click(object sender, EventArgs e)
        {
            pageNumTxt.Text = "1";
            Query();
        }


        /// <summary>
        /// 上一页
        /// </summary>
        private void PrevPageBtn_Click(object sender, EventArgs e)
        {
            if (currentPage <= 1)
                currentPage = 2;
            currentPage--;
            pageNumTxt.Text = currentPage.ToString();
            Query();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPageBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(currentPage+"--"+totalPage);
            if (currentPage >= totalPage)
                currentPage = totalPage - 1;
            currentPage++;
            pageNumTxt.Text = currentPage.ToString();
            Query();
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        private void LastPageBtn_Click(object sender, EventArgs e)
        {
            pageNumTxt.Text = totalPage.ToString();
            Query();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void DataDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            PopupClosedEvent("关闭", null);
            Popup.Close();
        }

        private void DataDgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopupClosedEvent("关闭", null);
                Popup.Close();
            }
        }

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
                        comboBox.DataSource = new List<string>() { SelectedElement.ToString()};
                    }
                    comboBox.DisplayMember = comboBox.CLCDisplayMember;
                    comboBox.SelectedIndex = 0;
                }
            }

            base.PopupClosedEvent(sender, e);
        }

        private void QueryBtn_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                dataDgv.Focus();
            }
        }

        private void ClearBtn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataDgv.Focus();
            }
        }

        private void PageSizeCboAndPageNumTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }
    }
}
