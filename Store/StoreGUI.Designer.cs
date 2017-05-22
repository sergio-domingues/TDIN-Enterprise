namespace Store
{
    partial class StoreGUI
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
            this.sellButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ordersListView = new System.Windows.Forms.ListView();
            this.BookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sellButton
            // 
            this.sellButton.Location = new System.Drawing.Point(34, 205);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(164, 23);
            this.sellButton.TabIndex = 0;
            this.sellButton.Text = "Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Stock,
            this.Price});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(34, 39);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(468, 160);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 344;
            // 
            // Stock
            // 
            this.Stock.Text = "Stock";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // ordersListView
            // 
            this.ordersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BookTitle,
            this.Quantity,
            this.id});
            this.ordersListView.FullRowSelect = true;
            this.ordersListView.Location = new System.Drawing.Point(34, 279);
            this.ordersListView.MultiSelect = false;
            this.ordersListView.Name = "ordersListView";
            this.ordersListView.Size = new System.Drawing.Size(468, 160);
            this.ordersListView.TabIndex = 10;
            this.ordersListView.UseCompatibleStateImageBehavior = false;
            this.ordersListView.View = System.Windows.Forms.View.Details;
            // 
            // BookTitle
            // 
            this.BookTitle.Text = "BookTitle";
            this.BookTitle.Width = 176;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 58;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 232;
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(338, 205);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(164, 23);
            this.orderButton.TabIndex = 11;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Available books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Received orders";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(34, 445);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(164, 23);
            this.acceptButton.TabIndex = 14;
            this.acceptButton.Text = "Accept Order";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // StoreGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 484);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.ordersListView);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.sellButton);
            this.Name = "StoreGUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StoreGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView ordersListView;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Stock;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader BookTitle;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader id;
    }
}

