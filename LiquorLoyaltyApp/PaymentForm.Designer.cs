namespace LiquorLoyaltyApp
{
    partial class PaymentForm
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
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSendOtp = new System.Windows.Forms.Button();
            this.lblOtp = new System.Windows.Forms.Label();
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnPaymentDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(30, 30);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(127, 23);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(30, 60);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 26);
            this.txtPhone.TabIndex = 1;
            // 
            // btnSendOtp
            // 
            this.btnSendOtp.BackColor = System.Drawing.Color.Blue;
            this.btnSendOtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOtp.ForeColor = System.Drawing.Color.White;
            this.btnSendOtp.Location = new System.Drawing.Point(30, 100);
            this.btnSendOtp.Name = "btnSendOtp";
            this.btnSendOtp.Size = new System.Drawing.Size(200, 33);
            this.btnSendOtp.TabIndex = 2;
            this.btnSendOtp.Text = "Send OTP";
            this.btnSendOtp.UseVisualStyleBackColor = false;
            this.btnSendOtp.Click += new System.EventHandler(this.btnSendOtp_Click);
            // 
            // lblOtp
            // 
            this.lblOtp.AutoSize = true;
            this.lblOtp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOtp.ForeColor = System.Drawing.Color.White;
            this.lblOtp.Location = new System.Drawing.Point(30, 150);
            this.lblOtp.Name = "lblOtp";
            this.lblOtp.Size = new System.Drawing.Size(86, 23);
            this.lblOtp.TabIndex = 3;
            this.lblOtp.Text = "Enter OTP";
            // 
            // txtOtp
            // 
            this.txtOtp.Location = new System.Drawing.Point(30, 180);
            this.txtOtp.MaxLength = 6;
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(200, 26);
            this.txtOtp.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Green;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(30, 230);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(200, 35);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm OTP";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotal.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTotal.Location = new System.Drawing.Point(393, 69);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 32);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total: ₹0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblDiscount.ForeColor = System.Drawing.Color.LightGreen;
            this.lblDiscount.Location = new System.Drawing.Point(393, 117);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(146, 32);
            this.lblDiscount.TabIndex = 7;
            this.lblDiscount.Text = "Discount: ₹0";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblFinal.ForeColor = System.Drawing.Color.Orange;
            this.lblFinal.Location = new System.Drawing.Point(393, 164);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(133, 32);
            this.lblFinal.TabIndex = 8;
            this.lblFinal.Text = "Payable: ₹0";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(399, 230);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(200, 35);
            this.btnPay.TabIndex = 9;
            this.btnPay.Text = "Pay Now";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(399, 271);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(200, 200);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 10;
            this.picQR.TabStop = false;
            // 
            // btnPaymentDone
            // 
            this.btnPaymentDone.BackColor = System.Drawing.Color.Green;
            this.btnPaymentDone.Enabled = false;
            this.btnPaymentDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentDone.ForeColor = System.Drawing.Color.White;
            this.btnPaymentDone.Location = new System.Drawing.Point(399, 477);
            this.btnPaymentDone.Name = "btnPaymentDone";
            this.btnPaymentDone.Size = new System.Drawing.Size(200, 35);
            this.btnPaymentDone.TabIndex = 11;
            this.btnPaymentDone.Text = "Payment Done";
            this.btnPaymentDone.UseVisualStyleBackColor = false;
            this.btnPaymentDone.Click += new System.EventHandler(this.btnPaymentDone_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.btnPaymentDone);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtOtp);
            this.Controls.Add(this.lblOtp);
            this.Controls.Add(this.btnSendOtp);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OTP Verification";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSendOtp;
        private System.Windows.Forms.Label lblOtp;
        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button btnPaymentDone;
    }
}