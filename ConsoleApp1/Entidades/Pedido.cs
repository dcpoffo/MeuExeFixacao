using ConsoleApp1.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp1.Entidades
{
    class Pedido
    {
        public DateTime DataPedido { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public Cliente Cliente { get; set; }
        public Transportadora Transportadora { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

        public Pedido()
        {
        }

        public Pedido(DateTime dataPedido, StatusPedido statusPedido, Cliente cliente, Transportadora transportadora)
        {
            DataPedido = dataPedido;
            StatusPedido = statusPedido;
            Cliente = cliente;
            Transportadora = transportadora;
        }

        public void AdicionarItem(ItemPedido item)
        {
            Itens.Add(item);
        }

        public void RemoveItem(ItemPedido item)
        {
            Itens.Add(item);
        }

        public double Total()
        {
            double soma = 0.0;
            foreach (ItemPedido itemPedido in Itens)
            {
                soma += itemPedido.SubTotal();
            }
            return soma + Transportadora.Frete;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("*** RESUMO DO PEDIDO ***");
            sb.AppendLine($"DATA DO PEDIDO          : {DataPedido.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"STATUS DO PEDIDO        : {StatusPedido}");
            sb.AppendLine();
            sb.AppendLine("DADOS DO CLIENTE");
            sb.AppendLine($"Cliente                 : {Cliente}");
            sb.AppendLine();
            sb.AppendLine("TRANSPORTADORA");
            sb.AppendLine($"Transportadora          : {Transportadora.Nome}");
            sb.AppendLine($"Valor do Frete         $: {Transportadora.Frete.ToString("F2",CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Previsão de Entrega     : {Transportadora.DataPrevistaEntrega.ToString("dd/mm/yyyy")}");
            sb.AppendLine();
            sb.AppendLine("ITENS DO PEDIDO");
            foreach (ItemPedido item in Itens)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"VALOR TOTAL DO PEDIDO   : ${Total().ToString("F2",CultureInfo.InvariantCulture)}");
            sb.AppendLine();
            sb.AppendLine("***  FIM DO PEDIDO  ***");

            return sb.ToString();
        }
    }
}
