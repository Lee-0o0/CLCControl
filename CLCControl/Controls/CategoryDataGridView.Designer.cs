
namespace CLCControls.Controls
{
    partial class CategoryDataGridView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.searchTxt = new CLCControls.Components.WatermarkTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataDgv = new CLCControls.Components.AutoColumnDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.categoryLst = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Controls.Add(this.searchTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 45);
            this.panel1.TabIndex = 0;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(311, 11);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            this.clearBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClearBtn_KeyUp);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(5, 11);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(300, 21);
            this.searchTxt.TabIndex = 0;
            this.searchTxt.WatermarkText = "搜索";
            this.searchTxt.TextChanged += new System.EventHandler(this.SearchTxt_TextChanged);
            this.searchTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTxt_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 195);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataDgv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(92, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(299, 195);
            this.panel4.TabIndex = 3;
            // 
            // dataDgv
            // 
            this.dataDgv.AllowUserToAddRows = false;
            this.dataDgv.AllowUserToDeleteRows = false;
            this.dataDgv.AllowUserToOrderColumns = true;
            this.dataDgv.AllowUserToResizeRows = false;
            this.dataDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataDgv.Location = new System.Drawing.Point(5, 5);
            this.dataDgv.Name = "dataDgv";
            this.dataDgv.ReadOnly = true;
            this.dataDgv.RowHeadersVisible = false;
            this.dataDgv.RowTemplate.Height = 23;
            this.dataDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDgv.Size = new System.Drawing.Size(289, 185);
            this.dataDgv.TabIndex = 3;
            this.dataDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataDgv_CellDoubleClick);
            this.dataDgv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataDgv_KeyUp);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.categoryLst);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(92, 195);
            this.panel3.TabIndex = 2;
            // 
            // categoryLst
            // 
            this.categoryLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryLst.FormattingEnabled = true;
            this.categoryLst.IntegralHeight = false;
            this.categoryLst.ItemHeight = 12;
            this.categoryLst.Location = new System.Drawing.Point(5, 5);
            this.categoryLst.Margin = new System.Windows.Forms.Padding(5);
            this.categoryLst.Name = "categoryLst";
            this.categoryLst.Size = new System.Drawing.Size(82, 185);
            this.categoryLst.TabIndex = 2;
            this.categoryLst.SelectedIndexChanged += new System.EventHandler(this.CategoryLst_SelectedIndexChanged);
            // 
            // CategoryDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CategoryDataGridView";
            this.Size = new System.Drawing.Size(391, 240);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearBtn;
        private Components.WatermarkTextBox searchTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private Components.AutoColumnDataGridView dataDgv;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox categoryLst;
    }
}
