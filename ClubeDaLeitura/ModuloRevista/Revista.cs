using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class Revista
    {
        public static int idContador;
        public int id { get; set; }
        public string tipoColecao { get; set; }
        public int numeroEdicao { get; set; }
        public DateTime ano { get; set; }
        public Caixa caixa { get; set; }

        public static List<Revista> listaRevistas = new List<Revista>();


        public Revista(int id, string tipoColecao, int numeroEdicao, DateTime ano, Caixa caixa)
        {
            this.id = id;
            this.tipoColecao = tipoColecao;
            this.numeroEdicao = numeroEdicao;
            this.ano = ano;
            this.caixa = caixa;
        }
    }
}
