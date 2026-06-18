using System;
class Jogo
{
    public Jogador[] jogadores;

    public int[] numsorteados = new int[75];

    public int qntdsorteados=0;

    //metodo para sortear numeros do bingo
    public int SortearNumero()
    {
        Random NumBingo= new Random();
        int NumeroAleatorio=0;
        NumeroAleatorio=NumBingo.Next(1,76);
        while(VerificarNum(NumeroAleatorio))
        {
            NumeroAleatorio=NumBingo.Next(1,76);
        }
        numsorteados[qntdsorteados]=NumeroAleatorio;
        qntdsorteados++;
        return NumeroAleatorio;
    }
    //Verificar numero que foi sorteado se ele ja saiu antes
    public bool VerificarNum(int numero)
    {
        for (int i=0;i<qntdsorteados;i++)
        {
            if(numsorteados[i]==numero)
            {
                return true;    
            }
        }
        return false;
    }
}


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
    //verificar se o número existe em cada coluna
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



    static void GerarCartela(Cartela cartela)
    {
        int numero;
        Random NumeroCartela = new Random();
        for (int i = 0; i < 5; i++)
        {
           //sorteio dos numeros com um intervalo para cada coluna. 
            for (int j = 0; j < 5; j++)
            {
                   if (i==2 && j==2)
                {
                    cartela.numeros[i, j] = 0;
                }
                if (j == 0)
                {
                    numero= NumeroCartela.Next(1, 16);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = NumeroCartela.Next(1, 16);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 1)
                {
                    numero= NumeroCartela.Next(16, 31);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = NumeroCartela.Next(16, 31);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 2)
                {
                    numero= NumeroCartela.Next(31, 46);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = NumeroCartela.Next(31, 46);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 3)
                {
                    numero= NumeroCartela.Next(46, 61);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = NumeroCartela.Next(46, 61);
                    }
                    cartela.numeros[i, j] = numero;
                }
                if(j == 4)
                {
                    numero= NumeroCartela.Next(61, 76);
                    while (NumeroExisteColuna(cartela, numero, j))
                    {
                        numero = NumeroCartela.Next(61, 76);
                    }
                    cartela.numeros[i, j] = numero;
                }
            }
        }   
    }



    //Mostrar as cartelas
    static void MostrarCartela(Cartela cartela)
    {
        for (int i=0; i<cartela.numeros.GetLength(0); i++)
        {
            for(int j=0; j<cartela.numeros.GetLength(1);j++)
            {
                Console.Write(cartela.numeros[i,j] + "\t");
            }
            console.WriteLine();
        }   
    }

    //Metodo para marcas os números na cartela
    public void MarcarNumero(Cartela cartela,int numero)
    {
        for (int i=0; i<5; i++)
        {
            for (int j=0;j<5; j++)
            {
                if (cartela.numeros[i,j]==numero)
                {
                     cartela.numeros[i,j]=0;
                }
            }
        }
    }




    
    //Verificar se as cartelas estão iguais ou não
    static bool CartelasIguais(Cartela c1, Cartela c2)
    {
        for (int i=0; i<cartela.numeros.GetLength(0);i++)
        {
            for (int j=0; j<cartela.numeros(1); j++)
            {
                if (c1.numeros[i,j] != c2.numeros[i,j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}



 static void Main()
    {
        //quantidade de jogadores
      int qntdjogadores;
        do
        {
            Console.WriteLine("Digite a quantidade de jogadores (entre 2 e 5):");
            qntdjogadores = int.Parse(Console.ReadLine());
        } while (qntdjogadores < 2 || qntdjogadores > 5);
        Jogador[] jogadores = new Jogador[qntdjogadores];

        //cadastro dos jogadores
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

        //preenchimento de cada cartela
        for (int i=0; i<qntdjogadores; i++)
        {
            
            for (int j=0; j<jogadores[i].cartelas.Length; j++)
            {
                jogadores[i].cartelas[j]=new Cartela();
                bool repetida;

                do
                {
                    GerarCartela(jogadores[i].cartelas[j]);
                    repetida=false;
                    for(int k=0;k<j;k++)
                    {
                        if(CartelasIguais(jogadores[i].cartelas[j], jogadores[i].cartelas[k]))
                        {
                            repetida=true;
                            break;
                        }
                    }
                }while(repetida);

               //Começo da partida
               Jogo jogo=new Jogo();
               jogo.jogadores=jogadores;
               for (int i=0; i<5;i++)
               {
                    int numero=jogo.SortearNumero();
                    Console.WriteLine("Numero Sorteado: " + numero);
                    for (int j=0;j<jogadores.Length;j++)
                    {
                        for (int k=0;k<jogadores[j].cartelas.Length;k++)
                        {
                            MarcarNumero(jogadores[j].cartelas[k], numero);
                        }
                    }
               }
            }
        }
    }