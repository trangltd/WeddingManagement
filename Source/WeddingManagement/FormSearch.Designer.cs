namespace WeddingManagement
{
    partial class FormSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataWedding = new System.Windows.Forms.DataGridView();
            this.label_search = new System.Windows.Forms.Label();
            this.dataBill = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rBtn_name = new System.Windows.Forms.RadioButton();
            this.rBtn_date = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_search_bill = new WeddingManagement.CustomBorderTextbox();
            this.tb_search_wd = new WeddingManagement.CustomBorderTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dataWedding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBill)).BeginInit();
            this.SuspendLayout();
            // 
            // dataWedding
            // 
            this.dataWedding.AllowUserToAddRows = false;
            this.dataWedding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataWedding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWedding.Location = new System.Drawing.Point(12, 158);
            this.dataWedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataWedding.Name = "dataWedding";
            this.dataWedding.ReadOnly = true;
            this.dataWedding.RowHeadersWidth = 51;
            this.dataWedding.RowTemplate.Height = 24;
            this.dataWedding.Size = new System.Drawing.Size(600, 600);
            this.dataWedding.TabIndex = 1;
            this.dataWedding.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataWedding_CellDouBleClick);
            // 
            // label_search
            // 
            this.label_search.AutoSize = true;
            this.label_search.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_search.ForeColor = System.Drawing.Color.Black;
            this.label_search.Location = new System.Drawing.Point(199, 18);
            this.label_search.Margin = new System.Windows.Forms.Padding(0);
            this.label_search.Name = "label_search";
            this.label_search.Size = new System.Drawing.Size(245, 35);
            this.label_search.TabIndex = 16;
            this.label_search.Text = "SEARCH WEDDING";
            // 
            // dataBill
            // 
            this.dataBill.AllowUserToAddRows = false;
            this.dataBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBill.Location = new System.Drawing.Point(727, 158);
            this.dataBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataBill.Name = "dataBill";
            this.dataBill.ReadOnly = true;
            this.dataBill.RowHeadersWidth = 51;
            this.dataBill.RowTemplate.Height = 24;
            this.dataBill.Size = new System.Drawing.Size(600, 600);
            this.dataBill.TabIndex = 17;
            this.dataBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBill_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(943, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "SEARCH BILL";
            // 
            // rBtn_name
            // 
            this.rBtn_name.AutoSize = true;
            this.rBtn_name.Checked = true;
            this.rBtn_name.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtn_name.Location = new System.Drawing.Point(267, 117);
            this.rBtn_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rBtn_name.Name = "rBtn_name";
            this.rBtn_name.Size = new System.Drawing.Size(349, 27);
            this.rBtn_name.TabIndex = 20;
            this.rBtn_name.TabStop = true;
            this.rBtn_name.Text = "Groom name, Bride name, Representative";
            this.rBtn_name.UseVisualStyleBackColor = true;
            // 
            // rBtn_date
            // 
            this.rBtn_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtn_date.AutoSize = true;
            this.rBtn_date.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtn_date.Location = new System.Drawing.Point(700, 117);
            this.rBtn_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rBtn_date.Name = "rBtn_date";
            this.rBtn_date.Size = new System.Drawing.Size(138, 27);
            this.rBtn_date.TabIndex = 21;
            this.rBtn_date.TabStop = true;
            this.rBtn_date.Text = "Wedding date";
            this.rBtn_date.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(1310, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 73;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tb_search_bill
            // 
            this.tb_search_bill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_search_bill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_bill.Location = new System.Drawing.Point(871, 68);
            this.tb_search_bill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_search_bill.Name = "tb_search_bill";
            this.tb_search_bill.Size = new System.Drawing.Size(343, 34);
            this.tb_search_bill.TabIndex = 18;
            this.tb_search_bill.TextChanged += new System.EventHandler(this.tb_search_bill_textChange);
            // 
            // tb_search_wd
            // 
            this.tb_search_wd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_wd.Location = new System.Drawing.Point(140, 68);
            this.tb_search_wd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_search_wd.Name = "tb_search_wd";
            this.tb_search_wd.Size = new System.Drawing.Size(343, 34);
            this.tb_search_wd.TabIndex = 0;
            this.tb_search_wd.TextChanged += new System.EventHandler(this.tb_search_wd_textChange);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1339, 784);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rBtn_date);
            this.Controls.Add(this.rBtn_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_search_bill);
            this.Controls.Add(this.dataBill);
            this.Controls.Add(this.label_search);
            this.Controls.Add(this.dataWedding);
            this.Controls.Add(this.tb_search_wd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 800);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.SizeChanged += new System.EventHandler(this.searchWedding_SizeChangedEvent);
            ((System.ComponentModel.ISupportInitialize)(this.dataWedding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomBorderTextbox tb_search_wd;
        private System.Windows.Forms.DataGridView dataWedding;
        private System.Windows.Forms.Label label_search;
        private System.Windows.Forms.DataGridView dataBill;
        private CustomBorderTextbox tb_search_bill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBtn_name;
        private System.Windows.Forms.RadioButton rBtn_date;
        private System.Windows.Forms.Label label6;
    }
}