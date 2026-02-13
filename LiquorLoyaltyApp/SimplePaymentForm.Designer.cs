namespace LiquorLoyaltyApp
{
    partial class SimplePaymentForm
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPayable = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnGenerateQR = new System.Windows.Forms.Button();
            this.btnPaymentDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotal.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTotal.Location = new System.Drawing.Point(73, 56);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 32);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total:";
            // 
            // lblPayable
            // 
            this.lblPayable.AutoSize = true;
            this.lblPayable.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblPayable.ForeColor = System.Drawing.Color.LightGreen;
            this.lblPayable.Location = new System.Drawing.Point(76, 109);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.Size = new System.Drawing.Size(100, 32);
            this.lblPayable.TabIndex = 1;
            this.lblPayable.Text = "Payable:";
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(82, 223);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(200, 200);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 2;
            this.picQR.TabStop = false;
            // 
            // btnGenerateQR
            // 
            this.btnGenerateQR.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGenerateQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenerateQR.ForeColor = System.Drawing.Color.White;
            this.btnGenerateQR.Location = new System.Drawing.Point(82, 180);
            this.btnGenerateQR.Name = "btnGenerateQR";
            this.btnGenerateQR.Size = new System.Drawing.Size(200, 35);
            this.btnGenerateQR.TabIndex = 3;
            this.btnGenerateQR.Text = "Generate QR";
            this.btnGenerateQR.UseVisualStyleBackColor = false;
            this.btnGenerateQR.Click += new System.EventHandler(this.btnGenerateQR_Click);
            // 
            // btnPaymentDone
            // 
            this.btnPaymentDone.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPaymentDone.Enabled = false;
            this.btnPaymentDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPaymentDone.ForeColor = System.Drawing.Color.White;
            this.btnPaymentDone.Location = new System.Drawing.Point(82, 442);
            this.btnPaymentDone.Name = "btnPaymentDone";
            this.btnPaymentDone.Size = new System.Drawing.Size(200, 35);
            this.btnPaymentDone.TabIndex = 4;
            this.btnPaymentDone.Text = "Payment Done";
            this.btnPaymentDone.UseVisualStyleBackColor = false;
            this.btnPaymentDone.Click += new System.EventHandler(this.btnPaymentDone_Click);
            // 
            // SimplePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.btnPaymentDone);
            this.Controls.Add(this.btnGenerateQR);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblPayable);
            this.Controls.Add(this.lblTotal);
            this.Name = "SimplePaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SimplePaymentForm";
            this.Load += new System.EventHandler(this.SimplePaymentForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPayable;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button btnGenerateQR;
        private System.Windows.Forms.Button btnPaymentDone;
    }
}