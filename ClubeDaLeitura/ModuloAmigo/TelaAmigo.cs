using ClubeDaLeitura.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    internal class TelaAmigo : RepositorioGeral
    {
        public RepositorioAmigo repositorio = new RepositorioAmigo();
        public int idContador;

        public void MenuAmigo()
        {
            Console.Clear();
            Console.WriteLine("========== Menu Amigo ==========");

            Console.WriteLine("1- Cadastrar amigo \n2- Ver amigos ");
            Console.WriteLine("3- Editar amigo \n4- Remover amigo \n5- Voltar ao menu principal\n");
            Console.Write("Informe a opção desejada -> ");
            int menuAmigo = Convert.ToInt32(Console.ReadLine());

            switch (menuAmigo)
            {
                case 1:
                    CadastraAmigo();
                    break;

                case 2:
                    VizualizaAmigos();
                    break;

                case 3:
                    EditaAmigo();
                    break;

                case 4:
                    RemoveAmigo();
                    break;

                case 5:
                    TelaMenuPrincipal tela = new TelaMenuPrincipal();

                    tela.MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuAmigo();
                    break;
            }
        }
        public void CadastraAmigo()
        {
            Console.Clear();
            Console.WriteLine("----- Cadastro Amigo -----\n");

            Console.WriteLine("Informe o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.WriteLine("Informe o telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe o endereço: ");
            string endereco = Console.ReadLine();

            idContador++;

            Amigo amigo = new Amigo(idContador, nome, nomeResponsavel, telefone, endereco);

            repositorio.Inserir(amigo);

            Console.WriteLine("\nAmigo cadastrado com sucesso!\n");

            Console.WriteLine("Pressione qualquer tecla.");
            Console.ReadKey();

            MenuAmigo();
        }
        public void VizualizaAmigos()
        {
            Console.Clear();

            repositorio.RetornaDadosAmigo();

            if (Amigo.listaAmigos.Count == 0)
            {
                Console.WriteLine("Não existe nenhum amigo cadastrado!");
            }
            else
            {
                Console.WriteLine("{0,-4} | {1,-18} | {2,-18} | {3,-12} | {4,-18} ", "ID", "Nome", "Nome Responsável", "Telefone", "Endereço");

                foreach (var item in Amigo.listaAmigos)
                {
                    Console.WriteLine("{0,-4} | {1,-18} | {2,-18} | {3,-12} | {4,-18} ", item.id, item.nome, item.nomeResponsavel, item.telefone,item.endereco);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuAmigo();
        }
        public void EditaAmigo()
        {
            if (Amigo.listaAmigos.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o id do amigo que deseja editar: ");
                int amigoEditar = Convert.ToInt32(Console.ReadLine());

                foreach (var item in Amigo.listaAmigos)
                {
                    if (amigoEditar == item.id)
                    {
                        Console.WriteLine(" ======== Dados do amigo ========\n");
                        Console.WriteLine("ID: {0} \nNome: {1} \nNome Responsável: {2} \nTelefone: {3} \nEndereço: {4}", item.id, item.nome, item.nomeResponsavel, item.telefone, item.endereco);
                        Console.WriteLine("===================================");
                        Console.WriteLine("\nInforme o nome: ");
                        string novoNome = Console.ReadLine();

                        Console.WriteLine("Informe o nome do responsável: ");
                        string novoNomeResponsavel = Console.ReadLine();

                        Console.WriteLine("Informe o telefone: ");
                        string novoTelefone = Console.ReadLine();

                        Console.WriteLine("Informe o endereço: ");
                        string novoEndereco = Console.ReadLine();

                        repositorio.AtualizaDados(novoNome,novoNomeResponsavel,novoTelefone,novoEndereco);

                        Console.WriteLine("\nAmigo editado com sucesso!");

                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                        Console.ReadKey();

                        MenuAmigo();
                        return;
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuAmigo();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhum amigo cadastrado!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuAmigo();
            }
        }
        public void RemoveAmigo()
        {
            if (Amigo.listaAmigos.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o id do amigo que deseja remover: ");
                int amigoRemover = Convert.ToInt32(Console.ReadLine());

                foreach (var item in Amigo.listaAmigos)
                {
                    if (amigoRemover == item.id)
                    {
                        Console.WriteLine("\n======== Dados a serem removidos ========");
                        Console.WriteLine($"ID: {item.id} \nNome: {item.nome} \nNome Responsável: {item.nomeResponsavel} \nTelefone: {item.telefone} \nEndereço: {item.endereco}");

                        Console.WriteLine("\n========Deseja realmente remover o amigo? (1) pra SIM (2) pra NÃO ========");
                        var remover = Convert.ToInt32(Console.ReadLine());

                        switch (remover)
                        {
                            case 1:
                                RemoverAmigo(item);
                                break;

                            case 2:
                                NaoRemoverAmigo();
                                break;
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("\nId não encontrado!\n");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuAmigo();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNão a nenhum amigo cadastrado!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();

                MenuAmigo();
            }
        }
        private void NaoRemoverAmigo()
        {
            Console.WriteLine("\nAmigo não será removida!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuAmigo();
        }
        private void RemoverAmigo(Amigo item)
        {
            repositorio.RemoveDados(item);

            Console.WriteLine("\nAmigo removido com sucesso!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();

            MenuAmigo();
        }
    }
}
