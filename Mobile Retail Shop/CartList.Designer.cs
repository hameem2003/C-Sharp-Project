namespace Mobile_Retail_Shop
{
    partial class CartList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.total_price = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.price = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.quantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.total_price);
            this.panel1.Controls.Add(this.price);
            this.panel1.Controls.Add(this.quantity);
            this.panel1.Controls.Add(this.name);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 63);
            this.panel1.TabIndex = 0;
            // 
            // total_price
            // 
            this.total_price.BackColor = System.Drawing.Color.Transparent;
            this.total_price.Location = new System.Drawing.Point(247, 34);
            this.total_price.Name = "total_price";
            this.total_price.Size = new System.Drawing.Size(57, 15);
            this.total_price.TabIndex = 1;
            this.total_price.Text = "Total Price: ";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Location = new System.Drawing.Point(134, 34);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(30, 15);
            this.price.TabIndex = 2;
            this.price.Text = "Price: ";
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.Color.Transparent;
            this.quantity.Location = new System.Drawing.Point(29, 34);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(42, 15);
            this.quantity.TabIndex = 3;
            this.quantity.Text = "Quantity";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Location = new System.Drawing.Point(29, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(34, 15);
            this.name.TabIndex = 4;
            this.name.Text = "Name: ";
            // 
            // CartList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CartList";
            this.Size = new System.Drawing.Size(423, 69);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel total_price;
        private Guna.UI2.WinForms.Guna2HtmlLabel price;
        private Guna.UI2.WinForms.Guna2HtmlLabel quantity;
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
    }
}
