using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura
{
    internal class RepositorioCaixa : RepositorioGeral
    {
        public void Inserir(Caixa caixa)
        {
            Caixa.listaCaixas.Add(caixa);
        }

        public List<Caixa> RetornaDadosCaixa()
        {
            return Caixa.listaCaixas;
        }

        public void AtualizaDados(string novaCor,string novaEtiqueta)
        {
            foreach (var item in Caixa.listaCaixas)
            {
                if (novaCor != item.cor)
                    item.cor = novaCor;
                if (novaEtiqueta != item.etiqueta)
                    item.etiqueta = novaEtiqueta;
            }
        }
        public void RemoveDados(Caixa caixa)
        {
            Caixa.listaCaixas.Remove(caixa);
        }
    }
}
