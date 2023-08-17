namespace WeddingManagement
{
    partial class FormMenu
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_menu = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add_item = new System.Windows.Forms.Button();
            this.btn_delete_item = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.cbt_search_item = new WeddingManagement.CustomBorderTextbox();
            this.cbt_item_note = new WeddingManagement.CustomBorderTextbox();
            this.cbt_item_price = new WeddingManagement.CustomBorderTextbox();
            this.cbt_item_name = new WeddingManagement.CustomBorderTextbox();
            this.btn_update_item = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(974, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgv_menu
            // 
            this.dgv_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_menu.Location = new System.Drawing.Point(12, 66);
            this.dgv_menu.Name = "dgv_menu";
            this.dgv_menu.RowHeadersWidth = 51;
            this.dgv_menu.RowTemplate.Height = 24;
            this.dgv_menu.Size = new System.Drawing.Size(614, 372);
            this.dgv_menu.TabIndex = 13;
            this.dgv_menu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_menu_CellClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(477, 16);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(88, 35);
            this.label.TabIndex = 20;
            this.label.Text = "MENU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(644, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 70;
            this.label2.Text = "Price(*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightBlue;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(644, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 72;
            this.label3.Text = "Note";
            // 
            // btn_add_item
            // 
            this.btn_add_item.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_add_item.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_item.ForeColor = System.Drawing.Color.White;
            this.btn_add_item.Location = new System.Drawing.Point(648, 372);
            this.btn_add_item.Name = "btn_add_item";
            this.btn_add_item.Size = new System.Drawing.Size(85, 39);
            this.btn_add_item.TabIndex = 74;
            this.btn_add_item.Text = "ADD";
            this.btn_add_item.UseVisualStyleBackColor = false;
            this.btn_add_item.Click += new System.EventHandler(this.btn_add_item_Click);
            // 
            // btn_delete_item
            // 
            this.btn_delete_item.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_delete_item.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_item.ForeColor = System.Drawing.Color.White;
            this.btn_delete_item.Location = new System.Drawing.Point(902, 372);
            this.btn_delete_item.Name = "btn_delete_item";
            this.btn_delete_item.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_item.TabIndex = 75;
            this.btn_delete_item.Text = "DELETE";
            this.btn_delete_item.UseVisualStyleBackColor = false;
            this.btn_delete_item.Click += new System.EventHandler(this.btn_delete_item_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(644, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 68;
            this.label1.Text = "Name(*)";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_search.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(903, 80);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 39);
            this.btn_search.TabIndex = 78;
            this.btn_search.Text = "SEARCH";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // cbt_search_item
            // 
            this.cbt_search_item.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_search_item.Location = new System.Drawing.Point(648, 81);
            this.cbt_search_item.Name = "cbt_search_item";
            this.cbt_search_item.Size = new System.Drawing.Size(238, 34);
            this.cbt_search_item.TabIndex = 76;
            // 
            // cbt_item_note
            // 
            this.cbt_item_note.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_item_note.Location = new System.Drawing.Point(734, 307);
            this.cbt_item_note.Name = "cbt_item_note";
            this.cbt_item_note.Size = new System.Drawing.Size(253, 34);
            this.cbt_item_note.TabIndex = 71;
            // 
            // cbt_item_price
            // 
            this.cbt_item_price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_item_price.Location = new System.Drawing.Point(734, 238);
            this.cbt_item_price.Name = "cbt_item_price";
            this.cbt_item_price.Size = new System.Drawing.Size(253, 34);
            this.cbt_item_price.TabIndex = 69;
            // 
            // cbt_item_name
            // 
            this.cbt_item_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_item_name.Location = new System.Drawing.Point(734, 169);
            this.cbt_item_name.Name = "cbt_item_name";
            this.cbt_item_name.Size = new System.Drawing.Size(254, 34);
            this.cbt_item_name.TabIndex = 67;
            // 
            // btn_update_item
            // 
            this.btn_update_item.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_update_item.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_item.ForeColor = System.Drawing.Color.White;
            this.btn_update_item.Location = new System.Drawing.Point(778, 372);
            this.btn_update_item.Name = "btn_update_item";
            this.btn_update_item.Size = new System.Drawing.Size(85, 39);
            this.btn_update_item.TabIndex = 79;
            this.btn_update_item.Text = "UPDATE";
            this.btn_update_item.UseVisualStyleBackColor = false;
            this.btn_update_item.Click += new System.EventHandler(this.btn_update_item_Click);
            // 
            // FormMenu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1000, 455);
            this.Controls.Add(this.btn_update_item);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.cbt_search_item);
            this.Controls.Add(this.btn_delete_item);
            this.Controls.Add(this.btn_add_item);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbt_item_note);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbt_item_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbt_item_name);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dgv_menu);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_menu;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private CustomBorderTextbox cbt_item_price;
        private System.Windows.Forms.Label label3;
        private CustomBorderTextbox cbt_item_note;
        private System.Windows.Forms.Button btn_add_item;
        private System.Windows.Forms.Button btn_delete_item;
        private CustomBorderTextbox cbt_item_name;
        private System.Windows.Forms.Label label1;
        private CustomBorderTextbox cbt_search_item;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_update_item;
    }
}