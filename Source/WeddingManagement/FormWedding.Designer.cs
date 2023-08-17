using System.Windows.Forms;

namespace WeddingManagement
{
    partial class FormWedding
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
            this.label_bookdate = new System.Windows.Forms.Label();
            this.label_tittle_wedding_in4 = new System.Windows.Forms.Label();
            this.label_phone = new System.Windows.Forms.Label();
            this.label_representative = new System.Windows.Forms.Label();
            this.label_bride = new System.Windows.Forms.Label();
            this.label_groom = new System.Windows.Forms.Label();
            this.label_weddingdate = new System.Windows.Forms.Label();
            this.label_deposit = new System.Windows.Forms.Label();
            this.label_contingency = new System.Windows.Forms.Label();
            this.label_table = new System.Windows.Forms.Label();
            this.Wedding = new System.Windows.Forms.GroupBox();
            this.cbb_lobby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_shift = new System.Windows.Forms.ComboBox();
            this.label_shift = new System.Windows.Forms.Label();
            this.cbt_deposit = new WeddingManagement.CustomBorderTextbox();
            this.cbt_representative = new WeddingManagement.CustomBorderTextbox();
            this.cbt_phone = new WeddingManagement.CustomBorderTextbox();
            this.cbt_contigency = new WeddingManagement.CustomBorderTextbox();
            this.cbt_table = new WeddingManagement.CustomBorderTextbox();
            this.cbt_broom = new WeddingManagement.CustomBorderTextbox();
            this.cbt_bride = new WeddingManagement.CustomBorderTextbox();
            this.date_booking = new System.Windows.Forms.DateTimePicker();
            this.date_wedding = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_add_wedding = new System.Windows.Forms.Button();
            this.btn_update_wedding = new System.Windows.Forms.Button();
            this.btn_delete_wedding = new System.Windows.Forms.Button();
            this.groupBox_menu = new System.Windows.Forms.GroupBox();
            this.btn_update_item = new System.Windows.Forms.Button();
            this.btn_delete_item = new System.Windows.Forms.Button();
            this.cbt_amount_item = new WeddingManagement.CustomBorderTextbox();
            this.cbt_price_item = new WeddingManagement.CustomBorderTextbox();
            this.btn_add_menu = new System.Windows.Forms.Button();
            this.label_item_price = new System.Windows.Forms.Label();
            this.label_amount_item = new System.Windows.Forms.Label();
            this.cbb_item = new System.Windows.Forms.ComboBox();
            this.label_menu = new System.Windows.Forms.Label();
            this.btn_detail_item = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_delete_service = new System.Windows.Forms.Button();
            this.cbt_amount_service = new WeddingManagement.CustomBorderTextbox();
            this.btn_update_service = new System.Windows.Forms.Button();
            this.cbt_price_service = new WeddingManagement.CustomBorderTextbox();
            this.btn_add_service = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_service = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_detail_service = new System.Windows.Forms.Button();
            this.dataWedding = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_menu_detail = new System.Windows.Forms.GroupBox();
            this.dgv_menu_detail = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_service_detail = new System.Windows.Forms.DataGridView();
            this.serviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wedding.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_menu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWedding)).BeginInit();
            this.gb_menu_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menu_detail)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_service_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // label_bookdate
            // 
            this.label_bookdate.AutoSize = true;
            this.label_bookdate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookdate.ForeColor = System.Drawing.Color.Black;
            this.label_bookdate.Location = new System.Drawing.Point(16, 18);
            this.label_bookdate.Name = "label_bookdate";
            this.label_bookdate.Size = new System.Drawing.Size(113, 24);
            this.label_bookdate.TabIndex = 16;
            this.label_bookdate.Text = "Booking date";
            // 
            // label_tittle_wedding_in4
            // 
            this.label_tittle_wedding_in4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tittle_wedding_in4.AutoSize = true;
            this.label_tittle_wedding_in4.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tittle_wedding_in4.ForeColor = System.Drawing.Color.Black;
            this.label_tittle_wedding_in4.Location = new System.Drawing.Point(626, 18);
            this.label_tittle_wedding_in4.Margin = new System.Windows.Forms.Padding(0);
            this.label_tittle_wedding_in4.Name = "label_tittle_wedding_in4";
            this.label_tittle_wedding_in4.Size = new System.Drawing.Size(316, 35);
            this.label_tittle_wedding_in4.TabIndex = 15;
            this.label_tittle_wedding_in4.Text = "WEDDING INFORMATION";
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_phone.ForeColor = System.Drawing.Color.Black;
            this.label_phone.Location = new System.Drawing.Point(17, 69);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(124, 24);
            this.label_phone.TabIndex = 14;
            this.label_phone.Text = "Phone number";
            // 
            // label_representative
            // 
            this.label_representative.AutoSize = true;
            this.label_representative.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_representative.ForeColor = System.Drawing.Color.Black;
            this.label_representative.Location = new System.Drawing.Point(15, 24);
            this.label_representative.Name = "label_representative";
            this.label_representative.Size = new System.Drawing.Size(125, 24);
            this.label_representative.TabIndex = 13;
            this.label_representative.Text = "Representative";
            // 
            // label_bride
            // 
            this.label_bride.AutoSize = true;
            this.label_bride.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bride.ForeColor = System.Drawing.Color.Black;
            this.label_bride.Location = new System.Drawing.Point(350, 67);
            this.label_bride.Name = "label_bride";
            this.label_bride.Size = new System.Drawing.Size(98, 24);
            this.label_bride.TabIndex = 22;
            this.label_bride.Text = "Bride name";
            // 
            // label_groom
            // 
            this.label_groom.AutoSize = true;
            this.label_groom.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_groom.ForeColor = System.Drawing.Color.Black;
            this.label_groom.Location = new System.Drawing.Point(350, 26);
            this.label_groom.Name = "label_groom";
            this.label_groom.Size = new System.Drawing.Size(110, 24);
            this.label_groom.TabIndex = 21;
            this.label_groom.Text = "Groom name";
            // 
            // label_weddingdate
            // 
            this.label_weddingdate.AutoSize = true;
            this.label_weddingdate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_weddingdate.ForeColor = System.Drawing.Color.Black;
            this.label_weddingdate.Location = new System.Drawing.Point(316, 18);
            this.label_weddingdate.Name = "label_weddingdate";
            this.label_weddingdate.Size = new System.Drawing.Size(116, 24);
            this.label_weddingdate.TabIndex = 20;
            this.label_weddingdate.Text = "Wedding date";
            // 
            // label_deposit
            // 
            this.label_deposit.AutoSize = true;
            this.label_deposit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_deposit.ForeColor = System.Drawing.Color.Black;
            this.label_deposit.Location = new System.Drawing.Point(350, 109);
            this.label_deposit.Name = "label_deposit";
            this.label_deposit.Size = new System.Drawing.Size(69, 24);
            this.label_deposit.TabIndex = 30;
            this.label_deposit.Text = "Deposit";
            // 
            // label_contingency
            // 
            this.label_contingency.AutoSize = true;
            this.label_contingency.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contingency.ForeColor = System.Drawing.Color.Black;
            this.label_contingency.Location = new System.Drawing.Point(17, 149);
            this.label_contingency.Name = "label_contingency";
            this.label_contingency.Size = new System.Drawing.Size(108, 24);
            this.label_contingency.TabIndex = 28;
            this.label_contingency.Text = "Contingency";
            // 
            // label_table
            // 
            this.label_table.AutoSize = true;
            this.label_table.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_table.ForeColor = System.Drawing.Color.Black;
            this.label_table.Location = new System.Drawing.Point(17, 109);
            this.label_table.Name = "label_table";
            this.label_table.Size = new System.Drawing.Size(140, 24);
            this.label_table.TabIndex = 26;
            this.label_table.Text = "Amount Of Table";
            // 
            // Wedding
            // 
            this.Wedding.Controls.Add(this.cbb_lobby);
            this.Wedding.Controls.Add(this.label1);
            this.Wedding.Controls.Add(this.cbb_shift);
            this.Wedding.Controls.Add(this.label_shift);
            this.Wedding.Controls.Add(this.label_groom);
            this.Wedding.Controls.Add(this.label_representative);
            this.Wedding.Controls.Add(this.label_phone);
            this.Wedding.Controls.Add(this.cbt_deposit);
            this.Wedding.Controls.Add(this.cbt_representative);
            this.Wedding.Controls.Add(this.cbt_phone);
            this.Wedding.Controls.Add(this.cbt_contigency);
            this.Wedding.Controls.Add(this.label_deposit);
            this.Wedding.Controls.Add(this.label_bride);
            this.Wedding.Controls.Add(this.label_contingency);
            this.Wedding.Controls.Add(this.cbt_table);
            this.Wedding.Controls.Add(this.cbt_broom);
            this.Wedding.Controls.Add(this.label_table);
            this.Wedding.Controls.Add(this.cbt_bride);
            this.Wedding.ForeColor = System.Drawing.Color.Black;
            this.Wedding.Location = new System.Drawing.Point(12, 87);
            this.Wedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wedding.Name = "Wedding";
            this.Wedding.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wedding.Size = new System.Drawing.Size(708, 189);
            this.Wedding.TabIndex = 42;
            this.Wedding.TabStop = false;
            this.Wedding.Text = "WEDDING";
            // 
            // cbb_lobby
            // 
            this.cbb_lobby.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_lobby.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_lobby.FormattingEnabled = true;
            this.cbb_lobby.Location = new System.Drawing.Point(583, 147);
            this.cbb_lobby.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_lobby.Name = "cbb_lobby";
            this.cbb_lobby.Size = new System.Drawing.Size(102, 36);
            this.cbb_lobby.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(518, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Lobby";
            // 
            // cbb_shift
            // 
            this.cbb_shift.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_shift.FormattingEnabled = true;
            this.cbb_shift.Location = new System.Drawing.Point(406, 147);
            this.cbb_shift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_shift.Name = "cbb_shift";
            this.cbb_shift.Size = new System.Drawing.Size(106, 36);
            this.cbb_shift.TabIndex = 35;
            // 
            // label_shift
            // 
            this.label_shift.AutoSize = true;
            this.label_shift.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shift.ForeColor = System.Drawing.Color.Black;
            this.label_shift.Location = new System.Drawing.Point(350, 149);
            this.label_shift.Name = "label_shift";
            this.label_shift.Size = new System.Drawing.Size(45, 24);
            this.label_shift.TabIndex = 34;
            this.label_shift.Text = "Shift";
            // 
            // cbt_deposit
            // 
            this.cbt_deposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbt_deposit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_deposit.Location = new System.Drawing.Point(475, 106);
            this.cbt_deposit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_deposit.Name = "cbt_deposit";
            this.cbt_deposit.Size = new System.Drawing.Size(210, 34);
            this.cbt_deposit.TabIndex = 33;
            // 
            // cbt_representative
            // 
            this.cbt_representative.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_representative.Location = new System.Drawing.Point(162, 21);
            this.cbt_representative.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_representative.Name = "cbt_representative";
            this.cbt_representative.Size = new System.Drawing.Size(162, 34);
            this.cbt_representative.TabIndex = 17;
            // 
            // cbt_phone
            // 
            this.cbt_phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_phone.Location = new System.Drawing.Point(162, 66);
            this.cbt_phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_phone.Name = "cbt_phone";
            this.cbt_phone.Size = new System.Drawing.Size(162, 34);
            this.cbt_phone.TabIndex = 18;
            // 
            // cbt_contigency
            // 
            this.cbt_contigency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_contigency.Location = new System.Drawing.Point(162, 146);
            this.cbt_contigency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_contigency.Name = "cbt_contigency";
            this.cbt_contigency.Size = new System.Drawing.Size(162, 34);
            this.cbt_contigency.TabIndex = 31;
            // 
            // cbt_table
            // 
            this.cbt_table.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_table.Location = new System.Drawing.Point(162, 106);
            this.cbt_table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_table.Name = "cbt_table";
            this.cbt_table.Size = new System.Drawing.Size(162, 34);
            this.cbt_table.TabIndex = 27;
            // 
            // cbt_broom
            // 
            this.cbt_broom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbt_broom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_broom.Location = new System.Drawing.Point(475, 23);
            this.cbt_broom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_broom.Name = "cbt_broom";
            this.cbt_broom.Size = new System.Drawing.Size(210, 34);
            this.cbt_broom.TabIndex = 24;
            // 
            // cbt_bride
            // 
            this.cbt_bride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbt_bride.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_bride.Location = new System.Drawing.Point(475, 64);
            this.cbt_bride.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_bride.Name = "cbt_bride";
            this.cbt_bride.Size = new System.Drawing.Size(210, 34);
            this.cbt_bride.TabIndex = 25;
            // 
            // date_booking
            // 
            this.date_booking.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_booking.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_booking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_booking.Location = new System.Drawing.Point(140, 13);
            this.date_booking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_booking.Name = "date_booking";
            this.date_booking.Size = new System.Drawing.Size(134, 30);
            this.date_booking.TabIndex = 34;
            // 
            // date_wedding
            // 
            this.date_wedding.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_wedding.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_wedding.Location = new System.Drawing.Point(443, 13);
            this.date_wedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_wedding.Name = "date_wedding";
            this.date_wedding.Size = new System.Drawing.Size(134, 30);
            this.date_wedding.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_booking);
            this.groupBox1.Controls.Add(this.label_weddingdate);
            this.groupBox1.Controls.Add(this.date_wedding);
            this.groupBox1.Controls.Add(this.label_bookdate);
            this.groupBox1.Location = new System.Drawing.Point(945, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(598, 48);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // btn_add_wedding
            // 
            this.btn_add_wedding.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_add_wedding.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_wedding.ForeColor = System.Drawing.Color.White;
            this.btn_add_wedding.Location = new System.Drawing.Point(396, 517);
            this.btn_add_wedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_wedding.Name = "btn_add_wedding";
            this.btn_add_wedding.Size = new System.Drawing.Size(85, 39);
            this.btn_add_wedding.TabIndex = 49;
            this.btn_add_wedding.Text = "ADD";
            this.btn_add_wedding.UseVisualStyleBackColor = false;
            this.btn_add_wedding.Click += new System.EventHandler(this.btn_add_wedding_Click);
            // 
            // btn_update_wedding
            // 
            this.btn_update_wedding.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_update_wedding.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_wedding.ForeColor = System.Drawing.Color.White;
            this.btn_update_wedding.Location = new System.Drawing.Point(516, 517);
            this.btn_update_wedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update_wedding.Name = "btn_update_wedding";
            this.btn_update_wedding.Size = new System.Drawing.Size(85, 39);
            this.btn_update_wedding.TabIndex = 55;
            this.btn_update_wedding.Text = "UPDATE";
            this.btn_update_wedding.UseVisualStyleBackColor = false;
            this.btn_update_wedding.Click += new System.EventHandler(this.btn_update_wedding_Click);
            // 
            // btn_delete_wedding
            // 
            this.btn_delete_wedding.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_delete_wedding.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_wedding.ForeColor = System.Drawing.Color.White;
            this.btn_delete_wedding.Location = new System.Drawing.Point(635, 517);
            this.btn_delete_wedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete_wedding.Name = "btn_delete_wedding";
            this.btn_delete_wedding.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_wedding.TabIndex = 56;
            this.btn_delete_wedding.Text = "DELETE";
            this.btn_delete_wedding.UseVisualStyleBackColor = false;
            this.btn_delete_wedding.Click += new System.EventHandler(this.btn_delete_wedding_Click);
            // 
            // groupBox_menu
            // 
            this.groupBox_menu.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox_menu.Controls.Add(this.btn_update_item);
            this.groupBox_menu.Controls.Add(this.btn_delete_item);
            this.groupBox_menu.Controls.Add(this.cbt_amount_item);
            this.groupBox_menu.Controls.Add(this.cbt_price_item);
            this.groupBox_menu.Controls.Add(this.btn_add_menu);
            this.groupBox_menu.Controls.Add(this.label_item_price);
            this.groupBox_menu.Controls.Add(this.label_amount_item);
            this.groupBox_menu.Controls.Add(this.cbb_item);
            this.groupBox_menu.Controls.Add(this.label_menu);
            this.groupBox_menu.Location = new System.Drawing.Point(726, 94);
            this.groupBox_menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_menu.Name = "groupBox_menu";
            this.groupBox_menu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_menu.Size = new System.Drawing.Size(349, 219);
            this.groupBox_menu.TabIndex = 58;
            this.groupBox_menu.TabStop = false;
            this.groupBox_menu.Text = "MENU";
            // 
            // btn_update_item
            // 
            this.btn_update_item.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_update_item.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_item.ForeColor = System.Drawing.Color.White;
            this.btn_update_item.Location = new System.Drawing.Point(153, 168);
            this.btn_update_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update_item.Name = "btn_update_item";
            this.btn_update_item.Size = new System.Drawing.Size(85, 39);
            this.btn_update_item.TabIndex = 62;
            this.btn_update_item.Text = "UPDATE";
            this.btn_update_item.UseVisualStyleBackColor = false;
            this.btn_update_item.Click += new System.EventHandler(this.btn_update_item_Click);
            // 
            // btn_delete_item
            // 
            this.btn_delete_item.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_delete_item.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_item.ForeColor = System.Drawing.Color.White;
            this.btn_delete_item.Location = new System.Drawing.Point(244, 168);
            this.btn_delete_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete_item.Name = "btn_delete_item";
            this.btn_delete_item.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_item.TabIndex = 63;
            this.btn_delete_item.Text = "DELETE";
            this.btn_delete_item.UseVisualStyleBackColor = false;
            this.btn_delete_item.Click += new System.EventHandler(this.btn_delete_item_Click);
            // 
            // cbt_amount_item
            // 
            this.cbt_amount_item.BackColor = System.Drawing.Color.White;
            this.cbt_amount_item.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_amount_item.Location = new System.Drawing.Point(136, 76);
            this.cbt_amount_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_amount_item.Name = "cbt_amount_item";
            this.cbt_amount_item.Size = new System.Drawing.Size(193, 34);
            this.cbt_amount_item.TabIndex = 60;
            // 
            // cbt_price_item
            // 
            this.cbt_price_item.BackColor = System.Drawing.Color.White;
            this.cbt_price_item.Enabled = false;
            this.cbt_price_item.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_price_item.Location = new System.Drawing.Point(136, 119);
            this.cbt_price_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_price_item.Name = "cbt_price_item";
            this.cbt_price_item.ReadOnly = true;
            this.cbt_price_item.Size = new System.Drawing.Size(193, 34);
            this.cbt_price_item.TabIndex = 38;
            // 
            // btn_add_menu
            // 
            this.btn_add_menu.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_add_menu.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_menu.ForeColor = System.Drawing.Color.White;
            this.btn_add_menu.Location = new System.Drawing.Point(62, 168);
            this.btn_add_menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_menu.Name = "btn_add_menu";
            this.btn_add_menu.Size = new System.Drawing.Size(85, 39);
            this.btn_add_menu.TabIndex = 59;
            this.btn_add_menu.Text = "ADD";
            this.btn_add_menu.UseVisualStyleBackColor = false;
            this.btn_add_menu.Click += new System.EventHandler(this.btn_add_menu_Click);
            // 
            // label_item_price
            // 
            this.label_item_price.AutoSize = true;
            this.label_item_price.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_item_price.ForeColor = System.Drawing.Color.Black;
            this.label_item_price.Location = new System.Drawing.Point(19, 122);
            this.label_item_price.Name = "label_item_price";
            this.label_item_price.Size = new System.Drawing.Size(86, 24);
            this.label_item_price.TabIndex = 40;
            this.label_item_price.Text = "Item Price";
            // 
            // label_amount_item
            // 
            this.label_amount_item.AutoSize = true;
            this.label_amount_item.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_amount_item.ForeColor = System.Drawing.Color.Black;
            this.label_amount_item.Location = new System.Drawing.Point(19, 79);
            this.label_amount_item.Name = "label_amount_item";
            this.label_amount_item.Size = new System.Drawing.Size(70, 24);
            this.label_amount_item.TabIndex = 38;
            this.label_amount_item.Text = "Amount";
            // 
            // cbb_item
            // 
            this.cbb_item.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_item.FormattingEnabled = true;
            this.cbb_item.Location = new System.Drawing.Point(136, 33);
            this.cbb_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_item.Name = "cbb_item";
            this.cbb_item.Size = new System.Drawing.Size(193, 36);
            this.cbb_item.TabIndex = 37;
            this.cbb_item.SelectedIndexChanged += new System.EventHandler(this.cbb_item_SelectedIndexChanged);
            // 
            // label_menu
            // 
            this.label_menu.AutoSize = true;
            this.label_menu.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_menu.ForeColor = System.Drawing.Color.Black;
            this.label_menu.Location = new System.Drawing.Point(19, 41);
            this.label_menu.Name = "label_menu";
            this.label_menu.Size = new System.Drawing.Size(42, 24);
            this.label_menu.TabIndex = 36;
            this.label_menu.Text = "Item";
            // 
            // btn_detail_item
            // 
            this.btn_detail_item.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_detail_item.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_detail_item.ForeColor = System.Drawing.Color.White;
            this.btn_detail_item.Location = new System.Drawing.Point(363, 186);
            this.btn_detail_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_detail_item.Name = "btn_detail_item";
            this.btn_detail_item.Size = new System.Drawing.Size(85, 32);
            this.btn_detail_item.TabIndex = 61;
            this.btn_detail_item.Text = "DETAIL";
            this.btn_detail_item.UseVisualStyleBackColor = false;
            this.btn_detail_item.Click += new System.EventHandler(this.btn_detail_item_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Linen;
            this.groupBox2.Controls.Add(this.btn_delete_service);
            this.groupBox2.Controls.Add(this.cbt_amount_service);
            this.groupBox2.Controls.Add(this.btn_update_service);
            this.groupBox2.Controls.Add(this.cbt_price_service);
            this.groupBox2.Controls.Add(this.btn_add_service);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbb_service);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(726, 319);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(349, 236);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERVICE";
            // 
            // btn_delete_service
            // 
            this.btn_delete_service.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_delete_service.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_service.ForeColor = System.Drawing.Color.White;
            this.btn_delete_service.Location = new System.Drawing.Point(244, 179);
            this.btn_delete_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete_service.Name = "btn_delete_service";
            this.btn_delete_service.Size = new System.Drawing.Size(85, 39);
            this.btn_delete_service.TabIndex = 65;
            this.btn_delete_service.Text = "DELETE";
            this.btn_delete_service.UseVisualStyleBackColor = false;
            this.btn_delete_service.Click += new System.EventHandler(this.btn_delete_service_Click);
            // 
            // cbt_amount_service
            // 
            this.cbt_amount_service.BackColor = System.Drawing.Color.White;
            this.cbt_amount_service.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_amount_service.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbt_amount_service.Location = new System.Drawing.Point(136, 89);
            this.cbt_amount_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_amount_service.Name = "cbt_amount_service";
            this.cbt_amount_service.Size = new System.Drawing.Size(193, 34);
            this.cbt_amount_service.TabIndex = 61;
            // 
            // btn_update_service
            // 
            this.btn_update_service.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_update_service.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_service.ForeColor = System.Drawing.Color.White;
            this.btn_update_service.Location = new System.Drawing.Point(153, 179);
            this.btn_update_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update_service.Name = "btn_update_service";
            this.btn_update_service.Size = new System.Drawing.Size(85, 39);
            this.btn_update_service.TabIndex = 64;
            this.btn_update_service.Text = "UPDATE";
            this.btn_update_service.UseVisualStyleBackColor = false;
            this.btn_update_service.Click += new System.EventHandler(this.btn_update_service_Click);
            // 
            // cbt_price_service
            // 
            this.cbt_price_service.BackColor = System.Drawing.Color.White;
            this.cbt_price_service.Enabled = false;
            this.cbt_price_service.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbt_price_service.Location = new System.Drawing.Point(136, 130);
            this.cbt_price_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbt_price_service.Name = "cbt_price_service";
            this.cbt_price_service.ReadOnly = true;
            this.cbt_price_service.Size = new System.Drawing.Size(193, 34);
            this.cbt_price_service.TabIndex = 60;
            // 
            // btn_add_service
            // 
            this.btn_add_service.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_add_service.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_service.ForeColor = System.Drawing.Color.White;
            this.btn_add_service.Location = new System.Drawing.Point(62, 179);
            this.btn_add_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_service.Name = "btn_add_service";
            this.btn_add_service.Size = new System.Drawing.Size(85, 39);
            this.btn_add_service.TabIndex = 59;
            this.btn_add_service.Text = "ADD";
            this.btn_add_service.UseVisualStyleBackColor = false;
            this.btn_add_service.Click += new System.EventHandler(this.btn_add_service_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "Service Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Amount";
            // 
            // cbb_service
            // 
            this.cbb_service.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_service.FormattingEnabled = true;
            this.cbb_service.Location = new System.Drawing.Point(136, 45);
            this.cbb_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_service.Name = "cbb_service";
            this.cbb_service.Size = new System.Drawing.Size(193, 36);
            this.cbb_service.TabIndex = 37;
            this.cbb_service.SelectedIndexChanged += new System.EventHandler(this.cbb_service_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 36;
            this.label4.Text = "Serivce";
            // 
            // btn_detail_service
            // 
            this.btn_detail_service.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_detail_service.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_detail_service.ForeColor = System.Drawing.Color.White;
            this.btn_detail_service.Location = new System.Drawing.Point(361, 203);
            this.btn_detail_service.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_detail_service.Name = "btn_detail_service";
            this.btn_detail_service.Size = new System.Drawing.Size(85, 32);
            this.btn_detail_service.TabIndex = 62;
            this.btn_detail_service.Text = "DETAIL";
            this.btn_detail_service.UseVisualStyleBackColor = false;
            this.btn_detail_service.Click += new System.EventHandler(this.btn_detail_service_Click);
            // 
            // dataWedding
            // 
            this.dataWedding.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataWedding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWedding.Location = new System.Drawing.Point(12, 282);
            this.dataWedding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataWedding.Name = "dataWedding";
            this.dataWedding.RowHeadersWidth = 51;
            this.dataWedding.RowTemplate.Height = 24;
            this.dataWedding.Size = new System.Drawing.Size(708, 231);
            this.dataWedding.TabIndex = 57;
            this.dataWedding.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataWedding_CellClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(1528, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 72;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // gb_menu_detail
            // 
            this.gb_menu_detail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_menu_detail.Controls.Add(this.btn_detail_item);
            this.gb_menu_detail.Controls.Add(this.dgv_menu_detail);
            this.gb_menu_detail.Location = new System.Drawing.Point(1085, 94);
            this.gb_menu_detail.Name = "gb_menu_detail";
            this.gb_menu_detail.Size = new System.Drawing.Size(458, 219);
            this.gb_menu_detail.TabIndex = 73;
            this.gb_menu_detail.TabStop = false;
            this.gb_menu_detail.Text = "MENU DETAIL";
            // 
            // dgv_menu_detail
            // 
            this.dgv_menu_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_menu_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_menu_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.itemAmount,
            this.itemPrice});
            this.dgv_menu_detail.Location = new System.Drawing.Point(6, 21);
            this.dgv_menu_detail.Name = "dgv_menu_detail";
            this.dgv_menu_detail.RowHeadersWidth = 51;
            this.dgv_menu_detail.RowTemplate.Height = 24;
            this.dgv_menu_detail.Size = new System.Drawing.Size(442, 161);
            this.dgv_menu_detail.TabIndex = 0;
            this.dgv_menu_detail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_menu_detail_CellClick);
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Item Name";
            this.itemName.MinimumWidth = 6;
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 97;
            // 
            // itemAmount
            // 
            this.itemAmount.HeaderText = "Item Amount";
            this.itemAmount.MinimumWidth = 6;
            this.itemAmount.Name = "itemAmount";
            this.itemAmount.ReadOnly = true;
            this.itemAmount.Width = 98;
            // 
            // itemPrice
            // 
            this.itemPrice.HeaderText = "Total Price";
            this.itemPrice.MinimumWidth = 6;
            this.itemPrice.Name = "itemPrice";
            this.itemPrice.ReadOnly = true;
            this.itemPrice.Width = 97;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_detail_service);
            this.groupBox3.Controls.Add(this.dgv_service_detail);
            this.groupBox3.Location = new System.Drawing.Point(1091, 319);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 236);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SERVICE DETAIL";
            // 
            // dgv_service_detail
            // 
            this.dgv_service_detail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_service_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_service_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serviceName,
            this.serviceAmount,
            this.servicePrice});
            this.dgv_service_detail.Location = new System.Drawing.Point(6, 21);
            this.dgv_service_detail.Name = "dgv_service_detail";
            this.dgv_service_detail.RowHeadersWidth = 51;
            this.dgv_service_detail.RowTemplate.Height = 24;
            this.dgv_service_detail.Size = new System.Drawing.Size(440, 178);
            this.dgv_service_detail.TabIndex = 0;
            this.dgv_service_detail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_service_detail_CellClick);
            // 
            // serviceName
            // 
            this.serviceName.HeaderText = "Service Name";
            this.serviceName.MinimumWidth = 6;
            this.serviceName.Name = "serviceName";
            this.serviceName.ReadOnly = true;
            this.serviceName.Width = 97;
            // 
            // serviceAmount
            // 
            this.serviceAmount.HeaderText = "Service Amount";
            this.serviceAmount.MinimumWidth = 6;
            this.serviceAmount.Name = "serviceAmount";
            this.serviceAmount.ReadOnly = true;
            this.serviceAmount.Width = 97;
            // 
            // servicePrice
            // 
            this.servicePrice.HeaderText = "Total Price";
            this.servicePrice.MinimumWidth = 6;
            this.servicePrice.Name = "servicePrice";
            this.servicePrice.ReadOnly = true;
            this.servicePrice.Width = 96;
            // 
            // FormWedding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1555, 578);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_menu_detail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_menu);
            this.Controls.Add(this.dataWedding);
            this.Controls.Add(this.btn_delete_wedding);
            this.Controls.Add(this.btn_update_wedding);
            this.Controls.Add(this.btn_add_wedding);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Wedding);
            this.Controls.Add(this.label_tittle_wedding_in4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2000, 800);
            this.Name = "FormWedding";
            this.Text = "FormWedding";
            this.Wedding.ResumeLayout(false);
            this.Wedding.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_menu.ResumeLayout(false);
            this.groupBox_menu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWedding)).EndInit();
            this.gb_menu_detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menu_detail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_service_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomBorderTextbox cbt_phone;
        private CustomBorderTextbox cbt_representative;
        private System.Windows.Forms.Label label_bookdate;
        private System.Windows.Forms.Label label_tittle_wedding_in4;
        private System.Windows.Forms.Label label_phone;
        private System.Windows.Forms.Label label_representative;
        private CustomBorderTextbox cbt_bride;
        private CustomBorderTextbox cbt_broom;
        private System.Windows.Forms.Label label_bride;
        private System.Windows.Forms.Label label_groom;
        private System.Windows.Forms.Label label_weddingdate;
        private CustomBorderTextbox cbt_deposit;
        private CustomBorderTextbox cbt_contigency;
        private System.Windows.Forms.Label label_deposit;
        private System.Windows.Forms.Label label_contingency;
        private CustomBorderTextbox cbt_table;
        private System.Windows.Forms.Label label_table;
        private System.Windows.Forms.GroupBox Wedding;
        private System.Windows.Forms.DateTimePicker date_booking;
        private System.Windows.Forms.DateTimePicker date_wedding;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_add_wedding;
        private System.Windows.Forms.Button btn_update_wedding;
        private System.Windows.Forms.Button btn_delete_wedding;
        private System.Windows.Forms.ComboBox cbb_lobby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_shift;
        private System.Windows.Forms.Label label_shift;
        private System.Windows.Forms.GroupBox groupBox_menu;
        private CustomBorderTextbox cbt_price_item;
        private System.Windows.Forms.Button btn_add_menu;
        private System.Windows.Forms.Label label_item_price;
        private System.Windows.Forms.Label label_amount_item;
        private System.Windows.Forms.ComboBox cbb_item;
        private System.Windows.Forms.Label label_menu;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomBorderTextbox cbt_price_service;
        private System.Windows.Forms.Button btn_add_service;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_service;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataWedding;
        private CustomBorderTextbox cbt_amount_item;
        private CustomBorderTextbox cbt_amount_service;
        private System.Windows.Forms.Button btn_detail_item;
        private System.Windows.Forms.Button btn_detail_service;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb_menu_detail;
        private System.Windows.Forms.DataGridView dgv_menu_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_service_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceAmount;
        private System.Windows.Forms.Button btn_delete_item;
        private System.Windows.Forms.Button btn_update_item;
        private System.Windows.Forms.Button btn_delete_service;
        private System.Windows.Forms.Button btn_update_service;
    }
}