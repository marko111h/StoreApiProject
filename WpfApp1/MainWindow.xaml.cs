using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
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
        public MainWindow()
        {
            client.BaseAddress = new Uri("http://localhost:5067/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void btnLoadProduct_Click(object sender, RoutedEventArgs e)
        {
            this.GetProducts();
        }

        private async void GetProducts()
        {
            lblMessage.Content = "";
            try
            {
                var response = await client.GetStringAsync("products");
                var products = JsonConvert.DeserializeObject<List<Product>>(response);
                dgProduct.ItemsSource = products;
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
        private async void SaveProduct(Product product)
        {
            try
            {
                await client.PostAsJsonAsync("products", product);
                GetProducts();
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
        }

        private async void DeleteProduct(int productId )
        {
            await client.DeleteAsync("products/delete/"+ productId);
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

    }

}
