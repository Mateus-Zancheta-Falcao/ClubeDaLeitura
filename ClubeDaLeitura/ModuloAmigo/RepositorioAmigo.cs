using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class RepositorioAmigo
    {
        public void Inserir(Amigo amigo)
        {
            Amigo.listaAmigos.Add(amigo);
        }
        public List<Amigo> RetornaDadosAmigo()
        {
            return Amigo.listaAmigos;
        }
        public void AtualizaDados(string novoNome, string novoNomeResponsavel, string novoTelefone, string novoEndereco)
        {
            foreach (var item in Amigo.listaAmigos)
            {
                if (novoNome != item.nome)
                    item.nome = novoNome;
                if (novoNomeResponsavel != item.nomeResponsavel)
                    item.nomeResponsavel = novoNomeResponsavel;
                if (novoTelefone != item.telefone)
                    item.telefone = novoTelefone;
                if (novoEndereco != item.endereco)
                    item.endereco = novoEndereco;
            }
        }
        public void RemoveDados(Amigo amigo)
        {
            Amigo.listaAmigos.Remove(amigo);
        }
    }
}
