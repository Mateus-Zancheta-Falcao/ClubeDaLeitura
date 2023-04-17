using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class Amigo
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public string nome { get; set; }
        public string nomeResponsavel { get; set; }
        public string endereco { get; set; }
        public static List<Amigo> listaAmigos = new List<Amigo>();

        public Amigo(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
    }
}
