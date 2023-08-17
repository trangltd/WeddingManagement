namespace WeddingManagement
{
    partial class FormAccount
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
            this.btn_delete_account = new System.Windows.Forms.Button();
            this.btn_add_account = new System.Windows.Forms.Button();
            this.btn_update_account = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.gv_act = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_level = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tb_iden = new WeddingManagement.CustomBorderTextbox();
            this.tb_name = new WeddingManagement.CustomBorderTextbox();
            this.tb_password = new WeddingManagement.CustomBorderTextbox();
            this.tb_username = new WeddingManagement.CustomBorderTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_act)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(1026, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_delete_account
            // 
            this.btn_delete_account.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_delete_account.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_account.ForeColor = System.Drawing.Color.White;
            this.btn_delete_account.Location = new System.Drawing.Point(856, 395);
            this.btn_delete_account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete_account.Name = "btn_delete_account";
            this.btn_delete_account.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_account.TabIndex = 7;
            this.btn_delete_account.Text = "DELETE";
            this.btn_delete_account.UseVisualStyleBackColor = false;
            this.btn_delete_account.Click += new System.EventHandler(this.btn_delete_account_Click);
            // 
            // btn_add_account
            // 
            this.btn_add_account.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_add_account.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_account.ForeColor = System.Drawing.Color.White;
            this.btn_add_account.Location = new System.Drawing.Point(673, 395);
            this.btn_add_account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Size = new System.Drawing.Size(85, 39);
            this.btn_add_account.TabIndex = 5;
            this.btn_add_account.Text = "ADD";
            this.btn_add_account.UseVisualStyleBackColor = false;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // btn_update_account
            // 
            this.btn_update_account.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_update_account.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_account.ForeColor = System.Drawing.Color.White;
            this.btn_update_account.Location = new System.Drawing.Point(765, 395);
            this.btn_update_account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update_account.Name = "btn_update_account";
            this.btn_update_account.Size = new System.Drawing.Size(85, 39);
            this.btn_update_account.TabIndex = 6;
            this.btn_update_account.Text = "UPDATE";
            this.btn_update_account.UseVisualStyleBackColor = false;
            this.btn_update_account.Click += new System.EventHandler(this.btn_update_account_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(633, 197);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(70, 24);
            this.name.TabIndex = 85;
            this.name.Text = "Name(*)";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Black;
            this.Password.Location = new System.Drawing.Point(633, 131);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(103, 24);
            this.Password.TabIndex = 83;
            this.Password.Text = "Password(*)";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Black;
            this.username.Location = new System.Drawing.Point(632, 65);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(104, 24);
            this.username.TabIndex = 81;
            this.username.Text = "Username(*)";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(409, 9);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(139, 35);
            this.label.TabIndex = 79;
            this.label.Text = "ACCOUNT";
            // 
            // gv_act
            // 
            this.gv_act.AllowUserToAddRows = false;
            this.gv_act.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_act.Location = new System.Drawing.Point(20, 62);
            this.gv_act.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gv_act.Name = "gv_act";
            this.gv_act.ReadOnly = true;
            this.gv_act.RowHeadersWidth = 51;
            this.gv_act.RowTemplate.Height = 24;
            this.gv_act.Size = new System.Drawing.Size(544, 372);
            this.gv_act.TabIndex = 78;
            this.gv_act.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_act_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(633, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 92;
            this.label1.Text = "Identification(*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(636, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 94;
            this.label2.Text = "Level";
            // 
            // cbb_level
            // 
            this.cbb_level.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_level.FormattingEnabled = true;
            this.cbb_level.Items.AddRange(new object[] {
            "Director",
            "Manager",
            "Staff"});
            this.cbb_level.Location = new System.Drawing.Point(784, 324);
            this.cbb_level.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_level.Name = "cbb_level";
            this.cbb_level.Size = new System.Drawing.Size(212, 36);
            this.cbb_level.TabIndex = 4;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_search.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(582, 395);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 39);
            this.btn_search.TabIndex = 95;
            this.btn_search.Text = "SEARCH";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRefresh.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(947, 395);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 39);
            this.btnRefresh.TabIndex = 96;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tb_iden
            // 
            this.tb_iden.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_iden.Location = new System.Drawing.Point(784, 259);
            this.tb_iden.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_iden.Name = "tb_iden";
            this.tb_iden.Size = new System.Drawing.Size(212, 34);
            this.tb_iden.TabIndex = 3;
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(784, 194);
            this.tb_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(212, 34);
            this.tb_name.TabIndex = 2;
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(784, 128);
            this.tb_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(212, 34);
            this.tb_password.TabIndex = 1;
            // 
            // tb_username
            // 
            this.tb_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.Location = new System.Drawing.Point(784, 62);
            this.tb_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(212, 34);
            this.tb_username.TabIndex = 0;
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1054, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.cbb_level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_iden);
            this.Controls.Add(this.btn_delete_account);
            this.Controls.Add(this.btn_add_account);
            this.Controls.Add(this.btn_update_account);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.label);
            this.Controls.Add(this.gv_act);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1200, 554);
            this.Name = "FormAccount";
            this.Text = "FormAccount";
            ((System.ComponentModel.ISupportInitialize)(this.gv_act)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_delete_account;
        private System.Windows.Forms.Button btn_add_account;
        private System.Windows.Forms.Button btn_update_account;
        private System.Windows.Forms.Label name;
        private CustomBorderTextbox tb_name;
        private System.Windows.Forms.Label Password;
        private CustomBorderTextbox tb_password;
        private System.Windows.Forms.Label username;
        private CustomBorderTextbox tb_username;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView gv_act;
        private System.Windows.Forms.Label label1;
        private CustomBorderTextbox tb_iden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_level;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btnRefresh;
    }
}