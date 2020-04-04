using System;

namespace ConsoleApp1.Entidades
{
    class Transportadora
    {
        public string Nome { get; set; }
        public double Frete { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }

        public Transportadora()
        {
        }
        
        public Transportadora(string nome, double frete, DateTime dataPrevistaEntrega)
        {
            Nome = nome;
            Frete = frete;
            DataPrevistaEntrega = dataPrevistaEntrega;
        }
    }
}
