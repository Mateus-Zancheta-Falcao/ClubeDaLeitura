using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioGeral
    {
        public void Inserir(Emprestimo emprestimo)
        {
            Emprestimo.listaEmprestimos.Add(emprestimo);
        }
        public List<Emprestimo> RetornaDadosEmprestimo()
        {
            return Emprestimo.listaEmprestimos;
        }
    }
}
