using ClubeDaLeitura.ModuloEmprestimo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class Emprestimo
    {
        public static int idContador;
        public int id { get; set; }
        public DateTime dataDeSaida { get; set; }
        public DateTime dataDeDevolucao { get; set; }
        public Amigo amigo { get; set; }
        public Revista revista { get; set; }

        public static List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        public Emprestimo(int id, Amigo amigo, Revista revista, DateTime dataDeSaida, DateTime dataDeDevolucao)
        {
            this.id = id;
            this.amigo = amigo;
            this.revista = revista;
            this.dataDeSaida = dataDeSaida;
            this.dataDeDevolucao = dataDeDevolucao;
        }
    }
}
