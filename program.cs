using System;
class Cartela
{
    public int[,] numeros=new int [5,5];
    public bool anulada=false;
}
class Jogador
{
    public string nome;
    public int idade;
    public char sexo;
    public Cartela [] cartelas;
    public bool ativo = true;

}
class Program
{
    static bool NumeroExisteColuna(Cartela cartela, int numero, int coluna)
    {
        for (int i = 0; i < 5; i++)
        {
            if (cartela.numeros[i, coluna] == numero)
            {
                return true;
            }
        }
        return false;
    }
    static void Main()
    {
      int qntdjogadores;
        do
        {
            Console.WriteLine("Digite a quantidade de jogadores (entre 2 e 5):");
            qntdjogadores = int.Parse(Console.ReadLine());
        } while (qntdjogadores < 2 || qntdjogadores > 5);
        Jogador[] jogadores = new Jogador[qntdjogadores];
      for(int i=0; i<qntdjogadores; i++)
        {
            jogadores[i] = new Jogador();
            Console.WriteLine($"Digite o nome do jogador {i + 1}:");
            jogadores[i].nome = Console.ReadLine();
            Console.WriteLine($"Digite a idade do jogador {i + 1}:");
            jogadores[i].idade = int.Parse(Console.ReadLine());
            Console.WriteLine($"Digite o sexo do jogador {i + 1} (M/F):");
            jogadores[i].sexo = char.Parse(Console.ReadLine());
            Console.WriteLine($"Digite a quantidade de cartelas para o jogador {i + 1} (entre 1 e 4):");
            int qntdcartelas = int.Parse(Console.ReadLine());
            jogadores[i].cartelas = new Cartela[qntdcartelas];
        }
    }
    static void GerarCartela(Cartela cartela)
    {
        int numero;
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            
            for (int j = 0; j < 5; j++)
            {
                   if (i==2 && j==2)
                {
                    cartela.numeros[i, j] = 0;
                }
                if (j == 0)
                {
                    numero= rand.Next(1, 16);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = rand.Next(1, 16);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 1)
                {
                    numero= rand.Next(16, 31);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = rand.Next(16, 31);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 2)
                {
                    numero= rand.Next(31, 46);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = rand.Next(31, 46);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 3)
                {
                    numero= rand.Next(46, 61);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = rand.Next(46, 61);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 4)
                {
                    numero= rand.Next(61, 76);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = rand.Next(61, 76);
                    }
                    cartela.numeros[i, j] = numero;
                }
              
            }
        }
        
    }
    
}

class Jogo
{
    public Jogador[] jogadores;

    public int[] numsorteados = new int[75];

    public int qntdsorteados;
}