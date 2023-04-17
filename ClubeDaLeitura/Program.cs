using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal tela = new TelaMenuPrincipal();

            int opcao = 0;

            while (opcao != 3)
            {
                tela.MenuPrincipal();

                opcao++;
            }

            Console.ReadKey();
        }
    }
}
