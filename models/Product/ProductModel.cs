

class ModelProduct
{
    private string id { set; get; }
    private string name { set; get; }
    private double price { set; get; }
    private int qtd { set; get; }


    public ModelProduct(string name, double price, int qtd)
    {
        Random numAleatorio = new Random();
        int num = numAleatorio.Next(1,99999999);

        id = num.ToString();
        this.name = name;
        this.price = price;
        this.qtd = qtd;
    }



    public string getName()
    {
        return name;
    }
    public double getPrice()
    {
        return price;
    }
    public int getQtd()
    {
        return qtd;
    }



    public string getInfos()
    {
        return($"Nome: {getName()} \nPreço: {getPrice()} \nQuantidade: {getQtd()}");
    }

}