

using System.ComponentModel.DataAnnotations;
using Loja.Models.User;

namespace Loja.Models.Product
{
    public class ModelProduct
    {   
        [Key]
        public Guid Id { set; get; } = Guid.NewGuid();
        public string Name { set; get; }
        public double Price { set; get; }
        public int Qtd { set; get; }
        public ModelUser user { set; get; }
        

        public ModelProduct(){}

    }
}