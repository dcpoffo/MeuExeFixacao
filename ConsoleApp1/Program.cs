using ConsoleApp1.Entidades;
using ConsoleApp1.Entidades.Enums;
using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do cliente");
            Console.Write("Nome: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("E-mail: ");
            string emailCliente = Console.ReadLine();
            Console.Write("Data Nascimento (DD/MM/YYYY): ");
            DateTime dataNascimentoCliente = DateTime.Parse(Console.ReadLine());

            // instanciando um novo cliente com os dados acima
            Cliente cliente = new Cliente(nomeCliente, emailCliente, dataNascimentoCliente);

            Console.WriteLine();
            Console.WriteLine("Entre com os dados da transportadora");
            Console.Write("Nome: ");
            string nomeTransportadora = Console.ReadLine();
            Console.Write("Valor do frete: ");
            double valorFrete = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            //Console.Write("Data entrega (prevista) (DD/MM/YYYY): ");
            //DateTime dataEntrega = DateTime.Now.AddDays(10.0);

            //instanciando uma nova transportadora com os dados acima
            Transportadora transportadora = new Transportadora(nomeTransportadora, valorFrete, DateTime.Now.AddDays(10.0));
            //Transportadora transportadora = new Transportadora(nomeTransportadora, valorFrete, dataEntrega);

            Console.WriteLine();
            Console.WriteLine("Entre com os dados do pedido");
            Console.Write("Status (PagamentoPendente/Processando/Enviado/Entregue): ");
            StatusPedido statusPedido = Enum.Parse<StatusPedido>(Console.ReadLine());
            
            //instanciando um novo pedido com os dados acima
            Pedido pedido = new Pedido(DateTime.Now, statusPedido, cliente, transportadora);

            Console.WriteLine();
            // testar com: Deseja cadastrar algum item S/N

            Console.Write("Quando itens deseja adicionar ao pedido: ");
            int qtd = int.Parse(Console.ReadLine());
            for (int i = 1; i <= qtd; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Dados do {i}º item");
                Console.Write("Nome do produto      : ");
                string nomeProduto = Console.ReadLine();
                Console.Write("Valor do produto     : ");
                double valorProduto = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantidade do produto: ");
                int qtdProduto = int.Parse(Console.ReadLine());

                //instanciando um novo produto
                Produto produto = new Produto(nomeProduto, valorProduto);
                //instanciando um novo item pedido
                ItemPedido itemPedido = new ItemPedido(qtdProduto, valorProduto, produto);

                pedido.AdicionarItem(itemPedido);
            }

            Console.Clear();
            Console.WriteLine(pedido);
        }
    }
}
