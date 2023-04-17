using ClubeDaLeitura.ModuloEmprestimo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class TelaEmprestimo : RepositorioGeral
    {
        public RepositorioEmprestimo repositorio = new RepositorioEmprestimo();
        public int idContador;

        public void MenuEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("========== Menu Empréstimo ==========");

            Console.WriteLine("1- Cadastrar empréstimo \n2- Ver empréstimos \n3- Voltar ao menu principal\n");
            Console.Write("Informe a opção desejada -> ");
            int menuRevista = Convert.ToInt32(Console.ReadLine());

            switch (menuRevista)
            {
                case 1:
                    CadastraEmprestimo();
                    break;

                case 2:
                    VizualizaEmprestimos();
                    break;

                case 3:
                    TelaMenuPrincipal tela = new TelaMenuPrincipal();

                    tela.MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuEmprestimo();
                    break;
            }
        }
        public void QuantidadeDeEmprestimosProAmigo(int idAmigo)
        {
            TelaEmprestimo tela = new TelaEmprestimo();

            foreach (var itemEmprestimo in Emprestimo.listaEmprestimos)
            {
                if (idAmigo == itemEmprestimo.amigo.id)
                {
                    Console.WriteLine($"\nO amigo {itemEmprestimo.amigo.nome} já fez um empréstimo! Não é possível fazer mais que um empréstimo.");

                    Console.WriteLine("\nPressione qualquer tecla.");
                    Console.ReadKey();

                    tela.MenuEmprestimo();
                }
            }
        }
        public void CadastraEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("----- Cadastro Empréstimo -----\n");

            Console.WriteLine("Informe o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            foreach (var itemAmigo in Amigo.listaAmigos)
            {
              QuantidadeDeEmprestimosProAmigo(idAmigo);
                
                if (idAmigo == itemAmigo.id)
                {
                    Console.WriteLine("Informe o id da revista emprestada: ");
                    int idRevista = Convert.ToInt32(Console.ReadLine());

                    foreach (var itemRevista in Revista.listaRevistas)
                    {
                        if (idRevista == itemRevista.id)
                        {
                            Console.WriteLine("Informe a data (dd/MM/yyyy) de empréstimo: ");
                            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Informe a data (dd/MM/yyyy) de devolução: ");
                            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

                            idContador++;

                            Emprestimo emprestimo = new Emprestimo(idContador, itemAmigo, itemRevista, dataEmprestimo, dataDevolucao);

                            repositorio.Inserir(emprestimo);

                            Console.WriteLine("\nEmpréstimo cadastrado com sucesso!\n");

                            Console.WriteLine("Pressione qualquer tecla.");
                            Console.ReadKey();

                            MenuEmprestimo();
                        }
                    }
                }
            }
            Console.WriteLine("Id não encontrado!");

            Console.WriteLine("Pressione qualquer tecla.");
            Console.ReadKey();

            MenuEmprestimo();
        }
        public void VizualizaEmprestimos()
        {
            Console.Clear();

            repositorio.RetornaDadosEmprestimo();

            if (Emprestimo.listaEmprestimos.Count == 0)
            {
                Console.WriteLine("Não existe nenhum empréstimo cadastrado!");
            }
            else
            {
                Console.WriteLine("----- Empréstimo -----");
                Console.WriteLine("{0,-13} | {1,-8} | {2,-15} | {3,-10} | {4,-16} | {5,-12} | {6,-12} | {7,-4}", "ID Empréstimo", "Data Saida", "Data Devolução", "ID Amigo", "Nome Amigo", "ID Revista", "Tipo Coleção", "Ano Revista");

                foreach (var item in Emprestimo.listaEmprestimos)
                {
                    Console.WriteLine("{0,-13} | {1,-8} | {2,-15} | {3,-10} | {4,-16} | {5,-12} | {6,-12} | {7,-4}", item.id, item.dataDeSaida.ToString("dd/MM/yyyy"), item.dataDeDevolucao.ToString("dd/MM/yyyy"), item.amigo.id, item.amigo.nome, item.revista.id, item.revista.tipoColecao, item.revista.ano.ToString("dd/MM/yyyy"));
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuEmprestimo();
        }
    }
}
