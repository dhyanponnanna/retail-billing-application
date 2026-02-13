namespace LiquorLoyaltyApp
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
            this.pnlCart = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblPoints = new System.Windows.Forms.Label();
            this.btnUsePoints = new System.Windows.Forms.Button();
            this.pnlCart.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlCart.Controls.Add(this.btnUsePoints);
            this.pnlCart.Controls.Add(this.lblPoints);
            this.pnlCart.Controls.Add(this.btnRemove);
            this.pnlCart.Controls.Add(this.btnPay);
            this.pnlCart.Controls.Add(this.lblTotal);
            this.pnlCart.Controls.Add(this.lstCart);
            this.pnlCart.Controls.Add(this.label1);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCart.Location = new System.Drawing.Point(580, 0);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(320, 647);
            this.pnlCart.TabIndex = 0;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Green;
            this.btnPay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(0, 602);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(320, 45);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotal.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTotal.Location = new System.Drawing.Point(105, 399);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 32);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total: ₹0";
            // 
            // lstCart
            // 
            this.lstCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.lstCart.ForeColor = System.Drawing.Color.White;
            this.lstCart.FormattingEnabled = true;
            this.lstCart.ItemHeight = 23;
            this.lstCart.Location = new System.Drawing.Point(20, 60);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(280, 326);
            this.lstCart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "CART";
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.flpProducts);
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProducts.Location = new System.Drawing.Point(0, 0);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(580, 647);
            this.pnlProducts.TabIndex = 1;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 0);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(580, 647);
            this.flpProducts.TabIndex = 0;
            this.flpProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flpProducts_Paint);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DarkRed;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(0, 434);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(320, 45);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.ForeColor = System.Drawing.Color.LightBlue;
            this.lblPoints.Location = new System.Drawing.Point(3, 504);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(132, 23);
            this.lblPoints.TabIndex = 5;
            this.lblPoints.Text = "Loyalty Points: 0";
            this.lblPoints.Visible = false;
            // 
            // btnUsePoints
            // 
            this.btnUsePoints.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUsePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsePoints.ForeColor = System.Drawing.Color.White;
            this.btnUsePoints.Location = new System.Drawing.Point(0, 551);
            this.btnUsePoints.Name = "btnUsePoints";
            this.btnUsePoints.Size = new System.Drawing.Size(320, 45);
            this.btnUsePoints.TabIndex = 7;
            this.btnUsePoints.Text = "Use Loyalty Points";
            this.btnUsePoints.UseVisualStyleBackColor = false;
            this.btnUsePoints.Click += new System.EventHandler(this.btnUsePoints_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlCart);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquor Loyalty POS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            this.pnlProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUsePoints;
        private System.Windows.Forms.Label lblPoints;
    }
}

