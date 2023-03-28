using System;
namespace ExercicioArray
{
    class Program
    {
        public static bool Continuar = true;

        static void Main()
        {
            AcoesDoSistema.CriarArray();

            while (Continuar)
            {
                switch (AcoesDoSistema.Menu())
                {
                    case 1: MostrarMaiorValor(); break;
                    case 2: MostrarMenorValor(); break;
                    case 3: MostrarValorMedio(); break;
                    case 4: MostrarOsTresMaioresValores(); break;
                    case 5: MostrarOsValoresNegativos(); break;
                    case 6: MostrarSequencia(); break;
                    case 7: RemoverItem(); break;
                    case 8: AdicionarItem(); break;
                    case 0: Sair(); break;
                    default: OpcaoInvalida(); break;
                }
            }
        }

        private static void OpcaoInvalida()
        {
            EnviarMensagem("Opção Inválida!");
        }

        private static void RemoverItem()
        {
            MostrarTitulo("--- Remover Item ---");

            Console.WriteLine("Informe o nr° que deseja excluir.");
            int valorParaExcluir = Convert.ToInt32(Console.ReadLine());

            AcoesDoSistema.RemoverItem(valorParaExcluir);
        }

          private static void AdicionarItem()
        {
            MostrarTitulo("--- Adicionar Item ---");

            Console.WriteLine("Informe o nr° que deseja adicionar.");
            int valorParaAdicionar = Convert.ToInt32(Console.ReadLine());
            
            AcoesDoSistema.AdicionarItem(valorParaAdicionar);
        }

        private static void MostrarSequencia()
        {
            MostrarTitulo("--- Valores no Array ---");
            AcoesDoSistema.MostrarTodosOsValores();
        }

        private static void MostrarOsValoresNegativos()
        {
            MostrarTitulo("--- Encontrar Valores Negativos ---\n");
            AcoesDoSistema.MostrarItensArray(AcoesDoSistema.EncontrarOsValoresNegativos());
        }

        private static void MostrarOsTresMaioresValores()
        {
            MostrarTitulo("--- Encontrar os Três Maiores Valores ---\n");
            AcoesDoSistema.MostrarItensArray(AcoesDoSistema.EncontrarOsTresMaioresValores());
        }

        private static void MostrarValorMedio()
        {
            MostrarTitulo("--- Encontrar Valor Médio ---");
            EnviarMensagem($"O valor médio é o {AcoesDoSistema.EncontrarValorMedio()}");
        }

        private static void MostrarMenorValor()
        {
            MostrarTitulo("--- Encontrar Menor Valor ---");
            EnviarMensagem($"O menor valor é o {AcoesDoSistema.EncontrarMenorValor()}");
        }

        private static void MostrarMaiorValor()
        {
            MostrarTitulo("--- Encontrar Maior Valor ---");
            EnviarMensagem($"O maior valor é o : {AcoesDoSistema.EncontrarMaiorValor()}");
        }

        static void Sair()
        {
            Continuar = false;
        }

        public static void EnviarMensagem(string menssagem)
        {
            Console.Clear();
            Console.WriteLine(menssagem);
            Console.ReadKey();
        }

        public static void MostrarTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine(titulo);
        }


    }
}

