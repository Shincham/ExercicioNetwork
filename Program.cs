using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma lista de numeros distintos com um espaço entre cada numero");
            try
            {
                // Lê a entrada do console e verifica o tamanho do vetor
                string[] ar_temp = Console.ReadLine().Split(' ');
                int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
                int tam = ar.Length;
                char fim = 's';

                //  Instanciar a classe de validações e validar set de entrada
                ValidacoesException validar = new ValidacoesException();
                validar.ValidarEntrada(ar);

                //  Criar uma lista contendo as listas de conexões válidas.
                List<int>[] listaconexoes = new List<int>[tam / 2];

                //  Instanciar classe Network e declarar as variáveis pra receber os inputs de par de conexão.
                Network net = new Network();

                string[] cn_temp;
                int[] cn;

                while (fim == 's')
                {
                    //  Receber o input
                    Console.WriteLine("\nInsira dois numeros para fazer uma conexão, com um espaço entre cada número");
                    Console.WriteLine("Os números precisam ser diferentes e precisam estar contidos na lista inicial");
                    cn_temp = Console.ReadLine().Split(' ');
                    cn = Array.ConvertAll(cn_temp, Int32.Parse);
                    //  Validar o Input
                    validar.ValidarEntrada(cn);
                    validar.ValidarEntrada(ar, cn);
                    validar.ValidarConexao(cn);
                    // Incluir conexao na lista de conexoes
                    listaconexoes = net.Connect(cn, listaconexoes, tam / 2);

                    // Verificar se o usuário deseja incluir mais conexões ou passar para a proxima etapa
                    Console.WriteLine("\nDeseja inserir mais uma conexão ? s/n");
                    fim = Console.ReadKey().KeyChar;
                }
              
                // Declaração de variáveis para a proxima etapa do programa (verificar quais pares estão conectados)
                fim = 's';
                string[] qr_temp;
                int[] qr;
                bool retornoqr;

                while (fim == 's')
                {
                    //  Pegar o input
                    Console.WriteLine("\n\nAgora Insira dois numeros para verificar se estão conectados ou não");
                    Console.WriteLine("Siga o mesmo critério das inclusões anteriores.");
                    qr_temp = Console.ReadLine().Split(' ');
                    qr = Array.ConvertAll(qr_temp, Int32.Parse);
                    //  Validar o Input
                    validar.ValidarEntrada(qr);
                    validar.ValidarEntrada(ar, qr);
                    validar.ValidarConexao(qr);
                    //  Verificar se o par está conectado ou não
                    retornoqr = net.Query(qr, listaconexoes);

                    //  Exibir na tela o resultado
                    if (retornoqr == true)
                    {
                        Console.WriteLine(retornoqr);
                        Console.WriteLine("Estes numero estão conectados.");
                    }
                    else
                    {
                        Console.WriteLine(retornoqr);
                        Console.WriteLine("Estes numero não estão conectados.");
                    }

                    //  Verificar se o usuário deseja verificar outros pares.
                    Console.WriteLine("\nDeseja verificar mais alguma conexão ? s/n");
                    fim = Console.ReadKey().KeyChar;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema: {0}", e);
            }
        }

        
    }

    public class Network
    {
        //  Metodo connect recebe a lista de conexões e retorna a lista de conexões atualizada.
        public List<int>[] Connect(int[] parconec, List<int>[] lista, int tamlista)
        {
            int x = 0;
            bool incluiu = false;

            while ((x < tamlista) && (incluiu == false))
            {
                if (lista[x] == null)
                {
                    lista[x] = new List<int>(parconec);
                    incluiu = true;
                    x++;
                }
                else
                {
                    if (lista[x].Contains(parconec[0]) == true && lista[x].Contains(parconec[1]) == false)
                    {
                        lista[x].Add(parconec[1]);
                        incluiu = true;
                        x++;
                    }
                    else if (lista[x].Contains(parconec[0]) == false && lista[x].Contains(parconec[1]) == true)
                    {
                        lista[x].Add(parconec[0]);
                        incluiu = true;
                        x++;
                    }
                    else if (lista[x].Contains(parconec[0]) == true && lista[x].Contains(parconec[1]) == true)
                    {
                        incluiu = true;
                    }
                    else
                    {
                        incluiu = false;
                        x++;
                    }
                }
            }

            return lista;
        }

        //  Metodo query verifica se o par passado como parâmetro existe na lista de conexões.
        public bool Query(int[] query, List<int>[] listacon)
        {
            bool conectado = false;
            int y = 0;

            while (y < listacon.Length && conectado == false)
            {
                if(listacon[y] != null)
                {
                    if(listacon[y].Contains(query[0]) == true && listacon[y].Contains(query[1]) == true)
                    {
                        conectado = true;
                        y++;
                    }
                    else
                    {
                        conectado = false;
                        y++;
                    }
                }
                else
                {
                    conectado = false;
                    y++;
                }
            }
            return conectado;
        }
    }

    //  Classe de validações com métodos para validar os inputs de entrada.
    public class ValidacoesException : Exception
    {
        public bool ValidarEntrada (int[] setofelements)
        {
            if (setofelements.Length != setofelements.Distinct().Count())
            {
                throw new FormatException("Os numeros precisam ser diferentes");
            }

            foreach (int n in setofelements)
            {
                if (n < 0)
                {
                    throw new FormatException("Os numeros precisam ser positivos.");
                }
            }
            return true;
        }

        public bool ValidarEntrada(int[] setofelements, int[] parcon)
        {
            if (setofelements.Contains<int>(parcon[0]) && setofelements.Contains<int>(parcon[1]))
            {
                return true;
            }
            else
            {
                throw new FormatException("O par precisa pertencer a lista inicial");
            }
        }

        public bool ValidarConexao (int[] par)
        {
            if (par.Length != 2)
            {
                throw new FormatException("Parâmetro incorreto. A conexão deve ser feita entre 2 numeros.");
            }

            return true;
        }
    }
}
