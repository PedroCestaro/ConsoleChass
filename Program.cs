using System;
using tabuleiro;
using xadrez;

namespace consoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadex partida = new PartidaDeXadex();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: "+partida.turno);
                    Console.WriteLine("Aguardando Jogador: "+ partida.jogadorAtual);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);
                    

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);

                    partida.executaMovimento(origem, destino);

                }

                Tela.ImprimirTabuleiro(partida.tab);
                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
          
        }
    }
}
