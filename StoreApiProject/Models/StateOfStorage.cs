using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApiProject.Models
{
    public class StateOfStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int StateOfStorageId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int StorageId { get; set; }
        [ForeignKey("StorageId")]
        public Storage Storage { get; set; }

        public int Quantity { get; set; }

    }
}
