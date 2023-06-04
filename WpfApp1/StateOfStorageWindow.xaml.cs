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
    /// Interaction logic for StateOfStorage.xaml
    /// </summary>
    public partial class StateOfStorageWindow : Window
    {
        HttpClient client = new HttpClient();
        public StateOfStorageWindow()
        {
            client.BaseAddress = new Uri("http://localhost:5067/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
            GetStateOfStorages();
        }

        private async void GetStateOfStorages()
        {


            try
            {
                var response = await client.GetStringAsync("stateOfStorages");
                var stateOfStorage = JsonConvert.DeserializeObject<List<StateOfStorage>>(response);


                dgStateOfStorage.ItemsSource = stateOfStorage.ToList();
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
