using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



namespace LiquorLoyaltyApp
{
    public partial class PaymentForm : Form
    {
        public string PhoneNumber { get; private set; }
        int originalTotal = 0;
        int finalTotal = 0;
        int userPoints = 0;
        int pointsEarned = 0;




        public PaymentForm()
        {
            InitializeComponent();
        }

        public PaymentForm(int totalAmount)
        {
            InitializeComponent();
            originalTotal = totalAmount;
            finalTotal = totalAmount;
        }


        private async void btnSendOtp_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid 10-digit phone number");
                return;
            }

            HttpClient client = new HttpClient();

            var data = new
            {
                phone = txtPhone.Text
            };

            string json = JsonConvert.SerializeObject(data);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            await client.PostAsync(
                "http://localhost:3000/api/send-otp",
                content
            );

            MessageBox.Show("OTP has been sent to your mobile number");
        }


        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOtp.Text))
            {
                MessageBox.Show("Please enter OTP");
                return;
            }

            // Verify OTP
            HttpClient client = new HttpClient();

            var data = new
            {
                phone = txtPhone.Text,
                otp = txtOtp.Text
            };

            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "http://localhost:3000/api/verify-otp",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Invalid OTP");
                return;
            }

            // ✅ OTP SUCCESS
            MessageBox.Show("OTP Verified! Loyalty discount applied.");

            PhoneNumber = txtPhone.Text;

            // Fetch points
            userPoints = await GetUserPointsAsync(PhoneNumber);

            int discount = Math.Min(userPoints, originalTotal);
            finalTotal = originalTotal - discount;

            lblDiscount.Text = $"Discount: ₹{discount}";
            lblFinal.Text = $"Payable: ₹{finalTotal}";

            // ❌ DO NOT update backend here
        }


        private async Task SaveUserAsync(string phone, int points)
        {
            HttpClient client = new HttpClient();

            var data = new
            {
                phone = phone,
                points = points
            };

            string json = JsonConvert.SerializeObject(data);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            await client.PostAsync(
                "http://localhost:3000/api/user",
                content
            );
        }


        private async Task<int> GetUserPointsAsync(string phone)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync(
                $"http://localhost:3000/api/user/{phone}"
            );

            dynamic user = JsonConvert.DeserializeObject(json);

            return (int)user.points;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string txnId = "TXN" + DateTime.Now.Ticks;

            string upiId = "7338147178@ptsbi"; // 🔴 REAL & ACTIVE UPI ID
            string merchantName = "LiquorStore";

            string encodedName = Uri.EscapeDataString(merchantName);
            string amount = finalTotal.ToString("0.00");

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

            // ✅ Enable Payment Done button
            btnPaymentDone.Enabled = true;
        }






        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblTotal.Text = $"Total: ₹{originalTotal}";
            lblDiscount.Text = "Discount: ₹0";
            lblFinal.Text = $"Payable: ₹{finalTotal}";
        }

        private void GenerateQrCode()
        {

            string upiId = "7338147178@ptsbi";   // 🔴 MUST be a REAL, ACTIVE UPI ID
            string merchantName = "LiquorStore";
            string txnId = "TXN" + DateTime.Now.Ticks;

            string encodedName = Uri.EscapeDataString(merchantName);
            string amount = finalTotal.ToString("0.00");

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
            picQR.Image = qrCode.GetGraphic(6);


        }

        private async void btnPaymentDone_Click(object sender, EventArgs e)
        {
            // 🔹 1. Calculate loyalty values
            int redeemedPoints = originalTotal - finalTotal;   // discount used
            pointsEarned = finalTotal / 100;

            int finalPoints = (userPoints - redeemedPoints) + pointsEarned;
            if (finalPoints < 0)
                finalPoints = 0;

            // 🔹 2. Update backend with new loyalty points
            await SaveUserAsync(PhoneNumber, finalPoints);

            // 🔹 3. Generate transaction ID
            string txnId = "TXN" + DateTime.Now.Ticks;

            // 🔹 4. Generate invoice PDF
            GenerateInvoicePdf(
                PhoneNumber,
                originalTotal,
                redeemedPoints,
                finalTotal,
                redeemedPoints,
                pointsEarned,
                finalPoints,
                txnId
            );

            // 🔹 5. Confirmation
            MessageBox.Show(
                "Payment successful!\nInvoice downloaded.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // 🔹 6. Close payment form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void GenerateInvoicePdf(
     string phone,
     int originalAmount,
     int discount,
     int finalAmount,
     int pointsUsed,
     int pointsEarned,
     int finalPoints,
     string txnId)

        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, $"Invoice_{txnId}.pdf");

            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            iTextSharp.text.Font titleFont =
    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);

            iTextSharp.text.Font normalFont =
                FontFactory.GetFont(FontFactory.HELVETICA, 11);


            doc.Add(new Paragraph("Liquor Store Invoice", titleFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph($"Transaction ID: {txnId}", normalFont));
            doc.Add(new Paragraph($"Date: {DateTime.Now}", normalFont));
            doc.Add(new Paragraph($"Customer Phone: {phone}", normalFont));
            doc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.AddCell("Description");
            table.AddCell("Amount (₹)");

            table.AddCell("Original Amount");
            table.AddCell(originalAmount.ToString());

            table.AddCell("Loyalty Discount");
            table.AddCell($"- {discount}");

            table.AddCell("Final Amount Paid");
            table.AddCell(finalAmount.ToString());

            doc.Add(table);
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph($"Points Used: {pointsUsed}", normalFont));
            doc.Add(new Paragraph($"Points Earned: {pointsEarned}", normalFont));
            doc.Add(new Paragraph($"Total Loyalty Points: {finalPoints}", normalFont));

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Thank you for your purchase!", normalFont));

            doc.Close();

            // 🔹 Automatically open (download)
            System.Diagnostics.Process.Start(filePath);
        }


    }
}
