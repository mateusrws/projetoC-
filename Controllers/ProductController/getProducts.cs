


namespace Loja
{
    public class GetProduct
    {
        public string GetProducts()
        {
            var product = new ModelProduct("Iphone 32", 12000.00, 100);

            return product.getInfos();
        }
    }
}