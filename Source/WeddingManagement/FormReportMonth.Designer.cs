namespace WeddingManagement
{
    partial class FormReportMonth
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
            this.labelRReport = new System.Windows.Forms.Label();
            this.tb_year = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.tb_revenue_total = new System.Windows.Forms.TextBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelRTotal = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.dataRPMonth = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            this.rBtn_month = new System.Windows.Forms.RadioButton();
            this.rBtn_year = new System.Windows.Forms.RadioButton();
            this.tb_seacrh_rpMonth = new System.Windows.Forms.TextBox();
            this.btn_search_rpMonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataRPMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRReport
            // 
            this.labelRReport.AutoSize = true;
            this.labelRReport.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRReport.ForeColor = System.Drawing.Color.Black;
            this.labelRReport.Location = new System.Drawing.Point(226, 16);
            this.labelRReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRReport.Name = "labelRReport";
            this.labelRReport.Size = new System.Drawing.Size(380, 40);
            this.labelRReport.TabIndex = 0;
            this.labelRReport.Text = "REVENUE REPORT MONTH";
            // 
            // tb_year
            // 
            this.tb_year.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_year.Location = new System.Drawing.Point(290, 172);
            this.tb_year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_year.Name = "tb_year";
            this.tb_year.Size = new System.Drawing.Size(133, 34);
            this.tb_year.TabIndex = 7;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.ForeColor = System.Drawing.Color.Black;
            this.labelYear.Location = new System.Drawing.Point(240, 175);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(44, 24);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Year";
            // 
            // tb_revenue_total
            // 
            this.tb_revenue_total.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_revenue_total.Location = new System.Drawing.Point(575, 172);
            this.tb_revenue_total.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_revenue_total.Name = "tb_revenue_total";
            this.tb_revenue_total.ReadOnly = true;
            this.tb_revenue_total.Size = new System.Drawing.Size(157, 34);
            this.tb_revenue_total.TabIndex = 3;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.DropDownWidth = 133;
            this.comboBoxMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxMonth.Location = new System.Drawing.Point(80, 172);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(133, 36);
            this.comboBoxMonth.TabIndex = 6;
            // 
            // labelRTotal
            // 
            this.labelRTotal.AutoSize = true;
            this.labelRTotal.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRTotal.ForeColor = System.Drawing.Color.Black;
            this.labelRTotal.Location = new System.Drawing.Point(448, 177);
            this.labelRTotal.Name = "labelRTotal";
            this.labelRTotal.Size = new System.Drawing.Size(121, 24);
            this.labelRTotal.TabIndex = 1;
            this.labelRTotal.Text = "Revenue Total";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonth.ForeColor = System.Drawing.Color.Black;
            this.labelMonth.Location = new System.Drawing.Point(15, 177);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(59, 24);
            this.labelMonth.TabIndex = 0;
            this.labelMonth.Text = "Month";
            // 
            // dataRPMonth
            // 
            this.dataRPMonth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataRPMonth.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataRPMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRPMonth.Location = new System.Drawing.Point(12, 233);
            this.dataRPMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataRPMonth.Name = "dataRPMonth";
            this.dataRPMonth.RowHeadersWidth = 51;
            this.dataRPMonth.Size = new System.Drawing.Size(828, 198);
            this.dataRPMonth.TabIndex = 3;
            this.dataRPMonth.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRPMonth_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(760, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.Gray;
            this.close.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.close.Location = new System.Drawing.Point(830, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(28, 25);
            this.close.TabIndex = 88;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // rBtn_month
            // 
            this.rBtn_month.AutoSize = true;
            this.rBtn_month.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtn_month.Location = new System.Drawing.Point(568, 115);
            this.rBtn_month.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rBtn_month.Name = "rBtn_month";
            this.rBtn_month.Size = new System.Drawing.Size(71, 26);
            this.rBtn_month.TabIndex = 93;
            this.rBtn_month.TabStop = true;
            this.rBtn_month.Text = "Month";
            this.rBtn_month.UseVisualStyleBackColor = true;
            // 
            // rBtn_year
            // 
            this.rBtn_year.AutoSize = true;
            this.rBtn_year.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtn_year.Location = new System.Drawing.Point(675, 115);
            this.rBtn_year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rBtn_year.Name = "rBtn_year";
            this.rBtn_year.Size = new System.Drawing.Size(61, 26);
            this.rBtn_year.TabIndex = 92;
            this.rBtn_year.TabStop = true;
            this.rBtn_year.Text = "Year";
            this.rBtn_year.UseVisualStyleBackColor = true;
            // 
            // tb_seacrh_rpMonth
            // 
            this.tb_seacrh_rpMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_seacrh_rpMonth.Location = new System.Drawing.Point(544, 77);
            this.tb_seacrh_rpMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_seacrh_rpMonth.Name = "tb_seacrh_rpMonth";
            this.tb_seacrh_rpMonth.Size = new System.Drawing.Size(215, 34);
            this.tb_seacrh_rpMonth.TabIndex = 89;
            // 
            // btn_search_rpMonth
            // 
            this.btn_search_rpMonth.BackColor = System.Drawing.Color.DimGray;
            this.btn_search_rpMonth.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_rpMonth.ForeColor = System.Drawing.Color.White;
            this.btn_search_rpMonth.Location = new System.Drawing.Point(765, 74);
            this.btn_search_rpMonth.Name = "btn_search_rpMonth";
            this.btn_search_rpMonth.Size = new System.Drawing.Size(75, 33);
            this.btn_search_rpMonth.TabIndex = 90;
            this.btn_search_rpMonth.Text = "SEARCH";
            this.btn_search_rpMonth.UseVisualStyleBackColor = false;
            this.btn_search_rpMonth.Click += new System.EventHandler(this.btn_search_rpMonth_Click);
            // 
            // FormReportMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(852, 449);
            this.Controls.Add(this.rBtn_month);
            this.Controls.Add(this.rBtn_year);
            this.Controls.Add(this.tb_seacrh_rpMonth);
            this.Controls.Add(this.btn_search_rpMonth);
            this.Controls.Add(this.tb_revenue_total);
            this.Controls.Add(this.labelRTotal);
            this.Controls.Add(this.tb_year);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.close);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataRPMonth);
            this.Controls.Add(this.labelRReport);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(852, 503);
            this.Name = "FormReportMonth";
            this.Text = "FormReportMonth";
            ((System.ComponentModel.ISupportInitialize)(this.dataRPMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelRReport;
        private System.Windows.Forms.TextBox tb_year;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox tb_revenue_total;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelRTotal;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.DataGridView dataRPMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.RadioButton rBtn_month;
        private System.Windows.Forms.RadioButton rBtn_year;
        private System.Windows.Forms.TextBox tb_seacrh_rpMonth;
        private System.Windows.Forms.Button btn_search_rpMonth;
    }
}