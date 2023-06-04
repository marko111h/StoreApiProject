using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        private DataTable originalTable;


        string[] vegetables = {
                    "Carrot", "Broccoli", "Lettuce", "Tomato", "Cucumber", "Spinach",
                    "Onion", "Potato", "Sweet Potato", "Pepper", "Cabbage", "Eggplant",
                    "Zucchini", "Mushroom", "Cauliflower", "Celery", "Radish", "Asparagus",
                    "Green Bean", "Beet", "Brussels Sprouts", "Artichoke"
                };

        private int pointerForLoadOnlyNamesOfProducts = 0;

     
        public MainWindow()
        {
            client.BaseAddress = new Uri("http://localhost:5067/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
            originalTable = new DataTable()
            {
                
            };
           
        }
        
    
        private void btnLoadProduct_Click(object sender, RoutedEventArgs e)
        {
            this.GetProducts(null, null);
            lblMessage.Content = "Product Loaded";

            if(pointerForLoadOnlyNamesOfProducts != 0)
            {

           
          dgProduct.Columns.Clear();
            dgProduct.ItemsSource = null;

                   foreach (DataColumn column in originalTable.Columns)
                   {
                       dgProduct.Columns.Add(new DataGridTextColumn
                       {
                           Header = column.ColumnName,
                           Binding = new Binding($"[{column.ColumnName}]")
                       });
                   }
            dgProduct.ItemsSource = originalTable.DefaultView;
            }

            pointerForLoadOnlyNamesOfProducts = 0;
            //   dgProduct.Columns.Add(new DataGridTextColumn()
            //   {
            //       Header = "Product Name",
            //       Binding = new Binding("."),
            //
            //   });

            ///
            ///   foreach(DataColumn column in originalTable.Columns)
            ///   {
            ///       dgProduct.Columns.Add(new DataGridTextColumn
            ///       {
            ///           Header = column.ColumnName,
            ///           Binding = new Binding($"[{column.ColumnName }]")
            ///       });
            ///   }
            ///
            ///       dgProduct.ItemsSource = originalTable.DefaultView;
        }

        private async void GetProducts(decimal? minPrice, decimal? maxPrice)
        {

            if (minPrice == null && maxPrice == null)
            {
                // If neither minimum nor maximum prices are specified, all products are obtained

                lblMessage.Content = "";
                try
                {
                    var response = await client.GetStringAsync("products");
                    var products = JsonConvert.DeserializeObject<List<Product>>(response);

               

                  dgProduct.ItemsSource = products.ToList();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while loading products: " + ex.Message);
                    throw;
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Task aborted while loading product: " + ex.Message);
                    throw;
                }
            }
            else if (maxPrice == null)
            {
                // If only the minimum price is given, products with a price higher than the minimum are obtained

                lblMessage.Content = "";
                try
                {
                    var response = await client.GetStringAsync($"products?greaterThen={minPrice}&lowerThen={maxPrice}");
                    var products = JsonConvert.DeserializeObject<List<Product>>(response);


                    dgProduct.ItemsSource = products.ToList();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while loading products: " + ex.Message);
                    throw;
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Task aborted while loading product: " + ex.Message);
                    throw;
                }
            }
            else if (minPrice == null)
            {
                // If only the max price is given, products with a price lower than the maximum are obtained

                lblMessage.Content = "";
                try
                {
                    var response = await client.GetStringAsync($"products?greaterThen={minPrice}&lowerThen={maxPrice}");
                    var products = JsonConvert.DeserializeObject<List<Product>>(response);


                    dgProduct.ItemsSource = products.ToList();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while loading products: " + ex.Message);
                    throw;
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Task aborted while loading product: " + ex.Message);
                    throw;
                }
            }
            else if (minPrice != null && maxPrice != null)
            {
                // If both the minimum and maximum price are given, products with a price between those two values are obtained

                lblMessage.Content = "";
                try
                {
                    var response = await client.GetStringAsync($"products?greaterThen={minPrice}&lowerThen={maxPrice}");
                    var products = JsonConvert.DeserializeObject<List<Product>>(response);

                    dgProduct.ItemsSource = products.ToList();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while loading products: " + ex.Message);
                    throw;
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Task aborted while loading product: " + ex.Message);
                    throw;
                }

            }


        }

        private async void GetProductNames()
        {
            try
            {
                var response = await client.GetStringAsync("products/productsName");
                var productNames = JsonConvert.DeserializeObject<List<string>>(response);

              

             dgProduct.ItemsSource = null;
             dgProduct.ItemsSource = productNames.ToList();

                dgProduct.Columns.Clear();
                dgProduct.Columns.Add(new DataGridTextColumn()
                {
                    Header = "Product Name",
                    Binding = new Binding(".")
                });

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while loading products:" + ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("Task aborted while loading product:" + ex.Message);
                throw;
            }
        }
        private async void GetProductsFruits()
        {
            try
            {
                var response = await client.GetStringAsync("products/fruits");
                var productFruits = JsonConvert.DeserializeObject<List<Product>>(response);
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = productFruits;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while loading products:" + ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("Task aborted while loading product:" + ex.Message);
                throw;
            }
        }
        private async void GetProductsVegetables()
        {
            try
            {
                var response = await client.GetStringAsync("products/vegetables");
                var productVegetables = JsonConvert.DeserializeObject<List<Product>>(response);
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = productVegetables;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while loading products:" + ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("Task aborted while loading product:" + ex.Message);
                throw;
            }
        }
        private async void SaveProduct(Product product)
        {
            try
            {
                await client.PostAsJsonAsync("products", product);
                GetProducts(null, null);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while saving the product: " + ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("Task aborted while saving product: " + ex.Message);
                throw;
            }

        }

        private async void UpdateProduct(Product product)
        {
            await client.PutAsJsonAsync("products/" + product.ProductId, product);
            GetProducts(null, null);
        }

        private async void DeleteProduct(int productId)
        {
            await client.DeleteAsync("products/delete/" + productId);
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product()
            {
                ProductId = int.Parse(txtProductId.Text),
                ProductName = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
            };


            if (product.ProductId == 0)
            {

                this.SaveProduct(product);
                lblMessage.Content = "Product Saved";

            }
            else
            {
                this.UpdateProduct(product);


                lblMessage.Content = "Product Updated";
            }

            txtProductId.Text = "0";
            txtName.Text = "";
            txtPrice.Text = "";
        }
        void btnEditProduct(object sender, RoutedEventArgs e)
        {
            Product product = ((FrameworkElement)sender).DataContext as Product;
            txtProductId.Text = product.ProductId.ToString();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.Price.ToString();

        }

        void btnDeleteProduct(object sender, RoutedEventArgs e)
        {
            Product product = ((FrameworkElement)sender).DataContext as Product;
            this.DeleteProduct(product.ProductId);

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            //   Product product = ((FrameworkElement)sender).DataContext as Product;

            if (txtMinPrice.Text == "" && txtMaxPrice.Text == "")
            {
                lblMessage.Content = "Input value";

            }
            else if (txtMinPrice.Text == "" && txtMaxPrice.Text != "")
            {
                var filter = new Filter()
                {
                    MinPrice = null,
                    MaxPrice = decimal.Parse(txtMaxPrice.Text)
                };
                this.GetProducts(filter.MinPrice, filter.MaxPrice);
            }
            else if (txtMinPrice.Text != "" && txtMaxPrice.Text == "")
            {
                var filter = new Filter()
                {
                    MinPrice = decimal.Parse(txtMinPrice.Text),
                    MaxPrice = null
                };
                this.GetProducts(filter.MinPrice, filter.MaxPrice);
            }
            else
            {
                var filter = new Filter()
                {
                    MinPrice = decimal.Parse(txtMinPrice.Text),
                    MaxPrice = decimal.Parse(txtMaxPrice.Text)
                };
                this.GetProducts(filter.MinPrice, filter.MaxPrice);
            }
            /// An error occurred while loading product: response status code does not indicate success: 400 (Bad Request)


        }

        private void btnViewStorages_Click(object sender, RoutedEventArgs e)
        {
            StorageWindow storageWindow = new StorageWindow();
            storageWindow.Show();
        }

        private void btnViewStateOfStorages_Click(object sender, RoutedEventArgs e)
        {
            StateOfStorageWindow stateOfStorageWindow = new StateOfStorageWindow();
            stateOfStorageWindow.Show();
        }

        private void btnProductNamesOnly_Click(object sender, RoutedEventArgs e)
        {
            this.GetProductNames();
            pointerForLoadOnlyNamesOfProducts = 1;
        }

        private void btnFruits_Click(object sender, RoutedEventArgs e)
        {
       
            this.GetProductsFruits();
        }

        private void btnVegetables_Click(object sender, RoutedEventArgs e)
        {
            this.GetProductsVegetables();
        }
    }
}
