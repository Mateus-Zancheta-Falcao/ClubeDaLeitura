using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class TelaCaixa : RepositorioGeral
    {
        public RepositorioCaixa repositorio = new RepositorioCaixa();
        public int idContador;

        public void MenuCaixa()
        {
            Console.Clear();
            Console.WriteLine("========== Menu Caixa ==========");

            Console.WriteLine("1- Cadastrar caixa \n2- Ver caixas ");
            Console.WriteLine("3- Editar caixa \n4- Remover caixa \n5- Voltar ao menu principal\n");

            Console.Write("Informe a opção desejada -> ");
            int menuCaixa = Convert.ToInt32(Console.ReadLine());

            switch (menuCaixa)
            {
                case 1:
                    CadastraCaixa();
                    break;

                case 2:
                    VizualizaCaixa();
                    break;

                case 3:
                    EditaCaixa();
                    break;

                case 4:
                    RemoveCaixa();
                    break;

                case 5:
                    TelaMenuPrincipal tela = new TelaMenuPrincipal();

                    tela.MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuCaixa();
                    break;
            }
        }
        public void CadastraCaixa()
        {
            Console.Clear();
            Console.WriteLine("----- Cadastro Caixa -----\n");

            Console.WriteLine("Informe a cor: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Informe a etiqueta: ");
            string etiqueta = Console.ReadLine();

            idContador++;

            Caixa caixa = new Caixa(idContador, cor, etiqueta);

            repositorio.Inserir(caixa);

            Console.WriteLine("\nCaixa cadastrada com sucesso!\n");

            Console.WriteLine("Pressione qualquer tecla.");
            Console.ReadKey();

            MenuCaixa();
        }
        public void VizualizaCaixa()
        {
            Console.Clear();

            repositorio.RetornaDadosCaixa();

            if (Caixa.listaCaixas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma caixa cadastrada!");
            }
            else
            {
                Console.WriteLine("{0,-4} | {1,-16} | {2,-18}", "ID", "Cor", "Etiqueta");

                foreach (var item in Caixa.listaCaixas)
                {
                    Console.WriteLine("{0,-4} | {1,-16} | {2,-18}", item.id, item.cor, item.etiqueta);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();
            MenuCaixa();
        }
        public void EditaCaixa()
        {
            if (Caixa.listaCaixas.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o id da caixa que deseja editar: ");
                int caixaEditar = Convert.ToInt32(Console.ReadLine());

                foreach (var item in Caixa.listaCaixas)
                {
                    if (caixaEditar == item.id)
                    {
                        Console.WriteLine("\n=========== Dados da caixa =========== ");
                        Console.WriteLine("Cor: {0} \nEtiqueta: {1}", item.cor, item.etiqueta);
                        Console.WriteLine("======================================== ");

                        Console.WriteLine("\nInforme a cor: ");
                        string novaCor = Console.ReadLine();

                        Console.WriteLine("Informe a etiqueta: ");
                        string novaEtiqueta = Console.ReadLine();

                        repositorio.AtualizaDados(novaCor,novaEtiqueta);

                        Console.WriteLine("\nCaixa editada com sucesso!");

                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        MenuCaixa();
                        return;
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuCaixa();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhuma caixa cadastrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuCaixa();
            }
        }
        public void RemoveCaixa()
        {
            if (Caixa.listaCaixas.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o id da caixa que deseja remover: ");
                int caixaRemover = Convert.ToInt32(Console.ReadLine());

                foreach (var item in Caixa.listaCaixas)
                {
                    if (caixaRemover == item.id)
                    {
                        Console.WriteLine("\n======== Dados a serem removidos ========");
                        Console.WriteLine($"ID: {item.id} \nCor: {item.cor} \nEtiqueta: {item.etiqueta}");


                        Console.WriteLine("\n========Deseja realmente remover a caixa? (1) pra SIM (2) pra NÃO ========");
                        var remover = Convert.ToInt32(Console.ReadLine());

                        switch (remover)
                        {
                            case 1:
                                RemoverCaixa(item);
                                break;

                            case 2:
                                NaoRemoverCaixa();
                                break;
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuCaixa();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhuma caixa cadastrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuCaixa();
            }
        }
        private void NaoRemoverCaixa()
        {
            Console.WriteLine("\nCaixa não sera removida!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuCaixa();
        }
        private void RemoverCaixa(Caixa item)
        {
            RepositorioCaixa repositorio = new RepositorioCaixa();

            repositorio.RemoveDados(item);

            Console.WriteLine("\nCaixa removida com sucesso!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuCaixa();
        }
    }
}
