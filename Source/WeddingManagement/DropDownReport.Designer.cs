namespace WeddingManagement
{
    partial class DropDownReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDay = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDay
            // 
            this.btnDay.BackColor = System.Drawing.Color.Teal;
            this.btnDay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDay.Location = new System.Drawing.Point(3, 3);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(141, 40);
            this.btnDay.TabIndex = 0;
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = false;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.BackColor = System.Drawing.Color.Teal;
            this.btnMonth.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMonth.Location = new System.Drawing.Point(2, 45);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(141, 40);
            this.btnMonth.TabIndex = 1;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = false;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // DropDownReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnDay);
            this.Name = "DropDownReport";
            this.Size = new System.Drawing.Size(147, 88);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnMonth;
    }
}
