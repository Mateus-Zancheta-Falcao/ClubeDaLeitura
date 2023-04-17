using ClubeDaLeitura.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class TelaRevista : RepositorioGeral
    {
        public RepositorioRevista repositorio = new RepositorioRevista();
        public int idContador;

        public void MenuRevista()
        {
            Console.Clear();
            Console.WriteLine("========== Menu Revista ==========");

            Console.WriteLine("1- Cadastrar revista \n2- Ver revistas ");
            Console.WriteLine("3- Editar revista \n4- Remover revista \n5- Voltar ao menu principal\n");

            Console.Write("Informe a opção desejada -> ");
            int menuRevista = Convert.ToInt32(Console.ReadLine());

            switch (menuRevista)
            {
                case 1:
                    CadastraRevista();
                    break;

                case 2:
                    VizualizaRevistas();
                    break;

                case 3:
                    EditaRevista();
                    break;

                case 4:
                    RemoveRevista();
                    break;

                case 5:
                    TelaMenuPrincipal tela = new TelaMenuPrincipal();

                    tela.MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuRevista();
                    break;
            }
        }
        public void CadastraRevista()
        {
            Console.Clear();
            Console.WriteLine("----- Cadastro Revista -----\n");

            Console.WriteLine("Informe o id da caixa que será guardada: ");
            int caixaId = Convert.ToInt32(Console.ReadLine());

            foreach (var item in Caixa.listaCaixas)
            {
                if (item.id == caixaId)
                {
                    Console.WriteLine("Informe o tipo da coleção: ");
                    string tipoColecao = Console.ReadLine();

                    Console.WriteLine("Informe o número da coleção: ");
                    int numeroEdicao = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe a data (dd/MM/yyyy) da coleção: ");
                    DateTime ano = Convert.ToDateTime(Console.ReadLine());

                    idContador++;

                    Revista revista = new Revista(idContador, tipoColecao, numeroEdicao, ano, item);

                    repositorio.Inserir(revista);

                    Console.WriteLine("\nRevista cadastrada com sucesso!\n");

                    Console.WriteLine("Pressione qualquer tecla.");
                    Console.ReadKey();

                    MenuRevista();
                }
            }

            Console.WriteLine("Id não encontrado!");

            Console.WriteLine("Pressione qualquer tecla.");
            Console.ReadKey();

            MenuRevista();
        }
        public void VizualizaRevistas()
        {
            Console.Clear();

            repositorio.RetornaDadosRevista();

            if (Revista.listaRevistas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma revista cadastrada!");
            }
            else
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-8} | {3,-10} | {4,-8} | {5,-16} | {6,-18}", "ID", "Coleção", "Número", "Data" , "ID Caixa", "Cor Caixa", "Etiqueta Caixa");
                foreach (var item in Revista.listaRevistas)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-8} | {3,-10} | {4,-8} | {5,-16} | {6,-18}", item.id,item.tipoColecao, item.numeroEdicao, item.ano.ToString("dd/MM/yyyy"), item.caixa.id, item.caixa.cor, item.caixa.etiqueta);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuRevista();
        }
        public void EditaRevista()
        {
            if (Revista.listaRevistas.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("----- Editar Revista -----\n");

                Console.WriteLine("Informe o id da revista que deseja editar: ");
                int revistaEditar = Convert.ToInt32(Console.ReadLine());

                foreach (var itemRevista in Revista.listaRevistas)
                {
                    if (revistaEditar == itemRevista.id)
                    {
                        Console.WriteLine("\n=========== Dados da revista =========== ");
                        Console.WriteLine("ID: {0} \nColeção: {1} \nNúmero: {2} \nAno: {3} \nID Caixa: {4} \nCaixa Cor: {5} \nCaixa Etiqueta: {6}", itemRevista.id, itemRevista.tipoColecao, itemRevista.numeroEdicao, itemRevista.ano.ToString("dd/MM/yyyy"), itemRevista.caixa.id, itemRevista.caixa.cor, itemRevista.caixa.etiqueta);
                        Console.WriteLine("===========================================");

                        Console.WriteLine("\nInforme o tipo da coleção: ");
                        string novoTipoColecao = Console.ReadLine();

                        Console.WriteLine("Informe o número da coleção: ");
                        int novoNumeroEdicao = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe o ano da coleção: ");
                        DateTime novoAno = Convert.ToDateTime(Console.ReadLine());


                        repositorio.AtualizaDados(novoTipoColecao,novoNumeroEdicao,novoAno);

                        Console.WriteLine("\nRevista editada com sucesso!");

                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        MenuRevista();
                        return;
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuRevista();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhuma revista cadastrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuRevista();
            }
        }
        public void RemoveRevista()
        {
            if (Revista.listaRevistas.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o id da revista que deseja remover: ");
                int revistaRemover = Convert.ToInt32(Console.ReadLine());

                foreach (var item in Revista.listaRevistas)
                {
                    if (revistaRemover == item.id)
                    {
                        Console.WriteLine("\n======== Dados a serem removidos ========");
                        Console.WriteLine($"ID: {item.id} \nColeção: {item.tipoColecao} \nNúmero: {item.numeroEdicao} \nAno:{item.ano.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"ID Caixa: {item.caixa.id} \nCaixa Cor: {item.caixa.cor} \nCaixa Etiqueta: {item.caixa.etiqueta}\n");


                        Console.WriteLine("\n========Deseja realmente remover a revista? (1) pra SIM (2) pra NÃO ========");
                        var remover = Convert.ToInt32(Console.ReadLine());

                        switch (remover)
                        {
                            case 1:
                                RemoverRevista(item);
                                break;

                            case 2:
                                NaoRemoverRevista();
                                break;
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuRevista();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhuma caixa cadastrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuRevista();
            }
        }
        private void NaoRemoverRevista()
        {
            Console.WriteLine("\nRevista não sera removida!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuRevista();
        }
        private void RemoverRevista(Revista item)
        {
            repositorio.RemoveDados(item);
            Console.WriteLine("\nRevista removida com sucesso!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

           MenuRevista();
        }
    }
}
