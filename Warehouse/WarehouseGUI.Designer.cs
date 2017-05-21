namespace Warehouse
{
    partial class warehouseGUI
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
            this.ordersListView = new System.Windows.Forms.ListView();
            this.ordersListView.FullRowSelect = true;
            this.shipButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ordersListView
            // 
            this.ordersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Client,
            this.BookTitle,
            this.Quantity,
            this.Status,
            this.id});
            this.ordersListView.Location = new System.Drawing.Point(27, 51);
            this.ordersListView.Name = "ordersListView";
            this.ordersListView.Size = new System.Drawing.Size(504, 170);
            this.ordersListView.TabIndex = 0;
            this.ordersListView.UseCompatibleStateImageBehavior = false;
            this.ordersListView.View = System.Windows.Forms.View.Details;
            // 
            // shipButton
            // 
            this.shipButton.Location = new System.Drawing.Point(208, 228);
            this.shipButton.Name = "shipButton";
            this.shipButton.Size = new System.Drawing.Size(95, 23);
            this.shipButton.TabIndex = 1;
            this.shipButton.Text = "Ship Order";
            this.shipButton.UseVisualStyleBackColor = true;
            this.shipButton.Click += new System.EventHandler(this.shipButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Orders";
            // 
            // Client
            // 
            this.Client.Text = "Client";
            this.Client.Width = 105;
            // 
            // BookTitle
            // 
            this.BookTitle.Text = "BookTitle";
            this.BookTitle.Width = 89;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 56;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 57;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 200;
            // 
            // warehouseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 263);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shipButton);
            this.Controls.Add(this.ordersListView);
            this.Name = "warehouseGUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.warehouseGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ordersListView;
        private System.Windows.Forms.Button shipButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Client;
        private System.Windows.Forms.ColumnHeader BookTitle;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader id;
    }
}