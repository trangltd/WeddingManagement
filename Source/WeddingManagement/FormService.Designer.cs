namespace WeddingManagement
{
    partial class FormService
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
            this.btn_delete_service = new System.Windows.Forms.Button();
            this.btn_add_service = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.dataService = new System.Windows.Forms.DataGridView();
            this.img_close_service = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search_service = new WeddingManagement.CustomBorderTextbox();
            this.tb_service_note = new WeddingManagement.CustomBorderTextbox();
            this.tb_service_price = new WeddingManagement.CustomBorderTextbox();
            this.tb_service_name = new WeddingManagement.CustomBorderTextbox();
            this.btn_search_service = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_delete_service
            // 
            this.btn_delete_service.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_delete_service.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_service.ForeColor = System.Drawing.Color.White;
            this.btn_delete_service.Location = new System.Drawing.Point(755, 371);
            this.btn_delete_service.Name = "btn_delete_service";
            this.btn_delete_service.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_service.TabIndex = 86;
            this.btn_delete_service.Text = "DELETE";
            this.btn_delete_service.UseVisualStyleBackColor = false;
            this.btn_delete_service.Click += new System.EventHandler(this.btn_delete_service_Click);
            // 
            // btn_add_service
            // 
            this.btn_add_service.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_add_service.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_service.ForeColor = System.Drawing.Color.White;
            this.btn_add_service.Location = new System.Drawing.Point(500, 371);
            this.btn_add_service.Name = "btn_add_service";
            this.btn_add_service.Size = new System.Drawing.Size(85, 39);
            this.btn_add_service.TabIndex = 85;
            this.btn_add_service.Text = "ADD";
            this.btn_add_service.UseVisualStyleBackColor = false;
            this.btn_add_service.Click += new System.EventHandler(this.btn_add_service_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(395, 9);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(122, 35);
            this.label.TabIndex = 77;
            this.label.Text = "SERVICE";
            // 
            // dataService
            // 
            this.dataService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataService.Location = new System.Drawing.Point(12, 60);
            this.dataService.Name = "dataService";
            this.dataService.RowHeadersWidth = 51;
            this.dataService.RowTemplate.Height = 24;
            this.dataService.Size = new System.Drawing.Size(454, 372);
            this.dataService.TabIndex = 76;
            this.dataService.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataService_CellContentClick);
            // 
            // img_close_service
            // 
            this.img_close_service.AutoSize = true;
            this.img_close_service.BackColor = System.Drawing.Color.Gray;
            this.img_close_service.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.img_close_service.ForeColor = System.Drawing.Color.White;
            this.img_close_service.Location = new System.Drawing.Point(843, 0);
            this.img_close_service.Name = "img_close_service";
            this.img_close_service.Size = new System.Drawing.Size(28, 25);
            this.img_close_service.TabIndex = 87;
            this.img_close_service.Text = "X";
            this.img_close_service.Click += new System.EventHandler(this.img_close_service_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(496, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 93;
            this.label3.Text = "Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(496, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 91;
            this.label2.Text = "Price(*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(496, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 89;
            this.label1.Text = "Name(*)";
            // 
            // tb_search_service
            // 
            this.tb_search_service.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_service.Location = new System.Drawing.Point(500, 87);
            this.tb_search_service.Name = "tb_search_service";
            this.tb_search_service.Size = new System.Drawing.Size(231, 34);
            this.tb_search_service.TabIndex = 94;
            // 
            // tb_service_note
            // 
            this.tb_service_note.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_service_note.Location = new System.Drawing.Point(586, 301);
            this.tb_service_note.Name = "tb_service_note";
            this.tb_service_note.Size = new System.Drawing.Size(254, 34);
            this.tb_service_note.TabIndex = 92;
            // 
            // tb_service_price
            // 
            this.tb_service_price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_service_price.Location = new System.Drawing.Point(586, 227);
            this.tb_service_price.Name = "tb_service_price";
            this.tb_service_price.Size = new System.Drawing.Size(254, 34);
            this.tb_service_price.TabIndex = 90;
            // 
            // tb_service_name
            // 
            this.tb_service_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_service_name.Location = new System.Drawing.Point(586, 153);
            this.tb_service_name.Name = "tb_service_name";
            this.tb_service_name.Size = new System.Drawing.Size(254, 34);
            this.tb_service_name.TabIndex = 88;
            // 
            // btn_search_service
            // 
            this.btn_search_service.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_search_service.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_service.ForeColor = System.Drawing.Color.White;
            this.btn_search_service.Location = new System.Drawing.Point(755, 84);
            this.btn_search_service.Name = "btn_search_service";
            this.btn_search_service.Size = new System.Drawing.Size(85, 39);
            this.btn_search_service.TabIndex = 96;
            this.btn_search_service.Text = "SEARCH";
            this.btn_search_service.UseVisualStyleBackColor = false;
            this.btn_search_service.Click += new System.EventHandler(this.btn_search_service_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(626, 371);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 39);
            this.btnUpdate.TabIndex = 97;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FormService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(871, 443);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btn_search_service);
            this.Controls.Add(this.tb_search_service);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_service_note);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_service_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_service_name);
            this.Controls.Add(this.img_close_service);
            this.Controls.Add(this.btn_delete_service);
            this.Controls.Add(this.btn_add_service);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1000, 443);
            this.Name = "FormService";
            this.Text = "FormServices";
            this.Load += new System.EventHandler(this.form_service_load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_delete_service;
        private System.Windows.Forms.Button btn_add_service;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dataService;
        private System.Windows.Forms.Label img_close_service;
        private CustomBorderTextbox tb_search_service;
        private System.Windows.Forms.Label label3;
        private CustomBorderTextbox tb_service_note;
        private System.Windows.Forms.Label label2;
        private CustomBorderTextbox tb_service_price;
        private System.Windows.Forms.Label label1;
        private CustomBorderTextbox tb_service_name;
        private System.Windows.Forms.Button btn_search_service;
        private System.Windows.Forms.Button btnUpdate;
    }
}