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
using Newtonsoft.Json;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace LiquorLoyaltyApp
{
    public partial class Form1 : Form
    {
        List<Alcohol> alcohols = new List<Alcohol>();
        int total = 0;
        string currentUserPhone = "";
        int currentUserPoints = 0;
        bool pointsApplied = false;


        private int CalculateLoyaltyPoints(int amount)
        {
            return amount / 100;
        }

        private void LoadLiquorCards()
        {
            flpProducts.Controls.Clear();

            foreach (var item in alcohols)
            {
                Panel card = new Panel();
                card.Width = 220;
                card.Height = 140;
                card.BackColor = Color.FromArgb(40, 40, 64);
                card.Margin = new Padding(10);

                Label lblName = new Label();
                lblName.Text = item.name;
                lblName.ForeColor = Color.White;
                lblName.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
                lblName.Location = new Point(10, 10);
                lblName.AutoSize = true;

                Label lblPrice = new Label();
                lblPrice.Text = "₹ " + item.price;
                lblPrice.ForeColor = Color.LightGreen;
                lblPrice.Font = new System.Drawing.Font("Segoe UI", 10);
                lblPrice.Location = new Point(10, 40);
                lblPrice.AutoSize = true;

                Button btnAdd = new Button();
                btnAdd.Text = "Add to Cart";
                btnAdd.Width = 180;
                btnAdd.Height = 45;
                btnAdd.Location = new Point(10, 80);
                btnAdd.BackColor = Color.FromArgb(0, 120, 215);
                btnAdd.ForeColor = Color.White;
                btnAdd.FlatStyle = FlatStyle.Flat;

                btnAdd.Click += (s, e) => AddToCart(item);

                card.Controls.Add(lblName);
                card.Controls.Add(lblPrice);
                card.Controls.Add(btnAdd);

                flpProducts.Controls.Add(card);
            }
        }

        private int ExtractPrice(string text)
        {
            int index = text.LastIndexOf('₹');
            if (index == -1) return 0;

            string priceText = text.Substring(index + 1);
            int.TryParse(priceText, out int price);

            return price;
        }


        private void AddToCart(Alcohol item)
        {
            if (item == null) return;

            lstCart.Items.Add($"{item.name} - ₹{item.price}");
            total += item.price;
            lblTotal.Text = $"Total: ₹{total}";
        }


        public Form1()
        {
            List<Alcohol> alcohols = new List<Alcohol>();
            int total = 0;



            InitializeComponent();
        }

        private void flpProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Call Node.js backend API
                string json = await client.GetStringAsync(
                    "http://localhost:3000/api/alcohols");

                // Convert JSON to C# objects
                alcohols = JsonConvert.DeserializeObject<List<Alcohol>>(json);

                // SAFETY CHECK
                if (alcohols == null || alcohols.Count == 0)
                {
                    MessageBox.Show("No liquor items found. Please add items from admin panel.");
                    return;
                }

                // Load items into modern card UI
                LoadLiquorCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to fetch liquor list.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to remove");
                return;
            }

            // Get selected item text
            string selectedItem = lstCart.SelectedItem.ToString();

            // Extract price from text (₹xxx)
            int price = ExtractPrice(selectedItem);

            // Remove from cart
            lstCart.Items.RemoveAt(lstCart.SelectedIndex);

            // Update total
            total -= price;
            if (total < 0) total = 0;

            lblTotal.Text = $"Total: ₹{total}";
        }

       

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (total == 0)
            {
                MessageBox.Show("Nothing to pay");
                return;
            }

            SimplePaymentForm payForm = new SimplePaymentForm(total);

            if (payForm.ShowDialog() == DialogResult.OK)
            {
                ResetCart();
            }
        }



        private void ResetCart()
        {
            lstCart.Items.Clear();
            total = 0;
            lblTotal.Text = "Total: ₹0";
            lblPoints.Text = "Loyalty Points: 0";
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
                $"http://localhost:3000/api/user/{phone}");

            dynamic user = JsonConvert.DeserializeObject(json);

            return (int)user.points;
        }

        private void btnUsePoints_Click(object sender, EventArgs e)
        {
            if (total == 0)
            {
                MessageBox.Show("Cart is empty");
                return;
            }

            PaymentForm otpForm = new PaymentForm(total);

            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                // Payment already completed inside OTP page
                ResetCart();
            }
        }



        private async void ApplyLoyaltyDiscount()
        {
            int discount = Math.Min(currentUserPoints, total);

            total -= discount;
            pointsApplied = true;

            lblTotal.Text = $"Total ₹{total}";
            lblPoints.Text = $"Points used: {discount}";

            int remainingPoints = currentUserPoints - discount;

            // Update remaining points in backend
            await SaveUserAsync(currentUserPhone, remainingPoints);

            MessageBox.Show(
                $"₹{discount} discount applied using loyalty points!"
            );
        }


    }
}
