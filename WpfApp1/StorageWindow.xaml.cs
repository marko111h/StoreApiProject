using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for StorageWindow.xaml
    /// </summary>
    public partial class StorageWindow : Window
    {
        HttpClient client = new HttpClient();
        public StorageWindow()
        {
            client.BaseAddress = new Uri("http://localhost:5067/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
            GetStorages();
        }

        private async void GetStorages()
        {


            try
            {
                var response = await client.GetStringAsync("storages");
                var storages = JsonConvert.DeserializeObject<List<Storage>>(response);


                dgStorages.ItemsSource = storages.ToList();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while loading storages: " + ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("Task aborted while loading storages: " + ex.Message);
                throw;




            }

        }
    }
}
