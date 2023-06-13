using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercicioAula07_Casa
{

    internal class Program
    {
        public static double numeroFinal = 0,
            expresso = 3.00,
                capuccino = 4.50,
                mocaccino = 6.50,
                aguaQuente = 1,
                opcao;
        public static double Saldo = 0;

        /*  Você recebeu do seu cliente as seguintes instruções para construir a máquina:
             • A máquina deve perguntar ao usuário o valor que ele quer depositar/inserir
             • A máquina deve verificar se o valor inserido pelo usuário é válido
             • Após inserido o valor, a máquina deve exibir na tela as opções de café:
            o Café expresso – R$ 3,00
            o Capuccino – R$ 4,50
            o Mocaccino – R$ 6,00
            o Água quente – R$ 1,00
             • Após o cliente escolher a opção desejada, verifique se existe o valor suficiente para a compra
             • A partir deste ponto, o hardware da máquina fará o resto, então mostre a mensagem final para o
             cliente e reinicie o sistema para atender ao próximo cliente.
        */
        static void Main(string[] args)
        {

            string escolha;
            double deposito;

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("--------------------------- CAFÉZIN ---------------------------");
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine($"Saldo atual: {Saldo}");

            Console.WriteLine("Deseja depositar/inserir: (s/n)?");
            escolha = Console.ReadLine();


            if (Saldo > 0 && escolha == "n")
            {

                if (Saldo < expresso && Saldo < capuccino && Saldo < mocaccino && Saldo < aguaQuente)
                {
                    Console.WriteLine("Saldo insuficiente, deposite para comprar");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    return;
                }


                Console.WriteLine("Gostaria de mais algum produto?");
                string e1 = Console.ReadLine();
                if (e1 == "s")
                {
                    Console.WriteLine("Digite uma tecla para mostrar as opções!!");
                    Console.ReadKey();
                    Console.Clear();

                    opcoes();

                }

                if (e1 != "s" && e1 != "n")
                {
                    Console.WriteLine("Digite uma opção válida !!!");
                    Console.ReadKey();
                    Main(null);
                    return;
                }
                if (e1 == "s")
                {
                    Console.WriteLine("Digite uma tecla para encerrar!!");
                    Console.ReadKey();

                    Console.ReadLine(); Console.WriteLine("Pressione qualquer tecla para reiniciar...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                if (e1 == "n")
                {
                    Console.WriteLine("Quer encerrar ?? (s/n)");
                    Console.WriteLine($"\nVocê perderá seu saldo de R${Saldo}!");
                    string e2 = Console.ReadLine();



                    if (e2 == "s")
                    {
                        Console.ReadLine(); Console.WriteLine("Pressione qualquer tecla para reiniciar...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                    Console.Clear();
                    Main(null);
 
                    return;
                }
            }

            if (Saldo == 0)
            {

                if (escolha == "n")
                {
                    Console.WriteLine("\n\n Aperte qualquer tecla para finalizarmos!!");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

            }

            Console.WriteLine("Insira um valor: ");
            deposito = int.Parse(Console.ReadLine());

            Saldo = Saldo + deposito;

            Console.WriteLine($"\nVocê tem o saldo de {Saldo}!");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\nPressione qualquer tecla para abrir o menu de opções....");
            Console.ReadKey();
            Console.Clear();
            opcoes();



        }

        void exemplo()
        {
            Random sorteador = new Random();
            double numeroSorteado = sorteador.Next(1, 11);
            string desistir;


            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("------------------------- XXI -------------------------");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Pressione uma tecla para puxar uma carta !!");
            Console.ReadKey();



            numeroFinal = numeroFinal + numeroSorteado;

            if (numeroFinal > 21)
            {
                Console.WriteLine("Você perdeu!!");
                Console.WriteLine($"Ultrapassando 21, com a marca de {numeroFinal}");
                Console.ReadKey();
                return;
            }
            else if (numeroFinal == 21)
            {
                Console.WriteLine("Você GANHOOOOOU!!");
                Console.WriteLine($"Com a marca de {numeroFinal} !!!!!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Total:{numeroFinal}");
            Console.WriteLine($"Numero sorteado:{numeroSorteado}");
            Console.WriteLine("\n\nGostaria de puxar mais uma carta: (s/n)");
            desistir = Console.ReadLine();

            if (desistir == "n" || desistir == "N")
            {
                Console.WriteLine("\n\nMelhor parar com medo que tentar a sorte né amigo?");
                Console.WriteLine($"Você desistiu com {numeroFinal}");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
            Console.Clear();

            Main(null);
        }


        static void opcoes()
        {

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------- OPÇÕES ---------------------------");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\nDigite o número da sua escolha !!\n");
            Console.WriteLine($"1- Café expresso - R${expresso}");
            Console.WriteLine($"2- Capuccino - R${capuccino}");
            Console.WriteLine($"3- Mocaccino - R${mocaccino}");
            Console.WriteLine($"4- Agua - R${aguaQuente}");

            opcao = int.Parse(Console.ReadLine());


            if (opcao > 4 && opcao < 1)
            {
                Console.WriteLine("\n\nDigite uma opção válida!!");
                Console.ReadKey();
                Console.Clear();
                Main(null);

            }

            if (opcao == 1 && Saldo > expresso)
            {
                Console.WriteLine("\n\nCompra realizada com sucesso, seu café já está sendo preparado");
                Saldo = Saldo - expresso;
                Console.WriteLine("---------------------------------------------------------------");

                Console.WriteLine($"Seu saldo atual é de R${Saldo}");
                Console.ReadKey();
                Console.Clear();
                Main(null);
                return;


            }

            if (opcao == 2 && Saldo > capuccino)
            {
                Console.WriteLine("\n\nCompra realizada com sucesso, seu capuccino já está sendo preparado!!\n");
                Saldo = Saldo - capuccino;
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"Seu saldo atual é de R${Saldo}");
                Console.ReadKey();
                Console.Clear();
                Main(null);
                return;


            }

            if (opcao == 3 && Saldo > mocaccino)
            {
                Console.WriteLine("\n\nCompra realizada com sucesso, seu mocaccino já está sendo preparado");
                Saldo = Saldo - mocaccino;
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"Seu saldo atual é de R${Saldo}");
                Console.ReadKey();
                Console.Clear();
                Main(null);
                return;


            }

            if (opcao == 4 && Saldo > aguaQuente)
            {
                Console.WriteLine("\n\nCompra realizada com sucesso, sua agua quente já está sendo preparado");
                Saldo = Saldo - aguaQuente;
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"Seu saldo atual é de R${Saldo}");
                Console.ReadKey();
                Console.Clear();
                Main(null);
                return;


            }
        }


    }

}
