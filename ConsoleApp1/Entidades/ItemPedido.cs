using System.Globalization;

namespace ConsoleApp1.Entidades
{
    class ItemPedido
    {
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public Produto Produto { get; set; }

        public ItemPedido()
        {
        }

        public ItemPedido(int quantidade, double preco, Produto produto)
        {
            Quantidade = quantidade;
            Preco = preco;
            Produto = produto;
        }

        public double SubTotal()
        {
            return Quantidade * Preco;
        }

        public override string ToString()
        {
            return Produto.Nome
                + ", $"
                + Preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantidade: "
                + Quantidade
                + ", SubTotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
