using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Retail_Shop
{
    public partial class Product : UserControl
    {
        private string customerID, productID, shopID;
        private int totalReviewer;
        private double totalReview;
        private Dictionary<string, CartItem> cart;
        private CartItem cartItem;
        public Product()
        {
            InitializeComponent();
        }

        public Product(string customerID, string productID, Dictionary<string, CartItem> cart) : this()
        {
            this.customerID = customerID;
            add_cart_btn.Tag = add_btn.Tag = remove_btn.Tag = this.productID = productID;
            this.cart = cart;
            DataLoad();
            UpdateQuantityDisplay();
        }

       /* private void UpdateQuantityDisplay()
        {
            if (this.cart.ContainsKey(this.productID))
            {
                cartItem = this.cart[this.productID];
                quantity.Text = cartItem.Quantity.ToString();
            }
            else
                // Handle the case where the productId is not in the cart
                quantity.Text = "0";
            
        }*/

        private void DataLoad()
        {
            string error, query = $"SELECT * FROM [Product Information] WHERE ID = '{this.productID}'";
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.DataAccess(query, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Class: Product Function: DataLoad \nError: {error}");
                return;
            }

            // product_picture.Image = Utility.ByteArrayToImage((byte[])(dataTable.Rows[0]["Picture"]));
            compnay_name.Text = dataSet.Tables[0].Rows[0]["Company Name"].ToString();
            model.Text = dataSet.Tables[0].Rows[0]["Model"].ToString();
            sim.Text = $"SIM: {dataSet.Tables[0].Rows[0]["SIM"]}";
            ram.Text = $"RAM: {dataSet.Tables[0].Rows[0]["RAM"]}";
            rom.Text = $"ROM: {dataSet.Tables[0].Rows[0]["ROM"]}";
            color.Text = $"COLOR: {dataSet.Tables[0].Rows[0]["Color"]}";
            price.Text = $"Price(BDT): {dataSet.Tables[0].Rows[0]["Price"]}";
            discount.Text = $"Discount(%): {dataSet.Tables[0].Rows[0]["Discount"]}";
            this.shopID = dataSet.Tables[0].Rows[0]["Shop ID"].ToString();

            // Fetch quantity and sold values
            int totalQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Quantity"]);
            int soldQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Sold"]);

            // Calculate the stock remaining
            int inStock = totalQuantity - soldQuantity;

            // Show "In Stock" or "Out of Stock" based on the remaining stock
            if (inStock > 0)
            {
                // Show "In Stock" in green, bold, and larger text
                guna2HtmlLabel1.Text = "In Stock";
                guna2HtmlLabel1.ForeColor = Color.Green;
                guna2HtmlLabel1.Font = new Font(guna2HtmlLabel1.Font, FontStyle.Bold);
                guna2HtmlLabel1.Font = new Font(guna2HtmlLabel1.Font.FontFamily, 14); // Set larger font size (14px)
            }
            else
            {
                // Show "Out of Stock" in red, bold, and larger text
                guna2HtmlLabel1.Text = "Out of Stock";
                guna2HtmlLabel1.ForeColor = Color.Red;
                guna2HtmlLabel1.Font = new Font(guna2HtmlLabel1.Font, FontStyle.Bold);
                guna2HtmlLabel1.Font = new Font(guna2HtmlLabel1.Font.FontFamily, 14); // Set larger font size (14px)
            }

            // Convert Total Review to decimal and Total Reviewer to int
            totalReview = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Total Review"]);
            totalReviewer = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Total Reviewer"]);

            // Calculate the rating
            double ratingValue;

            if (totalReviewer > 0) // Ensure there are reviewers to avoid division by zero
            {
                ratingValue = (totalReview / totalReviewer) * 5; // Calculate the rating
                rating.Text = $"Rating: {ratingValue:F1} Total Review: {totalReviewer}"; // Format rating to 1 decimal place
            }
            else
            {
                rating.Text = "Rating: N/A Total Review: 0"; // Handle case where there are no reviewers
            }
        }
        /*
                private void DataLoad()
                {
                    string error, query = $"SELECT * FROM [Product Information] WHERE ID = '{this.productID}'";
                    DataBase dataBase = new DataBase();
                    DataSet dataSet = dataBase.DataAccess(query, out error);

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Class: Product Function: DataLoad \nError: {error}");
                        return;
                    }


                   // product_picture.Image = Utility.ByteArrayToImage((byte[])(dataTable.Rows[0]["Picture"]));
                    compnay_name.Text = dataSet.Tables[0].Rows[0]["Company Name"].ToString();
                    model.Text = dataSet.Tables[0].Rows[0]["Model"].ToString();
                    sim.Text = $"SIM: {dataSet.Tables[0].Rows[0]["SIM"]}";
                    ram.Text = $"RAM: {dataSet.Tables[0].Rows[0]["RAM"]}";
                    rom.Text = $"ROM: {dataSet.Tables[0].Rows[0]["ROM"]}";
                    color.Text = $"COLOR: {dataSet.Tables[0].Rows[0]["Color"]}";
                    price.Text = $"Price(BDT): {dataSet.Tables[0].Rows[0]["Price"]}";
                    discount.Text = $"Discount(%): {dataSet.Tables[0].Rows[0]["Discount"]}";
                    this.shopID = dataSet.Tables[0].Rows[0]["Shop ID"].ToString();

                    // Convert Total Review to decimal and Total Reviewer to int
                    totalReview = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Total Review"]);
                    totalReviewer = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Total Reviewer"]);

                    // Calculate the rating
                    double ratingValue;

                    if (totalReviewer > 0) // Ensure there are reviewers to avoid division by zero
                    {
                        ratingValue = (totalReview / totalReviewer) * 5; // Calculate the rating
                        rating.Text = $"Rating: {ratingValue:F1} Total Review: {totalReviewer}"; // Format rating to 1 decimal place
                    }
                    else
                        rating.Text = "Rating: N/A Total Review: 0"; // Handle case where there are no reviewers


                }
        */

        /*private void add_btn_Click(object sender, EventArgs e)
        {
            remove_btn.Enabled = true;
            CartItem cartItem = new CartItem(productId: this.productID, productName: compnay_name.Text + " " + model.Text, shopId: this.shopID, quantity: 1, price: Convert.ToDouble(price.Text.Substring(7)), discount: Convert.ToDouble(discount.Text.Substring(10)));
            cartItem.AddToCart(cart, productID: this.productID, productName: compnay_name.Text + " " + model.Text, shopID: this.shopID, quantity: 1, price: Convert.ToDouble(price.Text.Substring(7)), discount: Convert.ToDouble(discount.Text.Substring(10)));
            UpdateQuantityDisplay();

        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cart[this.productID].Quantity) > 0)
            {
                CartItem cartItem = new CartItem(productId: this.productID, productName: compnay_name.Text + " " + model.Text, shopId: this.shopID, quantity: -1, price: (-(Convert.ToDouble(price.Text.Substring(7)))), discount: -Convert.ToDouble(discount.Text.Substring(10)));
                cartItem.AddToCart(cart, productID: this.productID, productName: compnay_name.Text + " " + model.Text, shopID: this.shopID, quantity: -1, price: (-(Convert.ToDouble(price.Text.Substring(7)))), discount: -Convert.ToDouble(discount.Text.Substring(10)));
                UpdateQuantityDisplay();
            }

            if (Convert.ToInt32(this.cart[this.productID].Quantity) == 0)
            {
                this.cart.Remove(this.productID);
                remove_btn.Enabled = false;
            }
               


        }

        private void add_cart_btn_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(customerID: this.customerID, cartItems: this.cart);
            DialogResult dialogResult = cart.ShowDialog();

            if (dialogResult == DialogResult.OK)
                cart.Hide();
        }*/

        private void back_btn_Click(object sender, EventArgs e)
        {
            CustomerDashboard.Instance.panelContainer.Controls.Clear();
            CustomerDashBoardData customerDashBoardData = new CustomerDashBoardData(customerID: this.customerID, cart: this.cart);
            customerDashBoardData.Dock = DockStyle.Fill;
            CustomerDashboard.Instance.panelContainer.Controls.Add(customerDashBoardData);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            // Check if the product is in stock
            int availableStock = GetAvailableStock(this.productID);
            int cartQuantity = (this.cart.ContainsKey(this.productID)) ? this.cart[this.productID].Quantity : 0;

            if (availableStock > cartQuantity)
            {
                // Enable the remove button once an item is added
                remove_btn.Enabled = true;

                // Extract and convert price and discount properly
                string priceText = price.Text.Replace("Price(BDT):", "").Trim();  // Remove "Price(BDT):" and trim spaces
                string discountText = discount.Text.Replace("Discount(%):", "").Trim();  // Remove "Discount(%):" and trim spaces

                // Parse the cleaned strings to double
                double parsedPrice;
                double parsedDiscount;

                // Try to convert price and discount
                if (double.TryParse(priceText, out parsedPrice) && double.TryParse(discountText, out parsedDiscount))
                {
                    // Create a CartItem and add it to the cart
                    CartItem cartItem = new CartItem(
                        productId: this.productID,
                        productName: compnay_name.Text + " " + model.Text,
                        shopId: this.shopID,
                        quantity: 1,
                        price: parsedPrice,
                        discount: parsedDiscount
                    );

                    cartItem.AddToCart(
                        cart,
                        productID: this.productID,
                        productName: compnay_name.Text + " " + model.Text,
                        shopID: this.shopID,
                        quantity: 1,
                        price: parsedPrice,
                        discount: parsedDiscount
                    );

                    // Update the quantity display
                    UpdateQuantityDisplay();
                }
                else
                {
                    MessageBox.Show("Failed to parse price or discount.");
                }
            }
            else
            {
                MessageBox.Show("Insufficient stock available.");
            }
        }


        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (this.cart.ContainsKey(this.productID) && this.cart[this.productID].Quantity > 0)
            {
                // Extract price and discount by cleaning the text
                string priceText = price.Text.Replace("Price(BDT):", "").Trim(); // Remove label and trim spaces
                string discountText = discount.Text.Replace("Discount(%):", "").Trim(); // Remove label and trim spaces

                // Parse the cleaned strings to double
                double parsedPrice;
                double parsedDiscount;

                // Try to convert price and discount to double, with error handling
                if (double.TryParse(priceText, out parsedPrice) && double.TryParse(discountText, out parsedDiscount))
                {
                    // Create a CartItem and add it to the cart with negative quantity
                    CartItem cartItem = new CartItem(
                        productId: this.productID,
                        productName: compnay_name.Text + " " + model.Text,
                        shopId: this.shopID,
                        quantity: -1,
                        price: -parsedPrice,  // Negate price for removal
                        discount: -parsedDiscount  // Negate discount for removal
                    );

                    // Add the item to the cart and update the display
                    cartItem.AddToCart(
                        cart,
                        productID: this.productID,
                        productName: compnay_name.Text + " " + model.Text,
                        shopID: this.shopID,
                        quantity: -1,
                        price: -parsedPrice,
                        discount: -parsedDiscount
                    );

                    UpdateQuantityDisplay();
                }
                else
                {
                    // Show error message if parsing fails
                    MessageBox.Show("Failed to parse price or discount.");
                    return;
                }
            }

            // If the quantity becomes zero or negative, remove the product from the cart
            if (this.cart.ContainsKey(this.productID) && this.cart[this.productID].Quantity <= 0)
            {
                // Remove the item from the cart
                this.cart.Remove(this.productID);
                remove_btn.Enabled = false; // Disable the remove button
            }
        }


        private void add_cart_btn_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(customerID: this.customerID, cartItems: this.cart);
            DialogResult dialogResult = cart.ShowDialog();

            if (dialogResult == DialogResult.OK)
                cart.Hide();
        }

        private void UpdateQuantityDisplay()
        {
            if (this.cart.ContainsKey(this.productID))
            {
                // Update quantity label to reflect the current cart quantity
                CartItem cartItem = this.cart[this.productID];
                quantity.Text = cartItem.Quantity.ToString();
            }
            else
            {
                // If the product is not in the cart, set quantity to 0
                quantity.Text = "0";
            }
        }

        // This function checks how much stock is left in the database for the given product ID
        private int GetAvailableStock(string productId)
        {
            string query = $"SELECT Quantity, Sold FROM [Product Information] WHERE ID = '{this.productID}'";
            string error;
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.DataAccess(query, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error fetching product stock information: {error}");
                return 0; // In case of error, return 0 stock
            }

            int totalQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Quantity"]);
            int soldQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Sold"]);

            // Return the remaining stock
            return totalQuantity - soldQuantity;
        }

    }
}
