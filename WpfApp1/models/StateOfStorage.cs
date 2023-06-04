using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.models
{
    public class StateOfStorage
    {

       
        public int StateOfStorageId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StorageId { get; set; }
   
        public Storage Storage { get; set; }    
        public int Quantity { get; set; }
    }
}
