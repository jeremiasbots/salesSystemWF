namespace Course
{
    partial class Form1
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
            this.data_groupbox = new System.Windows.Forms.GroupBox();
            this.client_label = new System.Windows.Forms.Label();
            this.client_textbox = new System.Windows.Forms.TextBox();
            this.date_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.venta_data = new System.Windows.Forms.GroupBox();
            this.product_label = new System.Windows.Forms.Label();
            this.product_combo_box = new System.Windows.Forms.ComboBox();
            this.price_label = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.cancelar_button = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.register_listbox = new System.Windows.Forms.ListView();
            this.productColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subtotalColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.discountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.netColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_total_label = new System.Windows.Forms.Label();
            this.quantity_net_total_label = new System.Windows.Forms.Label();
            this.quantity_venta_label = new System.Windows.Forms.Label();
            this.quantity_text_box = new System.Windows.Forms.TextBox();
            this.data_groupbox.SuspendLayout();
            this.venta_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_groupbox
            // 
            this.data_groupbox.Controls.Add(this.client_textbox);
            this.data_groupbox.Controls.Add(this.client_label);
            this.data_groupbox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.data_groupbox.Location = new System.Drawing.Point(12, 12);
            this.data_groupbox.Name = "data_groupbox";
            this.data_groupbox.Size = new System.Drawing.Size(660, 161);
            this.data_groupbox.TabIndex = 2;
            this.data_groupbox.TabStop = false;
            this.data_groupbox.Text = "DATOS DEL CLIENTE";
            // 
            // client_label
            // 
            this.client_label.AutoSize = true;
            this.client_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.client_label.Location = new System.Drawing.Point(6, 29);
            this.client_label.Name = "client_label";
            this.client_label.Size = new System.Drawing.Size(68, 21);
            this.client_label.TabIndex = 0;
            this.client_label.Text = "CLIENTE";
            this.client_label.Click += new System.EventHandler(this.client_label_Click);
            // 
            // client_textbox
            // 
            this.client_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.client_textbox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.client_textbox.Location = new System.Drawing.Point(7, 52);
            this.client_textbox.Name = "client_textbox";
            this.client_textbox.Size = new System.Drawing.Size(601, 22);
            this.client_textbox.TabIndex = 1;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.date_label.Location = new System.Drawing.Point(839, 12);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(57, 21);
            this.date_label.TabIndex = 2;
            this.date_label.Text = "FECHA";
            this.date_label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.time_label.Location = new System.Drawing.Point(1004, 12);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(53, 21);
            this.time_label.TabIndex = 3;
            this.time_label.Text = "HORA";
            // 
            // venta_data
            // 
            this.venta_data.Controls.Add(this.quantity_text_box);
            this.venta_data.Controls.Add(this.quantity_venta_label);
            this.venta_data.Controls.Add(this.registerButton);
            this.venta_data.Controls.Add(this.cancelar_button);
            this.venta_data.Controls.Add(this.lblPrecio);
            this.venta_data.Controls.Add(this.price_label);
            this.venta_data.Controls.Add(this.product_combo_box);
            this.venta_data.Controls.Add(this.product_label);
            this.venta_data.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.venta_data.Location = new System.Drawing.Point(12, 229);
            this.venta_data.Name = "venta_data";
            this.venta_data.Size = new System.Drawing.Size(1168, 161);
            this.venta_data.TabIndex = 3;
            this.venta_data.TabStop = false;
            this.venta_data.Text = "DATOS DE LA VENTA";
            // 
            // product_label
            // 
            this.product_label.AutoSize = true;
            this.product_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.product_label.Location = new System.Drawing.Point(6, 29);
            this.product_label.Name = "product_label";
            this.product_label.Size = new System.Drawing.Size(92, 21);
            this.product_label.TabIndex = 0;
            this.product_label.Text = "PRODUCTO";
            // 
            // product_combo_box
            // 
            this.product_combo_box.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.product_combo_box.FormattingEnabled = true;
            this.product_combo_box.Location = new System.Drawing.Point(6, 57);
            this.product_combo_box.Name = "product_combo_box";
            this.product_combo_box.Size = new System.Drawing.Size(414, 33);
            this.product_combo_box.TabIndex = 1;
            this.product_combo_box.SelectedIndexChanged += new System.EventHandler(this.product_combo_box_SelectedIndexChanged);
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.price_label.Location = new System.Drawing.Point(597, 29);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(63, 21);
            this.price_label.TabIndex = 2;
            this.price_label.Text = "PRECIO";
            this.price_label.Click += new System.EventHandler(this.price_label_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPrecio.Location = new System.Drawing.Point(607, 62);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(70, 21);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "lblPrecio";
            this.lblPrecio.Click += new System.EventHandler(this.lblPrecio_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFecha.Location = new System.Drawing.Point(838, 41);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(67, 21);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "lblFecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHora.Location = new System.Drawing.Point(1003, 41);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(61, 21);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "lblHora";
            // 
            // cancelar_button
            // 
            this.cancelar_button.BackColor = System.Drawing.SystemColors.Control;
            this.cancelar_button.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cancelar_button.Location = new System.Drawing.Point(723, 23);
            this.cancelar_button.Name = "cancelar_button";
            this.cancelar_button.Size = new System.Drawing.Size(191, 51);
            this.cancelar_button.TabIndex = 4;
            this.cancelar_button.Text = "CANCELAR";
            this.cancelar_button.UseVisualStyleBackColor = false;
            this.cancelar_button.Click += new System.EventHandler(this.cancelar_button_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.SystemColors.Control;
            this.registerButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.registerButton.Location = new System.Drawing.Point(723, 89);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(191, 51);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "REGISTRAR";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // register_listbox
            // 
            this.register_listbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productColumn,
            this.quantityColumn,
            this.priceColumn,
            this.subtotalColumn,
            this.discountColumn,
            this.netColumn});
            this.register_listbox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.register_listbox.HideSelection = false;
            this.register_listbox.Location = new System.Drawing.Point(12, 407);
            this.register_listbox.Name = "register_listbox";
            this.register_listbox.Size = new System.Drawing.Size(1176, 241);
            this.register_listbox.TabIndex = 6;
            this.register_listbox.UseCompatibleStateImageBehavior = false;
            this.register_listbox.View = System.Windows.Forms.View.Details;
            // 
            // productColumn
            // 
            this.productColumn.Text = "PRODUCTO";
            this.productColumn.Width = 150;
            // 
            // quantityColumn
            // 
            this.quantityColumn.Text = "CANTIDAD";
            this.quantityColumn.Width = 120;
            // 
            // priceColumn
            // 
            this.priceColumn.Text = "PRECIO";
            this.priceColumn.Width = 120;
            // 
            // subtotalColumn
            // 
            this.subtotalColumn.Text = "SUBTOTAL";
            this.subtotalColumn.Width = 150;
            // 
            // discountColumn
            // 
            this.discountColumn.Text = "DESCUENTO";
            this.discountColumn.Width = 150;
            // 
            // netColumn
            // 
            this.netColumn.Text = "NETO";
            this.netColumn.Width = 80;
            // 
            // net_total_label
            // 
            this.net_total_label.AutoSize = true;
            this.net_total_label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.net_total_label.Location = new System.Drawing.Point(908, 667);
            this.net_total_label.Name = "net_total_label";
            this.net_total_label.Size = new System.Drawing.Size(110, 25);
            this.net_total_label.TabIndex = 7;
            this.net_total_label.Text = "TOTAL NETO";
            this.net_total_label.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // quantity_net_total_label
            // 
            this.quantity_net_total_label.AutoSize = true;
            this.quantity_net_total_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.quantity_net_total_label.Location = new System.Drawing.Point(1039, 664);
            this.quantity_net_total_label.Name = "quantity_net_total_label";
            this.quantity_net_total_label.Size = new System.Drawing.Size(130, 28);
            this.quantity_net_total_label.TabIndex = 8;
            this.quantity_net_total_label.Text = "lblTotalNeto";
            // 
            // quantity_venta_label
            // 
            this.quantity_venta_label.AutoSize = true;
            this.quantity_venta_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.quantity_venta_label.Location = new System.Drawing.Point(470, 29);
            this.quantity_venta_label.Name = "quantity_venta_label";
            this.quantity_venta_label.Size = new System.Drawing.Size(86, 21);
            this.quantity_venta_label.TabIndex = 6;
            this.quantity_venta_label.Text = "CANTIDAD";
            // 
            // quantity_text_box
            // 
            this.quantity_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantity_text_box.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.quantity_text_box.Location = new System.Drawing.Point(473, 62);
            this.quantity_text_box.Name = "quantity_text_box";
            this.quantity_text_box.Size = new System.Drawing.Size(82, 22);
            this.quantity_text_box.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 707);
            this.Controls.Add(this.quantity_net_total_label);
            this.Controls.Add(this.net_total_label);
            this.Controls.Add(this.register_listbox);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.venta_data);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.data_groupbox);
            this.Name = "Form1";
            this.Text = "Sistema de ventas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.data_groupbox.ResumeLayout(false);
            this.data_groupbox.PerformLayout();
            this.venta_data.ResumeLayout(false);
            this.venta_data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox data_groupbox;
        private System.Windows.Forms.TextBox client_textbox;
        private System.Windows.Forms.Label client_label;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.GroupBox venta_data;
        private System.Windows.Forms.Button cancelar_button;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.ComboBox product_combo_box;
        private System.Windows.Forms.Label product_label;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.ListView register_listbox;
        private System.Windows.Forms.ColumnHeader productColumn;
        private System.Windows.Forms.ColumnHeader quantityColumn;
        private System.Windows.Forms.ColumnHeader priceColumn;
        private System.Windows.Forms.ColumnHeader subtotalColumn;
        private System.Windows.Forms.ColumnHeader discountColumn;
        private System.Windows.Forms.ColumnHeader netColumn;
        private System.Windows.Forms.Label net_total_label;
        private System.Windows.Forms.Label quantity_net_total_label;
        private System.Windows.Forms.Label quantity_venta_label;
        private System.Windows.Forms.TextBox quantity_text_box;
    }
}

