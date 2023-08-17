namespace WeddingManagement
{
    partial class FormGridViewService
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
            this.dataService = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).BeginInit();
            this.SuspendLayout();
            // 
            // dataService
            // 
            this.dataService.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataService.Location = new System.Drawing.Point(1, 0);
            this.dataService.MaximumSize = new System.Drawing.Size(676, 307);
            this.dataService.Name = "dataService";
            this.dataService.RowHeadersWidth = 51;
            this.dataService.RowTemplate.Height = 24;
            this.dataService.Size = new System.Drawing.Size(676, 307);
            this.dataService.TabIndex = 0;
            this.dataService.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(651, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 72;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FormGridViewService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 307);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGridViewService";
            this.Text = "gridView_service";
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataService;
        private System.Windows.Forms.Label label6;
    }
}