using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevista
{
    internal class RepositorioRevista : RepositorioGeral
    {
        public void Inserir(Revista revista)
        {
            Revista.listaRevistas.Add(revista);
        }
        public List<Revista> RetornaDadosRevista()
        {
            return Revista.listaRevistas;
        }
        public void AtualizaDados(string novoTipoColecao, int novoNumeroEdicao, DateTime novoAno)
        {
            foreach (var item in Revista.listaRevistas)
            {
                if (novoTipoColecao != item.tipoColecao)
                    item.tipoColecao = novoTipoColecao;
                if (novoNumeroEdicao != item.numeroEdicao)
                    item.numeroEdicao = novoNumeroEdicao;
                if (novoAno != item.ano)
                    item.ano = novoAno;
            }
        }
        public void RemoveDados(Revista revista)
        {
            Revista.listaRevistas.Remove(revista);
        }
    }
}
