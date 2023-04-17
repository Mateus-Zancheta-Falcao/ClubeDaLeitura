using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class Caixa : RepositorioGeral
    {
        public int id { get; set; }
        public string cor { get; set; }
        public string etiqueta { get; set; }
        public static List<Caixa> listaCaixas = new List<Caixa>();

        public Caixa(int id, string cor, string etiqueta)
        {
            this.id = id;
            this.cor = cor;
            this.etiqueta = etiqueta;
        }
    }
}
