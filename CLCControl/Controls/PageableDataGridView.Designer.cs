
namespace CLCControls.Controls
{
    partial class PageableDataGridView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageableDataGridView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.queryBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.searchTxt = new CLCControls.Components.WatermarkTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataDgv = new CLCControls.Components.AutoColumnDataGridView(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pageSizeCbo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.firstPageBtn = new System.Windows.Forms.ToolStripButton();
            this.prevPageBtn = new System.Windows.Forms.ToolStripButton();
            this.pageNumTxt = new System.Windows.Forms.ToolStripTextBox();
            this.totalPageLbl = new System.Windows.Forms.ToolStripLabel();
            this.nextPageBtn = new System.Windows.Forms.ToolStripButton();
            this.lastPageBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadBtn = new System.Windows.Forms.ToolStripButton();
            this.totalLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.queryBtn);
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Controls.Add(this.searchTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 39);
            this.panel1.TabIndex = 0;
            // 
            // queryBtn
            // 
            this.queryBtn.Location = new System.Drawing.Point(367, 9);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(91, 23);
            this.queryBtn.TabIndex = 2;
            this.queryBtn.Text = "查询";
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            this.queryBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QueryBtn_KeyUp);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(464, 9);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(91, 23);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            this.clearBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClearBtn_KeyUp);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(5, 10);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(356, 21);
            this.searchTxt.TabIndex = 0;
            this.searchTxt.WatermarkText = "输入关键字进行查询";
            this.searchTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTxt_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataDgv);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(558, 251);
            this.panel2.TabIndex = 1;
            // 
            // dataDgv
            // 
            this.dataDgv.AllowUserToAddRows = false;
            this.dataDgv.AllowUserToDeleteRows = false;
            this.dataDgv.AllowUserToOrderColumns = true;
            this.dataDgv.AllowUserToResizeRows = false;
            this.dataDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataDgv.Location = new System.Drawing.Point(5, 5);
            this.dataDgv.MultiSelect = false;
            this.dataDgv.Name = "dataDgv";
            this.dataDgv.ReadOnly = true;
            this.dataDgv.RowHeadersVisible = false;
            this.dataDgv.RowTemplate.Height = 23;
            this.dataDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDgv.Size = new System.Drawing.Size(548, 214);
            this.dataDgv.TabIndex = 1;
            this.dataDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataDgv_CellDoubleClick);
            this.dataDgv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataDgv_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.pageSizeCbo,
            this.toolStripSeparator1,
            this.firstPageBtn,
            this.prevPageBtn,
            this.pageNumTxt,
            this.totalPageLbl,
            this.nextPageBtn,
            this.lastPageBtn,
            this.toolStripSeparator2,
            this.reloadBtn,
            this.totalLbl,
            this.toolStripLabel3});
            this.toolStrip1.Location = new System.Drawing.Point(5, 219);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(548, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 25);
            this.toolStripLabel1.Text = "每页数量：";
            // 
            // pageSizeCbo
            // 
            this.pageSizeCbo.AutoSize = false;
            this.pageSizeCbo.Name = "pageSizeCbo";
            this.pageSizeCbo.Size = new System.Drawing.Size(50, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // firstPageBtn
            // 
            this.firstPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("firstPageBtn.Image")));
            this.firstPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstPageBtn.Name = "firstPageBtn";
            this.firstPageBtn.Padding = new System.Windows.Forms.Padding(2);
            this.firstPageBtn.Size = new System.Drawing.Size(24, 24);
            this.firstPageBtn.Text = "toolStripButton2";
            this.firstPageBtn.ToolTipText = "第一页";
            this.firstPageBtn.Click += new System.EventHandler(this.FirstPageBtn_Click);
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevPageBtn.Image")));
            this.prevPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Padding = new System.Windows.Forms.Padding(2);
            this.prevPageBtn.Size = new System.Drawing.Size(24, 24);
            this.prevPageBtn.Text = "toolStripButton3";
            this.prevPageBtn.ToolTipText = "上一页";
            this.prevPageBtn.Click += new System.EventHandler(this.PrevPageBtn_Click);
            // 
            // pageNumTxt
            // 
            this.pageNumTxt.BackColor = System.Drawing.SystemColors.Window;
            this.pageNumTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.pageNumTxt.Name = "pageNumTxt";
            this.pageNumTxt.Size = new System.Drawing.Size(40, 27);
            // 
            // totalPageLbl
            // 
            this.totalPageLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.totalPageLbl.Name = "totalPageLbl";
            this.totalPageLbl.Size = new System.Drawing.Size(40, 24);
            this.totalPageLbl.Text = "/ 0 页";
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextPageBtn.Image")));
            this.nextPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Padding = new System.Windows.Forms.Padding(2);
            this.nextPageBtn.Size = new System.Drawing.Size(24, 24);
            this.nextPageBtn.Text = "toolStripButton4";
            this.nextPageBtn.ToolTipText = "下一页";
            this.nextPageBtn.Click += new System.EventHandler(this.NextPageBtn_Click);
            // 
            // lastPageBtn
            // 
            this.lastPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("lastPageBtn.Image")));
            this.lastPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastPageBtn.Name = "lastPageBtn";
            this.lastPageBtn.Padding = new System.Windows.Forms.Padding(2);
            this.lastPageBtn.Size = new System.Drawing.Size(24, 24);
            this.lastPageBtn.Text = "toolStripButton5";
            this.lastPageBtn.ToolTipText = "最后一页";
            this.lastPageBtn.Click += new System.EventHandler(this.LastPageBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // reloadBtn
            // 
            this.reloadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadBtn.Image = ((System.Drawing.Image)(resources.GetObject("reloadBtn.Image")));
            this.reloadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Padding = new System.Windows.Forms.Padding(2);
            this.reloadBtn.Size = new System.Drawing.Size(24, 24);
            this.reloadBtn.Text = "toolStripButton6";
            this.reloadBtn.ToolTipText = "刷新";
            this.reloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // totalLbl
            // 
            this.totalLbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.totalLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.totalLbl.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(27, 24);
            this.totalLbl.Text = "0条";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(68, 24);
            this.toolStripLabel3.Text = "总记录数：";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // PageableDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PageableDataGridView";
            this.Size = new System.Drawing.Size(558, 290);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearBtn;
        private Components.WatermarkTextBox searchTxt;
        private System.Windows.Forms.Panel panel2;
        private Components.AutoColumnDataGridView dataDgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox pageSizeCbo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton firstPageBtn;
        private System.Windows.Forms.ToolStripButton prevPageBtn;
        private System.Windows.Forms.ToolStripTextBox pageNumTxt;
        private System.Windows.Forms.ToolStripButton nextPageBtn;
        private System.Windows.Forms.ToolStripButton lastPageBtn;
        private System.Windows.Forms.ToolStripButton reloadBtn;
        private System.Windows.Forms.ToolStripLabel totalPageLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel totalLbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button queryBtn;
    }
}
