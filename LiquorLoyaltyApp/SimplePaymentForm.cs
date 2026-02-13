using iTextSharp.text.pdf;
using iTextSharp.text;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiquorLoyaltyApp
{
    public partial class SimplePaymentForm : Form
    {
        int totalAmount;

        public SimplePaymentForm(int total)
        {
            InitializeComponent();
            totalAmount = total;
        }

        


        


        private void btnGenerateQR_Click(object sender, EventArgs e)
        {
            string txnId = "TXN" + DateTime.Now.Ticks;

            string upiId = "7338147178@ptsbi"; // 🔴 REAL & ACTIVE UPI ID
            string merchantName = "LiquorStore";

            string encodedName = Uri.EscapeDataString(merchantName);
            string amount = totalAmount.ToString("0.00");

            // 🔹 REAL UPI DEEP LINK
            string qrText =
                "upi://pay?" +
                "pa=" + upiId + "&" +
                "pn=" + encodedName + "&" +
                "am=" + amount + "&" +
                "cu=INR&" +
                "tn=" + txnId;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(
                qrText,
                QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(6);

            picQR.Image = qrImage;
            btnPaymentDone.Enabled = true;
        }

        private void GenerateSimpleInvoice(string paymentType, int amount)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(
                folderPath,
                $"Invoice_{DateTime.Now.Ticks}.pdf"
            );

            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            iTextSharp.text.Font titleFont =
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);

            iTextSharp.text.Font normalFont =
                FontFactory.GetFont(FontFactory.HELVETICA, 12);

            doc.Add(new Paragraph("Liquor Store Invoice", titleFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph($"Date: {DateTime.Now}", normalFont));
            doc.Add(new Paragraph($"Payment Mode: {paymentType}", normalFont));
            doc.Add(new Paragraph($"Total Amount Paid: ₹{amount}", normalFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Thank you for your purchase!", normalFont));

            doc.Close();

            // Auto open invoice
            System.Diagnostics.Process.Start(filePath);
        }

        private void btnPaymentDone_Click(object sender, EventArgs e)
        {
            GenerateSimpleInvoice("UPI", totalAmount);

            MessageBox.Show(
                "Payment successful!\nInvoice downloaded.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SimplePaymentForm_Load_1(object sender, EventArgs e)
        {
            lblTotal.Text = $"Total: ₹{totalAmount}";
            lblPayable.Text = $"Payable: ₹{totalAmount}";
        }
    }
}
