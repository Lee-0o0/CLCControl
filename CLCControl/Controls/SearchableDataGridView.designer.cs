
namespace CLCControls.Controls
{
    partial class SearchableDataGridView
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTxt = new CLCControls.Components.WatermarkTextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.acDgv = new CLCControls.Components.AutoColumnDataGridView(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.searchTxt);
            this.panel3.Controls.Add(this.clearBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 31);
            this.panel3.TabIndex = 4;
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(4, 4);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(299, 21);
            this.searchTxt.TabIndex = 0;
            this.searchTxt.WatermarkText = "可输入名称、拼音查询";
            this.searchTxt.TextChanged += new System.EventHandler(this.SearchTxt_TextChanged);
            this.searchTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTxt_KeyUp);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(309, 3);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(57, 23);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            this.clearBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClearBtn_KeyDown);
            // 
            // acDgv
            // 
            this.acDgv.AllowUserToAddRows = false;
            this.acDgv.AllowUserToDeleteRows = false;
            this.acDgv.AllowUserToOrderColumns = true;
            this.acDgv.AllowUserToResizeRows = false;
            this.acDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.acDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.acDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acDgv.Location = new System.Drawing.Point(0, 31);
            this.acDgv.MultiSelect = false;
            this.acDgv.Name = "acDgv";
            this.acDgv.ReadOnly = true;
            this.acDgv.RowHeadersVisible = false;
            this.acDgv.RowTemplate.Height = 23;
            this.acDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.acDgv.Size = new System.Drawing.Size(369, 153);
            this.acDgv.StandardTab = true;
            this.acDgv.TabIndex = 3;
            this.acDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AcDgv_CellDoubleClick);
            this.acDgv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AcDgv_KeyUp);
            // 
            // SearchableDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.acDgv);
            this.Controls.Add(this.panel3);
            this.Name = "SearchableDataGridView";
            this.Size = new System.Drawing.Size(369, 184);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button clearBtn;
        private CLCControls.Components.WatermarkTextBox searchTxt;
        private CLCControls.Components.AutoColumnDataGridView acDgv;
    }
}
