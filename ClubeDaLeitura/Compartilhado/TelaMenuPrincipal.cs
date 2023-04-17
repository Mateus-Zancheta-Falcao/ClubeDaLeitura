using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class TelaMenuPrincipal : RepositorioGeral
    {
        public TelaCaixa telaCaixa = new TelaCaixa();
        public TelaRevista telaRevista = new TelaRevista();
        public TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
        public TelaAmigo telaAmigo = new TelaAmigo();

        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("- Bem-vindo ao clube da leitura -\n");

            Console.WriteLine("1- Menu Caixa \n2- Menu Revista \n3- Menu Empréstimo\n4- Menu Amigo \n5- Sair\n");
            Console.Write("Informe a opção desejada -> ");
            int menuPrincipal = Convert.ToInt32(Console.ReadLine());

            switch (menuPrincipal)
            {
                case 1:
                    telaCaixa.MenuCaixa();
                    break;

                case 2:
                    telaRevista.MenuRevista();
                    break;

                case 3:
                    telaEmprestimo.MenuEmprestimo();
                    break;

                case 4:
                    telaAmigo.MenuAmigo();
                    break;

                case 5:
                    Console.WriteLine("\nSaindo do sistema...");
                    Console.ReadKey();

                    Environment.Exit(5);
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
