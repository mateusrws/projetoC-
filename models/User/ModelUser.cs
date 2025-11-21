using System.ComponentModel.DataAnnotations;
using Loja.Models.Product;

namespace Loja.Models.User
{
    public class ModelUser
    {
        [Key]
        public Guid Id { set; get; } = Guid.NewGuid();
        public string Name;
        public string Email;
        public string password;
        public ICollection<ModelProduct> products;
    }
}