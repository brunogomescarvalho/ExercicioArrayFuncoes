using System;
namespace ExercicioArray
{
    class Program
    {
        public static bool Continuar = true;
        static int[]? ArrayNumerosInteiro;
        static int[]? ArrayNumerosNegativo;
        static int[]? ArrayMaioresNumeros;
        static int MaiorValor;
        static int MenorValor;
        static int ValorMedio;

        static void Main()
        {
            CriarArray();

            while (Continuar)
            {
                switch (Menu())
                {
                    case 1: EncontrarMaiorValor(); break;
                    case 2: EncontrarMenorValor(); break;
                    case 3: EncontrarValorMedio(); break;
                    case 4: EncontrarOsTresMaioresValores(); break;
                    case 5: EncontrarOsValoresNegativos(); break;
                    case 6: MostrarTodosOsValores(); break;
                    case 7: RemoverItem(); break;
                    case 0: Sair(); break;
                    default: EnviarMensagem("Opção Inválida!"); break;
                }
            }
        }

        static void CriarArray()
        {
            ArrayNumerosInteiro = new int[] { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6 };
        }

        static void Sair()
        {
            Continuar = false;
        }

        static void EncontrarMaiorValor()
        {
            MostrarTitulo("--- Encontrar Maior Valor ---");
            MaiorValor = 0;

            foreach (var numero in ArrayNumerosInteiro!)
            {
                if (numero > MaiorValor)
                    MaiorValor = numero;
            }

            EnviarMensagem($"\nO maior valor é o {MaiorValor}.");
        }

        static void EncontrarMenorValor()
        {
            MostrarTitulo("--- Encontrar Menor Valor ---");
            MenorValor = 0;

            foreach (var numero in ArrayNumerosInteiro!)
            {
                if (numero < MenorValor)
                    MenorValor = numero;
            }
            EnviarMensagem($"\nO menor valor é o {MenorValor}.");
        }

        static void EncontrarValorMedio()
        {
            MostrarTitulo("--- Encontrar Valor Médio ---");

            MenorValor = 0;
            int soma = 0;

            foreach (var numero in ArrayNumerosInteiro!)
            {
                soma += numero;
            }

            ValorMedio = soma / ArrayNumerosInteiro.Length;

            EnviarMensagem($"\nO valor médio é o {ValorMedio}.");
        }


        static void EncontrarOsTresMaioresValores()
        {
            MostrarTitulo("--- Encontrar os Três Maiores Valores ---\n");

            ArrayMaioresNumeros = new int[3];

            int[] copiaArray = new int[ArrayNumerosInteiro!.Length];

            for (int i = 0; i < ArrayNumerosInteiro.Length; i++)
            {
                copiaArray[i] = ArrayNumerosInteiro[i];
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
            Console.Write("Os três maiores valores são: ");
            MostrarItensArray(ArrayMaioresNumeros);
        }

        static void EncontrarOsValoresNegativos()
        {
            MostrarTitulo("--- Encontrar Valores Negativos ---\n");

            int tamanhoArray = CalcularTotalNumerosNegativos();

            ArrayNumerosNegativo = new int[tamanhoArray];

          for (int j = 0 ; j < tamanhoArray; j++)
          {
              for (int i = 0; i < ArrayNumerosInteiro!.Length; i++)
            {
                if (ArrayNumerosInteiro[i] < 0)
                {
                    ArrayNumerosNegativo[j] = ArrayNumerosInteiro[i];
                }
            }
          }

            Console.Write("Os valores negativos são: ");
            MostrarItensArray(ArrayNumerosNegativo);
        }



        static void MostrarTodosOsValores()
        {
            MostrarTitulo("--- Valores no Array ---");
            MostrarItensArray(ArrayNumerosInteiro!);
        }

        static void RemoverItem()
        {
            MostrarTitulo("--- Remover Item ---");

            Console.WriteLine("Informe o nr° que deseja excluir.");
            int valorParaExcluir = Convert.ToInt32(Console.ReadLine());

            int index = Array.IndexOf(ArrayNumerosInteiro!, valorParaExcluir);

            if (index == -1)
            {
                EnviarMensagem($"O valor {valorParaExcluir} não existe no Array.");
                return;
            }

            Array.Clear(ArrayNumerosInteiro!, index, 1);

            EnviarMensagem($"Nr° {valorParaExcluir} excluido!\n");
        }


        static void EnviarMensagem(string menssagem)
        {
            Console.Clear();
            Console.WriteLine(menssagem);
            Console.ReadKey();
        }


        static void MostrarTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine(titulo);
        }


        static int CalcularTotalNumerosNegativos()
        {
            int tamanhoArray = 0;

            foreach (var item in ArrayNumerosInteiro!)
            {
                if (item < 0)
                    tamanhoArray++;
            }
            return tamanhoArray;
        }


        static void MostrarItensArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.ReadKey();
        }


        static int Menu()
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
            Console.WriteLine("[0] Sair");

            return Convert.ToInt16(Console.ReadLine());
        }
    }
}

