using System;
using System.Linq;


/*
    Exercício 1 - Projeto desenvolvido para a Avaliação técnica em C#
    By: Rodrigo Nabas Teruel
*/

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

            while (true)
            {
                Console.WriteLine("***Bem-vindo ao exercício 1 - DB1*** ");
                Console.WriteLine("Desenvolvido por Rodrigo Nabas Teruel\n");
                Console.WriteLine("Digite o número da opção que deseja, e pressione enter:");
                Console.WriteLine("1 - Qual o número inicial entre 1 e 1 milhão que produz a maior sequência aplicando o 'Problema de Collatz'?");
                Console.WriteLine("2 - O Array {0} contém somente números ímpares?", string.Join(",", numeros));
                Console.WriteLine("3 - Listar os número que contém no array {0} e não contém no array {1}?", string.Join(",", primeiroArray), string.Join(",", segundoArray));
                Console.WriteLine("4 - Sair");
                try{

                    //Verifica qual foi a opção selecionada
                    int resposta = Convert.ToInt16(Console.ReadLine());
                    switch (resposta)
                    {
                        case 1:
                            ProblemaCollatz();
                            break;

                        case 2:
                            MostraNumerosImpares(numeros);
                            break;

                        case 3:
                            MostraNumerosDiferenteEntreArrays(primeiroArray, segundoArray);
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Por favor, pressione enter e digite um numero válido.");
                            break;

                    }
                    Console.WriteLine("Pressione enter para selecionar outra opção.");
                    LimparTela();
                }
                catch(Exception e) {
                    Console.WriteLine("Por favor, pressione enter e digite um numero válido."); ;
                    LimparTela();
                }
            }
        }

        /// <summary>
        /// Método da opção 1 - Percorrer lista de 1 até 1000000 aplicando o Problema de Collatz e mostra o numero que teve maior resultado
        /// </summary>
        public static void ProblemaCollatz()
        {
            //Variaveis para armazenar o numero e a quantidade que teve o maior numero de termos
            long numeroSeq = 0;
            long quantSeq = 0;

            //Contagem de 1 até 1000000
            for (int i = 2; i <= 1000000; i++)
            {
                long numero = i;
                long quantidadeSeq = 0;

                //Aplica a regra de Collatz
                while (numero != 1)
                {
                    if ((numero % 2) == 0)
                        numero = numero / 2;

                    else
                        numero = numero * 3 + 1;
                    quantidadeSeq++;
                }

                //Verifica se o numero atual teve mais termos que o maior atual
                if (quantidadeSeq > quantSeq)
                {
                    numeroSeq = i;
                    quantSeq = quantidadeSeq;
                }
            }
            Console.WriteLine("O  número  que produz a maior sequência é o {0}, produzindo {1} termos", numeroSeq, quantSeq);
        }


        /// <summary>
        /// Método da opção 2 -  Verifica se o Array tem apenas números ímpares
        /// <param name="numeros">Array dos numeros para ser verificado</param>
        /// </summary>
        public static void MostraNumerosImpares(int[] numeros)
        {
            int[] resultado = numeros.Where(p => (p % 2) != 0).ToArray();
            if (numeros.Count() == resultado.Count())
                Console.WriteLine("O Array contém apenas números ímpares, são eles: ", string.Join(",", resultado));
            else
                Console.WriteLine("O Array contém números ímpares e pares");
        }


        /// <summary>
        /// Método da opção 3 -  Mostra Numeros que contém no primeiro Array, e não contém no segundo
        /// <param name="primeiroArray">Primeiro Array</param>
        /// <param name="segundoArray">Segundo Array</param>
        /// </summary>
        public static void MostraNumerosDiferenteEntreArrays(int[] primeiroArray, int[] segundoArray)
        {
            int[] resultado = primeiroArray.Where(p => !segundoArray.Any(p2 => p2 == p)).ToArray();
            Console.WriteLine("Os números que contém no primeiro array e não contém no segundo são os: {0}", string.Join(",", resultado));
        }


        /// <summary>
        /// Método para limpar a tela do console 
        /// </summary>
        public static void LimparTela()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }


}
