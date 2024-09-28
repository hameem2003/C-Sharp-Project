using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Retail_Shop
{
    public partial class NewProduct : UserControl
    {
        private bool newProduct, admin, shopOwner;
        private string shopID, productID;
        private int totalReviewer;
        private double totalReview;
        private Dictionary<string, CartItem> cart;
        private string currentName;
        private string currentModel;
        private string currentColor;
        private int currentPrice;
        private int currentDiscount;
        private int currentQuantity;


        public NewProduct()
        {
            InitializeComponent();
        }

        public NewProduct(string shopID = null, bool admin = false, bool newProduct = false, string productID = null, Dictionary<string, CartItem> cart = null) : this ()
        {
            this.shopID = shopID;
            this.admin = admin;
            this.newProduct = newProduct;
            delete_btn.Tag = this.productID = productID;
            update_btn.Tag = this.productID= productID;
            this.cart = cart;

            Design();
        }

        public void Design()
        {
            if (newProduct)
            {
                new_product_panel.Visible = true;
                product_panel.Visible = false;
            }
            else if (productID != null)
            {
                new_product_panel.Visible = false;
                product_panel.Visible = true;
                DataLoad();
            }

            else if (admin)
            {
                new_product_panel.Visible = false;
                product_panel.Visible = true;
                //back_btn.Visible = false;
                DataLoad();
            }
                
        }


        private int SimNumber()
        {
            if (one_sim_rb.Checked)
                return 1;
            else if (two_sim_rb.Checked)
                return 2;
            else
                return 0;
        }

        /*private void DataLoad()
        {

            string error, query = $"SELECT * FROM [Product Information] WHERE ID = {this.productID}";
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
            discount.Text = $"Discount % : {dataSet.Tables[0].Rows[0]["Discount"]}";
            //TotalQuantity.Text = $"Total Quantity: {dataSet.Tables[0].Rows[0]["Quantity"]}";
            //Sold.Text = $"Sold: {dataSet.Tables[0].Rows[0]["Sold"]}";


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
            

        }*/
        private void DataLoad()
        {
            string error, query = $"SELECT * FROM [Product Information] WHERE ID = {this.productID}";
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.DataAccess(query, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Class: Product Function: DataLoad \nError: {error}");
                return;
            }
            
            // Display product details
            compnay_name.Text = dataSet.Tables[0].Rows[0]["Company Name"].ToString();
            model.Text = dataSet.Tables[0].Rows[0]["Model"].ToString();
            sim.Text = $"SIM: {dataSet.Tables[0].Rows[0]["SIM"]}";
            ram.Text = $"RAM: {dataSet.Tables[0].Rows[0]["RAM"]}";
            rom.Text = $"ROM: {dataSet.Tables[0].Rows[0]["ROM"]}";
            color.Text = $"COLOR: {dataSet.Tables[0].Rows[0]["Color"]}";
            price.Text = $"Price(BDT): {dataSet.Tables[0].Rows[0]["Price"]}";
            discount.Text = $"Discount  : {dataSet.Tables[0].Rows[0]["Discount"]}";

            // Display total quantity, sold, and unsold
            int totalQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Quantity"]);
            int soldQuantity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Sold"]);
            int unsoldQuantity = totalQuantity - soldQuantity;

            TotalQuantity.Text = $"Total Quantity: {totalQuantity}";
            Sold.Text = $"Sold: {soldQuantity}";
            unsold_quantity_label.Text = $"Unsold: {unsoldQuantity}";

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

            //*************************************
            update_name.Text = dataSet.Tables[0].Rows[0]["Company Name"].ToString();
            update_modelname.Text = dataSet.Tables[0].Rows[0]["Model"].ToString();
            update_colour.Text = dataSet.Tables[0].Rows[0]["Color"].ToString();
            update_price.Text = dataSet.Tables[0].Rows[0]["Price"].ToString();
            update_discount.Text = dataSet.Tables[0].Rows[0]["Discount"].ToString();
            update_quantity.Text = dataSet.Tables[0].Rows[0]["Quantity"].ToString();
            // Optionally store the initial values for comparison
            currentName = update_name.Text;
            currentModel = update_modelname.Text;
            currentColor = update_colour.Text;
            currentPrice = Convert.ToInt32(update_price.Text);
            currentDiscount = Convert.ToInt32(update_discount.Text);
            currentQuantity = Convert.ToInt32(update_quantity.Text);

        }
        


        private void choose_picture_btn_Click(object sender, EventArgs e)
        {
            Utility.pictureUpload(product_image);
        }


          private void add_new_product_btn_Click(object sender, EventArgs e)
          {
              // Validate inputs
              if (string.IsNullOrWhiteSpace(company_name_tb.Text))
              {
                  MessageBox.Show("Fill the company name");
                  company_name_tb.Focus();
                  return;
              }

              if (string.IsNullOrWhiteSpace(model_tb.Text))
              {
                  MessageBox.Show("Fill the model name");
                  model_tb.Focus();
                  return;
              }

              if (SimNumber() == 0)
              {
                  MessageBox.Show("Choose the SIM number");
                  return;
              }

              if (ram_value.SelectedIndex == -1)
              {
                  MessageBox.Show("Fill the RAM value");
                  return;
              }

              if (ram_size.SelectedIndex == -1)
              {
                  MessageBox.Show("Fill the RAM Size");
                  return;
              }

              if (rom_value.SelectedIndex == -1)
              {
                  MessageBox.Show("Fill the ROM value");
                  return;
              }

              if (rom_size.SelectedIndex == -1)
              {
                  MessageBox.Show("Fill the ROM Size");
                  return;
              }

              if (string.IsNullOrWhiteSpace(color_tb.Text))
              {
                  MessageBox.Show("Fill the color");
                  color_tb.Focus();
                  return;
              }
        if (string.IsNullOrWhiteSpace(Quantity_set_by_shopowner.Text))
            {
                MessageBox.Show("Set the quantity for the product");
                Quantity_set_by_shopowner.Focus();
                return;
            }

            if (!int.TryParse(Quantity_set_by_shopowner.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Enter a valid quantity (positive integer)");
                Quantity_set_by_shopowner.Focus();
                return;
            }

              if (string.IsNullOrWhiteSpace(price_tb.Text))
              {
                  MessageBox.Show("Fill the price");
                  price_tb.Focus();
                  return;
              }

              if (string.IsNullOrWhiteSpace(discount_tb.Text))
              {
                  MessageBox.Show("Fill the discount");
                  discount_tb.Focus();
                  return;
              }

              // Convert the image to a byte array
              byte[] picture;
              Image image = null;
              if (product_picture.Image != null)
                  image = product_image.Image;

              else
                  image = Properties.Resources.show;

              picture = Utility.ImageToByteArray(image, Utility.GetImageFormat(image));



              // Define the query with placeholders for parameters
              string query = $@"
                              INSERT INTO [Product Information] 
                                  (Picture, [Company Name], [Model], SIM, RAM, ROM, Color, Price, Discount, [Total Review], [Total Reviewer], [Shop ID],Quantity, Sold)
                              VALUES
                                  ('{picture}', '{company_name_tb.Text}', '{model_tb.Text}', {SimNumber()}, '{ram_value.Text} {ram_size.Text}', '{rom_value.Text} {rom_size.Text}', '{color_tb.Text}', {decimal.Parse(price_tb.Text)},  {decimal.Parse(discount_tb.Text)},  {0},  {0},  '{this.shopID}','{Quantity_set_by_shopowner.Text}',{0})";

              DataBase dataBase = new DataBase();
              string error;
              dataBase.ExecuteNonQuery(query, out error);

              // Handle any errors
              if (!string.IsNullOrEmpty(error))
              {
                  MessageBox.Show($"Class: Product Function: add_btn_Click  \nError: {error}");
                  return;
              }
          }
         /*

        private void add_new_product_btn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(company_name_tb.Text))
            {
                MessageBox.Show("Fill the company name");
                company_name_tb.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(model_tb.Text))
            {
                MessageBox.Show("Fill the model name");
                model_tb.Focus();
                return;
            }

            if (SimNumber() == 0)
            {
                MessageBox.Show("Choose the SIM number");
                return;
            }

            if (ram_value.SelectedIndex == -1)
            {
                MessageBox.Show("Fill the RAM value");
                return;
            }

            if (ram_size.SelectedIndex == -1)
            {
                MessageBox.Show("Fill the RAM Size");
                return;
            }

            if (rom_value.SelectedIndex == -1)
            {
                MessageBox.Show("Fill the ROM value");
                return;
            }

            if (rom_size.SelectedIndex == -1)
            {
                MessageBox.Show("Fill the ROM Size");
                return;
            }

            if (string.IsNullOrWhiteSpace(color_tb.Text))
            {
                MessageBox.Show("Fill the color");
                color_tb.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(price_tb.Text))
            {
                MessageBox.Show("Fill the price");
                price_tb.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(discount_tb.Text))
            {
                MessageBox.Show("Fill the discount");
                discount_tb.Focus();
                return;
            }

            // Validate quantity - must be a positive integer
            if (string.IsNullOrWhiteSpace(Quantity_set_by_shopowner.Text))
            {
                MessageBox.Show("Set the quantity for the product");
                Quantity_set_by_shopowner.Focus();
                return;
            }

            if (!int.TryParse(Quantity_set_by_shopowner.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Enter a valid quantity (positive integer)");
                Quantity_set_by_shopowner.Focus();
                return;
            }

            // Handle optional image (picture is not mandatory)
            byte[] picture = null; // Initialize as null
            if (product_picture.Image != null)
            {
                picture = ImageToByteArray(product_picture.Image);  // Only convert to byte array if image is provided
            }

            // Define the query with placeholders for parameters
            string query = $@"
        INSERT INTO [Product Information] 
            ([Company Name], [Model], SIM, RAM, ROM, Color, Price, Discount, [Total Review], [Total Reviewer], [Shop ID], Quantity, Sold)
        VALUES
            (@CompanyName, @Model, @SIM, @RAM, @ROM, @Color, @Price, @Discount, 0, 0, @ShopID, @Quantity, 0)";

            // If picture is provided, modify the query to include it
            if (picture != null)
            {
                query = $@"
        INSERT INTO [Product Information] 
            (Picture, [Company Name], [Model], SIM, RAM, ROM, Color, Price, Discount, [Total Review], [Total Reviewer], [Shop ID], Quantity, Sold)
        VALUES
            (@Picture, @CompanyName, @Model, @SIM, @RAM, @ROM, @Color, @Price, @Discount, 0, 0, @ShopID, @Quantity, 0)";
            }

            // Set up parameters
            SqlParameter[] parameters = new SqlParameter[]
            {
        // Add picture parameter only if it's not null
        picture != null ? new SqlParameter("@Picture", picture) : null,
        new SqlParameter("@CompanyName", company_name_tb.Text),
        new SqlParameter("@Model", model_tb.Text),
        new SqlParameter("@SIM", SimNumber()),
        new SqlParameter("@RAM", $"{ram_value.Text} {ram_size.Text}"),
        new SqlParameter("@ROM", $"{rom_value.Text} {rom_size.Text}"),
        new SqlParameter("@Color", color_tb.Text),
        new SqlParameter("@Price", decimal.Parse(price_tb.Text)),
        new SqlParameter("@Discount", decimal.Parse(discount_tb.Text)),
        new SqlParameter("@ShopID", this.shopID),
        new SqlParameter("@Quantity", quantity)
            };

            // Filter out null parameters (if picture is null, it will be excluded)
            parameters = parameters.Where(p => p != null).ToArray();

            // Execute the query
            DataBase dataBase = new DataBase();
            string error;
            dataBase.ExecuteNonQuery(query, out error);

            // Handle any errors
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Class: Product Function: add_btn_Click  \nError: {error}");
                return;
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);  // Save image in the original format
                return ms.ToArray();              // Convert to byte array
            }
        }*/



        private void back_btn_Click(object sender, EventArgs e)
        {

        }

        private void ram_value_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [Product Information] SET ";
            string error;
            bool hasUpdates = false;

            // Check and update the Name
            if (currentName != update_name.Text)
            {
                query += $"[Company Name] = '{update_name.Text}', ";
                currentName = update_name.Text;  // Update the stored value
                hasUpdates = true;
            }

            // Check and update the Model
            if (currentModel != update_modelname.Text)
            {
                query += $"[Model] = '{update_modelname.Text}', ";
                currentModel = update_modelname.Text;
                hasUpdates = true;
            }

            // Check and update the Color
            if (currentColor != update_colour.Text)
            {
                query += $"[Color] = '{update_colour.Text}', ";
                currentColor = update_colour.Text;
                hasUpdates = true;
            }

            // Validate and update the Price
            if (int.TryParse(update_price.Text, out int newPrice) && newPrice >= 0 && currentPrice != newPrice)
            {
                query += $"[Price] = {newPrice}, ";
                currentPrice = newPrice;
                hasUpdates = true;
            }
            else if (newPrice < 0)
            {
                MessageBox.Show("Price must be a non-negative integer.");
                return;
            }

            // Validate and update the Discount
            if (int.TryParse(update_discount.Text, out int newDiscount) && newDiscount >= 0 && currentDiscount != newDiscount)
            {
                query += $"[Discount] = {newDiscount}, ";
                currentDiscount = newDiscount;
                hasUpdates = true;
            }
            else if (newDiscount < 0)
            {
                MessageBox.Show("Discount must be a non-negative integer.");
                return;
            }

            // Validate and update the Quantity
            if (int.TryParse(update_quantity.Text, out int newQuantity) && newQuantity >= 0 && currentQuantity != newQuantity)
            {
                query += $"[Quantity] = {newQuantity}, ";
                currentQuantity = newQuantity;
                hasUpdates = true;
            }
            else if (newQuantity < 0)
            {
                MessageBox.Show("Quantity must be a non-negative integer.");
                return;
            }

            // If there are updates, execute the query
            if (hasUpdates)
            {
                // Trim the last comma and add WHERE clause
                query = $"{query.Substring(0, query.Length - 2)} WHERE ID = '{this.productID}'";

                DataBase dataBase = new DataBase();
                dataBase.ExecuteNonQuery(query, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"Class: Product Function: update_Click \nError: {error}");
                    return;
                }

                MessageBox.Show("Product successfully updated.");
                DataLoad();
            }
            else
            {
                MessageBox.Show("No changes detected.");
                
            }
        }




        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
                ProductDelete();
            
        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            if (newProduct)
            {
                new_product_panel.Visible = true;
                product_panel.Visible = false;
            }
            else if (productID != null)
            {
                new_product_panel.Visible = false;
                product_panel.Visible = true;
                DataLoad();
            }

            else if (admin)
            {
                new_product_panel.Visible = false;
                product_panel.Visible = true;
                //back_btn.Visible = false;
                DataLoad();
            }
        }


        private void ProductDelete()
        {
            string error, query = $"DELETE FROM [Product Information] WHERE ID = {this.productID}";

            DataBase dataBase = new DataBase();
            dataBase.ExecuteNonQuery(query, out error);


            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Class: NewProduct Function: ProductDelete \nError: {error}");
                return;
            }


            MessageBox.Show("Product Successfully deleted");

            ShopOwner.Instance.panelContainer.Controls.Clear();
            AllProduct allProduct = new AllProduct(this.shopID);
            allProduct.Dock = DockStyle.Fill;
            ShopOwner.Instance.panelContainer.Controls.Add(allProduct);
        }



    }
}
