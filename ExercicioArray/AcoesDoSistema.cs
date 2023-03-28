using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioArray
{

    public static class AcoesDoSistema
    {

        public static int[]? ArrayNumerosInteiros;
        public static int[]? ArrayNumerosNegativo;
        public static int[]? ArrayMaioresNumeros;
        public static int MaiorValor;
        public static int MenorValor;
        public static decimal ValorMedio;


        public static void CriarArray()
        {
            ArrayNumerosInteiros = new int[] { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6 };
        }

        public static int EncontrarMaiorValor()
        {
            MaiorValor = 0;

            foreach (var numero in ArrayNumerosInteiros!)
            {
                if (numero > MaiorValor)
                    MaiorValor = numero;
            }

            return MaiorValor;
        }

        public static int EncontrarMenorValor()
        {
            MenorValor = 0;

            foreach (var numero in ArrayNumerosInteiros!)
            {
                if (numero < MenorValor)
                    MenorValor = numero;
            }
            return MenorValor;
        }

        public static decimal EncontrarValorMedio()
        {
            MenorValor = 0;
            int soma = 0;

            foreach (var numero in ArrayNumerosInteiros!)
            {
                soma += numero;
            }

            return Math.Round(ValorMedio = soma / ArrayNumerosInteiros.Length, 2);

        }


        public static int[] EncontrarOsTresMaioresValores()
        {
            ArrayMaioresNumeros = new int[3];

            int[] copiaArray = new int[ArrayNumerosInteiros!.Length];

            for (int i = 0; i < ArrayNumerosInteiros.Length; i++)
            {
                copiaArray[i] = ArrayNumerosInteiros[i];
            }

            for (int i = 0; i < ArrayMaioresNumeros!.Length; i++)
            {
                MaiorValor = 0;

                foreach (var item in copiaArray!)
                {
                    if (item > MaiorValor)
                    {
                        MaiorValor = item;
                        ArrayMaioresNumeros[i] = MaiorValor;
                    }
                }

                for (int j = 0; j < copiaArray!.Length; j++)
                {
                    if (copiaArray[j] == MaiorValor)
                    {
                        copiaArray[j] = 0;
                    }
                }
            }

            return ArrayMaioresNumeros;
        }

        public static int[] EncontrarOsValoresNegativos()
        {
            int tamanhoArray = CalcularTotalNumerosNegativos();

            ArrayNumerosNegativo = new int[tamanhoArray];

            for (int j = 0; j < tamanhoArray; j++)
            {
                for (int i = 0; i < ArrayNumerosInteiros!.Length; i++)
                {
                    if (ArrayNumerosInteiros[i] < 0)
                    {
                        ArrayNumerosNegativo[j] = ArrayNumerosInteiros[i];
                    }
                }
            }

            return ArrayNumerosNegativo;
        }



        public static void MostrarTodosOsValores()
        {
            MostrarItensArray(ArrayNumerosInteiros!);
        }

        public static void RemoverItem(int valorParaExcluir)
        {
            int qtdNumerosParaExcluir = CalcularQtosNumerosParaExcluir(valorParaExcluir);
            int qtd = ArrayNumerosInteiros!.Length - qtdNumerosParaExcluir;

            int[] novoArray = new int[qtd];
            int index = 0;

            foreach (var item in ArrayNumerosInteiros)
            {
                if (item != valorParaExcluir)
                {
                    novoArray[index] = item;
                    index++;
                }
            }

            ArrayNumerosInteiros = new int[novoArray.Length];
            Array.Copy(novoArray, ArrayNumerosInteiros, qtd);

        }

        private static int CalcularQtosNumerosParaExcluir(int valorParaExcluir)
        {
            int qtdNumerosParaExcluir = 0;
            foreach (var item in ArrayNumerosInteiros!)
            {
                if (item == valorParaExcluir)
                {
                    qtdNumerosParaExcluir++;
                }
            }
            return qtdNumerosParaExcluir;
        }

        public static int CalcularTotalNumerosNegativos()
        {
            int tamanhoArray = 0;

            foreach (var item in ArrayNumerosInteiros!)
            {
                if (item < 0)
                    tamanhoArray++;
            }
            return tamanhoArray;
        }

        public static void AdicionarItem(int valor)
        {
            int[] novoArray = new int[ArrayNumerosInteiros!.Length + 1];
            novoArray[0] = valor;

            for (int i = 1; i < novoArray.Length; i++)
            {
                novoArray[i] = ArrayNumerosInteiros[i - 1];
            }

            ArrayNumerosInteiros = new int[novoArray.Length];
            Array.Copy(novoArray, ArrayNumerosInteiros, novoArray.Length);

        }


        public static void MostrarItensArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.ReadKey();
        }


        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("--- Atividade sobre Arrays, Funções e Programação Estruturada ---");
            Console.WriteLine("[1] Encontrar o Maior Valor da sequência");
            Console.WriteLine("[2] Encontrar o Menor Valor da sequência");
            Console.WriteLine("[3] Encontrar o Valor Médio da sequência");
            Console.WriteLine("[4] Encontrar os 3 maiores valores da sequência");
            Console.WriteLine("[5] Encontrar os valores negativos da sequência");
            Console.WriteLine("[6] Mostrar na Tela os valores da sequência");
            Console.WriteLine("[7] Remover um item da sequência");
            Console.WriteLine("[8] Adicionar um item da sequência");
            Console.WriteLine("[0] Sair");

            return Convert.ToInt16(Console.ReadLine());
        }
    }
}