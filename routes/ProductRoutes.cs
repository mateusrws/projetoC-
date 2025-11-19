namespace Product.Routes;


public static class ProductRoute
{
    public static void ProductRoutes(WebApplication app)
    {
        var productService = new Loja.GetProduct();

        app.MapGet("products", () => productService.GetProducts());
    }
}