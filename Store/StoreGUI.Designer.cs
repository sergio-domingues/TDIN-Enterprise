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
            this.ordersListView = new System.Windows.Forms.ListView();
            this.orderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.BookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // sellButton
            // 
            this.sellButton.Location = new System.Drawing.Point(34, 219);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(65, 23);
            this.sellButton.TabIndex = 0;
            this.sellButton.Text = "Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(34, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(141, 160);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ordersListView
            // 
            this.ordersListView.FullRowSelect = true;
            this.ordersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BookTitle,
            this.Quantity,
            this.id});
            this.ordersListView.Location = new System.Drawing.Point(236, 39);
            this.ordersListView.MultiSelect = false;
            this.ordersListView.Name = "ordersListView";
            this.ordersListView.Size = new System.Drawing.Size(141, 160);
            this.ordersListView.TabIndex = 10;
            this.ordersListView.UseCompatibleStateImageBehavior = false;
            this.ordersListView.View = System.Windows.Forms.View.Details;
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(110, 219);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(65, 23);
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
            this.label2.Location = new System.Drawing.Point(233, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Received order";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(261, 219);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(91, 23);
            this.acceptButton.TabIndex = 14;
            this.acceptButton.Text = "Accept Order";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // BookTitle
            // 
            this.BookTitle.Text = "BookTitle";
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 51;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 100;
            // 
            // StoreGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 264);
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
        private System.Windows.Forms.ColumnHeader BookTitle;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader id;
    }
}

