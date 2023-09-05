using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RodrigoSantos_5091
{
    /* 
              Título do Projeto: Jogo do Galo
              Autor: Rodrigo Santos
              Data: 16/06/2023
    */

    internal class Program
    {
        public static char[,] jogo = new char[3, 3]; // Array Multidimensional
        public static char menuinicial;
        public static string jogador1;
        public static string jogador2;
        public static int exit;
        public static int posicao;
        public static int posicao2;

        static void Main(string[] args)
        {
        do
        {
                
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*************************************************");
            Console.WriteLine("**                 MENU INICIAL                **");
            Console.WriteLine("*************************************************");
            Console.WriteLine("1. Jogo do Galo");
            Console.WriteLine("2. Instruções");
            Console.WriteLine("3. Sair");
            Console.Write("R: ");
            menuinicial = char.Parse(Console.ReadLine());

            jogo[0, 0] = '1';
            jogo[0, 1] = '2';
            jogo[0, 2] = '3';

            jogo[1, 0] = '4';
            jogo[1, 1] = '5';
            jogo[1, 2] = '6';

            jogo[2, 0] = '7';
            jogo[2, 1] = '8';
            jogo[2, 2] = '9';

                switch (menuinicial)
                {
                    case '1':
                        jogo_do_galo();
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("**                 INSTRUÇÕES               **");
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Olá bem vindo ao jogo do galo. só esta disponivel o <<X>> e <<O>> para jogar, se tentar jogar com outro numero vai dar erro, obrigado.");
                        Console.WriteLine("\n\n\n\n\n\nPrima <<ENTER>> para continuar!");
                        Console.ReadKey();
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("O programa vai fechar dentro de momentos!");
                        Thread.Sleep(3000); // Fechar Programa com um TIME
                        Environment.Exit(0); // Sair do Programa
                        break;

                    default:
                        Console.WriteLine("\a");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção Invalida!");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
            } while (true);

        }
        static void jogo_do_galo()
        {
            bool check = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Introduza o nome do Jogador 1: ");
            jogador1 = Console.ReadLine();

            Console.WriteLine("Introduza o nome do Jogador 2: ");
            jogador2 = Console.ReadLine();

            int jogadas = 0; // contador para o empate

            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                mostrarjogo();

                if (vitoria_x())
                {
                  Console.WriteLine("Prima <<ENTER>> para continuar.");
                    break;
                }

                if (vitoria_o())
                {
                   Console.WriteLine("Prima <<ENTER>> para continuar.");
                    break;
                }

                if (empate())
                {
                    Console.WriteLine("Prima <<ENTER>> para continuar.");
                    break;
                }


                


                Console.WriteLine($"{jogador1}: Escolha o nº da posição que vai jogar o 'x': ");
                posicao = int.Parse(Console.ReadLine());

                Console.WriteLine($"{jogador2}: Escolha o nº da posição que vai jogar o 'o': ");
                posicao2 = int.Parse(Console.ReadLine());

                if (posicao < 1 || posicao > 9 || posicao2 < 1 || posicao2 > 9) // Validação
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Posição Invalida!");
                    Console.WriteLine("Pressiona <<enter>> para continuar...");
                    Console.ReadKey(); // Sempre Colocar
                    continue; // Inserir para continuar o programa
                }


                if (jogo[(posicao - 1) / 3, (posicao - 1) % 3] == 'x') // % = Módulo (resto da divisão)
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Já existe um 'x' nessa posição!!");
                    Console.WriteLine("Pressiona <<enter>> para continuar...");
                    Console.ReadKey(); // Sempre Colocar
                }
                if (jogo[(posicao2 - 1) / 3, (posicao2 - 1) % 3] == 'o')
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Já existe um 'o' nessa posição!!");
                    Console.WriteLine("Pressiona <<enter>> para continuar...");
                    Console.ReadKey(); // Sempre Colocar                           
                }
                else
                {
                    switch (posicao)
                    {
                        case 1:
                            if (jogo[0, 0] != 'o') // Verificar se não há 'o' na posição
                            {
                                jogadas++; 
                                jogo[0, 0] = 'x';

                            }
                            else
                            { // colocar as {} para executar a linha de codigo...
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada!");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            if (jogo[0, 1] != 'o')
                            {
                                jogadas++;
                                jogo[0, 1] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            
                            if (jogo[0, 2] != 'o')
                            {
                                jogadas++;
                                jogo[0, 2] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            if (jogo[1, 0] != 'o')
                            {
                                jogadas++;
                                jogo[1, 0] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 5:
                            if (jogo[1, 1] != 'o')
                            {
                                jogadas++;
                                jogo[1, 1] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 6:
                            if (jogo[1, 2] != 'o')
                            {
                                jogadas++;
                                jogo[1, 2] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;

                        case 7:
                            if (jogo[2, 0] != 'o')
                            {
                                jogadas++;
                                jogo[2, 0] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 8:
                            if (jogo[2, 1] != 'o')
                            {
                                jogadas++;
                                jogo[2, 1] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 9:
                            if (jogo[2, 2] != 'o')
                            {
                                jogadas++;
                                jogo[2, 2] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;

                    }
                   
                    switch (posicao2)
                    {
                        case 1:
                            
                            if (jogo[0, 0] != 'x') // Verificar se não há 'x' na posição
                            {
                                jogadas++;
                                jogo[0, 0] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            
                            if (jogo[0, 1] != 'x')
                            {
                                jogadas++;
                                jogo[0, 1] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            
                            if (jogo[0, 2] != 'x')
                            {
                                jogadas++;
                                jogo[0, 2] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            
                            if (jogo[1, 0] != 'x')
                            {
                                jogadas++;
                                jogo[1, 0] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 5:                            
                            if (jogo[1, 1] != 'x')
                            {
                                jogadas++;
                                jogo[1, 1] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;

                        case 6:
                            if (jogo[1, 2] != 'x')
                            {
                                jogadas++;
                                jogo[1, 2] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                        case 7:
                            if (jogo[2, 0] != 'x')
                            {
                                 jogadas++;
                                jogo[2, 0] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;

                        case 8:
                            if (jogo[2, 1] != 'x')
                            {
                                jogadas++;
                                jogo[2, 1] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;

                        case 9:                                 
                            if (jogo[2, 2] != 'x')
                            {
                                jogadas++;
                                jogo[2, 2] = 'o';
                            }
                            else
                            {
                                Console.WriteLine("\a");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A posição já se encontra ocupada");
                                Console.ReadKey();
                            }
                            break;
                    }

                    
              }

            } while (!check);
            Console.ReadKey();
        }

        static void fechou()  // SubPrograma para se o utilizador pretender jogar novamente no final do jogo !
        {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPretende Jogar Novamente? \n1.Sim\n2.Não");
                Console.Write("R: ");
                exit = int.Parse(Console.ReadLine());

                switch (exit)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("O programa vai fechar dentro de momentos!");
                        Thread.Sleep(3000); // Fechar Programa com um TIME
                        Environment.Exit(0); // Sair do Programa
                        break;

                    default:
                        Console.WriteLine("\a");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tente Novamente!");
                        fechou();
                        Console.ReadKey();
                        break;
                }
        }

        static void mostrarjogo() // SubPrograma para mostrar a grelha !
        {
            for (int i = 0; i < 3; i++) // grelha
            {
                Console.WriteLine("-------------------");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| ");
                    Console.Write($" {jogo[i, j]} ");
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("-------------------");
        }

        static bool vitoria_x() // SubPrograma que é um "bool" que no caso vai validar as linhas, colunas e diagonais do "x" e no fim não apresenta nenhuma das condições = false.
        {
    

            for (int i= 0; i < 3; i++) //Linha
            {
                if (jogo[i, 0] == 'x' && jogo[i, 1] == 'x' && jogo[i, 2] == 'x')
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O Vencedor é {jogador1} !");
                    fechou();
                    return true; // vai retornar o valor como verdadeiro

                }
              
            }
            
            for (int j=0; j<3; j++) //Coluna
            {
                if (jogo[0,j] == 'x' && jogo[1,j] == 'x' && jogo[2,j] == 'x')
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O Vencedor é {jogador1} !");
                    fechou();
                    return true; // vai retornar o valor como verdadeiro
                }
               
            }

            for (int g = 0; g < 3; g++) // diagonal
            {
                if (jogo[0,0] == 'x' && jogo[1,1] == 'x' && jogo[2, 2] == 'x') 
                {
                Console.WriteLine("\a");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O Vencedor é {jogador1} !");
                    fechou();
                    return true; // vai retornar o valor como verdadeiro
                }
                
            }

            for (int d = 0; d < 3; d++) //diagonal
            {
                if (jogo[0,2] == 'x' && jogo[1,1] == 'x' && jogo[2,0] == 'x') 
                {
                Console.WriteLine("\a");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O Vencedor é {jogador1} !");
                    fechou();
                    return true; // vai retornar o valor como verdadeiro
                }
               
            }

            return false; // vai retornar o valor como falso

        }

        static bool vitoria_o() // subprograma para a vitoria do 'o'
        {

            for (int i = 0; i < 3; i++) //Linha
            {
                if (jogo[i, 0] == 'o' && jogo[i, 1] == 'o' && jogo[i, 2] == 'o')
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O Vencedor é {jogador2} !");
                    fechou();
                    return true;
                }
               

            }

            for (int j = 0; j < 3; j++) //Coluna
            {
                if (jogo[0, j] == 'o' && jogo[1, j] == 'o' && jogo[2, j] == 'o')
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O Vencedor é {jogador2} !");
                    fechou();
                    return true;
                }
                
            }

            for (int g = 0; g < 3; g++)  // diagonal
            { 
                if (jogo[0, 0] == 'o' && jogo[1, 1] == 'o' && jogo[2, 2] == 'o') 
                {
                    Console.WriteLine("\a");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"O Vencedor é {jogador2} !");
                    fechou();
                    return true;
                }
               
            }

            for (int d = 0; d < 3; d++) //diagonal
            {
                if (jogo[0, 2] == 'o' && jogo[1, 1] == 'o' && jogo[2, 0] == 'o') 
                {
                   Console.WriteLine("\a");
                   Console.ForegroundColor = ConsoleColor.Green;
                   Console.WriteLine($"O Vencedor é {jogador2} !");
                    fechou();
                    return true;
                }

            }
            return false;



        }

        static bool empate() // Empate
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (jogo[i, j] != 'x' && jogo[i, j] != 'o')
                    {
                       
                        return false;
                    }
                }
            } 
            Console.WriteLine("\a");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Empate!");
            fechou();
            return true;
        }

    }
}
